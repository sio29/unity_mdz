/******************************************************************************
;	MDZÉvÉåÉCÉÑÅ[
******************************************************************************/
using System.IO;

namespace ulib{
namespace usound{
public class MDZPlayer {
	//
	class PPZ32_MakePCMCallback_MDZ : PPZ32_MakePCMCallback{
		private MDZDRV.MDZ_WORK mdzwork;
		public PPZ32_MakePCMCallback_MDZ(MDZDRV.MDZ_WORK _mdzwork){
			mdzwork=_mdzwork;
		}
		public bool driverMain(PPZ32_DriverBase driver){
			MDZDRV.MDZ_playMain(mdzwork);
			return false;
		}
	}
	//
	private PPZ32_Driver driver;
	private MDZ_BGMDATA bgmdata;
	private MDZDRV.MDZ_WORK mdzwork;
	private PPZ32_MakePCMCallback driver_main;
	private float[] pcm_window=new float[256*2];
	private string bgm_filename;
	//
	public MDZPlayer(){
		initMDZ();
	}
	private void initMDZ(){
		driver=new PPZ32_Driver();
		driver.init();
		mdzwork=new MDZDRV.MDZ_WORK();
		mdzwork.setPCMDriver(driver);
		/*
		//OPN
		if(use_opn){
			PPZ32_OPNBase opn=new PPZ32_OPN(rate);
			ppz32.addMixBase(opn);
			mdzwork.setOPNBase(opn);
		}
		*/
		driver_main=new PPZ32_MakePCMCallback_MDZ(mdzwork);
	}
	public MDZDRV.MDZ_WORK getMDZWork(){
		return mdzwork;
	}
	public void setSampleRate(int sample_rate){
		driver.setDistRate(sample_rate);
	}
	public PZIDATA loadPZI(string filename){
		MDZDebug.Log("loadPZI:"+filename);
		byte[] data=MDZFile.ReadAllBytes(filename);
		return PZIDecoder.decode(data);
	}
	public MDZ_BGMDATA loadMDZ(string filename){
		MDZDebug.Log("loadMDZ:"+filename);
		bgm_filename=filename;
		byte[] data=MDZFile.ReadAllBytes(filename);
		return MDZ_BGMDATA.decode(data);
	}
	public bool playMDZ(string filename){
		MDZDebug.Log("playMDZ:"+filename);
		bgm_filename=filename;
		MDZ_BGMDATA bgmdata=MDZ_BGMDATA.loadData(filename);
		if(bgmdata==null){
			return false;
		}
		return playMDZByBgmData(bgmdata);
	}
	public void stopMDZ(){
		MDZDRV.MDZ_stopBgm(mdzwork);
	}
	public bool playMDZByBgmData(MDZ_BGMDATA bgmdata){
		if(!MDZDRV.MDZ_playBgm(mdzwork,bgmdata)){
			return false;
		}
		return true;
	}
	public void playMDZFilename(string filename){
		bgm_filename=filename;
	}
	public void setSoutaiTempo(int _soutai_tempo){
		MDZDRV.MDZ_addTempo(mdzwork,_soutai_tempo);
	}
	public int getSoutaiTempo(){
		return mdzwork.soutai_tempo;
	}
	public void ToggleCnlMask(int cnl){
		bool mask=MDZDRV.MDZ_getMaskChannel(mdzwork,cnl);
		mask=!mask;
		MDZDRV.MDZ_setMaskChannel(mdzwork,cnl,mask);
	}
	public bool getCnlMask(int cnl){
		return MDZDRV.MDZ_getMaskChannel(mdzwork,cnl);
	}
	public void setCnlMask(int cnl,bool mask){
		MDZDRV.MDZ_setMaskChannel(mdzwork,cnl,mask);
	}
	public void playPZI(int cnl,PZIDATA _pzidata,int index,float _vol,float _pan,float _note){
		int vol     =PPZ32_Driver.VOL_MAX-4;
		int pan     =PPZ32_Driver.PAN_CENTER;
		int note    =0x1000;//PPZ32_Driver.NOTE_CENTER;
		driver.playCnl(cnl,_pzidata,index,vol,pan,note);
	}
	public float[] getPcmWindow(){
		return pcm_window;
	}
	public string getMDZFilename(){
		return bgm_filename;
	}
	public string getPZIFilename(int i){
		if(mdzwork==null)return null;
		if(mdzwork.bgmr==null)return null;
		if(i==0){
			return mdzwork.bgmr.pcm1_file;
		}else{
			return mdzwork.bgmr.pcm2_file;
		}
	}
	public string getComment(){
		if(mdzwork==null)return null;
		if(mdzwork.bgmr==null)return null;
		return mdzwork.bgmr.comment;
	}
	public int getTempo(){
		if(mdzwork==null)return 0;
		return mdzwork.src_tempo;
	}
	public int getBaseCount(){
		if(mdzwork==null)return 0;
		if(mdzwork.bgmr==null)return 0;
		return mdzwork.bgmr.base_cnt;
	}
	
	
	public void makeSampleData(float[] data, int channels,int sample_num){
		if(data==null)return;
		//int len=data.Length;
		//int sample_num=len/channels;
		int len=channels*sample_num;
		short[] pcm_buff_adr=new short[len];
		driver.makePCM(driver_main,pcm_buff_adr,sample_num);
		for(int i=0;i<len;i++){
			float n=data[i];
			n+=(float)pcm_buff_adr[i]/32768.0f;
			data[i]=n;
		}
		for(int cnl=0;cnl<2;cnl++){
			int window_size=pcm_window.Length/2;
			for(int i=0;i<window_size;i++){
				int ii=(sample_num*i)/window_size;
				pcm_window[i*2+cnl]=data[ii*2+cnl];
			}
		}
	}
}
/******************************************************************************
;	
******************************************************************************/
//======================
}
}
