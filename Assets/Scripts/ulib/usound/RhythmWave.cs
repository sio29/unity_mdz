/*-----------------------------------------------------------------------------
;	リズムデータ
-----------------------------------------------------------------------------*/
namespace ulib{
namespace usound{
public class RhythmWave{
	public static readonly sbyte[][] tbl={
		wave_2608_bd.data,
		wave_2608_sd.data,
		wave_2608_top.data,
		wave_2608_hh.data,
		wave_2608_tom.data,
		wave_2608_rym.data,
	};
	public static byte[][] u_tbl;
	static bool conv_flg=false;
	private static void conv(){
		if(u_tbl!=null)return;
		int tbl_num=tbl.Length;
		u_tbl=new byte[tbl_num][];
		for(int i=0;i<tbl_num;i++){
			sbyte[] _data=tbl[i];
			byte[] data=new byte[_data.Length];
			for(int j=0;j<_data.Length;j++){
				data[j]=(byte)(((int)_data[j]+128) & 0xff);
			}
			u_tbl[i]=data;
		}
	}
	public static sbyte[] getDataSint8(int i){
		return tbl[i];
	}
	public static byte[] getDataUint8(int i){
		conv();
		return u_tbl[i];
	}
}
//======================
}
}
