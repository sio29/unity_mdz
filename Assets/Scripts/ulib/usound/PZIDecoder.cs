/******************************************************************************
;	PZI decoder
******************************************************************************/

namespace ulib{
namespace usound{
//======================
public class PZIDecoder{
	public const int PZI=1;
	public const int PVI=2;
	public const int SBK=3;
	public const int SBI=4;
	public const string PZI_HEAD_M ="PZI0";
	public const string PZI_HEAD_M3="PZI";
	public const string PVI_HEAD_M ="PVI";
	public const string SBI_HEAD_M ="SBI0";
	public const string SBI_HEAD_M3="SBI";

	private static int getUint8(byte[] data,int off){
		int n=data[off] & 0xff;
		return n;
	}
	private static int getUint16(byte[] data,int off){
		int n0=data[off+0] & 0xff;
		int n1=data[off+1] & 0xff;
		int n=(n1 << 8) | n0;
		return n;
	}
	private static int getUint32(byte[] data,int off){
		int n0=data[off+0] & 0xff;
		int n1=data[off+1] & 0xff;
		int n2=data[off+2] & 0xff;
		int n3=data[off+3] & 0xff;
		int n=(n3 << 24) | (n2 << 16) | (n1 << 8) | n0;
		return n;
	}
	private static string getHeaderString(byte[] data){
		if(data==null)return null;
		if(data.Length<3)return null;
		string head_m=System.Text.Encoding.ASCII.GetString(data,0,3);
		return head_m;
	}
	private static void outUint8(byte[] data,int off,int n){
		data[off]=(byte)n;
	}
	private static void outUint16(byte[] data,int off,int n){
		int n0= n       & 0xff;
		int n1=(n >> 8) & 0xff;
		data[off+0]=(byte)n0;
		data[off+1]=(byte)n1;
	}
	private static void outUint32(byte[] data,int off,int n){
		int n0= n        & 0xff;
		int n1=(n >>  8) & 0xff;
		int n2=(n >> 16) & 0xff;
		int n3=(n >> 24) & 0xff;
		data[off+0]=(byte)n0;
		data[off+1]=(byte)n1;
		data[off+2]=(byte)n2;
		data[off+3]=(byte)n3;
	}
	private static void outString(byte[] data,int off,string n){
		byte[] b=System.Text.Encoding.ASCII.GetBytes(n);
		for(int i=0;i<b.Length;i++){
			data[off+i]=b[i];
		}
	}
	private static int getFileType(byte[] data){
		string head_m=getHeaderString(data);
		if(head_m.Equals(PZI_HEAD_M3)){
			return PZI;
		}else if(head_m.Equals(PVI_HEAD_M)){
			return PVI;
		}else if(head_m.Equals(SBI_HEAD_M3)){
			return SBI;
		}
		return -1;
	}
	private static int getFileType(string ext){
		ext=ext.ToLower();
		if(ext.Equals("pzi")){
			return PZI;
		}else if(ext.Equals("pvi")){
			return PVI;
		}else if(ext.Equals("sbi")){
			return SBI;
		}
		return -1;
	}
	public static PZIDATA decode(byte[] data){
		int type=getFileType(data);
		if(type==PZI){
			return decodePZI(data);
		}else if(type==PVI){
			return decodePVI(data,8);
		}
		return null;
	}
	//PZI deccode
	public static PZIDATA decodePZI(byte[] data){
		if(data==null)return null;
		if(data.Length<0x100)return null;
		string head_m=System.Text.Encoding.ASCII.GetString(data,0,4);
		if(!head_m.Equals("PZI0"))return null;
		
//		Debug.Log(path+" size(" + data.Length + ")");
//		string head=System.Text.Encoding.GetEncoding("shift_jis").GetString(data,0,3);
//		string head=System.Text.Encoding.ASCII.GetString(data,0,3);
//		Debug.Log("header:"+head_m);
		//
		int tbl_num=getUint8(data,0x0b);
		if(tbl_num==0)tbl_num=128;
//		Debug.Log("tbl_num:"+tbl_num);
		PZIDATA pzidata=new PZIDATA();
		pzidata.allocTbl(tbl_num);
		int src_tbl=0x20;
		int wave_top=0x20+tbl_num*0x12;
		//byte[] wave=UArrays.copyOfRange(data,wave_top,data.Length-1);
		
		//bool wave_shorten_flg=true;
		bool wave_shorten_flg=false;
		
		byte[] wave;
		if(wave_shorten_flg){
			wave=new byte[data.Length-wave_top];
			System.Buffer.BlockCopy(data,wave_top,wave,0,wave.Length);
		}else{
			wave=data;
		}
		pzidata.setWave(wave);
		
		for(int i=0;i<tbl_num;i++){
			int start     =getUint32(data,src_tbl+0x00);
			int end       =getUint32(data,src_tbl+0x04);
			int loop_start=getUint32(data,src_tbl+0x08);
			int loop_end  =getUint32(data,src_tbl+0x0c);
			int rate      =getUint16(data,src_tbl+0x10);
			if(rate==0)continue;
			if(end ==0)continue;
			if(rate<0)rate+=65536;
			PZIDATATBL t=new PZIDATATBL();
			t.index     =i;
			if(wave_shorten_flg){
				t.start     =start;
				t.end       =end;
				t.loop_start=loop_start;
				t.loop_end  =loop_end;
			}else{
				t.start     =start+wave_top;
				t.end       =end;
				t.loop_start=loop_start;
				t.loop_end  =loop_end;
			}
			t.rate      =rate;
			t.wave      =wave;
			t.bit       =8;
			t.cnl       =1;
			pzidata.setTbl(i,t);
//System.out.println(UString.format("[%3d]:tbl(%04x),start(%08x),end(%08x),ls(%08x-%08x)",i,src_tbl,start,end,loop_start,loop_end));
			//
			src_tbl+=0x12;
		}
		pzidata.shortenTbl();
		return pzidata;
	}
	private static byte[] convertByteWave(short[] _wave){
		int len=_wave.Length;
		byte[] output=new byte[len];
		for(int i=0;i<len;i++){
			int n=_wave[i];
			//n=n / 256;
			n=n >> 8;
			if(n<-128)n=-128;
			if(n> 127)n= 127;
			n=(n+128);
			n&=0xff;
			output[i]=(byte)n;
		}
		return output;
	}
	//PVI deccode
	public static PZIDATA decodePVI(byte[] data,int out_bit){
		if(data.Length<0x210)return null;
		string head_m=System.Text.Encoding.ASCII.GetString(data,0,3);
		if(!head_m.Equals("PVI"))return null;
		//ADPCMデコード
		//short[] _wave=null;//ADPCM_DECODER.decode(data,0x210,data.length-0x210);
		//byte[] wave=convertByteWave(_wave);
		//byte[] wave=ADPCM_DECODER.decode(data,0x210,data.Length-0x210);
		short[] _wave=ADPCM_DECODER.decode(data,0x210,data.Length-0x210);
		byte[] wave=convertByteWave(_wave);
		//
		int tbl_num=128;
		//
		PZIDATA pzidata=new PZIDATA();
		pzidata.allocTbl(tbl_num);
		pzidata.setWave(wave);
		pzidata.bit=out_bit;
		int src_tbl=0x10;
		//int wave_top=0;
		for(int i=0;i<tbl_num;i++){
			int start     =(getUint16(data,src_tbl+0x00) & 0xffff) << 6;
			int end       =(getUint16(data,src_tbl+0x02) & 0xffff) << 6;
			if(start==0 && end==0)continue;
			int loop_start=-1;
			int loop_end  =-1;
			int rate      =16000;
			end-=start;
			if(rate==0)continue;
			if(end ==0)continue;
			if(rate<0)rate+=65536;
			//
			PZIDATATBL t=new PZIDATATBL();
			t.index     =i;
			t.start     =start;
			t.end       =end;
			t.loop_start=loop_start;
			t.loop_end  =loop_end;
			t.rate      =rate;
			t.wave      =wave;
			t.bit       =out_bit;
			t.cnl       =1;
			pzidata.setTbl(i,t);
			//
			src_tbl+=0x4;
		}
		//
		pzidata.shortenTbl();
		return pzidata;
	}
	
}
//======================
}
}
