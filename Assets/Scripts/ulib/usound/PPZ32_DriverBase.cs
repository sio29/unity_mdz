/*-----------------------------------------------------------------------------
;	PPZ32_DriverBase
-----------------------------------------------------------------------------*/

namespace ulib{
namespace usound{
//======================

public interface PPZ32_DriverBase{
	void init();
	int getFreeCnl();
	void initCnl(int i);
	void stopCnl(int i);
	void setPan(int i,int pan);
	void setNote(int i,int wave);
	void setVol(int i,int vol);
	//
	void keyOn(int i,int index,byte[] data,int start,int end,int loop,int loopflg,int src_rate,int src_bit,int src_cnl);
	bool playCnl(int i,int index,byte[] data,int start,int end,int loop,int loopflg,int src_rate,int src_bit,int src_cnl,int vol,int pan,int note);
	bool playCnl(int i,PZIDATA pzidata,int index,int vol,int pan,int note);
	//
	void setTimer(int tempo,int base_cnt);
	int getNowMakePCMSize();
	void startPCMBuffer();
	int getPCMBufferAdr();
	void setDistRate(int rate);
};
//======================
}
}

