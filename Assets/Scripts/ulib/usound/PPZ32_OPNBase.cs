/*-----------------------------------------------------------------------------
;	PPZ32 OPN��PCM�����x�[�X
-----------------------------------------------------------------------------*/

namespace ulib{
namespace usound{
//======================

public interface PPZ32_OPNBase : PPZ32_MixBase{
	void outRegOPN(int reg,int data);
	bool hasPort(int port);
	void outRegOPN(int port,int reg,int data);
	int getOPNType();
}

//======================
}
}
