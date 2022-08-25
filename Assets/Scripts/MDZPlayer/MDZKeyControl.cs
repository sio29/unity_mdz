/******************************************************************************
;	
******************************************************************************/
using UnityEngine;
using System.IO;
using System;
using ulib.usound;

public class MDZKeyControl : MonoBehaviour
{
	private int index_add=0;
	private int bgm_index=1;
	private int soutai_tempo=0;
	private MDZPlayerComponent mdz_player;
	private PZIDATA pzidata;
	
	void Awake() {
		//Debug.Log("MDZKeyControl Awake");
		
		findMDZPlayerComponent();
	}
	void findMDZPlayerComponent(){
		GameObject mdz_player_obj=GameObject.Find("MDZPlayerObject");
		if(mdz_player_obj){
			mdz_player=mdz_player_obj.GetComponent<MDZPlayerComponent>();
		}
	}
	public string getPath(string path){
		//return Application.dataPath + path;
		return Application.streamingAssetsPath + path;
	}
	void Start(){
		//Debug.Log("MDZKeyControl Start");
		//string pcm_filename=getPath("/data/msw.pzi");
		//string pcm_filename=getPath("/Resources/data/msw.pzi");
		//pzidata=loadPZI(pcm_filename);
		
		playMDZ_MSW(1);
	}
	public bool playMDZ_MSW(int index){
		if(!mdz_player)return false;
		//string bgm_filename=getPath(String.Format("/data/msw_p{0:00}.mdz",index));
		string bgm_filename=getPath(String.Format("/Resources/data/msw_p{0:00}.mdz",index));
		return playMDZ(bgm_filename);
	}
	public bool playMDZ(string filename){
		if(!mdz_player)return false;
		return mdz_player.playMDZ(filename);
	}
	public void play(int index){
		if(!mdz_player)return;
		if(pzidata==null)return;
		int cnl=0;
		float vol =1.0f;
		float pan =0.0f;
		float note=1.0f;
		mdz_player.playPZI(cnl,pzidata,index,vol,pan,note);
	}
	public void setSoutaiTempo(int _soutai_tempo){
		if(!mdz_player)return;
		mdz_player.setSoutaiTempo(_soutai_tempo);
	}
	public void ToggleCnlMask(int cnl){
		if(!mdz_player)return;
		mdz_player.ToggleCnlMask(cnl);
	}
	public PZIDATA loadPZI(string path){
		if(!mdz_player)return null;
		return mdz_player.loadPZI(path);
	}
	public void stopMDZ(){
		if(!mdz_player)return;
		mdz_player.stopMDZ();
	}
	public void setFastPlay(bool n){
		if(n){
			setSoutaiTempo(200);
		}else{
			setSoutaiTempo(soutai_tempo);
		}
	}
	public void nextPlay(){
		bgm_index++;
		if(bgm_index>12)bgm_index=1;
		playMDZ_MSW(bgm_index);
	}
	public void prevPlay(){
		bgm_index--;
		if(bgm_index<1)bgm_index=12;
		playMDZ_MSW(bgm_index);
	}
	public void playCurrent(){
		playMDZ_MSW(bgm_index);
	}
	
	
	void Update(){
		if(Input.GetKeyDown("1")){
			ToggleCnlMask(0);
		}
		if(Input.GetKeyDown("2")){
			ToggleCnlMask(1);
		}
		if(Input.GetKeyDown("3")){
			ToggleCnlMask(2);
		}
		if(Input.GetKeyDown("4")){
			ToggleCnlMask(3);
		}
		if(Input.GetKeyDown("5")){
			ToggleCnlMask(4);
		}
		if(Input.GetKeyDown("6")){
			ToggleCnlMask(5);
		}
		if(Input.GetKeyDown("7")){
			ToggleCnlMask(6);
		}
		if(Input.GetKeyDown("8")){
			ToggleCnlMask(7);
		}
		
		/*
		if(Input.GetKeyDown("0")){
			int index=index_add+0;
			play(index);
		}
		if(Input.GetKeyDown("1")){
			int index=index_add+1;
			play(index);
		}
		if(Input.GetKeyDown("2")){
			int index=index_add+2;
			play(index);
		}
		if(Input.GetKeyDown("3")){
			int index=index_add+3;
			play(index);
		}
		if(Input.GetKeyDown("4")){
			int index=index_add+4;
			play(index);
		}
		if(Input.GetKeyDown("5")){
			int index=index_add+5;
			play(index);
		}
		if(Input.GetKeyDown("6")){
			int index=index_add+6;
			play(index);
		}
		if(Input.GetKeyDown("7")){
			int index=index_add+7;
			play(index);
		}
		if(Input.GetKeyDown("8")){
			int index=index_add+8;
			play(index);
		}
		if(Input.GetKeyDown("9")){
			int index=index_add+9;
			play(index);
		}
		if(Input.GetKeyDown(KeyCode.F1)){
			ToggleCnlMask(0);
		}
		if(Input.GetKeyDown(KeyCode.F2)){
			ToggleCnlMask(1);
		}
		if(Input.GetKeyDown(KeyCode.F3)){
			ToggleCnlMask(2);
		}
		if(Input.GetKeyDown(KeyCode.F4)){
			ToggleCnlMask(3);
		}
		if(Input.GetKeyDown(KeyCode.F5)){
			ToggleCnlMask(4);
		}
		if(Input.GetKeyDown(KeyCode.F6)){
			ToggleCnlMask(5);
		}
		if(Input.GetKeyDown(KeyCode.F7)){
			ToggleCnlMask(6);
		}
		if(Input.GetKeyDown(KeyCode.F8)){
			ToggleCnlMask(7);
		}
		*/
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			index_add+=10;
			if(index_add>100)index_add=100;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			index_add-=10;
			if(index_add<0)index_add=0;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			soutai_tempo++;
			setSoutaiTempo(soutai_tempo);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			soutai_tempo--;
			setSoutaiTempo(soutai_tempo);
		}
		if(Input.GetKeyDown(KeyCode.Home)){
			soutai_tempo=0;
			setSoutaiTempo(soutai_tempo);
		}
		if(Input.GetKeyDown(KeyCode.End)){
			setSoutaiTempo(200);
		}
		if(Input.GetKeyUp(KeyCode.End)){
			setSoutaiTempo(soutai_tempo);
		}
		if(Input.GetKeyDown(KeyCode.PageUp)){
			bgm_index++;
			if(bgm_index>12)bgm_index=1;
			playMDZ_MSW(bgm_index);
		}
		if(Input.GetKeyDown(KeyCode.PageDown)){
			bgm_index--;
			if(bgm_index<1)bgm_index=12;
			playMDZ_MSW(bgm_index);
		}
		
		if(Input.GetKeyDown(KeyCode.P)){
			playMDZ_MSW(bgm_index);
		}
		if(Input.GetKeyDown(KeyCode.S)){
			stopMDZ();
		}
		/*
		if(Input.GetKeyDown("space")){
			int index=5;
			play(index);
		}
		*/
	}
}
