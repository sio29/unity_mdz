/*-----------------------------------------------------------------------------
;	PPZ32_Driver
;	ソフトウェアPCM合成
-----------------------------------------------------------------------------*/

namespace ulib{
namespace usound{
//======================

public class PPZ32_Driver : PPZ32_DriverBase {
//	public static void Log(string m){
//		
//	}
	
	
	private const int SHORT_MIN=-32768;
	private const int SHORT_MAX= 32767;
	public const int PCM_CNL_MAX=32;				//PCMチャネル数
	public const int VOL_MIN=0;
	public const int VOL_MAX=63;
	public const int PAN_MIN=0;
	public const int PAN_MAX=9;
	public const int PAN_CENTER=5;
	public const int NOTE_CENTER=0x800;
	public const int PCMCATE_8BITMONOUNSIGNED  =0;
	public const int PCMCATE_8BITSTEREOUNSIGNED=1;
	public const int PCMCATE_16BITMONO         =2;
	public const int PCMCATE_16BITSTEREO       =3;
	public const int PCMCATE_8BITMONOSIGNED    =4;
	public const int PCMCATE_8BITSTEREOSIGNED  =5;
	//シフトテーブル
	//0 16bitステレオ ->  8bitモノラル(unsigned)
	//1 16bitステレオ ->  8bitステレオ(unsigned)
	//2 16bitステレオ -> 16bitモノラル(signed)
	//3 16bitステレオ -> 16bitステレオ(signed)
	//4 16bitステレオ ->  8bitモノラル(signed)
	//5 16bitステレオ ->  8bitステレオ(signed)
	private static readonly int[] dist_cate_shift={2,1,1,0,2,1};
	//パンテーブル
	private static readonly int[] pcm_pan_tbl={
		 0 , 0,	//0 無音
		 4 , 0,	//1 左
		 4 , 1,	//2 
		 4 , 2,	//3 
		 4 , 3,	//4 
		 4 , 4,	//5 中央
		 3,  4,	//6 
		 2,  4,	//7 
		 1,  4,	//8 
		 0 , 4 	//9 右
	};
	//ボリュームテーブル
	private static readonly int[] pcm_vol_tbl={
		0x0000,0x0004,0x0005,0x0005,0x0006,0x0006,0x0007,0x0007, // 0- 7
		0x0008,0x0009,0x000A,0x000B,0x000C,0x000D,0x000E,0x000F, // 8-15
		0x0011,0x0013,0x0014,0x0016,0x0018,0x001A,0x001D,0x001F, //16-23
		0x0022,0x0026,0x0029,0x002D,0x0031,0x0035,0x003A,0x003F, //24-31
		0x0045,0x004C,0x0052,0x005A,0x0062,0x006B,0x0075,0x007F, //32-39
		0x008B,0x0098,0x00A5,0x00B5,0x00C5,0x00D7,0x00EA,0x00FF, //40-47
		0x0117,0x0130,0x014B,0x016A,0x018A,0x01AE,0x01D5,0x01FF, //48-51
		0x022E,0x0260,0x0297,0x02D4,0x0315,0x035D,0x03AB,0x0400  //52-63
	};
	//音程テーブル
	private static readonly int[] pcm_ontei_tbl={
		0x8000,		//00 c
		0x87A6,		//01 d-
		0x8FB3,		//02 d
		0x9838,		//03 e-
		0xA146,		//04 e
		0xAADE,		//05 f
		0xB4FF,		//06 g-
		0xBFCC,		//07 g
		0xCB34,		//08 a-
		0xD747,		//09 a
		0xE418,		//10 b-
		0xF1A5		//11 b
	};
	//チャネルワーク
	public class PPZ32_PCMCNL{
		public bool use;			//使用されている
		public int state;			//ステータス
		public int vol;				//音量
		public int pan;				//パン
		public int loop_flg;		//ループフラグ
		public int src_rate;		//元データレート
		public int add_l;			//アドレス増加量 LOW
		public int add_h;			//アドレス増加量 HIGH
		public int now_xor;			//現在のアドレス,小数点部
		public int now_adr;			//現在のアドレス,整数部
		public int start_adr;		//
		public int end_adr;			//現在の終了アドレス
		public int loop_adr;		//ループ開始アドレス
		public byte[] pcmdata;		//PCMデータ
		public int bit=8;			//
		public int cnl=1;			//
		//
		public PPZ32_PCMCNL(){
			use=false;
			state=0;
		}
		public void Init(){
			state=0;
			add_l=0;
			add_h=0x10000;				//周波数
			pan  =PAN_CENTER;			//PAN中心
			vol  =VOL_MAX;				//ボリューム初期化
		}
	}
	private int dist_rate=44100;				//出力バッファの再生レート
	//private bool supply_flg=true;			//補間フラグ
	//シーケンサ一つ分のデータ
	private PPZ32_PCMCNL[] pcmw=new PPZ32_PCMCNL[PCM_CNL_MAX];	//チャネルワーク
	private int pcm_step_cnt;					//PCMステップ数初期化
	private int pcm_badr_wk;					//現在のリニアな合成アドレス
	private int pcm_now_makesize;			 	//作成PCMサイズ
	private int pcm_one_step;					//テンポ一回分のサンプル数
	private PPZ32_MixBase mixbase;				//拡張合成プラグイン(FM音源など)
	//
	public PPZ32_Driver(){
		pcm_step_cnt=0;					//PCMステップ数初期化
		pcm_one_step=0x100;
		for(int i=0;i<PCM_CNL_MAX;i++){
			pcmw[i]=new PPZ32_PCMCNL();
			pcmw[i].state=0;					//キーオフ
			pcmw[i].add_l=0;					//周波数下位
			pcmw[i].add_h=0x10000;				//周波数上位
			pcmw[i].pan  =PAN_CENTER;			//PAN中心
			pcmw[i].vol  =VOL_MAX;				//ボリューム初期化
		}
	}
	public void addMixBase(PPZ32_MixBase n){
		mixbase=n;
	}
	//初期化
	//public override void init(){
	public void init(){
		for(int i=0;i<PCM_CNL_MAX;i++){
			pcmw[i].state=0;
		}
		pcm_step_cnt=0;					//PCMステップ数初期化
	}
	//バッファ開始
	//public override void startPCMBuffer(){
	public void startPCMBuffer(){
		pcm_badr_wk=0;						//現在のリニアな合成アドレス
	}
	//現在のバッファを返す
	//public override int getPCMBufferAdr(){
	public int getPCMBufferAdr(){
		return pcm_badr_wk;
	}
	//空きチャネルを返す
	//public override int getFreeCnl(){
	public int getFreeCnl(){
		for(int i=0;i<PCM_CNL_MAX;i++){
			if(!pcmw[i].use){
				pcmw[i].use=true;
				return i;
			}
		}
		return -1;
	}
	//チャネル停止
	//public override void stopCnl(int i){
	public void stopCnl(int i){
		if(i<0 || i>=PCM_CNL_MAX)return;
		pcmw[i].state=0;
	}
	//チャネル初期化
	//public override void initCnl(int i){
	public void initCnl(int i){
		if(i<0 || i>=PCM_CNL_MAX)return;
		//pcmw[i].Init();							//周波数
		pcmw[i].add_l=0;							//周波数下位
		pcmw[i].add_h=0x10000;						//周波数上位
		pcmw[i].pan=PAN_CENTER;						//PAN中心
		pcmw[i].vol=VOL_MAX;						//ボリューム初期化
	}
	private static int normalizeAdr(byte[] data,int adr){
		if(adr<0)return 0;
		int bottom=data.Length-1;
		if(adr>bottom)return bottom;
		return adr;
	}
	//チャネルキーオン
	public void keyOn(int i,int index,byte[] data,int start,int end,int loop,int loopflg,int src_rate,int src_bit,int src_cnl){
		if(i<0 || i>=PCM_CNL_MAX)return;
		if(data==null)return;
//		loop =normalizeAdr(data,loop);
//		start=normalizeAdr(data,start);
//		end  =normalizeAdr(data,end);
string s="cnl("+i+"),index("+index+")";
s+=",start("+start+"),end("+end+"),loop_start("+loop+"),loopflg("+loopflg+"),src_rate("+src_rate+"),wave_size("+((data!=null)?data.Length:0)+")";
s+=",bit("+src_bit+"),cnl("+src_cnl+")";
//MDZDebug.Log("keyon:"+s);
		
		pcmw[i].end_adr  =end;
		pcmw[i].loop_flg =loopflg;
		pcmw[i].loop_adr =loop;
		pcmw[i].src_rate =src_rate;
		pcmw[i].pcmdata  =data;
		pcmw[i].now_xor  =0;
		pcmw[i].now_adr  =0;//start;
		pcmw[i].start_adr=start;
		pcmw[i].state    =1;
		pcmw[i].bit      =src_bit;
		pcmw[i].cnl      =src_cnl;
//System.out.println(""+src_bit);
	}
	//チャネル再生(8bitモノラルの配列で)
	public bool playCnl(int i,int index,byte[] data,int start,int end,int loop,int loopflg,int src_rate,int src_bit,int src_cnl,int vol,int pan,int note){
		if(i<0 || i>=PCM_CNL_MAX)return false;
		setVol(i,vol);
		setPan(i,pan);
		keyOn(i,index,data,start,end,loop,loopflg,src_rate,src_bit,src_cnl);
		setNote(i,note);
		return true;
	}
	public bool playCnl(int i,PZIDATA pzidata,int index,int vol,int pan,int note){
		if(index<0 || index>=pzidata.tbl.Length){
			MDZDebug.Log("play index error !!:"+index);
			return false;
		}
		PZIDATATBL tbl=pzidata.tbl[index];
		byte[] wave=tbl.wave;
		int start   =tbl.start;
		int end     =tbl.end;
		int loop    =tbl.loop_start;
		int loopflg =0;
		int src_bit =tbl.bit;
		int src_cnl =tbl.cnl;
		int src_rate=tbl.rate;
		return playCnl(0,index,wave,start,end,loop,loopflg,src_rate,src_bit,src_cnl,vol,pan,note);
	}
	
