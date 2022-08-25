/*-----------------------------------------------------------------------------
;	MDZ BGMデータ
-----------------------------------------------------------------------------*/
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ulib{
namespace usound{
/******************************************************************************
;	BGM情報
******************************************************************************/
public class MDZ_BGMDATA{
	public class MDZ_BGMDATACNL{
		public int type;
		public int index;
		public int offset;
		//
		public void Init(){
			type  =-1;
			index =-1;
			offset=-1;
		}
	};
	
	public const string MDZS_VER		="0.05";			//MDZバージョン
	public const int _MDZS_VER			=1;				//ｺﾝﾊﾟｲﾗ処理可能バージョン
	public static readonly int BGM_CNL_MAX		=26;				//BGMチャネル数
	public const int PZI_BANK_MAX		=4;				//バンク数
	//MDZヘッダー
	public const int MDZH_SIZE1			=0x00;		//2byte サイズ1
	public const int MDZH_SIZE2			=0x02;		//2byte サイズ2
	public const int MDZH_STRING		=0x04;		//4byte ヘッダー文字列
	public const int MDZH_VER			=0x09;		//2byte バージョン
	public const int MDZH_EX_FLG		=0x10;		//2byte 拡張フラグ
	public const int MDZH_QFLG			=0x12;		//2byte ゲートタイムの種類
	public const int MDZH_FM_OTO		=0x14;		//2byte FM音色
	public const int MDZH_SSG_OTO		=0x16;		//2byte SSG音色
	public const int MDZH_ADPCM_OTO		=0x18;		//2byte ADPCM音色
	public const int MDZH_PCM2_NAME		=0x1A;		//2byte PCM2のファイル名
	public const int MDZH_COMMENT		=0x1C;		//2byte コメントアドレス
	public const int MDZH_FM_VOL_FLG	=0x1E;		//2byte FMボリュームフラグ
	public const int MDZH_PRIORITY		=0x20;		//2byte 
	public const int MDZH_BGM_DATA2_TOP	=0x22;		//2byte 
	public const int MDZH_CNL_NUM		=0x24;		//2byte チャネル数
	public const int MDZH_PCM1_NAME		=0x26;		//2byte PCM1のファイル名
	public const int MDZH_PPZ8_OTO		=0x28;		//2byte 
	public const int MDZH_PCM1_CATE		=0x2A;		//2byte PCM1のファイルの種類
	public const int MDZH_BASE			=0x2E;		//2byte ベースカウント
	public const int MDZ_HEADER_SIZE	=0x30;		//ヘッダーサイズ
	//チャネルの種別
	public const int _FM_F				=0x00;		//FM
	public const int _SSG_F				=0x01;		//SSG
	public const int _RITHM_F			=0x02;		//リズム
	public const int _ADPCM_F			=0x03;		//ADPCM
	public const int _PCM68_F			=0x04;		//68ADPCM
	public const int _PCM86_F			=0x05;		//86PCM
	public const int _PPZ_F				=0x06;		//PPZ CHANEL
	public const int _PPZ86_F			=0x07;		//PPZ86 CHANEL
	public const int _PPZ8_F			=0x08;		//PPZ8 CHANEL
	public const int _MIDI_F			=0x09;		//MIDI
	public const int _OPX_F				=0x0A;		//OPX
	public const int _OPL4_FM_F			=0x0B;		//OPL4_FM
	public const int _OPL4_RITHM_F		=0x0C;		//OPL4_RITHM
	public const int _OPL4_PCM_F		=0x0D;		//OPL4_PCM
	//コマンド
	public const int _REST_COM			=0x80;		//休符
	public const int _COM_TOP			=0x81;		//コマンドの先頭
	public const int _STOP_COM			=0xFF;		//停止コマンド
	//
	
	public byte[] data;
	public MDZ_BGMDATACNL[] cnltbl=new MDZ_BGMDATACNL[BGM_CNL_MAX];
	public string pcm1_file;
	public int pcm1_cate;
	public string pcm2_file;
	public int pcm2_cate;
	public string comment;
	public int ex_flg;
	public int qflg;
	public int fm_oto;
	public int ssg_oto;
	public int adpcm_oto;
	public int cnl_num;
	public int base_cnt;
	public PZIDATA[] pzi_tbl=new PZIDATA[PZI_BANK_MAX];
	
	
	public MDZ_BGMDATA(){
		initSub();
	}
	public MDZ_BGMDATA(byte[] data){
		initSub();
		setData(data);
	}
	private void initSub(){
		for(int i =0;i<BGM_CNL_MAX;i++){
			cnltbl[i]=new MDZ_BGMDATACNL();
		}
		init();
	}
	public void init(){
		base_cnt=192;				//ベースカウント
		for(int i =0;i<BGM_CNL_MAX;i++){
			cnltbl[i].Init();
		}
	}
	public static byte[] MDZ_getDataBytes(byte[] data,int offset,int size){
		//return UArrays.copyOfRange(data,offset,offset+size);
		byte[] dst=new byte[size];
		System.Buffer.BlockCopy(data,offset,dst,0,size);
		return dst;
	}
	public static string MDZ_getDataStringN(byte[] data,int offset,int size){
		byte[] m=MDZ_getDataBytes(data,offset,size);
		//return new string(m);
		return System.Text.Encoding.ASCII.GetString(m);
	}
	public static byte[] MDZ_getDataStringSub(byte[] data,int offset){
		int bottom=0;
		for(int i=offset;i<data.Length;i++){
			if(data[i]==0){
				bottom=i;
				break;
			}
		}
		byte[] m=MDZ_getDataBytes(data,offset,bottom-offset);
		return m;
	}
	public static string MDZ_getDataString(byte[] data,int offset){
		/*
		int bottom=0;
		for(int i=offset;i<data.Length;i++){
			if(data[i]==0){
				bottom=i;
				break;
			}
		}
		byte[] m=MDZ_getDataBytes(data,offset,bottom-offset);
		*/
		//return new string(m);
		byte[] m=MDZ_getDataStringSub(data,offset);
		return System.Text.Encoding.ASCII.GetString(m);
	}
	public static string MDZ_getDataString_SJIS(byte[] data,int offset){
		byte[] m=MDZ_getDataStringSub(data,offset);
		//return System.Text.Encoding.SJIS.GetString(m);
		//return System.Text.Encoding.GetEncoding("Shift_JIS").GetString(m);
		
		System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("Shift_JIS");
		byte[] dst = System.Text.Encoding.Convert(encoding, System.Text.Encoding.UTF8, m);
		return System.Text.Encoding.UTF8.GetString(dst);
	}
	public static bool MDZ_CheckOffset(byte[] data,int offset){
		if(offset<0 || offset>=data.Length)return false;
		return true;
	}
	public static sbyte toSByte(byte n){
		/*
		if(n<0x80){
			return (sbyte)n;
		}else{
			return (sbyte)(-256+n);
		}
		*/
		return (sbyte)n;
	}
	public static int MDZ_getDataUint8(byte[] data,int offset){
		int n=data[offset+0] & 0xff;
		return n;
	}
	public static int MDZ_getDataSint8(byte[] data,int offset){
		//int n=data[offset+0];
		int n=toSByte(data[offset+0]);
		return n;
	}
	public static int MDZ_getDataUint16(byte[] data,int offset){
		int n0=data[offset+0] & 0xff;
		int n1=data[offset+1] & 0xff;
		return (n1 << 8) | n0;
		
	}
	public static int MDZ_getDataSint16(byte[] data,int offset){
		int n0=data[offset+0] & 0xff;
		//int n1=data[offset+1];
		int n1=toSByte(data[offset+1]);
		return (n1 << 8) | n0;
	}
	public static int MDZ_getDataUint32(byte[] data,int offset){
		int n0=data[offset+0] & 0xff;
		int n1=data[offset+1] & 0xff;
		int n2=data[offset+2] & 0xff;
		int n3=data[offset+3] & 0xff;
		return (n3 << 24) | (n2 << 16) | (n1 << 8) | n0;
		
	}
	public static int MDZ_getDataSint32(byte[] data,int offset){
		int n0=data[offset+0] & 0xff;
		int n1=data[offset+1] & 0xff;
		int n2=data[offset+2] & 0xff;
		//int n3=data[offset+3];
		int n3=toSByte(data[offset+3]);
		return (n3 << 24) | (n2 << 16) | (n1 << 8) | n0;
	}
	
	public int getDataUint8(int offset){
		return MDZ_getDataUint8(data,offset);
	}
	public int getDataSint8(int offset){
		return MDZ_getDataSint8(data,offset);
	}
	public int getDataUint16(int offset){
		return MDZ_getDataUint16(data,offset);
	}
	public int getDataSint16(int offset){
		return MDZ_getDataSint16(data,offset);
	}
	public int getDataUint32(int offset){
		return MDZ_getDataUint32(data,offset);
	}
	public int getDataSint32(int offset){
		return MDZ_getDataSint32(data,offset);
	}
	
	public bool setData(byte[] _data){
		return MDZ_checkHeader(this,_data);
	}
	//MDZヘッダーの獲得
	public static bool MDZ_checkHeader(MDZ_BGMDATA bgmr,byte[] data){
		if(data==null)return false;
		if(bgmr==null)return false;
		bgmr.data=data;
		//MDZHEAD mdzh=data;
		//if(strncmp(mdzh.m,"MDZS",4)!=0)return false;
		string head_m=MDZ_getDataStringN(data,MDZH_STRING,4);
		if(!head_m.Equals("MDZS"))return false;
		//int ver=mdzh.ver;
		int ver=MDZ_getDataUint16(data,MDZH_VER);
		if(ver!=_MDZS_VER)return false;
		//拡張フラグ
		bgmr.ex_flg=MDZ_getDataUint16(data,MDZH_EX_FLG);
		//Q
		int qflg=MDZ_getDataUint16(data,MDZH_QFLG);
		if(qflg==0){
			bgmr.qflg=8;
		}else{
			bgmr.qflg=1;
		}
		bgmr.fm_oto   =0;
		bgmr.ssg_oto  =0;
		bgmr.adpcm_oto=0;
		//FM音
		int fm_oto=MDZ_getDataUint16(data,MDZH_FM_OTO);
		if(fm_oto<data.Length){
			bgmr.fm_oto=fm_oto;
		}
		//SSG音
		int ssg_oto=MDZ_getDataUint16(data,MDZH_SSG_OTO);
		if(ssg_oto<data.Length){
			bgmr.ssg_oto=ssg_oto;
		}
		//ADPCM音
		int adpcm_oto=MDZ_getDataUint16(data,MDZH_ADPCM_OTO);
		if(adpcm_oto<data.Length){
			bgmr.adpcm_oto=adpcm_oto;
		}
		//
		bgmr.pcm1_file=null;
		bgmr.pcm2_file=null;
		bgmr.comment=null;
		//PCM1名前
		int pcm1_name_offset=MDZ_getDataUint16(data,MDZH_PCM1_NAME);
//MDZDebug.Log("pcm1_name_offset:"+pcm1_name_offset);
		if(pcm1_name_offset!=0xffff){
			bgmr.pcm1_file=MDZ_getDataString(data,pcm1_name_offset);
		}
		//PCM1種別
		int pcm1_cate=MDZ_getDataUint16(data,MDZH_PCM1_CATE);
		bgmr.pcm1_cate=pcm1_cate & 1;
		//PCM2名前
		int pcm2_name_offset=MDZ_getDataUint16(data,MDZH_PCM2_NAME);
//MDZDebug.Log("pcm2_name_offset:"+pcm2_name_offset);
		if(pcm2_name_offset!=0xffff){
			bgmr.pcm2_file=MDZ_getDataString(data,pcm2_name_offset);
		}
		//PCM2種別
		bgmr.pcm2_cate=0;
		//コメント
		int comment_offset=MDZ_getDataUint16(data,MDZH_COMMENT);
//MDZDebug.Log("comment_offset:"+comment_offset);
		if(comment_offset!=0xffff){
			//bgmr.comment=MDZ_getDataString(data,comment_offset);
			//bgmr.comment=MDZ_getDataString_SJIS(data,comment_offset);
			bgmr.comment="---";
			if(bgmr.comment!=null){
				int ii=bgmr.comment.LastIndexOf("$");
				if(ii>=0){
					bgmr.comment=bgmr.comment.Substring(0,ii);
				}
			}
		}
		//ベース
		int base_cnt=MDZ_getDataUint16(data,MDZH_BASE);
//MDZDebug.Log("base_cnt:"+base_cnt);
		//if(base_cnt==0xffff)base_cnt=192;
		if(base_cnt==0xffff)base_cnt=96;
		bgmr.base_cnt=base_cnt;
		//チャネル数
		bgmr.cnl_num=MDZ_getDataUint16(data,MDZH_CNL_NUM);
//MDZDebug.Log("cnl_num:"+bgmr.cnl_num);
		if(bgmr.cnl_num>BGM_CNL_MAX)bgmr.cnl_num=BGM_CNL_MAX;
		//
		for(int i=0;i<BGM_CNL_MAX;i++){
			bgmr.cnltbl[i].Init();
		}
		//
		for(int i=0;i<BGM_CNL_MAX;i++){
			int cnl_tbl_index=MDZ_HEADER_SIZE+(i*4);
			int cnl_type  =MDZ_getDataSint8(data,cnl_tbl_index+0);
			int cnl_index =MDZ_getDataUint8(data,cnl_tbl_index+1);
			int cnl_offset=MDZ_getDataUint16(data,cnl_tbl_index+2);
//MDZDebug.Log("cnl["+i+"]:type("+cnl_type+")"+getCnlCateName(cnl_type)+"["+cnl_index+"]:offset("+cnl_offset+")");
			if(cnl_type==-1)continue;
			//PPZ8チャネル以外スキップ
			//if(cnl_type!=_PPZ8_F)continue;
//if(cnl_type!=_PPZ8_F && cnl_type!=_ADPCM_F )continue;
//if(cnl_type!=_PPZ8_F && cnl_type!=_ADPCM_F && cnl_type!=_FM_F )continue;
//if(cnl_type!=_PPZ8_F && cnl_type!=_ADPCM_F && cnl_type!=_FM_F )continue;
if(cnl_type!=_PPZ8_F && cnl_type!=_ADPCM_F && cnl_type!=_RITHM_F && cnl_type!=_FM_F && cnl_type!=_SSG_F)continue;
//if(cnl_type!=_PPZ8_F && cnl_type!=_ADPCM_F && cnl_type!=_SSG_F)continue;
//if(cnl_type!=_SSG_F )continue;
//if(cnl_type!=_FM_F )continue;
//if(cnl_type!=_RITHM_F )continue;
//2,4
//if(cnl_index!=7)continue;
			//チャンネルオーバー
			if(cnl_index>=BGM_CNL_MAX)continue;
			//最初のデータが停止だったら
			if(!MDZ_CheckOffset(data,cnl_offset))continue;
			
			int first_data=MDZ_getDataUint8(data,cnl_offset);
			if(first_data==0xff)continue;
			bgmr.cnltbl[i].type  =cnl_type;
			bgmr.cnltbl[i].index =cnl_index;
			bgmr.cnltbl[i].offset=cnl_offset;
//MDZDebug.Log("cnl["+i+"]:"+getCnlCateName(cnl_type)+"["+cnl_index+"]:offset("+cnl_offset+")");
		}
//MDZDebug.Log("MDZ_checkHeader end.");
		return true;
	}
	//コマンド名
	public static string getCommandName(int command){
		switch(command){
			case 0x81:return "Volset";
			case 0x82:return "VolUp";
			case 0x83:return "VolDown";
			case 0x84:return "TEMPO_SET";
			case 0x85:return "JumpCom";
			case 0x86:return "LoopCom";
			case 0x87:return "LoopOut";
			case 0x88:return "Quotaset";
			case 0x89:return "Detuneset";
			case 0x8A:return "LFOset";
			case 0x8B:return "LFOCom";
			case 0x8C:return "OPN_WRITE";
			case 0x8D:return "OtoCom";
			case 0x8E:return "Panset";
			case 0x8F:return "NOISE_SET";
			case 0x90:return "Envset";
			case 0x91:return "Volset2";
			case 0x92:return "Taiset";
			case 0x93:return "Loopset";
			case 0x94:return "SYNC_COM";
			case 0x95:return "WAIT_COM";
			case 0x96:return "FadeCom";
			case 0x97:return "VEND_SET";
			case 0x98:return "PCM_F_SET";
			case 0x99:return "SentDataCom";
			case 0x9A:return "SIcho";
			case 0x9B:return "Suraset";
			case 0x9C:return "DefLenset";
			case 0x9D:return "BankSel";
			case 0x9E:return "MIDIEffect";
			case 0x9F:return "ベンドレンジ";
			case 0xA0:return "ベロシティＵＰ";
			case 0xA1:return "ベロシティＤＯＷＮ";
			case 0xA2:return "チャネル番号設定";
			case 0xA3:return "PPZのPAN設定";
			case 0xA4:return "ベロシティセット";
			case 0xA5:return "AutoPanset";
			case 0xA6:return "RestOffset";
			case 0xA7:return "TIMERA_COM";
			case 0xA8:return "Temposet";
			case 0xA9:return "Vendset";
			case 0xAA:return "LoopPointset";
			case 0xAB:return "LoopIs";
		}
		return null;
	}
	//チャンネル種類名
	public static string getCnlCateName(int cnl_cate){
		switch(cnl_cate){
			case _FM_F:return "FM";
			case _SSG_F:return "SSG";
			case _RITHM_F:return "RITHM";
			case _ADPCM_F:return "ADPCM";
			case _PCM68_F:return "PCM68";
			case _PCM86_F:return "PCM86";
			case _PPZ_F:return "PPZ";
			case _PPZ86_F:return "PPZ86";
			case _PPZ8_F:return "PPZ8";
			case _MIDI_F:return "MIDI";
			case _OPX_F:return "OPX";
			case _OPL4_FM_F:return "OPL4_FM";
			case _OPL4_RITHM_F:return "OPL4_RITHM";
			case _OPL4_PCM_F:return "OPL4_PCM";
		}
		return null;
	}
	public static string getCnlName(int cnl_cate,int cnl_index){
		return getCnlCateName(cnl_cate)+"["+cnl_index+"]";
	}
	//=================================================
	//decode
	public static MDZ_BGMDATA decode(byte[] data){
		MDZ_BGMDATA bgmdata=new MDZ_BGMDATA();
		if(!MDZ_checkHeader(bgmdata,data))return null;
		return bgmdata;
	}
	
	//BGMデータだけ読み込む
	public static MDZ_BGMDATA loadDataOnly(string filename){
		byte[] data=MDZFile.ReadAllBytes(filename);
		if(data==null){
			MDZDebug.Log("MDZ_BGMDATA.LoadDataOnly Error!!");
			return null;
		}
		return decode(data);
	}
	//拡張子を得る
//	public static string getFileExt(string filename){
//		return Path.GetExtension(filename);
//	}
	//拡張子を変更する
	public static string changeFileExt(string filename,string new_ext){
		return Path.ChangeExtension(filename,new_ext);
	}
	//BGMデータ読み込み
	public static MDZ_BGMDATA loadData(string filename){
//MDZDebug.Log("loadData:"+filename);
		//BGMデータ読み込み
		MDZ_BGMDATA bgmdata=loadDataOnly(filename);
		if(bgmdata==null)return null;
		if(!loadPCMForBGM(filename,bgmdata))return null;
		//MDZDebug.Log("loadData ok !!:"+filename);
		return bgmdata;
	}
	public static bool loadPCMForBGM(string filename,MDZ_BGMDATA bgmdata){
		//PCM1の読み込み
		if(bgmdata.pcm1_file!=null){
			PZIDATA pzi=loadPCM(filename,bgmdata.pcm1_file);
			if(pzi!=null){
				bgmdata.pzi_tbl[0]=pzi;
			}else{
				MDZDebug.Log("file not found !!:"+bgmdata.pcm1_file);
			}
		}
		//PCM2の読み込み
		if(bgmdata.pcm2_file!=null){
			PZIDATA pzi=loadPCM(filename,bgmdata.pcm2_file);
			if(pzi!=null){
				bgmdata.pzi_tbl[1]=pzi;
			}else{
				MDZDebug.Log("file not found !!:"+bgmdata.pcm2_file);
			}
		}
		return true;
	}
	//PCMファイルの読み込み
	public static PZIDATA loadPCM(string bgm_filename,string pcm_filename){
//MDZDebug.Log("loadPCM:"+pcm_filename);
		string filename=null;
		string bgm_dir=Path.GetDirectoryName(bgm_filename);
//MDZDebug.Log("bgm_dir:"+bgm_dir);
		//PZI
		filename=checkFileExist(bgm_dir,pcm_filename,"pzi");
		if(filename!=null){
			PZIDATA pzi=loadPZI(filename);
			if(pzi!=null){
				//MDZDebug.Log("load ok:"+filename);
				return pzi;
			}
		}
		//PVI
		filename=checkFileExist(bgm_dir,pcm_filename,"pvi");
		if(filename!=null){
			PZIDATA pzi=loadPZI(filename);
			if(pzi!=null){
				//MDZDebug.Log("load ok:"+filename);
				return pzi;
			}
		}
		MDZDebug.Log("(PVI/PZI) load error !!:"+pcm_filename);
		return null;
	}
	//PZIデータの読み込み
	public static PZIDATA loadPZI(string filename){
		//if(!filename.exist())return null;
		byte[] data=MDZFile.ReadAllBytes(filename);
		PZIDATA pzi=PZIDecoder.decode(data);
		if(pzi==null){
			MDZDebug.Log("PZI load error !!:"+filename);
			return null;
		}
		return pzi;
	}
	public static string makeFullpathFilename(string filename,string filebody){
		//return Path.GetFullPath(Path.Combine(filename,filebody));
		char m=filename[filename.Length-1];
		if(!(m=='/' || m=='\\')){
			filename+="/";
		}
		filename+=filebody;
		return filename;
	}
	//
	public static string[] makePCMFilename(string bgm_filename,MDZ_BGMDATA bgmdata,int i){
		string pcm_filename;
		if(i==0){
			pcm_filename=bgmdata.pcm1_file;
		}else{
			pcm_filename=bgmdata.pcm2_file;
		}
		return makePCMFilename(bgm_filename,pcm_filename);
	}
	public static string getDirectoryName(string filename){
		//return Path.GetDirectoryName(filename);
		int i0=filename.LastIndexOf("/");
		int i1=filename.LastIndexOf("\\");
		int i2=filename.LastIndexOf(":");
		int i=i0;
		if(i<i1)i=i1;
		if(i<i2)i=i2;
		if(i>=0){
			filename=filename.Substring(0,i);
		}
		return filename;
	}
	public static string[] makePCMFilename(string bgm_filename,string pcm_filename){
		if(pcm_filename==null)return null;
		List<string> list=new List<string>();
		string bgm_dir=getDirectoryName(bgm_filename);
		makeCheckFileExist(list,bgm_dir,pcm_filename,"pzi");
		makeCheckFileExist(list,bgm_dir,pcm_filename,"pvi");
		return (string[])list.ToArray();
	}
	//
	public static void makeCheckFileExist(List<string> ret,string dir,string filebody,string ext){
		if(dir==null)return;
		string[] exts=new string[3];
		string[] bodys=new string[3];
		string[] rets=new string[3*3];
		exts[0]=ext;
		exts[1]=ext.ToLower();
		exts[2]=ext.ToUpper();
		bodys[0]=makeFullpathFilename(dir,filebody);
		bodys[1]=makeFullpathFilename(dir,filebody.ToLower());
		bodys[2]=makeFullpathFilename(dir,filebody.ToUpper());
		for(int i=0;i<bodys.Length;i++){
			for(int j=0;j<exts.Length;j++){
				string new_filename=changeFileExt(bodys[i],exts[j]);
				ret.Add(new_filename);
			}
		}
	}
	//
	public static string checkFileExist(string dir,string filebody,string ext){
		if(dir==null)return null;
		string[] exts=new string[3];
		string[] bodys=new string[3];
		exts[0]=ext;
		exts[1]=ext.ToLower();
		exts[2]=ext.ToUpper();
		bodys[0]=makeFullpathFilename(dir,filebody);
		bodys[1]=makeFullpathFilename(dir,filebody.ToLower());
		bodys[2]=makeFullpathFilename(dir,filebody.ToUpper());
		for(int i=0;i<bodys.Length;i++){
			for(int j=0;j<exts.Length;j++){
				string new_filename=changeFileExt(bodys[i],exts[j]);
				bool r=File.Exists(new_filename);
//MDZDebug.Log("exists:"+new_filename+":"+r);
				if(r)return new_filename;
			}
		}
		return null;
	}
};
/******************************************************************************
;	おしまい
******************************************************************************/
//======================
}
}
