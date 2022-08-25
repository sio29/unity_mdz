/*-----------------------------------------------------------------------------
;	PZIデータ　テーブル
-----------------------------------------------------------------------------*/

namespace ulib{
namespace usound{
	public class PZIDATATBL{
		public int start;
		public int end;
		public int loop_start;
		public int loop_end;
		public int rate;
		public byte[] wave;
		public int bit;
		public int cnl;
		public int index;
		
		public override string ToString(){
			string s="start("+start+"),end("+end+"),loop_start("+loop_start+"),loop_end("+loop_end+"),rate("+rate+"),wave_size("+((wave!=null)?wave.Length:0)+")";
			s+=",bit("+bit+"),cnl("+cnl+"),index("+index+")";
			return s;
		}
	}
	
}
}