	//チャネルパン設定
	//public override void setPan(int i,int pan){
	public void setPan(int i,int pan){
		if(i<0 || i>=PCM_CNL_MAX)return;
		if(pan<PAN_MIN)pan=PAN_MIN;
		if(pan>PAN_MAX)pan=PAN_MAX;
		pcmw[i].pan=pan;
	}
	//チャネル音程設定
	//public override void setNote(int i,int wave){
	public void setNote(int i,int wave){
		if(i<0 || i>=PCM_CNL_MAX)return;
		int src_rate=pcmw[i].src_rate;
		int[] r=onteiOutSub(wave,src_rate,dist_rate);
		pcmw[i].add_l=r[0];
		pcmw[i].add_h=r[1];
	}
	//音程計算
	public static int[] onteiOutSub(int wave,int src_rate,int dist_rate){
		//int n=(src_rate*wave/dist_rate) << 4;
		int n=(src_rate*wave/dist_rate) << (4+1);
		int low =n & 0xffff;
		int high=(n >> 16) & 0xffff;
		return new int[]{low,high};
	}
	//チャネル音量設定
	//public override void setVol(int i,int vol){
	public void setVol(int i,int vol){
		if(i<0 || i>=PCM_CNL_MAX)return;
		if(vol<VOL_MIN)vol=VOL_MIN;
		if(vol>VOL_MAX)vol=VOL_MAX;
		pcmw[i].vol=vol;
	}
	//テンポ設定
	//public override void setTimer(int tempo,int base_cnt){
	public void setTimer(int tempo,int base_cnt){
		pcm_one_step=getTimerCount(tempo,base_cnt,dist_rate);
	}
	//テンポとベースカウントから1回分のサンプリング数を求める
	public static int getTimerCount(int tempo,int base_cnt,int dist_rate){
		return (4*60*dist_rate)/(tempo*base_cnt);
	}
	//出力バッファの周波数
	//public override void setDistRate(int rate){
	public void setDistRate(int rate){
		dist_rate=rate;
	}
	//作成されたPCMのサイズ
	//public override int getNowMakePCMSize(){
	public int getNowMakePCMSize(){
		return pcm_now_makesize;
	}
	//全てのチャネルが停止しているか?
	public bool checkAllCnlStop(){
		for(int i=0;i<PCM_CNL_MAX;i++){
			if(pcmw[i].state!=0)return false;
		}
		return true;
	}
	//音程テーブルを返す
	public static int[] getNoteTbl(){
		return pcm_ontei_tbl;
	}
	//o4c(4*12)が基準
	public static int getNoteWave(int ontei){
		int oct =ontei / 12;
		int note=ontei % 12;
		int n=pcm_ontei_tbl[note];
		n=n >> (7-oct);
		return n;
	}
	//PCM形式とサイズから計算
	public static int calcPCMOneStep(int cate,int size){
		int mix_size=size << dist_cate_shift[cate];
		return mix_size >> 2;		//16bit/Sterao
	}
	//テンポ一回分のサンプル数設定
	public void setPCMOneStep(int n){
		pcm_one_step=n;
	}
	//======================================
	//	PCM合成ルーチン
	//	void mdz_make_pcm(void *dst_adr);
	//	out	EAX	合成したPCMのサイズ
	//		(普段は合成バッファサイズ、最後だけ合成した分のサイズ)
	//======================================
	public void makePCM(PPZ32_MakePCMCallback callback,short[] pcm_buff_adr,int sample_num){
		//合成バッファのサイズ求める
		pcm_now_makesize=sample_num*2;		//現在の合成サイズ
		//合成バッファの確保
		//バッファクリア
		for(int i=0;i<pcm_buff_adr.Length;i++){
			pcm_buff_adr[i]=0;
		}
		//========================
		//合成回数を求める
		//int pcm_left_cnt=pcm_buff_size/2;	//残りの回数初期化
		int pcm_left_cnt=pcm_buff_adr.Length/2;	//残りの回数初期化
		int _now_buff_adr=0;
		while(true){
			if(pcm_step_cnt!=0 && pcm_one_step!=0){
				if(pcm_left_cnt==0)break;
				int _now_loop_cnt=pcm_left_cnt;
				if(pcm_left_cnt>pcm_step_cnt){
					_now_loop_cnt=pcm_step_cnt;
				}
				pcm_step_cnt-=_now_loop_cnt;
				pcm_left_cnt-=_now_loop_cnt;
				pcm_badr_wk +=_now_loop_cnt;
				//PCMの合成
				mixPCMCnl(pcm_buff_adr,_now_buff_adr,_now_loop_cnt);
				//OPNの合成
				//if(mixbase!=null)mixbase.mix(pcm_buff_adr,_now_buff_adr,_now_loop_cnt,true);
				//次のバッファへ
				_now_buff_adr+=_now_loop_cnt;
				//1ステップの終わりか？
				if(pcm_step_cnt!=0)continue;
			}
			//音源ドライバー処理へ
			if(callback!=null){
				callback.driverMain(this);
			}
			if(pcm_one_step==0)break;
			pcm_step_cnt=pcm_one_step;	//ステップ数設定
		}
		//========================
		//データの補正
		//一次補間
//		if(supply_flg){
//			supplyPCM(pcm_buff_adr);
//		}
		//
		//outputFormatConvert(pcm_buff_adr,output_cate,output_buffer);
		//return pcm_buff_adr;
	}
	//======================================
	//	合成処理
	//	now_buff_adr 合成バッファ位置
	//	now_loop_cnt 合成サンプル数
	//======================================
	private void mixPCMCnl(short[] pcm_buff_adr,int now_buff_adr,int now_loop_cnt){
		for(int i=0;i<PCM_CNL_MAX;i++){
			PPZ32_PCMCNL _pcmw=pcmw[i];
			if(_pcmw==null)continue;
			//再生中?
			if(_pcmw.state==0)continue;
			
			if(_pcmw.pcmdata==null){
				_pcmw.state=0;
				continue;
			}
			if(_pcmw.now_adr<0){
				_pcmw.state=0;
				continue;
			}
			if(_pcmw.bit==8){
				if(_pcmw.now_adr>=_pcmw.pcmdata.Length){
					_pcmw.state=0;
					continue;
				}
			}else if(_pcmw.bit==16){
				if((_pcmw.now_adr*2)>=_pcmw.pcmdata.Length){
					_pcmw.state=0;
					continue;
				}
			}else{
				continue;
			}
			
			//int vol_wk=_pcmw.vol;				//0~63
			int vol_wk=pcm_vol_tbl[_pcmw.vol];
			int start_adr=_pcmw.start_adr;
			int now_xor=_pcmw.now_xor;
			int now_adr=_pcmw.now_adr;
			int pan=_pcmw.pan;
			int pan_l=pcm_pan_tbl[pan*2+0]*vol_wk;		//0~4
			int pan_r=pcm_pan_tbl[pan*2+1]*vol_wk;		//0~4
			int vol_shift8=(2+6-3);
			int vol_shift16=(2+6-3)+8;
			int dst_index=now_buff_adr*2;
			for(int j=0;j<now_loop_cnt;j++){
				int nl=0;
				int nr=0;
				if(_pcmw.bit==8){
					nl=(_pcmw.pcmdata[start_adr+now_adr] & 0xff)-0x80;	//-128~s~127
					nr=nl;
					nl=(nl*pan_l) >> vol_shift8;
					nr=(nr*pan_r) >> vol_shift8;
				}else if(_pcmw.bit==16){
					int nll=       _pcmw.pcmdata[start_adr+(now_adr*2)+0];
					int nlh=(sbyte)_pcmw.pcmdata[start_adr+(now_adr*2)+1];
					nl=(nlh << 8) | (nll & 0xff);
					nr=nl;
					nl=(nl*pan_l) >> vol_shift16;
					nr=(nr*pan_r) >> vol_shift16;
				}
				
				int l=pcm_buff_adr[dst_index+0]+nl;
				int r=pcm_buff_adr[dst_index+1]+nr;
				if(l<SHORT_MIN)l=SHORT_MIN;
				if(l>SHORT_MAX)l=SHORT_MAX;
				if(r<SHORT_MIN)r=SHORT_MIN;
				if(r>SHORT_MAX)r=SHORT_MAX;
				pcm_buff_adr[dst_index+0]=(short)l;
				pcm_buff_adr[dst_index+1]=(short)r;
				dst_index+=2;
				//次のアドレスへ
				now_xor+=_pcmw.add_l;
				if(now_xor>=0x10000){
					now_xor&=0xffff;
					now_adr++;
				}
				now_adr+=_pcmw.add_h;
				if(now_adr>=_pcmw.end_adr){
					if(_pcmw.loop_flg==0){
					//ループしない場合
						_pcmw.state=0;			//チャネル停止
						break;
					}else{
					//ループする場合
						now_adr=_pcmw.loop_adr;
					}
				}
			}
			_pcmw.now_xor=now_xor;
			_pcmw.now_adr=now_adr;
		}

	}
	//======================================
	//	一次補間
	//======================================
	private static void supplyPCM(short[] pcm_buff_adr){
		int size=pcm_buff_adr.Length-2;
		for(int i=0;i<size;i+=2){
			pcm_buff_adr[i+0]=(short)((pcm_buff_adr[i+0]+pcm_buff_adr[i+2]) >> 1);
			pcm_buff_adr[i+1]=(short)((pcm_buff_adr[i+1]+pcm_buff_adr[i+3]) >> 1);
		}
	}
	//======================================
	//	short形式へコンバート
	//======================================
	private static void normalizeShortPCM(short[] pcm_buff_adr){
		int size=pcm_buff_adr.Length;
		for(int i=0;i<size;i+=2){
			int l=pcm_buff_adr[i+0];
			int r=pcm_buff_adr[i+1];
			if(l<SHORT_MIN)l=SHORT_MIN;
			if(l>SHORT_MAX)l=SHORT_MAX;
			if(r<SHORT_MIN)r=SHORT_MIN;
			if(r>SHORT_MAX)r=SHORT_MAX;
			pcm_buff_adr[i+0]=(short)l;
			pcm_buff_adr[i+1]=(short)r;
		}
	}
	//======================================
	//	出力バッファ形式へコンバート
	//======================================
	private static void outputFormatConvert(short[] pcm_buff_adr,int output_cate,byte[] output_buffer){
		switch(output_cate){
			case 0: //8bit,mono,unsigned
				{
				int pcm_buff_size=pcm_buff_adr.Length;
				for(int i=0;i<pcm_buff_size/2;i++){
					int l=pcm_buff_adr[i*2+0];
					int r=pcm_buff_adr[i*2+1];
					int lr=(l+r) >> 1;
					int lr1=((lr >> 8)+0x80) & 0xff;
					output_buffer[i]=(byte)lr1;
				}
				}
				break;
			case 1: //8bit,sterao,unsigned,L/R
				{
				int pcm_buff_size=pcm_buff_adr.Length;
				for(int i=0;i<pcm_buff_size/2;i++){
					int l=pcm_buff_adr[i*2+0];
					int r=pcm_buff_adr[i*2+1];
					int l1=((l >> 8)+0x80) & 0xff;
					int r1=((r >> 8)+0x80) & 0xff;
					output_buffer[i*2+0]=(byte)l1;
					output_buffer[i*2+1]=(byte)r1;
				}
				}
				break;
			case 2: //16bit LittleEndian,mono,signed
				{
				int pcm_buff_size=pcm_buff_adr.Length;
				for(int i=0;i<pcm_buff_size/2;i++){
					int l=pcm_buff_adr[i*2+0];
					int r=pcm_buff_adr[i*2+1];
					int lr=(l+r) >> 1;
					byte lr1=(byte)((lr >> 8) & 0xff);
					byte lr0=(byte)( lr       & 0xff);
					output_buffer[i*2+0]=lr0;
					output_buffer[i*2+1]=lr1;
				}
				}
				break;
			case 3: //16bit LittleEndian,sterao,signed,L/R
				{
				
				
				int pcm_buff_size=pcm_buff_adr.Length;
				for(int i=0;i<pcm_buff_size/2;i++){
					int l=pcm_buff_adr[i*2+0];
					int r=pcm_buff_adr[i*2+1];
					byte l1=(byte)((l >> 8) & 0xff);
					byte l0=(byte)( l       & 0xff);
					byte r1=(byte)((r >> 8) & 0xff);
					byte r0=(byte)( r       & 0xff);
					output_buffer[i*4+2*0+0]=l0;
					output_buffer[i*4+2*1+0]=r0;
					output_buffer[i*4+2*0+1]=l1;
					output_buffer[i*4+2*1+1]=r1;
				}
				}
				break;
			case 4: //8bit,mono,signed
				{
				int pcm_buff_size=pcm_buff_adr.Length;
				for(int i=0;i<pcm_buff_size/2;i++){
					int l=pcm_buff_adr[i*2+0];
					int r=pcm_buff_adr[i*2+1];
					int lr=(l+r) >> 1;
					byte lr1=(byte)((lr >> 8) & 0xff);
					output_buffer[i]=lr1;
				}
				}
				break;
			case 5: //8bit,sterao,signed,L/R
				{
				int pcm_buff_size=pcm_buff_adr.Length;
				for(int i=0;i<pcm_buff_size/2;i++){
					int l=pcm_buff_adr[i*2+0];
					int r=pcm_buff_adr[i*2+1];
					byte l1=(byte)((l >> 8) & 0xff);
					byte r1=(byte)((r >> 8) & 0xff);
					output_buffer[i*2+0]=l1;
					output_buffer[i*2+1]=r1;
				}
				}
				break;
		}
	}
};

//======================
}
}
