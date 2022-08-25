/******************************************************************************
;	
******************************************************************************/
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

using ulib.usound;


delegate void LoadAfterProc(string filename,byte[] data);

[RequireComponent(typeof(AudioSource))]
public class MDZPlayerComponent : MonoBehaviour
{
	private MDZPlayer mdz_player;

#if UNITY_WEBGL && !UNITY_EDITOR
	//プラグイン関数のインポート
	[DllImport("__Internal")]
	private static extern int USOUND_InitWebAudio(int size);
	
	[DllImport("__Internal")]
	private static extern void USOUND_ExecWebAudio(string gameobj_name,string func_name,float[] buffer);
	
	[DllImport("__Internal")]
	private static extern int USOUND_GetSampleRate();
	//PCMバッファ
	float[] webgl_buffer;
	//WebAudio(ScriptProcessorNode)の初期化
	public void WebAudio_Init(){
		Debug.Log("WebAudio_Init");
		string gameobj_name=gameObject.name;
		//WebAudio(ScriptProcessorNode)の初期化
		int buff_size=USOUND_InitWebAudio(2048);
		webgl_buffer=new float[buff_size*2];
		//バッファクリア
		for(int i=0;i<webgl_buffer.Length;i++){
			webgl_buffer[i]=0.0f;
		}
		//WebAudio(ScriptProcessorNode)の再生
		USOUND_ExecWebAudio(gameobj_name,"WebAudio_OnAudioFilterRead",webgl_buffer);
	}
	//PCM合成
	public void WebAudio_OnAudioFilterRead(int sample_num){
		//バッファクリア
		for(int i=0;i<sample_num*2;i++){
			webgl_buffer[i]=0.0f;
		}
		int channels=2;
		//ドライバーのPCM合成へ
		mdz_player.makeSampleData(webgl_buffer,channels,sample_num);
	}
#endif
	
