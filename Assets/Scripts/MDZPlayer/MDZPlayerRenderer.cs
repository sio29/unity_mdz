/******************************************************************************
;	
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using ulib.usound;

public class MDZPlayerRenderer : MonoBehaviour
{
	static readonly int LEVELMETER_MX=20;
	static readonly int LEVELMETER_MY=4;
	static readonly int LEVELMETER_MMX=24;
	static readonly int LEVELMETER_MMY=8;
	private MDZPlayerComponent mdz_player;
	private MDZKeyControl mdz_keycontrol;
	private Texture aTexture;
	private Color col_levmater_g0=new Color(0,0.5f,0);
	private Color col_levmater_g1=new Color(0,1.0f,0);
	private Color col_levmater_gm=new Color(0.1f,0.3f,0.1f);
	private Color col_levmater_r0=new Color(0.5f,0,0);
	private Color col_levmater_r1=new Color(1.0f,0,0);
	private Color col_levmater_rm=new Color(0.3f,0.1f,0.1f);
	
	private Dictionary<int,Texture> coltex_map=new Dictionary<int,Texture>();
	private float[] vol_tbl=new float[32];
	private bool[] mask_tbl=new bool[32];
	private Texture2D tex_pcmwindow;
	private byte[] img_pcmwindow;
	private int pcm_tex_width =256;
	private int pcm_tex_height=128;
	
	// Start is called before the first frame update
	void Start(){
		findMDZPlayerComponent();
		
		tex_pcmwindow=new Texture2D(pcm_tex_width,pcm_tex_height);
		img_pcmwindow=new byte[pcm_tex_width*pcm_tex_height*4];
		
		var texture = new Texture2D(1, 1);
		texture.SetPixel(0, 0, Color.white);
		texture.Apply();
		aTexture = texture;
	}
	void findMDZPlayerComponent(){
		GameObject mdz_player_obj=GameObject.Find("MDZPlayerObject");
		if(mdz_player_obj){
			mdz_player=mdz_player_obj.GetComponent<MDZPlayerComponent>();
		}
		GameObject mdz_key_obj=GameObject.Find("MDZKeyObject");
		if(mdz_key_obj){
			mdz_keycontrol=mdz_key_obj.GetComponent<MDZKeyControl>();
		}
	}
	// Update is called once per frame
	void Update(){
		float delta_time=Time.deltaTime;
		float frame_speed=delta_time/(1.0f/60.0f);
		//
		MDZDRV.MDZ_WORK mdzwork=mdz_player.getMDZWork();
		for(int i=0;i<8;i++){
			MDZDRV.MDZ_CNL cnl=mdzwork.bgm[i];
			int vol=cnl.vol / 4;
			if(cnl.state.mask){
				vol_tbl[i]=0;
				mask_tbl[i]=true;
			}else{
				mask_tbl[i]=false;
				if(cnl.state.kon){
					vol_tbl[i]=vol;
				}else{
					vol_tbl[i]-=(0.1f*frame_speed);
					if(vol_tbl[i]<0.0f){
						vol_tbl[i]=0.0f;
					}
				}
			}
		}
		float[] pcm_window=mdz_player.getPcmWindow();
		for(int i=0;i<pcm_tex_width*pcm_tex_height;i++){
			img_pcmwindow[i*4+0]=64;
			img_pcmwindow[i*4+1]=64;
			img_pcmwindow[i*4+2]=64;
			img_pcmwindow[i*4+3]=255;
		}
		float scale=2.0f;
		for(int cnl=0;cnl<2;cnl++){
			int hh=pcm_tex_height/2;
			int hh2=hh/2;
			for(int i=0;i<pcm_tex_width;i++){
				float d=pcm_window[i*2+cnl];
				d*=scale;
				int y=(int)(d*hh2)+hh2;
				if(y<0)y=0;
				if(y>(hh-1))y=(hh-1);
				y+=(cnl*hh);
				//tex_pcmwindow.SetPixel(i,y, Color.red);
				img_pcmwindow[(y*pcm_tex_width+i)*4+0]=255;
				img_pcmwindow[(y*pcm_tex_width+i)*4+1]=255;
				img_pcmwindow[(y*pcm_tex_width+i)*4+2]=255;
				img_pcmwindow[(y*pcm_tex_width+i)*4+3]=255;
			}
		}
		tex_pcmwindow.SetPixelData(img_pcmwindow,0,0);
		tex_pcmwindow.Apply();
		
	}
	private bool fast_flg=false;
	void OnGUI () {
		float x=10.0f;
		float y=10.0f;
		string filename="---";
		string comment="---";
		string pcm1_file="---";
		string pcm2_file="---";
		int tempo=0;
		int base_cnt=0;
		filename=mdz_player.getMDZFilename();
		//comment=mdz_player.getComment();
		tempo=mdz_player.getTempo();
		base_cnt=mdz_player.getBaseCount();
		pcm1_file=mdz_player.getPZIFilename(0);
		pcm2_file=mdz_player.getPZIFilename(1);
		if(filename==null){
			filename="---";
		}else{
			filename=Path.GetFileName(filename);
		}
		if(comment==null)comment="---";
		if(pcm1_file==null)pcm1_file="---";
		if(pcm2_file==null)pcm2_file="---";
		
		//GUIStyle style  = new GUIStyle();
		//style.fonSize=24;
		
		//GUILayout.BeginArea(new Rect(0,0,640,480));
		
		//drawRect(new Rect(0,0,640,480),new Color(0,0,0,0.5f));
		drawRect(new Rect(0,0,512,360),new Color(0,0,0,0.5f));
		
		
		//GUI.Label(new Rect(x,y,1024,64), "filename:"+filename,style);
		GUI.Label(new Rect(x,y,1024,64), "filename:"+filename);
		y+=16.0f;
		GUI.Label(new Rect(x,y,1024,32), "comment:"+comment);
		y+=16.0f;
		GUI.Label(new Rect(x,y,1024,32), "pcm1:"+pcm1_file+" pcm2:"+pcm2_file);
		y+=16.0f;
		GUI.Label(new Rect(x,y,1024,32), "Base("+base_cnt+"),Temop("+tempo+")");
		y+=16.0f;
		
		drawLevelMeters(x,y);
		
		GUI.DrawTexture(new Rect(x+224,y-64,256,256), tex_pcmwindow, ScaleMode.ScaleToFit, true, (float)pcm_tex_width/(float)pcm_tex_height);
		
		
		y+=32.0f;
		y+=144.0f;
		/*
		if(GUI.Button(new Rect(x,y,50, 30), "‘‘—‚è")){
			mdz_keycontrol.setFastPlay(true);
		}else{
			mdz_keycontrol.setFastPlay(false);
		}
		*/
		
		float xx=x;
		//
		//fast_flg=GUI.Toggle(new Rect(xx,y,80, 30),fast_flg,"‘‘—‚è");
		//if(fast_flg){
		if(GUI.Button(new Rect(xx,y,80, 30),"Stop") ){
			mdz_keycontrol.stopMDZ();
		}
		xx+=100.0f;
		if(GUI.Button(new Rect(xx,y,80, 30),"Play") ){
			mdz_keycontrol.playCurrent();
		}
		xx+=100.0f;
		if(GUI.RepeatButton(new Rect(xx,y,80, 30),"Fast") ){
			mdz_keycontrol.setFastPlay(true);
		}else{
			mdz_keycontrol.setFastPlay(false);
		}
		xx+=100.0f;
		if(GUI.Button(new Rect(xx,y,80, 30), "Prev")){
			mdz_keycontrol.prevPlay();
		}
		xx+=100.0f;
		if(GUI.Button(new Rect(xx,y,80, 30), "Next")){
			mdz_keycontrol.nextPlay();
		}
		
		
		
		
		y+=32.0f;
		if(mdz_player.getSoutaiTempo()>0){
			GUI.Label(new Rect(x,y,100,100), ">>>");
		}
		
		
		//GUILayout.EndArea();
		
	}
	
	
	void drawRect(Rect rect,Color col){
		float aspect=rect.width/rect.height;
		GUI.DrawTexture(rect,getColorTexture(col), ScaleMode.ScaleToFit, true, aspect);
	}
	int getColorKey(Color col){
		int r=(int)(col.r*255.0f) & 0xff;
		int g=(int)(col.g*255.0f) & 0xff;
		int b=(int)(col.b*255.0f) & 0xff;
		int a=(int)(col.a*255.0f) & 0xff;
		int n=(a << 24) | (r << 16) | (g << 8) | b;
		return n;
	}
	Texture getColorTexture(Color col){
		int ck=getColorKey(col);
		Texture tex;
		if(coltex_map.ContainsKey(ck)){
			tex=coltex_map[ck];
		}else{
			tex=makeColorTexture(col);
			coltex_map.Add(ck,tex);
		}
		return tex;
	}
	Texture makeColorTexture(Color col){
		var texture = new Texture2D(1, 1);
		texture.SetPixel(0, 0, col);
		texture.Apply();
		return texture;
	}
	void drawLevelMeters(float x,float y){
		for(int i=0;i<8;i++){
			drawLevelMeter(i,x,y,(int)vol_tbl[i],mask_tbl[i]);
			x+=LEVELMETER_MMX;
		}
	}
	void drawLevelMeterOne(float x,float y,Color col){
		drawRect(new Rect(x,y,LEVELMETER_MX,LEVELMETER_MY),col);
	}
	void drawLevelMeter(int index,float x,float y,int vol,bool mask){
		int vol_max=16;
		int vol_max2=vol_max-4;
		y+=vol_max*(LEVELMETER_MMY);
		float yy=y;
		Color col;
		for(int i=0;i<vol_max;i++){
			if(i<vol_max2){
				if(mask){
					col=col_levmater_gm;
				}else{
					if(vol<i){
						col=col_levmater_g0;
					}else{
						col=col_levmater_g1;
					}
				}
			}else{
				if(mask){
					col=col_levmater_rm;
				}else{
					if(vol<i){
						col=col_levmater_r0;
					}else{
						col=col_levmater_r1;
					}
				}
			}
			drawLevelMeterOne(x,y,col);
			y-=LEVELMETER_MMY;
		}
		y=yy;
		y+=8;
		bool mask_flg=!mdz_player.getCnlMask(index);
		mask_flg=GUI.Toggle(new Rect(x,y,28, 30),mask_flg,""+index);
		mdz_player.setCnlMask(index,!mask_flg);
		
	}
}
