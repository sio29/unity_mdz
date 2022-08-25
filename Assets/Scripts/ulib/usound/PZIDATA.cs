/*-----------------------------------------------------------------------------
;	PZIƒf[ƒ^
-----------------------------------------------------------------------------*/

namespace ulib{
namespace usound{
//======================
public class PZIDATA{
	public PZIDATATBL[] tbl;
	public byte[] wave;
	public int bit=8;
	public int cnl=1;
	
	public void shortenTbl(){
		int tbl_num=tbl.Length;
		int new_tbl_num=tbl_num;
		for(int i=tbl_num-1;i>=0;i--){
			if(tbl[i]!=null)break;
			new_tbl_num=i;
		}
		PZIDATATBL[] new_tbl=new PZIDATATBL[new_tbl_num];
		for(int i=0;i<new_tbl_num;i++){
			new_tbl[i]=tbl[i];
		}
		tbl=new_tbl;
	}
	public void allocTbl(int num){
		tbl=new PZIDATATBL[num];
	}
	public int getTblNum(){
		if(tbl==null)return 0;
		return tbl.Length;
	}
	public void setTbl(int i,PZIDATATBL t){
		if(i<0 || i>=tbl.Length)return;
		tbl[i]=t;
	}
	public PZIDATATBL getTbl(int i){
		if(tbl==null)return null;
		if(i<0 || i>=tbl.Length)return null;
		return tbl[i];
	}
	public PZIDATATBL getTblFromIndex(int index){
		if(tbl==null)return null;
		for(int i=0;i<tbl.Length;i++){
			if(tbl[i].index==index)return tbl[i];
		}
		return null;
	}
	public int[] getIndexBounds(){
		if(tbl==null)return null;
		//int min=Int32.MaxValue;
		//int max=Int32.MinValue;
		int min=int.MaxValue;
		int max=int.MinValue;
		for(int i=0;i<tbl.Length;i++){
			int index=tbl[i].index;
			if(index<min)min=index;
			if(index>max)max=index;
		}
		return new int[]{min,max};
	}
	public void setWave(byte[] _wave){
		wave=_wave;
	}
	public byte[] getWave(){
		return wave;
	}
	
}
//======================
}
}