	void Awake() {
		int sample_rate=(int)AudioSettings.outputSampleRate;
		Debug.Log("AudioSettings.outputSampleRate:"+(int)AudioSettings.outputSampleRate);
#if UNITY_WEBGL && !UNITY_EDITOR
		sample_rate=USOUND_GetSampleRate();
		WebAudio_Init();
#endif
		MDZDebug.logger=Debug.Log;
		mdz_player=new MDZPlayer();
		mdz_player.setSampleRate(sample_rate);
	}
	void Start(){
	}
	void Update(){
	}
	void OnAudioFilterRead(float[] data, int channels){
		int sample_num=data.Length/channels;
		mdz_player.makeSampleData(data, channels,sample_num);
	}
	public MDZPlayer getMDZPlayer(){
		return mdz_player;
	}
	public MDZDRV.MDZ_WORK getMDZWork(){
		return mdz_player.getMDZWork();
	}
	public PZIDATA loadPZI(string path){
		return mdz_player.loadPZI(path);
	}
	public MDZ_BGMDATA loadMDZ(string path){
		return mdz_player.loadMDZ(path);
	}
	public bool playMDZ(string filename){
		if(filename.Contains("://")) {
			return playMDZFromWeb(filename);
		}else{
			return playMDZFromLocal(filename);
		}
	}
	public bool playMDZFromLocal(string filename){
		return mdz_player.playMDZ(filename);
	}
	public bool playMDZFromWeb(string filename){
		//Debug.Log("playMDZFromWeb:001");
		IEnumerator proc=PlayBGMData(filename);
		//Debug.Log("playMDZFromWeb:002");
		StartCoroutine(proc);
		//Debug.Log("playMDZFromWeb:003");
		return true;
	}
	public IEnumerator PlayBGMData(string filename){
		mdz_player.playMDZFilename(filename);
		//Debug.Log("PlayBGMData:001");
		IEnumerator proc=ReadBGMData(filename);
		//Debug.Log("PlayBGMData:002");
		yield return StartCoroutine(proc);
		//Debug.Log("PlayBGMData:Current:"+proc.Current);
		if(proc.Current==null){
		}else{
			MDZ_BGMDATA bgmdata=(MDZ_BGMDATA)proc.Current;
			mdz_player.playMDZByBgmData(bgmdata);
		}
	}
	public IEnumerator ReadBGMData(string filename){
		//Debug.Log("ReadBGMData:001:"+filename);
		IEnumerator proc=ReadBinary(filename);
		//Debug.Log("ReadBGMData:002");
		yield return StartCoroutine(proc);
		//Debug.Log("ReadBGMData:Current:"+proc.Current.GetType());
		if(proc.Current==null){
			yield return null;
		}else{
			MDZ_BGMDATA bgmdata=MDZ_BGMDATA.decode((byte[])proc.Current);
			if(bgmdata==null){
				yield return null;
			}else{
				Debug.Log("ReadBGMData OK:"+filename);
				string[] pcm1_filenames=MDZ_BGMDATA.makePCMFilename(filename,bgmdata,0);
				string[] pcm2_filenames=MDZ_BGMDATA.makePCMFilename(filename,bgmdata,1);
				//
				//Debug.Log("------------------------------------------------ 01");
				if(pcm1_filenames!=null){
					IEnumerator proc1=ReadPZIData(pcm1_filenames);
					yield return StartCoroutine(proc1);
					if(proc1.Current!=null){
						bgmdata.pzi_tbl[0]=(PZIDATA)proc1.Current;
					}
				}
				//
				//Debug.Log("------------------------------------------------ 02");
				if(pcm2_filenames!=null){
					IEnumerator proc2=ReadPZIData(pcm2_filenames);
					yield return StartCoroutine(proc2);
					if(proc2.Current!=null){
						bgmdata.pzi_tbl[1]=(PZIDATA)proc2.Current;
					}
				}
				
				yield return bgmdata;
			}
		}
	}
	public IEnumerator ReadPZIData(string[] filenames){
		PZIDATA pzidata=null;
		for(int i=0;i<filenames.Length;i++){
			string filename=filenames[i];
			IEnumerator proc=ReadPZIData(filename);
			yield return StartCoroutine(proc);
			if(proc.Current==null){
			}else{
				Debug.Log("ReadPZIData OK:"+filename);
				pzidata=(PZIDATA)proc.Current;
				break;
			}
		}
		yield return pzidata;
	}
	public IEnumerator ReadPZIData(string filename){
		IEnumerator proc=ReadBinary(filename);
		yield return StartCoroutine(proc);
		if(proc.Current==null){
			yield return null;
		}else{
			PZIDATA pzidata=PZIDecoder.decode((byte[])proc.Current);
			if(pzidata==null){
				yield return null;
			}else{
				yield return pzidata;
			}
		}
	}
	public IEnumerator ReadBinary(string filename){
		//Debug.Log("ReadBinary:001:"+filename);
		UnityWebRequest www = UnityWebRequest.Get(filename);
		yield return www.SendWebRequest();
		if(www.isNetworkError || www.isHttpError) {
			Debug.Log("ReadBinary:GetBinary Error !!:"+www.error);
			yield return null;
		}else{
			// 結果をテキストとして表示します
			//Debug.Log("GetBinary Error !!:"+www.downloadHandler.text);
			//  または、結果をバイナリデータとして取得します
			byte[] results = www.downloadHandler.data;
			yield return results;
		}
		//Debug.Log("ReadBinary:GetBinary End:"+filename);
	}
	public void stopMDZ(){
		mdz_player.stopMDZ();
	}
	public bool playMDZByBgmData(MDZ_BGMDATA bgmdata){
		return mdz_player.playMDZByBgmData(bgmdata);
	}
	public void setSoutaiTempo(int _soutai_tempo){
		mdz_player.setSoutaiTempo(_soutai_tempo);
	}
	public int getSoutaiTempo(){
		return mdz_player.getSoutaiTempo();
	}
	public void ToggleCnlMask(int cnl){
		mdz_player.ToggleCnlMask(cnl);
	}
	public bool getCnlMask(int cnl){
		return mdz_player.getCnlMask(cnl);
	}
	public void setCnlMask(int cnl,bool mask){
		mdz_player.setCnlMask(cnl,mask);
	}
	public void playPZI(int cnl,PZIDATA _pzidata,int index,float _vol,float _pan,float _note){
		mdz_player.playPZI(cnl,_pzidata,index,_vol,_pan,_note);
	}
	public float[] getPcmWindow(){
		return mdz_player.getPcmWindow();
	}
	public string getMDZFilename(){
		return mdz_player.getMDZFilename();
	}
	public string getPZIFilename(int i){
		return mdz_player.getPZIFilename(i);
	}
	public string getComment(){
		return mdz_player.getComment();
	}
	public int getTempo(){
		return mdz_player.getTempo();
	}
	public int getBaseCount(){
		return mdz_player.getBaseCount();
	}
	
}

