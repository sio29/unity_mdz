/******************************************************************************
;	ADPCM decoder
******************************************************************************/
namespace ulib{
namespace usound{
//======================
public class ADPCM_DECODER{
	private const int X_N0    =0x80;		//Xn ‚Ì‰Šú’l
	private const int DELTA_N0=127;		//DELTA_N ‚Ì‰Šú’l
	private static readonly int[] F_TBL={57*4,57*4,57*4,57*4,77*4,102*4,128*4,153*4};
	private const int F_MIN=127;
	private const int F_MAX=24576;
	//
	public class DECODE_WORK{
		public int x_n=X_N0*256;			//—\‘ª’l‚Ì‰Šú‰»
		public int delta_n=DELTA_N0;		//DELTA_N‚Ì‰Šú‰»
	}
	//
	//public static byte[] decode(byte[] data){
	public static short[] decode(byte[] data){
		return decode(data,0,data.Length);
	}
	//public static byte[] decode(byte[] data,int offset,int size){
	public static short[] decode(byte[] data,int offset,int size){
		if(size<0)return null;
		if(size>data.Length)return null;
		DECODE_WORK work=new DECODE_WORK();
		short[] output=new short[size*2];
		//byte[] output=new byte[size*2];
		for(int i=0;i<size;i++){
			byte d=data[offset+i];
			byte n1=(byte)((d >> 4) & 0xf);	//ãˆÊ4bit
			byte n2=(byte)( d       & 0xf);	//‰ºˆÊ4bit
			output[i*2+0]=decodeOne(work,n1);
			output[i*2+1]=decodeOne(work,n2);
		}
		return output;
	}
	//public static byte decodeOne(DECODE_WORK work,int n){
	public static short decodeOne(DECODE_WORK work,int n){
		int ax=((((n & 0x7) << 1)+1) * work.delta_n) >> 3;
		//
		if((n & 0x8)==0){
			ax=work.x_n+ax;
			if(ax>65535)ax=65535;
		}else{
			ax=work.x_n-ax;
			if(ax<0)ax=0;
		}
		work.x_n=ax;
		//
		int f=((F_TBL[n & 7]*work.delta_n) >> 8);
		if(f<F_MIN){
			f=F_MIN;
		}else if(f>F_MAX){
			f=F_MAX;
		}
		work.delta_n=f;
		//
		//return (byte)(work.x_n-32768);
		return (short)(work.x_n-32768);
	}
}
//======================
}
}
