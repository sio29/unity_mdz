/*-----------------------------------------------------------------------------
;	PPZ32 PCM合成ベース
-----------------------------------------------------------------------------*/

namespace ulib{
namespace usound{
//======================

public interface PPZ32_MixBase{
	public void mix(short[] buffer,int offset,int sample_num,bool stereo);
}
//======================
}
}
