/*-----------------------------------------------------------------------------
;	PPZ32 PCM�����x�[�X
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
