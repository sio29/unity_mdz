/*-----------------------------------------------------------------------------
;	MDZドライバー
-----------------------------------------------------------------------------*/
using System;

namespace ulib{
namespace usound{
/******************************************************************************
;	
******************************************************************************/
public class MDZDRV{
/******************************************************************************
;	EQU
******************************************************************************/
public const int BGM_CNL_MAX			=16;			//BGMチャネル数
public const int PZI_BANK_MAX		=4;				//バンク数
//public const int X_N0				=0x80;			//Xn の初期値
//public const int DELTA_N0			=127;			//DELTA_N の初期値
//public const int DEF_PBUFF_VOL		=0x400;			//合成バッファの大きさ
public const int DEF_TEMPO			=120;			//デフォルトテンポ
public const int TEMPO_MIN			=30;
public const int TEMPO_MAX			=1024;
public const int CNL_LOOPSTACK_MAX	=20;			//ループスタック数


public const int ADPCM_VOL_SCALE			=150;
public const int SSG_VOL_SCALE			=85;
public const int RITHM_VOL_SCALE			=110;
public const int SSGPPZ8_VOL_SCALE		=150;

/******************************************************************************
;	PVI&PZIデータフォーマット
******************************************************************************/
//public const  int PZI_TBL_NUM		=128;			//PZIテーブルの数
/*
public const  int PVI_NUM_MAX		=0x0B;		//PVIデータの定義数
public const  int PVI_TBL_NUM		=128;			//PVIテーブル数
public const  int PVI_TBL_TOP		=0x010;		//PVIテーブルの先頭
public const  int PVI_DATA_TOP		=0x210;		//ADPCMデータの先頭
public const  int PVIT_WORK_ONE		=4;			//

public const  int PZI_NUM_MAX		=0x0B;		//PZIデータの定義数
public const  int PZI_TBL_TOP		=0x020;		//PZIテーブルの先頭
public const  int PZI_DATA_TOP		=0x920;		//PCMデータの先頭

public const  int PZIT_START			=0x00;		//
public const  int PZIT_END			=0x04;		//
public const  int PZIT_LOOP_START	=0x08;		//
public const  int PZIT_LOOP_END		=0x0C;		//
public const  int PZIT_RATE			=0x10;		//
public const  int PZIT_WORK_ONE		=0x12;		//PZI_TBLサイズ

public const  int PZIL_START			=0;			//
public const  int PZIL_END			=4;			//
public const  int PZIL_WORK_ONE		=8;			//PZI_LOOPサイズ
public const  int PZIL_WORK_SIZE		=(PZIL_WORK_ONE*PZI_TBL_NUM);	//ループテーブル
/******************************************************************************
;		ステータスのフラグ
******************************************************************************/
/*
//ステータス
//					FEDCBA9876543210FEDCBA9876543210
public const int TAI_F		=0x00000001;	//00000000000000000000000000000001 タイ
public const int TAI_F2		=0x00000002;	//00000000000000000000000000000010 タイ2
public const int STOP_F		=0x00000004;	//00000000000000000000000000000100 停止
public const int REST_F		=0x00000008;	//00000000000000000000000000001000 休符
public const int KON_F		=0x00000010;	//00000000000000000000000000010000 キーオン
public const int KOFF_F		=0x00000020;	//00000000000000000000000000100000 キーオフ
public const int START_F		=0x00000040;	//00000000000000000000000001000000 スタート
public const int VEND_F		=0x00000080;	//00000000000000000000000010000000 ベンド
public const int PLFO_F		=0x00000100;	//00000000000000000000000100000000 P_LFO
public const int QLFO_F		=0x00000200;	//00000000000000000000001000000000 Q_LFO
public const int RLFO_F		=0x00000400;	//00000000000000000000010000000000 R_LFO
public const int ALFO_F		=0x00000800;	//00000000000000000000100000000000 A_LFO
public const int HLFO_F		=0x00001000;	//00000000000000000001000000000000 H_LFO
public const int KON_R_F		=0x00002000;	//00000000000000000010000000000000 キーオン
public const int SURA_F		=0x00004000;	//00000000000000000100000000000000 スラー
public const int SURA_F2		=0x00008000;	//00000000000000001000000000000000 スラー２
public const int APAN_F		=0x00010000;	//00000000000000010000000000000000 APAN
public const int AR_F		=0x00020000;	//00000000000000100000000000000000 AR
public const int DR_F		=0x00040000;	//00000000000001000000000000000000 DR
public const int SR_F		=0x00080000;	//00000000000010000000000000000000 SR
public const int REST_OFF_F	=0x00100000;	//00000000000100000000000000000000 REST_OFF
public const int ONELOOP_F	=0x00200000;	//00000000001000000000000000000000 1周した
*/
/******************************************************************************
;		チャネルごとのワーク
******************************************************************************/
/*
public const int P_LOOP_STACK	=0;			//20byte ループスタック
public const int P_LOOP_ADR		=20;		//4byte  ループスタックのアドレス
public const int P_DATA_ADR		=24;		//4byte  データアドレス
public const int P_PCM_WORK		=28;		//4byte  PCMワークアドレス
public const int P_STATE			=32;		//4byte  ステータス
public const int P_DEF_LEN		=36;		//2byte  デフォルトの音長
public const int P_LEN_WK		=38;		//2byte  音長のカウンタ
public const int P_WAVE			=40;		//2byte  現在の周波数
public const int P_BEFORE_WAVE	=42;		//2byte  前の周波数
public const int P_QUOTA_WK		=44;		//2byte  ゲートタイムカウンタ
public const int P_DETUNE		=46;		//2byte  ディチューン
public const int P_CNL_NUMBER	=48;		//1byte  チャネル番号
public const int P_QUOTA			=49;		//1byte  ゲートタイム
public const int P_NOW_ONTEI		=50;		//1byte  現在の音程
public const int P_BEFORE_ONTEI	=51;		//1byte  前の音程
public const int P_VOL			=52;		//1byte  ボリューム
public const int P_BEFORE_VOL	=53;		//1byte  前の音量
public const int P_SOUTAI_ICHO	=54;		//1byte  相対移調の値
public const int P_PAN			=55;		//1byte  PAN
public const int P_OTO_NUM		=56;		//1byte  音色番号
public const int P_OTO_BANK		=57;		//1byte  バンク番号
public const int P_PLFO			=58;		//12byte
public const int P_QLFO			=70;		//12byte
public const int P_RLFO			=82;		//12byte
public const int P_VEND			=94;		// 8byte
public const int P_ENV			=102;		// 8byte
public const int P_APAN			=110;		//12byte
public const int P_PCM_START		=122;		//4byte
public const int P_PCM_END		=126;		//4byte
public const int P_PCM_LOOP		=130;		//4byte
public const int P_PCM_LOOPFLG	=134;		//1byte
public const int P_PCM_RATE		=136;		//2byte

public const int BGM_WORK_ONE	=160;		//ワークの大きさ
public const int BGM_WORK_SIZE	=(BGM_WORK_ONE*BGM_CNL_MAX);	//
*/
/******************************************************************************
;	LFO,VEND,ENV,APAN関係
******************************************************************************/
/*
public const int LFO_MD			=0;			//	LFOデェレイ
public const int LFO_MD_CNT		=1;			//	LFOデェレイカウンタ
public const int LFO_SPEED		=2;			//	LFOスピード
public const int LFO_SPEED_CNT	=3;			//	LFOスピードカウンタ
public const int LFO_RATE		=4;			//2byte	LFO大きさ
public const int LFO_RATE_SUB	=6;			//2byte	LFO大きさサブ
public const int LFO_DEPTH		=8;			//	LFO深さ
public const int LFO_DEPTH_CNT	=10;		//	LFO深さカウンタ
public const int LFO_WAVE_NUM	=11;		//	LFOの波形番号
public const int LFO_SIZE		=12;		//	LFOのワークの大きさ

public const int VEND_MD_CNT		=P_VEND+0;	//	ピッチベンドのデュレイ
public const int VEND_SPEED		=P_VEND+1;	//	ピッチベンドのスピード
public const int VEND_SPEED_CNT	=P_VEND+2;	//	ピッチベンドのスピードカウンタ
public const int VEND_ONTEI		=P_VEND+3;	//	ピッチベンドの音程
public const int VEND_RATE		=P_VEND+4;	//2byte	ピッチベンドの大きさ
public const int VEND_WAVE		=P_VEND+6;	//2byte	ピッチベンドの目標周波数
public const int VEND_SIZE		=8;			//	ベンドのワークの大きさ

public const int ENV_VOL2		=P_ENV+0;		//	エンベロープ用ボリューム
public const int ENV_SV			=P_ENV+1;		//	エンベロープ用スタートボリュー
public const int ENV_AR			=P_ENV+2;		//	アタックレート
public const int ENV_DR			=P_ENV+3;		//	デュケイレート
public const int ENV_SL			=P_ENV+4;		//	サスティンレベル
public const int ENV_SR			=P_ENV+5;		//	サスティンレート
public const int ENV_RR			=P_ENV+6;		//	リリースレート
public const int ENV_SIZE		=8;				//	エンベロープのワークの大きさ

public const int APAN_MD			=P_APAN+0;	//	デュレイ
public const int APAN_MD_CNT		=P_APAN+1;	//	デュレイ
public const int APAN_SPEED		=P_APAN+2;	//	スピード
public const int APAN_SPEED_CNT	=P_APAN+3;	//	スピードカウンタ
public const int APAN_SORC		=P_APAN+4;	//	PANソース
public const int APAN_DIST		=P_APAN+5;	//	PANディスト
public const int APAN_SORC_W		=P_APAN+6;	//	PANソース
public const int APAN_DIST_W		=P_APAN+7;	//	PANディスト
public const int APAN_NUM		=P_APAN+8;	//	現在のPAN
public const int APAN_ADD		=P_APAN+9;	//	PAN加算方向
public const int APAN_FLG		=P_APAN+10;	//	PANの種類
public const int APAN_SIZE		=12;		//
*/
/******************************************************************************
;	PCMチャネルワーク
******************************************************************************/
/*
public const int PCMW_STATE		=0;		//1byte ステータス
public const int PCMW_VOL		=1;		//1byte 音量
public const int PCMW_PAN		=2;		//1byte パン
public const int PCMW_LOOP_FLG	=3;		//1byte ループフラグ
public const int PCMW_KEYON		=4;		//1byte KEYON_FLG
public const int PCMW_SRC_RATE	=6;		//2byte 元データﾚｰﾄ
public const int PCMW_ADD_L		=8;		//4byte アドレス増加量 LOW
public const int PCMW_ADD_H		=12;		//4byte アドレス増加量 HIGH
public const int PCMW_NOW_XOR	=16;		//4byte 現在のアドレス,小数点部
public const int PCMW_NOW_ADR	=20;		//4byte 現在のアドレス,整数部
public const int PCMW_END_ADR	=24;		//4byte 現在の終了アドレス
public const int PCMW_LOOP_ADR	=28;		//4byte ループ開始アドレス

public const int PCMW_START_ADR	=32;		//4byte

public const int PCMW_WORK_ONE	=36;		//PCMワークサイズ
public const int PCMW_WORK_SIZE	=(PCMW_WORK_ONE*PCM_CNL_MAX);	//チャネル分のPCMワーク
*/
/******************************************************************************
;	BGM情報
******************************************************************************/
/*
public const int BGMR_PCM1_FILE	=0x00;		//;
public const int BGMR_PCM1_CATE	=0x04;		//;
public const int BGMR_PCM2_FILE	=0x08;		//;
public const int BGMR_PCM2_CATE	=0x0C;		//;
public const int BGMR_COMMENT	=0x10;		//;
public const int BGMR_QFLG		=0x14;		//;
public const int BGMR_CNL_NUM	=0x18;		//;
public const int BGMR_BASE_CNT	=0x1C;		//;基本カウンタ
public const int BGMR_WORK_SIZE	=0x20;		//;
*/

/******************************************************************************
;		PCMチャネルワーク
******************************************************************************/
/*
static class MDZ_HEADTBL{
	byte type;							//
	byte cnl;							//
	short off;							//
};
static class MDZHEAD{
	short size;							//
	short size2;						//
	byte[] m=new byte[5];				//
	short ver;							//
	byte[] dummy1=new byte[7];			//
	short qflg;							//0x12 Q
	byte[] dummy2=new byte[8];			//
	short pcm2_name;					//0x1a PCM2の名前
	short comment;						//0x1c コメント
	byte[] dummy3=new byte[6];			//
	short cnl_num;						//0x24 チャネル数
	short pcm1_name;					//0x26 PCM1の名前
	byte[] dummy4=new byte[2];			//
	short pcm1_cate;					//0x2a PCM1のタイプ
	byte[] dummy5=new byte[4];			//
	short pcm1_cate_;					//0x2a
	//
	MDZ_HEADTBL[] tbl=new MDZ_HEADTBL[BGM_CNL_MAX];	//
};
*/


/*
//PZIの一つのデータ
static class PZIT{
	int start;					//開始位置
	int end;					//終了位置
	int loop_start;				//ループ開始位置
	int loop_end;				//ループ終了位置
	int rate;					//元レート
};
//PZIのヘッダー
static class PZIHEAD{
//	byte[] m=new byte[4];						//ヘッダー文字
//	byte[] dummy=new byte[0x20-4];				//ダミー
	PZIT[] tbl=new PZIT[PZI_TBL_NUM];			//音色テーブル
	byte[] pcmdata;
};
*/

//パンテーブル
public static readonly int[] g_ppz_pan_tbl={0,1,9,5};

//FM音源の音程テーブル(618,1272,2.05825)
public static readonly int[] fm_ontei_tbl={
	0x026A,0x028F,0x02B6,0x02DF,0x030B,0x0339,
	0x036A,0x039E,0x03D5,0x0410,0x044E,0x048F
};
//SSGの音程テーブル(3816,2022,1.8872403560830860534124629080119)
public static readonly int[] ssg_ontei_tbl={
	0x0EE8,0x0E12,0x0D48,0x0C89,0x0BD5,0x0B2B,
	0x0A8A,0x09F3,0x0964,0x08DD,0x085E,0x07E6
};
//ADPCMの音程テーブル
public static readonly int[] adpcm_ontei_tbl={
	0x0000,0x0463,0x0909,0x0DF6,0x132D,0x1864,	//o1
	0x1E8A,0x24BD,0x2B4E,0x3244,0x39A3,0x4173,
	0x49BA,0x527E,0x5BC8,0x65A0,0x700D,0x7b19,	//o2
	0x86CC,0x9336,0xA057,0xAE42,0xBD01,0xCCA2,
	0xC8B4,0xC9CC,0xCAF5,0xCC30,0xCD7E,0xCEDF,	//o3
	0xD056,0xD1E3,0xD387,0xD544,0xD71C,0xD911,
	0xDB22,0xDD53,0xDFA6,0xE21C,0xE4B7,0xE777,	//o4
	0xEA65,0xED7F,0xF0C8,0xF443,0xF7F4,0xFBDC,
	0x0000,0x0463,0x0909,0x0DF6,0x132D,0x1864,	//o5
	0x1E8A,0x24BD,0x2B4E,0x3244,0x39A3,0x4173,
	0x49BA,0x527E,0x5BC8,0x65A0,0x700D,0x7b19,	//o6
	0x86CC,0x9336,0xA057,0xAE42,0xBD01,0xCCA2,
	0xC8B4,0xC9CC,0xCAF5,0xCC30,0xCD7E,0xCEDF,	//o7
	0xD056,0xD1E3,0xD387,0xD544,0xD71C,0xD911,
};
//音程テーブル
public static readonly int[] ppz8_ontei_tbl=new int[]{
	0x8000,		//00 c
	0x87A6,		//01 d-
	0x8FB3,		//02 d
	0x9838,		//03 e-
	0xA146,		//04 e
	0xAADE,		//05 f
	0xB4FF,		//06 g-
	0xBFCC,		//07 g
	0xCB34,		//08 a-
	0xD747,		//09 a
	0xE418,		//10 b-
	0xF1A5		//11 b	(1.887847900390625)
};

//FM音源の音量テーブル
public static readonly int[] fm_vol_tbl={
	0x38,0x34,0x30,0x2A,0x28,0x25,0x22,0x20,
	0x1D,0x1A,0x18,0x15,0x12,0x10,0x0D,0x09,
};
//SSGのミキサー出力データ作成テーブル
public static readonly int[] ssg_mixer_tbl={
	0x09,	//00001001B,	//0 NONE
	0x08,	//00001000B,	//1 TONE
	0x01,	//00000001B,	//2 NOISE
	0x00,	//00000000B,	//3 TONE+NOISE
};
public static readonly int[] ssg_mixer_mask={
	0xf6,	//(1111_0110B)
	0xed,	//(1110_1101B)
	0xdb,	//(1101_1011B)
};
//FM音源のアルゴリズムテーブル
public static readonly int[] fm_alg_tbl={
	0x08,	//00001000B,	//0
	0x08,	//00001000B,	//1
	0x08,	//00001000B,	//2
	0x08,	//00001000B,	//3
	0x0c,	//00001100B,	//4
	0x0e,	//00001110B,	//5
	0x0e,	//00001110B,	//6
	0x0f,	//00001111B,	//7
};

public static readonly int[] adpcm_em_vol={
//	 0  1  2  3  4  5  6  7  8  9  a  b  c  d  e  f
	 0, 0, 0, 0, 0, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4,	//00
	 4, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6,	//10
	 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,	//20
	 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,	//30
	 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,	//40
	 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,	//50
	10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,	//60
	10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,	//70
	10,10,10,10,10,10,10,10,11,11,11,11,11,11,11,11,	//80
	11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,	//90
	11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,	//a0
	11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,	//b0
	12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,	//c0
	12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,	//d0
	12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,	//e0
	12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,	//f0
};

public static readonly int[] g_spb_pan_tbl={0,2,1,3};		//SPBのPAN補正


//ループテーブル
public class PZILT{
	public int start;						//
	public int end;						//
	//
	public void Init(){
		start=-1;
		end  =-1;
	}
};
public class PZIL{
	public PZILT[] tbl;
	
	public PZIL(int tbl_num){
		Init(tbl_num);
	}
	public void Init(int tbl_num){
		tbl=new PZILT[tbl_num];
		for(int i=0;i<tbl.Length;i++){
			tbl[i]=new PZILT();
			tbl[i].Init();
		}
	}
};
//PCM作成のパラメータ
public class MDZ_MakePara{
	public int loopadr;			//ループアドレス
	public int endadr;				//終了アドレス
	public int nowsize;			//現在のサイズ
	public bool play_flg;		//再生終了フラグ
};
/******************************************************************************
;	BGMチャンネルワーク
******************************************************************************/
//チャンネルフラグ
public class MDZ_CNLFLG{
	public bool tai;			//タイ
	public bool tai2;		//タイ2
	public bool stop;		//停止
	public bool rest;		//休符
	public bool kon;			//キーオン
	public bool koff;		//キーオフ
	public bool start;		//スタート
	public bool vend;		//ベンド
	public bool[] lfo=new bool[3]; //P,Q,R LFO
	public bool alfo;		//A_LFO
	public bool hlfo;		//H_LFO
	public bool kon_r;		//キーオン
	public bool sura;		//スラー
	public bool sura2;		//スラー２
	public bool apan;		//APAN
	public bool rest_off;	//REST_OFF
	public bool oneloop;	//1周した
	public bool onteiout;	//
	public bool mask;		//チャネルマスク
	//
	public void Init(){
		tai=false;			//タイ
		tai2=false;			//タイ2
		stop=true;			//停止
		rest=false;			//休符
		kon=false;			//キーオン
		koff=false;			//キーオフ
		start=false;		//スタート
		vend=false;			//ベンド
		for(int i=0;i<lfo.Length;i++){
			lfo[i]=false;
		}
		alfo=false;			//A_LFO
		hlfo=false;			//H_LFO
		kon_r=false;		//キーオン
		sura=false;			//スラー
		sura2=false;		//スラー２
		apan=false;			//APAN
		rest_off=false;		//REST_OFF
		oneloop=false;		//1周した
		mask=false;			//
	}
};
//LFO
public class MDZ_LFO{
	public int md;				//LFOデェレイ
	public int md_cnt;			//LFOデェレイカウンタ
	public int speed;			//LFOスピード
	public int speed_cnt;		//LFOスピードカウンタ
	public int rate;			//LFO大きさ
	public int rate_sub;		//LFO大きさサブ
	public int depth;			//LFO深さ
	public int depth_cnt;		//LFO深さカウンタ
	public int wave_num;		//LFOの波形番号
	//
	public void Init(){
		md=0;
		md_cnt=0;
	}
};
public class MDZ_ALFO{
}
public class MDZ_HLFO{
}
//VEND
public class MDZ_VEND{
	public int md_cnt;			//ピッチベンドのデュレイ
	public int speed;			//ピッチベンドのスピード
	public int speed_cnt;		//ピッチベンドのスピードカウンタ
	public int ontei;			//ピッチベンドの音程
	public int rate;			//ピッチベンドの大きさ
	public int wave;			//ピッチベンドの目標周波数
	public int oct_wk;			//
	//
	public void Init(){
		md_cnt=0;
	}
};
//ENV
public class MDZ_ENVFLG{
	public bool ar;			//AR
	public bool dr;			//DR
	public bool sr;			//SR
};
public class MDZ_ENV{
	public MDZ_ENVFLG flg=new MDZ_ENVFLG();
	public int vol2;			//エンベロープ用ボリューム
	public int sv;				//エンベロープ用スタートボリュー
	public int ar;				//アタックレート
	public int dr;				//デュケイレート
	public int sl;				//サスティンレベル
	public int sr;				//サスティンレート
	public int rr;				//リリースレート
	//
	public void Init(){
		flg.ar=false;
		flg.dr=false;
		flg.sr=false;
		vol2=0;
		sv=0xff;				//SV
		ar=0xff;				//AR
		dr=0xff;				//DR
		sl=0xff;				//SL
		sr=0;					//SR
		rr=0xff;				//RR
	}
};
//オートPAN
public class MDZ_APAN{
	public int md;				//デュレイ
	public int md_cnt;			//デュレイ
	public int speed;			//スピード
	public int speed_cnt;		//スピードカウンタ
	public int sorc;			//PANソース
	public int dist;			//PANディスト
	public int sorc_w;			//PANソース
	public int dist_w;			//PANディスト
	public int num;				//現在のPAN
	public int add;				//PAN加算方向
	public int flg;				//PANの種類
	//
	public void Init(){
		md=0;
		md_cnt=0;
	}
};
//キーオン時PCM登録用ワーク
public class MDZ_PCMTone{
	public int start;			//スタート
	public int end;				//エンド
	public int loop;			//ループ
	public int loopflg;			//ループフラグ
	public int rate;			//レート
	public byte[] data;			//
	public int src_bit=8;
	public int src_cnl=1;
	public int index;
	//
	public void Init(){
		start=0;
		end  =0;
		data =null;
		index=-1;
		loop =-1;
		loopflg=0;
	}
	
	public void setPcmTone(PZIDATATBL pzit,PZILT pzilt){
		this.rate   =pzit.rate;
		this.start  =pzit.start;
		this.end    =pzit.end;
		this.data   =pzit.wave;
		this.src_bit=pzit.bit;
		this.src_cnl=pzit.cnl;
		bool lp_flg=false;
		if(pzilt!=null){
			if(pzilt.start!=-1 || pzilt.end!=-1){
				lp_flg=true;
			}
		}
		
		//if(pzilt.start==-1 && pzilt.end==-1){
		if(!lp_flg){
		//ループしない場合
			this.loopflg=0;
			this.loop   =-1;
		}else{
		//ループする場合
			this.loopflg=1;
			//ループ開始位置のｸﾘｯﾋﾟﾝｸﾞ
			int loop=pzit.start+pzilt.start;
			if(loop>=pzit.end){
				loop=pzit.end-1;
			}
			this.loop=loop;
			//ループ終了位置のｸﾘｯﾋﾟﾝｸﾞ
			int end=pzit.start+pzilt.end;
			if(end>pzit.end){
				end=pzit.end;
			}
			if(end<=this.loop){
				end=this.loop+1;
			}
			this.end=end;
		}
	}
	
	
};
/*
LOOP_STACK		EQU	00	;20byte	ループスタック
LOOP_ADR		EQU	20	;2byte	現在のループスタックアドレス
DAT_ADR			EQU	22	;2byte	現在のデータアドレス
STATE			EQU	24	;2byte	ステータス
DEF_LEN			EQU	26	;2byte	デフォルトの音長
LEN_WK			EQU	28	;2byte	レングスカウンタ
WAVE			EQU	30	;4byte	現在の周波数
BEFORE_WAVE		EQU	34	;4byte	前の周波数
QUOTA_WK		EQU	36	;2byte	Ｑカウンタ
DETUNE			EQU	40	;2byte	ディテューン
CNL_CATE		EQU	42	;	チャネルの種類
CNL_NUMBER		EQU	43	;	チャネル番号
CNL_PORT_NUM	EQU	44	;	アクセスするポート番号
QUOTA			EQU	45	;	Ｑ
OCT_WK			EQU	46	;	現在のオクターブ
NOW_ONTEI		EQU	47	;	現在の音程
BEFORE_ONTEI	EQU	48	;	前の音程
VOL				EQU	49	;	ボリューム
BEFORE_VOL		EQU	50	;	前の音量
SOUTAI_ICHO		EQU	51	;	相対移調の値
PAN				EQU	52	;	ＰＡＮ
OTO_NUM			EQU	53	;	音色番号
STATE2			EQU	54	;2byte	ステータス２
REST_OFF_FLG	EQU	56	;	休符でキーオフするか

;拡張
PLFO			EQU	60	;12byte	LFO1
QLFO			EQU	72	;12byte	LFO2
RLFO			EQU	84	;12byte	LFO3
VEND			EQU	96	;08byte	VEND

;FM音源ワーク
ALFO			EQU	104	;08byte	LFOA
HLFO			EQU	112	;00byte	LFOH
FM_NOW_OTO		EQU	112	;2byte	FM音源の現在の音色アドレス
FM_CNL_NUMBER	EQU	114	;	FM音源の番号
ALG				EQU	115	;	アルゴリズム
;SSGワーク
ENV				EQU	104	;08byte ENV
;リズムワーク
RT_VOL			EQU	60	;6byte	リズムのボリューム
;PCMワーク
PCM_START_ADR	EQU	104	;2byte	PCMの開始アドレス
PCM_END_ADR		EQU	106	;2byte	PCMの終了アドレス
PCM_DELTA_N		EQU	108	;2byte	PCMのＤＥＬＴＡ＿Ｎ
;PPZ8ワーク
APAN			EQU	104	;8byte	オートPAN


*/
//チャネルワーク
public class MDZ_CNL{
	//基本
	public int[] loop_stack=new int[CNL_LOOPSTACK_MAX];//ループスタック
	public int loop_adr;						//ループスタックのアドレス
	public int data_adr;						//データアドレス
	public MDZ_CNLFLG state=new MDZ_CNLFLG();	//ステータス
	public int def_len;							//デフォルトの音長
	public int len_wk;							//音長のカウンタ
	public int wave;							//現在の周波数
	public int oct_wk;							//現在の周波数
	public int before_wave;						//前の周波数
	public int quota_wk;						//ゲートタイムカウンタ
	public int detune;							//ディチューン
	public int cnl_cate;						//チャネル種類
	public int cnl_number;						//チャネル番号
	public int cnl_port_num;					//チャネルポート番号
	public int quota;							//ゲートタイム
	public int now_ontei;						//現在の音程
	public int before_ontei;					//前の音程
	public int vol;								//ボリューム
	public int before_vol;						//前の音量
	public int soutai_icho;						//相対移調の値
	public int pan;								//PAN
	public int oto_num;							//音色番号
	//拡張
	public MDZ_LFO[] lfo=new MDZ_LFO[3];		//LFO
	public MDZ_VEND vend=new MDZ_VEND();		//ピッチベンド
	//FM
	public int fm_cnl_number;					//
	public int fm_now_oto;						//FM音源の現在の音色アドレス
	public int fm_alg;							//アルゴリズム
	//SSG/PPZ8
	public MDZ_ENV env=new MDZ_ENV();			//エンベロープ
	//リズム
	public int[] rt_vol=new int[6];				//リズムのボリューム
	//PPZ8
	public MDZ_APAN apan=new MDZ_APAN();			//オートパン
	public MDZ_PCMTone pcmtone=new MDZ_PCMTone();	//PCM音色
	public int oto_bank;							//バンク番号
	public int pcm_work;							//使用するPCMチャネル
	//
	public MDZ_CNL(){
		for(int i=0;i<lfo.Length;i++){
			lfo[i]=new MDZ_LFO();
		}
		init();
	}
	public void init(){
		state.stop=true;
		loop_adr  =-1;				//(byte *)((int)&cnl.stack-1);//LOOP初期化
		data_adr  =0;				//チャネルデータ
		state.Init();
		def_len   =0x30;			//デフォルトの音長
		len_wk    =1;				//音長カウンタ
		wave      =0;				//現在の周波数
		before_wave=0xffff;			//前の周波数
		quota_wk  =1;				//Qカウンタ
		detune    =0;				//ディチューン
		cnl_cate  =MDZ_BGMDATA._PPZ8_F;		//チャネルIndex
		cnl_number=0;				//チャネルIndex
		cnl_port_num=0;				//チャネルIndex
		quota     =1;				//Q
		now_ontei =0;				//現在の音程
		before_ontei=0xffff;		//前の音程
		vol       =63;				//VOL
		before_vol=-1;				//前の音量
		soutai_icho=0;				//
		pan        =5;				//
		oto_num    =-1;				//音番号
		//
		oto_bank   =0;				//バンク番号
		pcm_work  =-1;				//使用するPCMチャネル
		for(int i=0;i<lfo.Length;i++){
			lfo[i].Init();
		}
		vend.Init();				//エンベロープ初期化
		env.Init();					//エンベロープ初期化
		apan.Init();				//エンベロープ初期化
		pcmtone.Init();
	}
	public string getCnlName(){
		return MDZ_BGMDATA.getCnlName(cnl_cate,cnl_number);
	}
	public void errorStop(MDZ_WORK work,string name){
		MDZDebug.Log(name+" Error!!:"+getCnlName());
		MDZ_CnlStop(work,this);
	}
};
/******************************************************************************
;		MDZ環境
******************************************************************************/
public class MDZ_WORK{
	public byte[] keyon_tbl=new byte[BGM_CNL_MAX];
	public PZIL[] pzi_lp=new PZIL[PZI_BANK_MAX];
	public MDZ_CNL[] bgm=new MDZ_CNL[BGM_CNL_MAX];
	public MDZ_BGMDATA bgmr;
	public int soutai_tempo;					//相対テンポ
	public int fade_cnt;						//フェードカウンタ
	public int fade_cnt2;						//
	public int fade_vol;						//
	public int src_tempo;						//元のテンポ
	public int now_tempo;						//実際のテンポ
	public int init_flg;						//初期化された
	public int bgm_state;						//BGM停止
	public int loop_is_flg;						//ループクリア
	public int loop_is_adr;						//ループアドレス
	public int end_is_adr;						//演奏終了アドレス
	public int pause_flg;						//ポーズフラグ
	public int one_loop_flg;					//
	public int sent_data;						//外部出力データ
	public int key_check_flg;					//キーチェックフラグ
	public int ssg_noise;						//
	public int ssg_mixer;						//
	public int before_noise;					//
	public int before_mixer;					//
	//public int timer_flg;						//現在のタイマーの割り込み
	public int fm_vol_flg;						//
	public bool p8_data;
	
	public int old_tempo;
	public int old_base_cnt;

	
	/*
ex_flg		EQU	02	;
q_flg_wk	EQU	04	;
fm_oto_top	EQU	06	;
ssg_oto_top	EQU	08	;
pcm_oto_top	EQU	10	;
coment_top	EQU	12	;
fm_vol_flg	EQU	14	;
_pcm_file_flg	EQU	18	;
_pcm_file_top	EQU	20	;
_pcm_file_flg2	EQU	22	;
_pcm_file_top2	EQU	24	;
adpcm_track	EQU	26	;
bgm_tbl_max	EQU	28	;
ppz8_oto_top	EQU	30	;
ppz_file_cate	EQU	32	;
	
	*/
	
	//======================
	public MDZ_WORK(){
		old_tempo=-1;
		old_base_cnt=-1;
		for(int i=0;i<BGM_CNL_MAX;i++){
			bgm[i]=new MDZ_CNL();
		}
		MDZ_initWork(this);
	}
	//======================
	private PPZ32_OPNBase opn;
	public void setOPNBase(PPZ32_OPNBase _opn){
		opn=_opn;
	}
	public void OutReg(int reg,int data){
		if(opn==null)return;
		opn.outRegOPN(reg,data);
	}
	public bool HasPort(int port){
		if(opn==null)return false;
		return opn.hasPort(port);
	}
	public void OutReg(int port,int reg,int data){
		if(opn==null)return;
		opn.outRegOPN(port,reg,data);
	}
	public int getOPNType(){
		if(opn==null)return 0;
		return opn.getOPNType();
	}
	//=====================
	private PPZ32_DriverBase pcmdriver;
	public void setPCMDriver(PPZ32_DriverBase _pcmdriver){
		pcmdriver=_pcmdriver;
	}
	public void startPCMBuffer(){
		if(pcmdriver==null)return;
		pcmdriver.startPCMBuffer();
	}
	public void setTimer(int tempo,int base_cnt){
		if(pcmdriver==null)return;
		pcmdriver.setTimer(tempo,base_cnt);
	}
	public int getNowMakePCMSize(){
		if(pcmdriver==null)return 0;
		return pcmdriver.getNowMakePCMSize();
	}
	public int getPCMBufferAdr(){
		if(pcmdriver==null)return 0;
		return pcmdriver.getPCMBufferAdr();
	}
	public void initCnl(int i){
		if(pcmdriver==null)return;
		pcmdriver.initCnl(i);
	}
	public void stopCnl(int i){
		if(pcmdriver==null)return;
		pcmdriver.stopCnl(i);
	}
	public void cnlKeyOn(int i,int index,byte[] data,int start,int end,int loop,int loopflg,int src_rate,int src_bit,int src_cnl){
		if(pcmdriver==null)return;
		pcmdriver.keyOn(i,index,data,start,end,loop,loopflg,src_rate,src_bit,src_cnl);
	}
	public void setCnlPan(int i,int pan){
		if(pcmdriver==null)return;
		pcmdriver.setPan(i,pan);
	}
	public void setCnlNote(int i,int wave){
		if(pcmdriver==null)return;
		pcmdriver.setNote(i,wave);
	}
	public void setCnlVol(int i,int vol){
		if(pcmdriver==null)return;
		pcmdriver.setVol(i,vol);
	}
};
/******************************************************************************
;	MDZ初期化
******************************************************************************/
public static bool MDZ_initWork(MDZ_WORK work){
	MDZ_initBgmWork(work);
	work.soutai_tempo=0;				//相対テンポ
	work.fade_cnt=0;					//フェードカウンタ
	work.fade_cnt2=0;
	work.fade_vol =0;
	work.src_tempo=DEF_TEMPO;			//元のテンポ
	work.now_tempo=DEF_TEMPO;			//実際のテンポ
	work.key_check_flg=0;					//キーチェックフラグ
	work.init_flg=1;					//初期化された
	work.bgm_state=0;					//BGM停止
	work.loop_is_flg=0;					//ループクリア
	work.loop_is_adr=-1;				//ループだアドレス
	work.end_is_adr=-1;					//演奏終了アドレス
	work.pause_flg=0;
	work.one_loop_flg=0;
	work.sent_data=0;					//外部出力データ
	work.key_check_flg=0;				//キーチェックフラグ
	return true;
}
/******************************************************************************
;	BGM_WORKの初期化
******************************************************************************/
public static bool MDZ_initBgmWork(MDZ_WORK work){
	work.bgm_state=0;					//BGM停止
	//ZeroMemory(work.bgm,sizeof(MDZ_CNL)*BGM_CNL_MAX);
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnl=work.bgm[i];
		cnl.init();
		cnl.state.stop=true;
	}
	return true;
}
/******************************************************************************
;	すべてのPZIループポインタの初期化
******************************************************************************/
public static void MDZ_initLoopAll(MDZ_WORK work){
	for(int i=0;i<PZI_BANK_MAX;i++){
		MDZ_initLoopOne(work,i);
	}
}
/******************************************************************************
;	一つのPZIのループポインタの初期化
******************************************************************************/
public static void MDZ_initLoopOne(MDZ_WORK work,int bank){
	if(bank<0 || bank>=PZI_BANK_MAX)return;
	PZIDATA pzi=work.bgmr.pzi_tbl[bank];
	if(pzi==null)return;
	int tbl_num=pzi.getTblNum();
	PZIL pzil=new PZIL(tbl_num);
	work.pzi_lp[bank]=pzil;
	if(pzil==null)return;
	//bool use_ppz8_neiro_set=true;
	bool use_ppz8_neiro_set=false;
	for(int i=0;i<tbl_num;i++){
		PZIDATATBL tbl=pzi.getTbl(i);
		int start=-1;
		int end  =-1;
		if(use_ppz8_neiro_set){
			if(tbl!=null){
				start=tbl.loop_start;
				end  =tbl.loop_end;
			}
		}
		pzil.tbl[i].start=start;
		pzil.tbl[i].end  =end;
	}
}
/******************************************************************************
;	
******************************************************************************/
public static int MDZ_getCommandUint8(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=work.bgmr.getDataUint8(cnlwork.data_adr);
	cnlwork.data_adr++;
	return n;
}
public static int MDZ_getCommandSint8(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=work.bgmr.getDataSint8(cnlwork.data_adr);
	cnlwork.data_adr++;
	return n;
}
public static int MDZ_getCommandUint16(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=work.bgmr.getDataUint16(cnlwork.data_adr);
	cnlwork.data_adr+=2;
	return n;
}
public static int MDZ_getCommandSint16(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=work.bgmr.getDataSint16(cnlwork.data_adr);
	cnlwork.data_adr+=2;
	return n;
}
public static int MDZ_getCommandUint32(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=work.bgmr.getDataUint32(cnlwork.data_adr);
	cnlwork.data_adr+=4;
	return n;
}
public static int MDZ_getCommandSint32(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=work.bgmr.getDataSint32(cnlwork.data_adr);
	cnlwork.data_adr+=4;
	return n;
}
/******************************************************************************
;	○ 演奏開始
;	void mus_play(void *mdz_data);
;	out	0 正常終了
;		1 異常終了
******************************************************************************/
public static bool MDZ_playBgm(MDZ_WORK work,MDZ_BGMDATA bgmdata){
	if(work==null)return false;
	if(bgmdata==null)return false;
	//
	//演奏停止
	MDZ_stopBgm(work);
	//BGMワークの初期化
	MDZ_initBgmWork(work);
	work.p8_data=true;
	//ヘッダーチェック
	//if(!MDZ_CheckHeader(work.bgmr,data))return false;
	//if(!work.bgmr.setData(data))return false;
	work.bgmr=bgmdata;
	int pcm_cnl_cnt=0;
	//BGMワークを初期化
	for(int i=0;i<BGM_CNL_MAX;i++){
		int cnl_type  =work.bgmr.cnltbl[i].type;
		int cnl_index =work.bgmr.cnltbl[i].index;
		int cnl_offset=work.bgmr.cnltbl[i].offset;
		if(cnl_type==-1)continue;
		if(cnl_type==MDZ_BGMDATA._FM_F || cnl_type==MDZ_BGMDATA._SSG_F || cnl_type==MDZ_BGMDATA._RITHM_F || cnl_type==MDZ_BGMDATA._ADPCM_F){
			work.p8_data=false;
		}
		
		//MDZ_HEADTBL htbl=mdzh.tbl[i];
		MDZ_CNL cnl=work.bgm[i];
		cnl.init();
		//if(htbl.type==0xff)continue;
		//最初のデータが停止だったら
		//byte *cdat;
		//cdat=(byte *)((int)mdzh+htbl.off);
		//if(*cdat==0xff)continue;
		//PPZ8チャネル以外スキップ
		//if(htbl.type!=_PPZ8_F)continue;
		//チャンネルオーバー
		//if(htbl.cnl>=BGM_CNL_MAX)continue;
		//
		//ZeroMemory(cnl,sizeof(MDZ_CNL));
		cnl.state.stop=false;
		cnl.data_adr  =cnl_offset;		//チャネルデータ
		cnl.cnl_cate  =cnl_type;		//チャネルIndex
		cnl.cnl_number=cnl_index;		//チャネルIndex
		cnl.quota     =work.bgmr.qflg;		//Q
		cnl.len_wk    =1;					//音長カウンタ
		cnl.def_len   =0x30;				//デフォルトの音長
		cnl.quota_wk  =1;					//Qカウンタ
		cnl.pan       =5;						//PAN
		cnl.vol       =63;						//VOL
		cnl.loop_adr  =-1;				//(byte *)((int)&cnl.stack-1);//LOOP初期化
		cnl.soutai_icho=0;				//
		cnl.now_ontei =0;				//現在の音程
		cnl.before_vol=-1;
		cnl.before_ontei=0xffff;		//前の音程
		cnl.before_wave=0xffff;			//前の周波数
		cnl.wave      =0;						//現在の周波数
		cnl.detune    =0;					//ディチューン
		cnl.oto_num   =-1;				//音番号
		//cnl.env.sv=0xff;				//SV
		//cnl.env.ar=0xff;				//AR
		//cnl.env.dr=0xff;				//DR
		//cnl.env.sl=0xff;				//SL
		//cnl.env.rr=0xff;				//RR
		cnl.env.Init();					//エンベロープ初期化
		for(int j=0;j<6;j++){
			cnl.rt_vol[j]=0xdf;		//11011111B
		}
		//PCMW設定
if(true){
		//if(cnl_type==MDZ_BGMDATA._PPZ8_F || cnl_type==MDZ_BGMDATA._ADPCM_F){
				if(cnl_type!=MDZ_BGMDATA._RITHM_F){
					cnl.pcm_work=pcm_cnl_cnt;
					pcm_cnl_cnt++;
					work.initCnl(cnl.pcm_work);
				}else{
					cnl.pcm_work=pcm_cnl_cnt;
					pcm_cnl_cnt+=6;
					for(int j=0;j<6;j++){
						work.initCnl(cnl.pcm_work+j);
					}
				}
			//}
		}
		if(cnl_type==MDZ_BGMDATA._ADPCM_F){
			cnl.oto_bank=1;
		}
		if(cnl_type==MDZ_BGMDATA._FM_F){
			MDZ_setOto(work,cnl);
			MDZ_initCnlFM(cnl);
		}
		if(cnl_type==MDZ_BGMDATA._SSG_F){
			MDZ_setOto(work,cnl);
			MDZ_initCnlSSG(cnl);
		}
		if(cnl_type==MDZ_BGMDATA._ADPCM_F){
			MDZ_initCnlADPCM(cnl);
		}
		if(cnl_type==MDZ_BGMDATA._PPZ8_F){
			MDZ_initCnlPPZ8(cnl);
		}
		
	}
	//キーオン&ボリュームテーブルクリア
	//ZeroMemory(bgmr.keyon,sizeof(byte)*BGM_CNL_MAX);
	for(int i=0;i<BGM_CNL_MAX;i++){
		work.keyon_tbl[i]=0;
	}
	//PZIループポインタの初期化
	MDZ_initLoopAll(work);
	//その他全体ワーク初期化
	work.soutai_tempo=0;				//相対テンポ
	work.fade_cnt=0;					//フェードカウンタ
	work.src_tempo=DEF_TEMPO;			//元のテンポ
	work.now_tempo=DEF_TEMPO;			//実際のテンポ
	MDZ_setTimer(work);
	work.bgm_state=1;					//演奏フラグ 1
	work.loop_is_flg=0;					//ループクリア
	work.loop_is_adr=-1;				//ループだアドレス
	work.end_is_adr=-1;					//演奏終了アドレス
	//
	work.startPCMBuffer();
	//FMパン初期化
	work.OutReg(0,0xb4,0xc0);
	work.OutReg(0,0xb5,0xc0);
	work.OutReg(0,0xb6,0xc0);
	work.OutReg(1,0xb4,0xc0);
	work.OutReg(1,0xb5,0xc0);
	work.OutReg(1,0xb6,0xc0);
	
	//SSGミキサー初期化
	
	work.OutReg(7,work.ssg_mixer);
	work.before_noise=-1;
	work.before_mixer=-1;
	work.ssg_mixer=0xb8;				//1011_1000B;
	work.OutReg(7,work.ssg_mixer);
	
	
	///
	return true;
}
public static bool MDZ_initCnlFM(MDZ_CNL cnl){
	cnl.pan=3;
	cnl.vol=0x10;
	cnl.before_vol=255;
	cnl.before_wave=0xffff;
	//
	if(cnl.cnl_number<3){
		cnl.fm_cnl_number=cnl.cnl_number;	//FM音源のチャネル
		cnl.cnl_port_num =0;				//アクセスポート
	}else{
		cnl.fm_cnl_number=cnl.cnl_number-3;	//FM音源のチャネル
		cnl.cnl_port_num =1;				//アクセスポート
	}
	return true;
}
public static bool MDZ_initCnlSSG(MDZ_CNL cnl){
	cnl.cnl_port_num=0;		//アクセスポート
	cnl.env.Init();
	cnl.before_vol=0;
	cnl.before_wave=-1;
	cnl.vol=15;
	cnl.pan=1;
	return true;
}
public static bool MDZ_initCnlRITHM(MDZ_CNL cnl){
	cnl.cnl_port_num=0;			//アクセスポート
	cnl.vol=63;
	cnl.before_vol=0;
	for(int i=0;i<6;i++){
		cnl.rt_vol[i]=0xdf;		//11011111B
	}
	return true;
}
public static bool MDZ_initCnlADPCM(MDZ_CNL cnl){
		/*
		CALL	CNL_INIT_SUB
		MOV	BYTE PTR [BX+CNL_PORT_NUM],1	;アクセスポート
		MOV	BYTE PTR [BX+PAN],3
		MOV	BYTE PTR [BX+VOL],127
		MOV	BYTE PTR [BX+BEFORE_VOL],0
		MOV	WORD PTR [BX+BEFORE_WAVE],0FFFFH
		;
		MOV	AL,TRACK_NUM			;
		MOV	DS:[BP+ADPCM_TRACK],AL
		;
		CMP	OPNA_RAM_FLG,0
		JNZ	PCM_INIT_01
		CMP	PPZ8_FLG,0
		JZ	PCM_INIT_01
		MOV	ADPCM_EM_FLG,1
		MOV	AX,1801H		;ADPCMエミュレートをする
		PPZ8_FUNC
PCM_INIT_01:
		*/
	return true;
}
public static bool MDZ_initCnlPPZ8(MDZ_CNL cnl){
		/*
		MOV	BYTE PTR [BX+PAN],5
		MOV	BYTE PTR [BX+VOL],15
		MOV	BYTE PTR [BX+BEFORE_VOL],0
		*/
	return true;
}
/******************************************************************************
;	演奏終了
******************************************************************************/
public static bool MDZ_stopBgm(MDZ_WORK work){
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnl=work.bgm[i];
		cnl.state.stop=true;
		work.stopCnl(cnl.pcm_work);
	}
	work.bgm_state=0;	//BGM停止
	//FMストップ
	MDZ_stopFM(work,0);
	MDZ_stopFM(work,1);
	MDZ_stopFM2(work,0);
	MDZ_stopFM2(work,1);
	
	//SSG停止
	work.OutReg( 8,0);
	work.OutReg( 9,0);
	work.OutReg(10,0);
	//
	return true;
}
public static void MDZ_stopFM(MDZ_WORK work,int port){
	//TL=0
	{
	int data=127;
	int reg=0x40;
	for(int i=0;i<4;i++){
		work.OutReg(port,reg+0,data);
		work.OutReg(port,reg+1,data);
		work.OutReg(port,reg+2,data);
		reg+=4;
	}
	}
	//RR停止
	{
	int data=15;
	int reg=0x80;
	for(int i=0;i<16;i++){
		work.OutReg(port,reg,data);
		reg++;
	}
	}
}
public static void MDZ_stopFM2(MDZ_WORK work,int port){
	for(int i=0;i<3;i++){
		MDZ_keySubFM2(work,port,i,0);
	}
}

/******************************************************************************
;		ポーズON/OFF
******************************************************************************/
public static void MDZ_setPauseBgm(MDZ_WORK work,int flg){
	work.pause_flg=flg;
}

/*
GET_PCMCNL:
		CMP	ECX,100H
		JAE	GET_PCMCNL_01
		CMP	ECX,EFF_CNL_MAX
		JAE	GET_PCMCNL_09
		ADD	ECX,BGM_CNL_MAX
		MOV	EAX,PCMW_WORK_ONE
		MUL	ECX
		LEA	EBX,[EAX+PCMW_WORK]
		RET
GET_PCMCNL_01:
		CMP	ECX,BGM_CNL_MAX+100H
		JAE	GET_PCMCNL_09
		SUB	ECX,100H
		MOV	EAX,PCMW_WORK_ONE
		MUL	ECX
		LEA	EBX,[EAX+PCMW_WORK]
		RET
GET_PCMCNL_09:
		XOR	EBX,EBX
		RET
*/
/******************************************************************************
;		効果音の登録
;	void mdz_play_eff(
;		int cnl;		//チャネル
;		int bank;		//PCMバンク
;		int oto;		//PCM音色番号
;		int vol;		//音量
;		int pan;		//パン
;		int rate;		//再生ﾚｰﾄ 1000H で原音
;	);
;	ECX	cnl
;	EDX	BANK
;	ESP+4	OTO
;	ESP+8	VOL
;	ESP+12	PAN
;	ESP+16	RATE
;	out	0 正常終了
;		1 再生出来なかった
******************************************************************************/
/*
public static void MDZ_PlayEff(MDZ_WORK work,int cnl,int bank,int oto,int vol,int pan,int rate){
		PZIDATA pzi=work.pzi[bank];
		work.PlayEff(cnl,pzi,oto,vol,pan,rate);
}
*/
/*
@mdz_play_eff@24:
		MOV	EAX,ESP
		_PUSH	ESI,EDI,EBP
		MOV	EBP,EAX
		PUSH	EDX
		CALL	GET_PCMCNL		;EBX PCMチャネル
		POP	EDX
		OR	EBX,EBX
		JZ	PLAY_EFF_09
		;
		MOV	EAX,[EBP+8]		;VOLUME設定
		MOV	[EBX+PCMW_VOL],AL
		MOV	EAX,[EBP+12]		;PAN設定
		MOV	[EBX+PCMW_PAN],AL
		;
		MOV	EDI,[EDX*4+PZI_BANK_TBL]	;EDI BANKアドレス
		MOV	EAX,[EBP+4]			;OTO
		LEA	EAX,[EAX*8+EAX]
		LEA	ESI,[EAX*2+EDI+PZI_TBL_TOP]	;ESI PZIテーブル
		ADD	EDI,PZI_DATA_TOP		;EDI PZIデータ先頭
		MOV	EAX,[ESI+PZIT_START]		;STARTアドレス設定
		ADD	EAX,EDI
		MOV	[EBX+PCMW_NOW_ADR],EAX
		MOV	DWORD PTR [EBX+PCMW_NOW_XOR],0	;アドレス小数点部
		ADD	EAX,[ESI+PZIT_END]		;ENDアドレス設定
		MOV	[EBX+PCMW_END_ADR],EAX
		MOV	BYTE PTR [EBX+PCMW_LOOP_FLG],0	;ループしない
		MOV	AX,[ESI+PZIT_RATE]		;元のレート
		MOV	[EBX+PCMW_SRC_RATE],AX
		;
		MOV	EAX,[EBP+16]			 ;EAX WAVE
		MOVZX	EDX,WORD PTR [EBX+PCMW_SRC_RATE] ;EDX SRC_RATE
		MUL	EDX			;EAX SORC_RATE*WAVE/DIST_RATE
		DIV	DIST_RATE
		SHL	EAX,4
		MOV	ECX,EAX
		SHL	EAX,16			;下位
		SHR	ECX,16			;上位
		MOV	[EBX+PCMW_ADD_L],EAX
		MOV	[EBX+PCMW_ADD_H],ECX
		;
		MOV	BYTE PTR [EBX+PCMW_KEYON],1	;KEYON
		MOV	BYTE PTR [EBX+PCMW_STATE],1	;PCMを停止
		;
		XOR	EAX,EAX
		_POP	ESI,EDI,EBP
		RET	(24-8)
PLAY_EFF_09:
		MOV	EAX,1
		_POP	ESI,EDI,EBP
		RET	(24-8)
/******************************************************************************
;		効果音の停止
;	int mdz_stop_eff(int cnl);
;	cnl	0~eff_cnl_max-1 指定チャネルの停止
;		-1		全チャネルの停止
******************************************************************************/
/*
public static void MDZ_StopEff(MDZ_WORK work,int cnl){
		work.StopEff(cnl);
}
/******************************************************************************
;		PIZ/PVIデータの読み込み
******************************************************************************/
/*
public static bool MDZ_LoadPZI(MDZ_WORK work,int bank,UFile url){
	PZIDATA pzidata=new PZIDATA();
	if(!pzidata.LoadPZI(url))return false;
	work.pzi[bank]=pzidata;
	return true;
}
public static bool MDZ_LoadPVI(MDZ_WORK work,int bank,UFile url){
	PZIDATA pzidata=new PZIDATA();
	if(!pzidata.LoadPVI(url))return false;
	work.pzi[bank]=pzidata;
	return true;
}
*/
/******************************************************************************
;		pziデータの設定
;	int mdz_set_pzi(int bank,void *data);
;	out	0 正常終了
;		1 異常終了
******************************************************************************/
/*
public static bool MDZ_setPZI(MDZ_WORK work,int bank,byte[] data){
	return false;
}
*/
/*
@mdz_set_pzi@8:
		MOV	EAX,[EDX]
		CMP	EAX,'0IZP'
		JNZ	SET_PZI_09
		MOV	[ECX*4+PZI_BANK_TBL],EDX
		MOV	EAX,ECX				;ループワーク初期化
		CALL	INIT_LOOP_ONE
		XOR	EAX,EAX
		RET
SET_PZI_09:
		MOV	DWORD PTR [ECX*4+PZI_BANK_TBL],0
		MOV	EAX,1
		RET
/******************************************************************************
;	PVIからPZIのコンバートのサイズ
;	int mdz_decode_pvisize(void *data,int size,int *pzisize);
;	out	0 正常終了
;		1 異常終了
******************************************************************************/
/*
public static bool MDZ_DecodePVISize(byte[] data,int[] pvisize){
	return false;
}
*/
/*
@mdz_decode_pvisize@12:
		MOV	EAX,[ECX]		;PVIのチェック
		AND	EAX,0FFFFFFH
		CMP	EAX,'IVP'
		JNZ	DEC_PVISIZE_ERR1
		MOV	EBX,[ESP+4]		;EBX PZISIZEアドレス
		SUB	EDX,PVI_DATA_TOP
		JC	DEC_PVISIZE_ERR2
		JZ	DEC_PVISIZE_ERR2
		LEA	EDX,[EDX*2+PZI_DATA_TOP]
		MOV	[EBX],EAX
		XOR	EAX,EAX
DEC_PVISIZE_09:
		RET	(12-8)
DEC_PVISIZE_ERR1:
		MOV	EAX,1
		JMP	DEC_PVISIZE_09
DEC_PVISIZE_ERR2:
		MOV	EAX,2
		JMP	DEC_PVISIZE_09
/******************************************************************************
;	PVIデータの設定
;	int mdz_decode_pvi(
;		void *pvi_data,int pvi_size,
;		void *pzi_data,int pzi_size);
;	out	0 正常終了
;		1 異常終了
******************************************************************************/
/*
public static byte[] MDZ_DecodePVI(byte[] pvi_data){
	return null;
}
*/
/*
@mdz_decode_pvi@16:
		MOV	EAX,[ESP+8]
		MOV	DECODE_PVI_SIZE,EDX
		MOV	DECODE_PZI_SIZE,EAX
		MOV	EDX,[ESP+4]
		PUSHF
		CLD
		_PUSH	ESI,EDI,EBP
		MOV	AX,DS
		MOV	ES,AX
		MOV	EBX,ECX			;EBX PVI先頭
		MOV	EBP,EDX			;EBP PZI先頭
		;
		MOV	EAX,[EBX]		;PVIのチェック
		AND	EAX,0FFFFFFH
		CMP	EAX,'IVP'
		JNZ	DEC_PVI_ERR1
	;=======================================
	;PZIテーブル初期化
	;=======================================
		MOV	EDI,EBP			;PZIヘッダー0クリア
		XOR	EAX,EAX
		MOV	ECX,PZI_DATA_TOP/4
		REP	STOSD
		MOV	DWORD PTR DS:[EBP],'0IZP' ;「PZI0」
		;
		;PZI<=PVIヘッダーに変換
		LEA	ESI,[EBX+PVI_TBL_TOP]
		LEA	EDI,[EBP+PZI_TBL_TOP]
		MOV	ECX,PVI_TBL_NUM
DEC_PVI_01:
		MOVZX	EAX,WORD PTR [ESI+0]	;EAX 先頭アドレス
		MOVZX	EDX,WORD PTR [ESI+2]	;EDX 終了アドレス
		SUB	EDX,EAX			;SIZE=終了-先頭
		SHL	EAX,6			;*32
		SHL	EDX,6			;*32
		MOV	[EDI+PZIT_START],EAX
		MOV	[EDI+PZIT_END],EDX
		MOV	EAX,-1			;ループしないとする
		MOV	[EDI+PZIT_LOOP_START],EAX
		MOV	[EDI+PZIT_LOOP_END],EAX
		MOV	WORD PTR [EDI+PZIT_RATE],16000	;16KHzデフォルト
		ADD	ESI,PVIT_WORK_ONE
		ADD	EDI,PZIT_WORK_ONE
		DEC	ECX
		JNZ	DEC_PVI_01
	;=======================================
	;ADPCM.PCMコンバート
	;=======================================
;		LEA	EDI,[EBP+PZI_DATA_TOP]	;EDI データ先頭
;		MOV	NOW_CONV_PVI,0		;現在コンバート中のPVI=0
;PVI_LOAD_12:
;		MOV	X_N,X_N0*256		;予測値の初期化
;		MOV	DELTA_N,DELTA_N0	;DELTA_Nの初期化
;		;
;		MOVZX	ESI,NOW_CONV_PVI	;BX=BX*18+PZI_TBL_TOP
;		LEA	ESI,[ESI*8+ESI]
;		LEA	ESI,[ESI*2+PZI_TBL_TOP]
;		ADD	ESI,DST_PZI_ADR
;		;
;		MOV	ECX,[ESI+4]		;ループ回数
;		SHR	ECX,1
;		INC	ECX
;		;
;		INC	NOW_CONV_PVI		;PVIの番号を+1
;PVI_LOAD_13:
;		MOV	AL,[ESI]		;上位4bitの変換
;		SHR	AL,4
;		CALL	PCM_CONV		;ADPCM>PCMへ変換
;		MOV	[EDI],AL
;		MOV	AL,[ESI]
;		CALL	PCM_CONV		;ADPCM>PCMへ変換
;		MOV	[EDI+1],AL
;		INC	ESI
;		ADD	EDI,2
;		DEC	ECX
;		JNZ	PVI_LOAD_13
;		DEC	EBP
;		JNZ	PVI_LOAD_13
;		;
;		MOV	EBX,DST_PZI_ADR
;		MOV	AL,[EBX+PVI_NUM_MAX]
;		CMP	AL,NOW_CONV_PVI		;データ数が越えたら終了
;		JNZ	PVI_LOAD_12
	;=======================================
	;ADPCM.PCMコンバート
	;=======================================
		MOV	X_N,X_N0*256		;予測値の初期化
		MOV	DELTA_N,DELTA_N0	;DELTA_Nの初期化
		LEA	ESI,[EBX+PVI_DATA_TOP]
		LEA	EDI,[EBP+PZI_DATA_TOP]	;EDI データ先頭
		MOV	ECX,DECODE_PVI_SIZE
		SUB	ECX,PVI_DATA_TOP
DEC_PVI_11:
		MOV	AL,[ESI]		;上位4bitの変換
		SHR	AL,4
		CALL	PCM_CONV		;ADPCM>PCMへ変換
		MOV	[EDI],AL
		MOV	AL,[ESI]
		CALL	PCM_CONV		;ADPCM>PCMへ変換
		MOV	[EDI+1],AL
		INC	ESI
		ADD	EDI,2
		DEC	ECX
		JNZ	DEC_PVI_11
	;=======================================
	;終了
	;=======================================
SKIP:
		XOR	EAX,EAX
DEC_PVI_RET:
		_POP	ESI,EDI,EBP
		POPF
		RET	(16-8)
DEC_PVI_ERR1:
		MOV	EAX,1
		JMP	DEC_PVI_RET
/******************************************************************************
;		予測値と量子化幅を求める
;		破壊	AX
;		ワーク	NOW_ADPCM,DELTA_N,X_N,F_TBL
******************************************************************************/
/*
PCM_CONV:
		_PUSH	EBX,EDX
		;
		AND	AX,0FH
		MOV	NOW_ADPCM,AX
		AND	AX,07H
		;
		SHL	AX,1		;8倍
		INC	AX
		MUL	DELTA_N
		REPT	3
		SHR	DX,1
		RCR	AX,1
		ENDM
		;
		MOV	DX,X_N
		TEST	NOW_ADPCM,00001000B
		JNZ	PCM_CONV_01
		ADD	AX,DX
		JNC	PCM_CONV_02
		MOV	AX,-1
		JMP	PCM_CONV_02
PCM_CONV_01:
		SUB	DX,AX
		MOV	AX,DX
		JNC	PCM_CONV_02
		XOR	AX,AX
PCM_CONV_02:
		MOV	X_N,AX
		;
		MOV	BX,NOW_ADPCM
		AND	BX,07H
		MOVZX	EBX,BX
		MOV	AX,[EBX*2+F_TBL]
		MUL	DELTA_N
		MOV	AL,AH
		MOV	AH,DL
		CMP	AX,127
		JAE	PCM_CONV_03
		MOV	AX,127
		JMP	PCM_CONV_04
PCM_CONV_03:
		CMP	AX,24576
		JBE	PCM_CONV_04
		MOV	AX,24576
PCM_CONV_04:
		MOV	DELTA_N,AX
		;
		MOV	AX,X_N
		MOV	AL,AH
		_POP	EBX,EDX
		RET
		*/
/*******************************************************************************
;	○ フェードアウト
;	void mdz_fade(int speed);
******************************************************************************/
public static void MDZ_fadeBgm(MDZ_WORK work,int speed){
	//フェード初期化
	if(work.fade_cnt==0){
		work.fade_cnt =speed;
		work.fade_cnt2=speed;
		work.fade_vol =0;
	}
}
/*******************************************************************************
;	○ BGM演奏チェック
;	int mdz_check_bgm(void);
;	out	0 終了
;		1 演奏中
;		2 PAUSE中
******************************************************************************/
public static int MDZ_checkBgm(MDZ_WORK work){
	if(work.bgm_state==0)return 0;
	if(work.pause_flg==0)return 1;
	return 2; 
}
/*******************************************************************************
;	○ 相対テンポ指定
;	void mdz_add_tempo(int add_tempo);
;	add_tempo	-128~0~127相対テンポ
******************************************************************************/
public static void MDZ_addTempo(MDZ_WORK work,int n){
	work.soutai_tempo=n;
}
/*******************************************************************************
;	○ チャネルマスク
******************************************************************************/
public static void MDZ_setMaskChannel(MDZ_WORK work,int cnl,bool mask){
	if(cnl<0 || cnl>=BGM_CNL_MAX)return;
	MDZ_CNL cnlwork=work.bgm[cnl];
	if(cnlwork==null)return;
	cnlwork.state.mask=mask;
	if(mask){
		MDZ_keyOff(work,cnlwork);
	}
}
public static bool MDZ_getMaskChannel(MDZ_WORK work,int cnl){
	if(cnl<0 || cnl>=BGM_CNL_MAX)return false;
	MDZ_CNL cnlwork=work.bgm[cnl];
	if(cnlwork==null)return false;
	return cnlwork.state.mask;
}
/*******************************************************************************
;	○ PCMの種類設定
;	void mdz_set_pcmcate(int cate,int rate,int size,void *buff);
;	in	cate	0:8bit mono
;			1:8bit stareo
;			2:16bit mono
;			3:16bit stereo
;			4:8bit mono(puz)
;			5:8bit stareo(puz)
;		rate	再生レート
;		size	再生バッファサイズ
;		buff	合成バッファ
******************************************************************************/
/*
public static void MDZ_setPCMCate(MDZ_WORK work,int cate,int rate,int size,short[] buff){
//	work.dist_cate    =cate;
//	work.dist_rate    =rate;
//	work.pcm_dist_size=size;
//	work.pcm_buff_adr =buff;
		work.setPCMCate(cate,rate,size,buff);
}
*/
/******************************************************************************
;		PCM作成のパラメータ
;	int mdz_get_makepara(int *loopadr,int *endadr,int *nowsize);
;	OUT	EAX	0:継続
;			1:終了
******************************************************************************/
public static MDZ_MakePara MDZ_getMakePara(MDZ_WORK work){
	MDZ_MakePara para=new MDZ_MakePara();
	para.loopadr=work.loop_is_adr;
	para.endadr =work.end_is_adr;
	para.nowsize=0;
	para.nowsize=work.getNowMakePCMSize();
	//終了アドレスが求まった?
	if(work.end_is_adr==-1){
		para.play_flg=true;		//継続
	}else{
		para.play_flg=false;		//終了
	}
	return para;
}



/*
@mdz_get_makepara@12:
		MOV	EAX,LOOP_IS_ADR
		MOV	EBX,END_IS_ADR
		MOV	[ECX],EAX
		MOV	[EDX],EBX
		MOV	EAX,[ESP+4]
		MOV	EBX,PCM_NOW_MAKESIZE
		MOV	[EAX],EBX
		XOR	EAX,EAX			;継続
		CMP	END_IS_ADR,-1		;終了アドレスが求まった?
		JZ	GET_MAKEPARA_01
		MOV	EAX,1			;終了
GET_MAKEPARA_01:
		RET	(12-8)
*/
/*******************************************************************************
;	○ PCM合成のパラメータ
;	int mdz_loop_mode(int mode);
;	mode	0:普通にループ
;			1:すべてのチャネルがループしたら終了
******************************************************************************/
public static void MDZ_setLoopMode(MDZ_WORK work,int n){
	work.one_loop_flg=n;
}

/******************************************************************************
;	○ 作成されるwavpcmデータサイズ
;	int mdz_get_wavsize(int loop,int fade);
;	loop回数
;	fadeスピード
******************************************************************************/
/*
public static int MDZ_getWaveSize(MDZ_WORK work,int loop,int fade){
	return 0;
}
*/
/*
@mdz_get_wavsize@8:
		RET
/******************************************************************************
;		作成されるpuzpcmデータサイズ
;	int mdz_get_puzsize(void);
******************************************************************************/
/*
public static int MDZ_getPUZSize(MDZ_WORK work){
	
	return 0;
}
*/
/*
@mdz_get_puzsize@0:


GET_PUZSIZE_01:
		_PUSH	EDI
		CALL	DRIVER_MAIN
		_POP	EDI
		MOV	EAX,PCM_ONE_STEP
		MOV	PCM_STEP_CNT,EAX
		
		CMP	END_IS_ADR,-1		;すでに終了アドレスを設定した?
		JNZ	MAKE_PCM_01
		CMP	BGM_STATE,0		;演奏終了?
		JNZ	MAKE_PCM_01
		MOV	EAX,PCM_BADR_WK		;ENDアドレス設定
		MOV	END_IS_ADR,EAX
		JMP	GET_PUZSIZE_01
GET_PUZSIZE_09:
		
		
		RET
/******************************************************************************
;	○ テンポ計算
;	IN	RATE		サンプリングレート
;		TEMPO		テンポ
;		BASE		基本カウント値（全音符のカウント数）
;	OUT	ONE_STEP	1ｽﾃｯﾌﾟの処理回数
;	ONE_STEP = RATE/[(TEMPO*BASE)/(4*60)]
;	         = (RATE*4*60)/(TEMPO*BASE)
******************************************************************************/
public static void MDZ_setTimer(MDZ_WORK work){
	int tempo   =work.now_tempo;
	int base_cnt=work.bgmr.base_cnt;
	if(tempo!=work.old_tempo || base_cnt!=work.old_base_cnt){
		work.old_tempo   =tempo;
		work.old_base_cnt=base_cnt;
	}
	work.setTimer(tempo,base_cnt);
}
/******************************************************************************
;	○ BGM演奏処理呼び出し
******************************************************************************/
public static void MDZ_playMain(MDZ_WORK work){
	MDZ_driverMain(work);
}
public static bool MDZ_isCnlStop(MDZ_CNL cnlwork){
	return (cnlwork.state.stop || cnlwork.state.oneloop);
}
//全てのチャネルがストップした?
public static bool MDZ_checkAllCnlStop(MDZ_WORK work){
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnlwork=work.bgm[i];
		if(!MDZ_isCnlStop(cnlwork))return false;
	}
	return true;
}
public static void MDZ_getLoopAdr(MDZ_WORK work){
	//すでにループポインタを設定した?
	if(work.loop_is_adr==-1){
		//[ループだ!]があった?
		if(work.loop_is_flg!=0){
			work.loop_is_adr=work.getPCMBufferAdr();//ループアドレス設定
		}
	}
	//すでに終了アドレスを設定した?
	if(work.end_is_adr==-1){
		//演奏終了?
		if(work.bgm_state==0){
			work.end_is_adr=work.getPCMBufferAdr();//ENDアドレス設定
		}
	}
}
public static void MDZ_driverMain(MDZ_WORK work){
	if(work.bgm_state==0)return;
	//チャネルごとの処理へ
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_driverCom(work,work.bgm[i]);
	}
	//すべてのチャネルが終了またはループした
	if(MDZ_checkAllCnlStop(work)){
		work.bgm_state=0;		//演奏フラグOFF
		//MDZDebug.Log("AllCnlStop");
		return;
	}
	/*======================================
	;	ミキサー出力
	;=====================================*/
	MDZ_MixerOutSSG(work);
	/*======================================
	;	テンポ計算
	;=====================================*/
	int tempo=work.src_tempo+work.soutai_tempo;
	if(tempo<TEMPO_MIN)tempo=TEMPO_MIN;
	if(tempo>TEMPO_MAX)tempo=TEMPO_MAX;
	work.now_tempo=tempo;
	/*======================================
	;	フェードアウト処理
	;=====================================*/
	if(work.fade_cnt!=0){
		work.fade_cnt2--;
		if(work.fade_cnt2==0){
			work.fade_cnt2=work.fade_cnt;
			work.fade_vol++;
			if(work.fade_vol>64){
				work.fade_cnt=0;
				MDZ_stopBgm(work);
				return;
			}
		}
	}
	/*======================================
	;	早送り&演奏停止
	;=====================================*/
	//キーチェックするか？
	/*
	if(work.key_check_flg!=0){
		MDZ_stopBgm(work);		//演奏停止
	}else{
		work.now_tempo=255;
	}
	*/
	MDZ_setTimer(work);
	//ループアドレスの獲得
	MDZ_getLoopAdr(work);
}
/*
DRIVER_MAIN:
		CMP	BGM_STATE,0		;演奏されてなければ
		JNZ	DR_BGM_01		;すぐリターン
		RET
DR_BGM_01:
		MOV	EBX,OFFSET BGM_WORK
		MOV	ECX,BGM_CNL_MAX
DR_BGM_02:
		PUSH	ECX
		CALL	DRIVER_COM		;チャネルごとの処理へ
		POP	ECX
		ADD	EBX,BGM_WORK_ONE
		DEC	ECX
		JNZ	DR_BGM_02
		;演奏終了チェック
		MOV	EBX,OFFSET BGM_WORK
		MOV	ECX,BGM_CNL_MAX
DR_BGM_04:
		TEST	DWORD PTR [EBX+P_STATE],STOP_F+ONELOOP_F
		JZ	DR_BGM_06
		ADD	EBX,BGM_WORK_ONE
		DEC	ECX
		JNZ	DR_BGM_04
		;すべてのチャネルが終了またはループした
		MOV	BGM_STATE,0		;演奏フラグOFF
		RET
DR_BGM_06:
	;=======================================
	;	テンポ計算
	;=======================================
		MOV	EAX,SRC_TEMPO
		MOV	EDX,SOUTAI_TEMPO
		CMP	EDX,0
		JZ	DR_BGM_13
		JNS	DR_BGM_12
		ADD	EAX,EDX
		JNC	DR_BGM_13
		MOV	EAX,-1
		JMP	DR_BGM_13
DR_BGM_11:
		NEG	EDX
		SUB	EAX,EDX
		JC	DR_BGM_12
		CMP	EAX,30
		JAE	DR_BGM_13
DR_BGM_12:
		MOV	EAX,30
DR_BGM_13:
		MOV	NOW_TEMPO,EAX
	;=======================================
	;	フェードアウト処理
	;=======================================
		CMP	FADE_CNT,0
		JZ	FADE_SKIP
		DEC	FADE_CNT2
		JNZ	FADE_SKIP
		MOV	AL,FADE_CNT
		MOV	FADE_CNT2,AL
		INC	FADE_VOL
		CMP	FADE_VOL,64
		JB	FADE_SKIP
		MOV	FADE_CNT,0		;フェード終了
		CALL	STOP_BGM		;演奏停止
		RET
FADE_SKIP:
	;=======================================
	;	早送り&演奏停止
	;=======================================
		CMP	KEY_CHECK_FLG,0		;キーチェックするか？
		JZ	KEY_CK_SKIP
		CALL	STOP_BGM		;演奏停止
		JMP	KEY_CK_SKIP
CTRL_GRPH:
		MOV	NOW_TEMPO,255
KEY_CK_SKIP:
		CALL	TIMER_SET
		RET
/******************************************************************************
;	○ チャネルごとのコマンド実行
******************************************************************************/
public static void MDZ_driverCom(MDZ_WORK work,MDZ_CNL cnlwork){
	//停止している?
	if(cnlwork.state.stop)return;
	//キーオンクリア
	cnlwork.state.kon=false;	//KON_F 0
	//
	if(cnlwork.state.start){
		if(!cnlwork.state.tai){
			if(cnlwork.quota_wk!=0){
				cnlwork.quota_wk--;
				if(cnlwork.quota_wk==0){
					cnlwork.state.vend=false;
					MDZ_keyOff(work,cnlwork);
				}
			}
		}
		cnlwork.len_wk--;
		if(cnlwork.len_wk!=0){
			MDZ_LFOMain(work,cnlwork);
			return;
		}else{
			bool old_sura=cnlwork.state.sura;
			cnlwork.state.sura=false;
			if(old_sura){
				cnlwork.state.sura2=true;
			}else{
				cnlwork.state.sura2=false;
			}
			bool old_tai=cnlwork.state.tai;
			cnlwork.state.tai=false;
			if(old_tai){
				cnlwork.state.tai2=true;
			}else{
				cnlwork.state.tai2=false;
			}
		}
	}
	//
	if(!MDZ_getCommand(work,cnlwork))return;
	//
	//停止していたら終了コマンド終了(oneloopした?)
	if(MDZ_isCnlStop(cnlwork)){
		//全てのチャネル停止?
		if(MDZ_checkAllCnlStop(work)){
			return;
		}
	}
	//※
	MDZ_onchoCommand(work,cnlwork);
}
/*
DRIVER_COM:
		TEST	DWORD PTR [EBX+P_STATE],STOP_F
		JZ	QUOTA_CNT
		RET
QUOTA_CNT:
		AND	DWORD PTR [EBX+P_STATE],NOT KON_F	;KON_F 0
		;
		TEST	DWORD PTR [EBX+P_STATE],START_F
		JZ	GET_COMMAND
		TEST	DWORD PTR [EBX+P_STATE],TAI_F
		JNZ	LEN_CNT
		CMP	WORD PTR [EBX+P_QUOTA_WK],0
		JZ	LEN_CNT
		DEC	WORD PTR [EBX+P_QUOTA_WK]
		JNZ	LEN_CNT
		AND	DWORD PTR [EBX+P_STATE],NOT VEND_F
		CALL	KEYOFF
LEN_CNT:
		DEC	WORD PTR [EBX+P_LEN_WK]
		JNZ	LFO_MAIN
		;
		MOV	EAX,[EBX+P_STATE]
		AND	DWORD PTR [EBX+P_STATE],NOT SURA_F
		OR	DWORD PTR [EBX+P_STATE],SURA_F2
		TEST	EAX,SURA_F
		JNZ	SURA2_SKIP
		AND	DWORD PTR [EBX+P_STATE],NOT SURA_F2
SURA2_SKIP:
		MOV	EAX,[EBX+P_STATE]
		AND	DWORD PTR [EBX+P_STATE],NOT TAI_F
		OR	DWORD PTR [EBX+P_STATE],TAI_F2
		TEST	EAX,TAI_F
		JNZ	TAI2_SKIP
		AND	DWORD PTR [EBX+P_STATE],NOT TAI_F2
TAI2_SKIP:
/******************************************************************************
;	○ コマンド処理
******************************************************************************/
public static bool MDZ_getCommand(MDZ_WORK work,MDZ_CNL cnlwork){
	//work.setCnlAdr(cnlwork.pcm_work,cnlwork.data_adr);
	//
	cnlwork.state.onteiout=false;
	cnlwork.state.start=true;
	while(true){
		int n=MDZ_getCommandUint8(work,cnlwork);
		if(n==MDZ_BGMDATA._STOP_COM){
			MDZ_CnlStop(work,cnlwork);
			return false;
		}else if(n<MDZ_BGMDATA._COM_TOP){
			cnlwork.now_ontei=n;
			break;
		}
		//コマンドジャンプ
		MDZ_jumpCommand(work,cnlwork,n);
		//停止していたら終了コマンド終了(oneloopした?)
		if(MDZ_isCnlStop(cnlwork)){
			//全てのチャネル停止?
			if(MDZ_checkAllCnlStop(work)){
				break;
			}
		}
	}
	cnlwork.state.onteiout=true;
	return true;
}
/*
GET_COMMAND:
		OR	DWORD PTR [EBX+P_STATE],START_F
		MOV	ESI,[EBX+P_DATA_ADR]
GET_COM_01:
		MOV	AL,[ESI]
		INC	ESI
		CMP	AL,_STOP_COM		;0FFH データエンド
		JZ	CNL_STOP
		CMP	AL,_COM_TOP		;00H~7FH 音程,80H 休符
		JB	GET_COM_SKIP
		SUB	AL,_COM_TOP		;81H~FEH コマンド
		MOVZX	EAX,AL
		CALL	[EAX*4+COMMAND_TBL]
		JMP	GET_COM_01
GET_COM_SKIP:
/******************************************************************************
;	○ 音長コマンド
******************************************************************************/
public static void MDZ_onchoCommand(MDZ_WORK work,MDZ_CNL cnlwork){
	int len=cnlwork.def_len;
	int n=MDZ_getCommandUint8(work,cnlwork);
	if(n!=0){
		if(n<0x80){
			len=n;
		}else{
			int n2=MDZ_getCommandUint8(work,cnlwork);
			len=(((n & 0x7f) << 8) | n2);
		}
	}
	cnlwork.len_wk=len;
	//
	if(work.bgmr.qflg!=8){
		int qw=cnlwork.len_wk-(cnlwork.quota-1);
		if(qw<=0)qw=cnlwork.len_wk;
		cnlwork.quota_wk=qw;
	}else{
		if(cnlwork.quota==8){
			cnlwork.quota_wk=cnlwork.len_wk;
		}else{
			int qw=(cnlwork.len_wk >> 3)*cnlwork.quota;
			if(qw==0)qw=1;
			cnlwork.quota_wk=qw;
		}
	}
	//
	if(cnlwork.cnl_cate==MDZ_BGMDATA._RITHM_F){
		//RITHM_OUT:
		MDZ_OutRITHM(work,cnlwork);
	}else{
		if(cnlwork.now_ontei==MDZ_BGMDATA._REST_COM){
			MDZ_rest(work,cnlwork);
		}else{
			MDZ_restSkip(work,cnlwork);
		}
	}
}
/*
		MOV	[EBX+P_NOW_ONTEI],AL
		;
		MOV	DX,[EBX+P_DEF_LEN]
		MOV	AL,[ESI]
		INC	ESI
		OR	AL,AL
		JZ	LEN_SET_01
		XOR	DX,DX
		MOV	DL,AL
		OR	AL,AL
		JNS	LEN_SET_01
		MOV	DH,DL
		AND	DH,7FH
		MOV	DL,[ESI]
		INC	ESI
LEN_SET_01:
		MOV	[EBX+P_LEN_WK],DX
		MOV	AX,DX
		CMP	DWORD PTR BGMR_WORK+BGMR_QFLG,8
		JZ	Q_8
		;
		XOR	DX,DX
		MOV	DL,[EBX+P_QUOTA]
		DEC	DL
		SUB	AX,DX
		JZ	Q_1_SKIP
		JNC	QUOTA_SKIP
Q_1_SKIP:
		MOV	AX,[EBX+P_LEN_WK]
		JMP	QUOTA_SKIP
Q_8:
		CMP	BYTE PTR [EBX+P_QUOTA],8
		JZ	QUOTA_SKIP
		SHR	AX,3
		XOR	DX,DX
		MOV	DL,[EBX+P_QUOTA]
		MUL	DX
		OR	AX,AX
		JNZ	QUOTA_SKIP
		INC	AX
QUOTA_SKIP:
		MOV	[EBX+P_QUOTA_WK],AX
		MOV	[EBX+P_DATA_ADR],ESI
/******************************************************************************
;	○ 音程のチェックと休符処理
******************************************************************************/
public static void MDZ_rest(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.before_ontei=-1;
	cnlwork.state.rest=false;
	MDZ_keyOff(work,cnlwork);
}
public static void MDZ_restSkip(MDZ_WORK work,MDZ_CNL cnlwork){
	int old_ontei=cnlwork.before_ontei;
	cnlwork.before_ontei=cnlwork.now_ontei;
	cnlwork.state.rest=true;
	//
	if(cnlwork.state.vend){
		//ピッチベンドの場合、前の音程
		//はベンドの目標音程となる
		cnlwork.before_ontei=cnlwork.vend.ontei;
		if(cnlwork.vend.ontei<cnlwork.now_ontei){
			cnlwork.vend.rate=-cnlwork.vend.rate;
		}
	}
	if(cnlwork.state.tai2){
		bool old_sura2=cnlwork.state.sura2;
		cnlwork.state.sura2=false;
		if(cnlwork.now_ontei==old_ontei){
			MDZ_LFOMain(work,cnlwork);
			return;
		}else{
			if(old_sura2){
				MDZ_keyOff(work,cnlwork);
			}
		}
	}
	MDZ_keyOnOut(work,cnlwork);
}


/*
		MOV	AL,[EBX+P_NOW_ONTEI]
		CMP	AL,_REST_COM
		JNZ	REST_SKIP
		JMP REST
REST:
		MOV	BYTE PTR [EBX+P_BEFORE_ONTEI],-1
		AND	DWORD PTR [EBX+P_STATE],NOT REST_F
		JMP	KEYOFF
REST_SKIP:
		MOV	AH,[EBX+P_BEFORE_ONTEI]
		MOV	[EBX+P_BEFORE_ONTEI],AL
		;
		OR	DWORD PTR [EBX+P_STATE],REST_F
		;
		TEST	DWORD PTR [EBX+P_STATE],VEND_F
		JZ	NOT_VEND
		MOV	DL,[EBX+VEND_ONTEI]	;ピッチベンドの場合、前の音程
		MOV	[EBX+P_BEFORE_ONTEI],DL	;はベンドの目標音程となる
		CMP	[EBX+VEND_ONTEI],AL
		JAE	NOT_VEND
		NEG	WORD PTR [EBX+VEND_RATE]
NOT_VEND:
		TEST	WORD PTR [EBX+P_STATE],TAI_F2
		JZ	NOT_TAI
		MOV	EDX,[EBX+P_STATE]
		AND	DWORD PTR [EBX+P_STATE],NOT SURA_F2 ;スラークリア
		CMP	AL,AH
		JZ	LFO_MAIN
		TEST	DX,SURA_F2
		JZ	NOT_TAI
		CALL	KEYOFF
NOT_TAI:
/******************************************************************************
;	○ キーオンをする
******************************************************************************/
public static void MDZ_keyOnOut(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_WAVEOCT waveoct=MDZ_getOntei(work,cnlwork,cnlwork.now_ontei);
	cnlwork.wave  =waveoct.wave;
	cnlwork.oct_wk=waveoct.oct;
	MDZ_AllLFOInit(work,cnlwork);
	MDZ_keyOn(work,cnlwork);
}
/*
KEYON_OUT:
		MOV	AL,[EBX+P_NOW_ONTEI]		;音程からWAVEを求める
		CALL	ONTEI_GET
		MOV	[EBX+P_WAVE],AX
		//LFOの初期化へ
		CALL	ALL_LFO_INIT
/******************************************************************************
;	○ キーオン処理
******************************************************************************/
public static void MDZ_keyOn(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.state.kon  =true;
	cnlwork.state.koff =false;
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_keyOnFM(work,cnlwork);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_keyOnSSG(work,cnlwork);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_keyOnADPCM(work,cnlwork);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_keyOnPPZ8(work,cnlwork);break;
	}
}
public static void MDZ_keyOnEnv(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.state.kon_r=true;
	cnlwork.env.flg.ar=false;
	cnlwork.env.flg.dr=false;
	cnlwork.env.flg.sr=false;
	cnlwork.env.vol2=cnlwork.env.sv;
}
public static void MDZ_keyOnFM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_OnteiVolOut(work,cnlwork);
	if(!cnlwork.state.mask){
		MDZ_keySubFM(work,cnlwork,0xf0);
	}
}
public static void MDZ_keyOnSSG(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keyOnEnv(work,cnlwork);
	MDZ_OnteiVolOut(work,cnlwork);
}
public static void MDZ_keyOnADPCM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keyOnPPZ8(work,cnlwork);
}
public static void MDZ_keyOnPPZ8(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keyOnEnv(work,cnlwork);
	//音色アドレス設定
	int start  =cnlwork.pcmtone.start;
	int end    =cnlwork.pcmtone.end;
	int loop   =cnlwork.pcmtone.loop;
	int loopflg=cnlwork.pcmtone.loopflg;
	int rate   =cnlwork.pcmtone.rate;
	byte[] data=cnlwork.pcmtone.data;
	int src_bit=cnlwork.pcmtone.src_bit;
	int src_cnl=cnlwork.pcmtone.src_cnl;
	int index  =cnlwork.pcmtone.index;
//if(loopflg==0)return;
//end +=start;
//loop+=start;
	if(!cnlwork.state.mask){
		work.cnlKeyOn(cnlwork.pcm_work,index,data,start,end,loop,loopflg,rate,src_bit,src_cnl);
	}
	//音程、ボリューム設定
	MDZ_OnteiVolOut(work,cnlwork);		//音程、ボリューム設定
}
/*
KEYON:
		OR	DWORD PTR [EBX+P_STATE],KON_F+KON_R_F	;KON_F  1
		AND	DWORD PTR [EBX+P_STATE],NOT KOFF_F	;KOFF_F 0
		AND	DWORD PTR [EBX+P_STATE],NOT (AR_F+DR_F+SR_F) ;ENV 0
		MOV	AL,[EBX+ENV_SV]			;VOL2<=SV
		MOV	[EBX+ENV_VOL2],AL
	;=======================================
	;	音色アドレス設定
	;=======================================
		MOV	EDI,[EBX+P_PCM_WORK]		;EDX PCM_WORK_ADR
		MOV	BYTE PTR [EDI+PCMW_STATE],1	;再生開始
		MOV	BYTE PTR [EDI+PCMW_KEYON],1	;KEYON
		MOV	EAX,[EBX+P_PCM_START]
		MOV	[EDI+PCMW_START_ADR],EAX	;スタート保存
		MOV	[EDI+PCMW_NOW_ADR],EAX		;整数位置
		MOV	DWORD PTR [EDI+PCMW_NOW_XOR],0	;小数点位置=0
		MOV	EAX,[EBX+P_PCM_END]		;終了アドレス
		MOV	[EDI+PCMW_END_ADR],EAX
		MOV	AL,[EBX+P_PCM_LOOPFLG]		;LOOPフラグ
		MOV	[EDI+PCMW_LOOP_FLG],AL
		MOV	EAX,[EBX+P_PCM_LOOP]		;LOOPアドレス
		MOV	[EDI+PCMW_LOOP_ADR],EAX
		MOV	AX,[EBX+P_PCM_RATE]		;SRC_RATE
		MOV	[EDI+PCMW_SRC_RATE],AX
	;=======================================
	;	音程、ボリューム設定
	;=======================================
		CALL	ONTEI_VOL_OUT			;音程、ボリューム設定
		RET
/******************************************************************************
;	○ 音色設定サブ
;	Break)EAX,ECX,EDX,ESI,EDI,EBP
******************************************************************************/
public static void MDZ_setOto(MDZ_WORK work,MDZ_CNL cnlwork){
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_setOtoFM(work,cnlwork);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_setOtoSSG(work,cnlwork);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_setOtoADPCM(work,cnlwork);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_setOtoPPZ8(work,cnlwork);break;
	}
}

public const int ONTEI_HZ_C3=161;
public const int ONTEI_HZ_C4=262;
public const int ONTEI_HZ_C5=523;

//C3 131Hz
//C4 262Hz
//C5 523Hz
static int dummy_pcm_note=ONTEI_HZ_C4;
static int dummy_pcm_rate=44100*2;
static byte[] dummy_pcm=null;
public static void DummyPCM(){
	const float PI=(float)Math.PI;
	if(dummy_pcm!=null)return;
	//int size=360;
	int size=dummy_pcm_rate/dummy_pcm_note;
	dummy_pcm=new byte[size];
	for(int i=0;i<size;i++){
		float per=(float)i/(float)size;
		float ang=PI*(per*2.0f-1.0f);
		float n=(float)Math.Sin(ang);
		int p=(int)(n*128.0f+128.0f);
		if(p<0)p=0;
		if(p>255)p=255;
		dummy_pcm[i]=(byte)(p & 0xff);
	}
}


public static void MDZ_setOtoDummyPCM(MDZ_WORK work,MDZ_CNL cnlwork){
	DummyPCM();
	
	cnlwork.pcmtone.index=-1;
	cnlwork.pcmtone.rate =dummy_pcm_rate;
	cnlwork.pcmtone.start=0;
	cnlwork.pcmtone.end  =dummy_pcm.Length-1;
	cnlwork.pcmtone.data =dummy_pcm;
	//cnlwork.pcmtone.loopflg=0;
	
	cnlwork.pcmtone.loopflg=1;
	cnlwork.pcmtone.loop =0;
}
public static void MDZ_setOtoFM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_setOtoDummyPCM(work,cnlwork);
}
public static void MDZ_setOtoSSG(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_setOtoDummyPCM(work,cnlwork);
}
public static void MDZ_setOtoADPCM(MDZ_WORK work,MDZ_CNL cnlwork){
	
/*
		CMP	B86_FLG,0
		JNZ	PCM_OTO_B86
		;
		OR	AL,AL
		JS	PCM_OTO2
		;
*/
	//bool use_adpcm_neiro_set=true;
	bool use_adpcm_neiro_set=false;
	if(cnlwork.oto_num<0x80){
		if(use_adpcm_neiro_set){
		int pcm_oto_top=work.bgmr.adpcm_oto;
		int adr=pcm_oto_top+(cnlwork.oto_num*6);
		int start=MDZ_BGMDATA.MDZ_getDataUint16(work.bgmr.data,adr+0);
		int end  =MDZ_BGMDATA.MDZ_getDataUint16(work.bgmr.data,adr+2);
		int rate =MDZ_BGMDATA.MDZ_getDataUint16(work.bgmr.data,adr+4);
		PZIDATA pzi=work.bgmr.pzi_tbl[1];
		PZIDATATBL pzit=new PZIDATATBL();
		pzit.start=start*64;
		pzit.end  =((end-start)*64);
		pzit.rate =rate/2;
		pzit.wave =pzi.getWave();
//		pzit.bit  =8;
		pzit.bit  =pzi.bit;
		pzit.cnl  =pzi.cnl;
		cnlwork.pcmtone.setPcmTone(pzit,null);
		cnlwork.pcmtone.index=cnlwork.oto_num;
		return;
		}
		//PZIDATA pzi=work.bgmr.pzi_tbl[1];
		//if(pzi==null)return;
		//PZIDATATBL pzit=pzi.getTbl(num);
		
		
		/*
		PUSH	SI
		XOR	AH,AH
		SHL	AX,1
		MOV	SI,AX
		SHL	AX,1
		ADD	SI,AX
		ADD	SI,DS:[BP+PCM_OTO_TOP]	pcm_oto_top
		LODSW
		MOV	[BX+PCM_START_ADR],AX
		LODSW
		MOV	[BX+PCM_END_ADR],AX
		LODSW
		MOV	[BX+PCM_DELTA_N],AX
		POP	SI
		RET
		
		*/
	}else{
		
	}
	
	
	MDZ_setOtoPPZ8Sub(work,cnlwork);
}
public static void MDZ_setOtoPPZ8(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_setOtoPPZ8Sub(work,cnlwork);
}
public static void MDZ_setOtoPPZ8Sub(MDZ_WORK work,MDZ_CNL cnlwork){
	int bank=cnlwork.oto_bank;
	int num =cnlwork.oto_num;
	if(bank<0 || bank>=MDZ_BGMDATA.PZI_BANK_MAX){
		MDZDebug.Log("setOto Bank["+bank+"] Error !!");
		return;
	}
	PZIDATA pzi=work.bgmr.pzi_tbl[bank];
	if(pzi==null){
		cnlwork.errorStop(work,"MDZ_setOtoPPZ8Sub:PZI null:"+bank);
		return;
	}
	PZIDATATBL pzit=pzi.getTbl(num);
	if(pzit==null){
		MDZDebug.Log("setOto pzi.getTbl:bank("+bank+"),num("+num+") Error !!");
		return;
	}
	PZILT pzilt=work.pzi_lp[bank].tbl[num];
	if(pzilt==null){
		MDZDebug.Log("setOto work.pzi_lp:bank("+bank+"),num("+num+") Error !!");
		return;
	}
	cnlwork.pcmtone.setPcmTone(pzit,pzilt);
	cnlwork.pcmtone.index=num;
}
/*
public static void MDZ_setOtoPPZ8Sub2(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.pcmtone.rate =pzit.rate;
	cnlwork.pcmtone.start=pzit.start;
	cnlwork.pcmtone.end  =pzit.end;
	cnlwork.pcmtone.data =pzit.wave;
	if(pzilt.start==-1 && pzilt.end==-1){
	//ループしない場合
		cnlwork.pcmtone.loopflg=0;
		cnlwork.pcmtone.loop   =0;
	}else{
	//ループする場合
		cnlwork.pcmtone.loopflg=1;
		//ループ開始位置のｸﾘｯﾋﾟﾝｸﾞ
		int loop=pzit.start+pzilt.start;
		if(loop>=pzit.end){
			loop=pzit.end-1;
		}
		cnlwork.pcmtone.loop=loop;
		//ループ終了位置のｸﾘｯﾋﾟﾝｸﾞ
		int end=pzit.start+pzilt.end;
		if(end>pzit.end){
			end=pzit.end;
		}
		if(end<=cnlwork.pcmtone.loop){
			end=cnlwork.pcmtone.loop+1;
		}
		cnlwork.pcmtone.end=end;
	}
}
*/
/*
SET_OTO:
		MOVZX	EAX,BYTE PTR [EBX+P_OTO_BANK]
		MOVZX	EDX,BYTE PTR [EBX+P_OTO_NUM]
		MOV	ESI,[EAX*4+PZI_BANK_TBL]	;ESI PZIデータ
		SHL	EAX,10				;BANK*1028
		LEA	EBP,[ESI+PZI_DATA_TOP]		;EBP PZIデータ先頭
		LEA	ECX,[EDX*8+EAX+PZI_LP_WORK]	;ECX ループワーク
		LEA	EDX,[EDX*8+EDX]			;EDX 12H=(NUM*9)*2
		LEA	ESI,[EDX*2+ESI+PZI_TBL_TOP]	;ESI PZIテーブル
		;
		MOV	AX,[ESI+PZIT_RATE]	;元周波数設定
		MOV	[EBX+P_PCM_RATE],AX
		MOV	EAX,[ESI+PZIT_START]	;開始アドレス設定
		ADD	EAX,EBP
		MOV	[EBX+P_PCM_START],EAX
		ADD	EAX,[ESI+PZIT_END]	;終了アドレス設定
		MOV	[EBX+P_PCM_END],EAX
		;
		MOV	EAX,[ECX+PZIL_START]	;ループチェック
		AND	EAX,[ECX+PZIL_END]
		INC	EAX
		JNZ	SET_OTO_10
	;=======================================
	;ループしない場合
	;=======================================
		MOV	BYTE PTR [EBX+P_PCM_LOOPFLG],0
		RET
	;=======================================
	;	ループする場合
	;=======================================
SET_OTO_10:
		MOV	BYTE PTR [EBX+P_PCM_LOOPFLG],1
		;
		MOV	EAX,[ECX+PZIL_START]	;ループ開始位置のクリッピング
		ADD	EAX,[EBX+P_PCM_START]
		CMP	EAX,[EBX+P_PCM_END]
		JB	SET_OTO_11
		MOV	EAX,[EBX+P_PCM_END]
		DEC	EAX
SET_OTO_11:
		MOV	[EBX+P_PCM_LOOP],EAX
		;
		MOV	EAX,[ECX+PZIL_END]	;ループ終了位置のクリッピング
		ADD	EAX,[EBX+P_PCM_START]
		CMP	EAX,[EBX+P_PCM_END]	;終了位置以前ならOK
		JBE	SET_OTO_12
		MOV	EAX,[EBX+P_PCM_END]
SET_OTO_12:
		CMP	EAX,[EBX+P_PCM_LOOP]	;ループ開始より後ろにあればOK
		JA	SET_OTO_13
		MOV	EAX,[EBX+P_PCM_LOOP]
		INC	EAX
SET_OTO_13:
		MOV	[EBX+P_PCM_END],EAX	;終了アドレス
		RET
/******************************************************************************
;	○ LFOの処理
******************************************************************************/
public static void MDZ_LFOMain(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.cnl_cate==MDZ_BGMDATA._RITHM_F){
		//MDZ_volOutRITHM(work,cnlwork);
	}else{
		MDZ_LFOSub(work,cnlwork,0);
		MDZ_LFOSub(work,cnlwork,1);
		MDZ_LFOSub(work,cnlwork,2);
		MDZ_PitchVend(work,cnlwork);
		MDZ_AutoPan(work,cnlwork);
		//
		MDZ_OnteiVolOut(work,cnlwork);
	}
}
/*
LFO_MAIN:
		LEA	EDI,[EBX+P_PLFO]	;MP
		MOV	EAX,PLFO_F
		CALL	LFO_SUB
		LEA	EDI,[EBX+P_QLFO]	;MQ
		MOV	EAX,QLFO_F
		CALL	LFO_SUB
		LEA	EDI,[EBX+P_RLFO]	;MR
		MOV	EAX,RLFO_F
		CALL	LFO_SUB
		;
		CALL	PITCH_VEND	;ピッチベンド処理
		CALL	AUTO_PAN	;オートパン処理
*/
public static void MDZ_OnteiVolOut(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_OnteiOut(work,cnlwork);
	MDZ_volOut(work,cnlwork);
}
/*
ONTEI_VOL_OUT:
		CALL	ONTEI_OUT	;音程出力
		JMP	SOFT_ENV	;ボリューム出力
/******************************************************************************
;	○ LFOの演算処理
******************************************************************************/
public static void MDZ_LFOSub(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	if(!cnlwork.state.lfo[type])return;
	MDZ_LFO lfo=cnlwork.lfo[type];
	if(lfo.md_cnt==0)return;
	lfo.md_cnt--;
	if(lfo.md_cnt!=0)return;
	lfo.md_cnt=1;
	lfo.speed_cnt--;
	if(lfo.speed_cnt!=0)return;
	lfo.speed_cnt=lfo.speed;
	//
	switch(lfo.wave_num){
		case 0:
			MDZ_LFOWave0(work,cnlwork,type);
			break;
		case 1:
			MDZ_LFOWave1(work,cnlwork,type);
			break;
		case 2:
			MDZ_LFOWave2(work,cnlwork,type);
			break;
		case 3:
			MDZ_LFOWave3(work,cnlwork,type);
			break;
		case 4:
			MDZ_LFOWave4(work,cnlwork,type);
			break;
		case 5:
			MDZ_LFOWave0(work,cnlwork,type);
			break;
	}
}
/*
LFO_SUB:
		TEST	EAX,[EBX+P_STATE]
		JZ	LFO_SKIP
		;
		CMP	BYTE PTR [EDI+LFO_MD_CNT],0	;デュレイ
		JZ	LFO_SKIP
		DEC	BYTE PTR [EDI+LFO_MD_CNT]
		JNZ	LFO_SKIP
		MOV	BYTE PTR [EDI+LFO_MD_CNT],1
		DEC	BYTE PTR [EDI+LFO_SPEED_CNT]	;スピード
		JNZ	LFO_SKIP
		MOV	AL,[EDI+LFO_SPEED]
		MOV	[EDI+LFO_SPEED_CNT],AL
		;
		MOVZX	EAX,BYTE PTR [EDI+LFO_WAVE_NUM]
		JMP	[EAX*4+LFO_WAVE_TBL]
LFO_SKIP:
		RET
		
LFO_WAVE_TBL	DD	LFO_WAVE0	;0
		DD	LFO_WAVE1	;1
		DD	LFO_WAVE2	;2
		DD	LFO_WAVE3	;3
		DD	LFO_WAVE4	;4
		DD	LFO_WAVE0	;5
*/
	/*======================================
	;	[0]三角波
	;=====================================*/
public static void MDZ_LFOWave0(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,lfo.rate_sub);
	lfo.depth_cnt--;
	if(lfo.depth_cnt!=0)return;
	lfo.depth_cnt=lfo.depth;
	lfo.rate_sub=-lfo.rate_sub;
}
/*
LFO_WAVE0:
		MOV	DX,[EDI+LFO_RATE_SUB]
		MOV	AX,[EBX+P_WAVE]
		CALL	WAVE_ADD
		MOV	[EBX+P_WAVE],AX
		;
		DEC	BYTE PTR [EDI+LFO_DEPTH_CNT]
		JNZ	LFO_SKIP
		MOV	AL,[EDI+LFO_DEPTH]
		MOV	[EDI+LFO_DEPTH_CNT],AL
		;
		NEG	WORD PTR [EDI+LFO_RATE_SUB]
		RET
*/
	/*======================================
	;	[1]のこぎり波
	;=====================================*/
public static void MDZ_LFOWave1(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,lfo.rate);
	lfo.depth_cnt--;
	if(lfo.depth_cnt!=0)return;
	lfo.depth_cnt=lfo.depth;
	lfo.rate=-lfo.rate_sub;
	//cnlwork.wave=-lfo.rate_sub;
}
/*
LFO_WAVE1:
		MOV	DX,[EDI+LFO_RATE]
		MOV	AX,[EBX+P_WAVE]
		CALL	WAVE_ADD
		MOV	[EBX+P_WAVE],AX
		;
		DEC	BYTE PTR [EDI+LFO_DEPTH_CNT]
		JNZ	LFO_SKIP
		MOV	AL,[EDI+LFO_DEPTH]
		MOV	[EDI+LFO_DEPTH_CNT],AL
		;
		MOV	AX,[EDI+LFO_RATE_SUB]
		ADD	[EBX+P_WAVE],AX
		RET
	/*======================================
	;	[2]方形波
	;=====================================*/
public static void MDZ_LFOWave2(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	int n=lfo.rate_sub;
	if(lfo.depth_cnt!=0){
		n=n >> 1;
		lfo.depth_cnt=0;
	}
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,n);
	lfo.rate_sub=-lfo.rate_sub;
}
/*
LFO_WAVE2:
		MOV	DX,[EDI+LFO_RATE_SUB]
		;
		CMP	BYTE PTR [EDI+LFO_DEPTH_CNT],0
		JZ	LFO_WAVE2_01
		SAR	DX,1
		MOV	BYTE PTR [EDI+LFO_DEPTH_CNT],0
LFO_WAVE2_01:
		MOV	AX,[EBX+P_WAVE]
		CALL	WAVE_ADD
		MOV	[EBX+P_WAVE],AX
		;
		NEG	WORD PTR [EDI+LFO_RATE_SUB]
		RET
*/
	/*======================================
	;	[3]ポルタメント
	;=====================================*/
public static void MDZ_LFOWave3(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,lfo.rate_sub);
	if(lfo.depth_cnt!=0)return;
	lfo.md_cnt=0;	//終了
}
/*
LFO_WAVE3:
		MOV	DX,[EDI+LFO_RATE_SUB]
		MOV	AX,[EBX+P_WAVE]
		CALL	WAVE_ADD
		MOV	[EBX+P_WAVE],AX
		;
		DEC	BYTE PTR [EDI+LFO_DEPTH_CNT]
		JNZ	LFO_SKIP
		MOV	BYTE PTR [EDI+LFO_MD_CNT],0	;終了
		RET
*/
	/*======================================
	;	[4]階段波
	;=====================================*/
public static void MDZ_LFOWave4(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,lfo.rate_sub);
	lfo.depth_cnt--;
	if(lfo.depth_cnt==0){
		lfo.depth_cnt=2;
	}
	lfo.rate_sub=-lfo.rate_sub;
}
/*
LFO_WAVE4:
		MOV	DX,[EDI+LFO_RATE_SUB]
		MOV	AX,[EBX+P_WAVE]
		CALL	WAVE_ADD
		MOV	[EBX+P_WAVE],AX
		;
		DEC	BYTE PTR [EDI+LFO_DEPTH_CNT]
		JZ	LFO_WAVE4_01
		MOV	BYTE PTR [EDI+LFO_DEPTH_CNT],2
LFO_WAVE4_01:
		NEG	WORD PTR [EDI+LFO_RATE_SUB]
		RET
*/
/******************************************************************************
;	○ ピッチベンドの処理
******************************************************************************/
public static void MDZ_PitchVend(MDZ_WORK work,MDZ_CNL cnlwork){
	if(!cnlwork.state.vend)return;
	MDZ_VEND vend=cnlwork.vend;
	vend.md_cnt--;
	if(vend.md_cnt!=0)return;
	vend.md_cnt=1;
	vend.speed_cnt--;
	if(vend.speed_cnt!=0)return;
	vend.speed_cnt=vend.speed;
	if(vend.rate==0)return;
	//
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_PitchVendFM(work,cnlwork);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_PitchVendSSG(work,cnlwork);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_PitchVendADPCM(work,cnlwork);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_PitchVendPPZ8(work,cnlwork);break;
	}
}
public static void MDZ_PitchVendEnd(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_VEND vend=cnlwork.vend;
	cnlwork.wave      =vend.wave;
	cnlwork.oct_wk    =vend.oct_wk;
	cnlwork.state.vend=false;
	vend.rate         =0;
}
public static void MDZ_PitchVendFM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_PitchVendPPZ8(work,cnlwork);
}
public static void MDZ_PitchVendSSG(MDZ_WORK work,MDZ_CNL cnlwork){
	//MDZ_PitchVendPPZ8(work,cnlwork);
	MDZ_VEND vend=cnlwork.vend;
	int old_wave =cnlwork.wave >> cnlwork.oct_wk;
	int vend_wave=vend.wave >> vend.oct_wk;
	int rate=vend.rate;
	if(vend_wave<old_wave)rate=-rate;
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,rate);
	int now_wave =cnlwork.wave >> cnlwork.oct_wk;
	if(rate>0){
		if(now_wave>=vend_wave){
			MDZ_PitchVendEnd(work,cnlwork);
		}
	}else{
		if(now_wave<=vend_wave){
			MDZ_PitchVendEnd(work,cnlwork);
		}
	}
}
public static void MDZ_PitchVendADPCM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_PitchVendPPZ8(work,cnlwork);
}
public static void MDZ_PitchVendPPZ8(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_VEND vend=cnlwork.vend;
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,vend.rate);
	if(vend.rate>0){
		if(cnlwork.wave>=vend.wave){
			cnlwork.wave=vend.wave;
			vend.rate=0;
			cnlwork.state.vend=false;
		}
	}else{
		if(cnlwork.wave<=vend.wave){
			cnlwork.wave=vend.wave;
			vend.rate=0;
			cnlwork.state.vend=false;
		}
	}
}
/*
PITCH_VEND:
		TEST	DWORD PTR [EBX+P_STATE],VEND_F	;ベンドじゃなければ
		JZ	PITCH_VEND_09
		;
		DEC	BYTE PTR [EBX+VEND_MD_CNT]
		JNZ	PITCH_VEND_09
		MOV	BYTE PTR [EBX+VEND_MD_CNT],1
		DEC	BYTE PTR [EBX+VEND_SPEED_CNT]
		JNZ	PITCH_VEND_09
		MOV	AL,[EBX+VEND_SPEED]
		MOV	[EBX+VEND_SPEED_CNT],AL
		MOV	DX,[EBX+VEND_RATE]
		OR	DX,DX
		JZ	PITCH_VEND_09
		;
		MOV	AX,[EBX+P_WAVE]
		CALL	WAVE_ADD			;波形加算
		MOV	[EBX+P_WAVE],AX
		;
		CMP	WORD PTR [EBX+VEND_RATE],0	;
		JS	PITCH_VEND_01
		CMP	AX,[EBX+VEND_WAVE]
		JB	PITCH_VEND_09
		JMP	PITCH_VEND_02
PITCH_VEND_01:
		CMP	AX,[EBX+VEND_WAVE]
		JA	PITCH_VEND_09
PITCH_VEND_02:
		MOV	AX,[EBX+VEND_WAVE]
		MOV	[EBX+P_WAVE],AX
		MOV	WORD PTR [EBX+VEND_RATE],0
		AND	DWORD PTR [EBX+P_STATE],NOT VEND_F
PITCH_VEND_09:
		RET
/******************************************************************************
;	○ 音程を足す
;		IN	AX	WAVE
;			DX	加算値
;		OUT	AX	WAVE
******************************************************************************/
public static int MDZ_WaveAdd(int wave,int add){
	if(add==0)return wave;
	if(add>0){
		wave+=add;
		if(wave>0xffff)wave=0xffff;
	}else{
		wave+=add;
		if(wave<0)wave=0;
	}
	return wave;
}

/*
WAVE_ADD:
		OR	DX,DX
		JS	WAVE_ADD_01
		;+の場合
		ADD	AX,DX		;WAVE=WAVE+加算値
		JNC	WAVE_ADD_02
		MOV	AX,-1
		RET
		;-の場合
WAVE_ADD_01:
		NEG	DX
		SUB	AX,DX
		JNC	WAVE_ADD_02
		XOR	AX,AX
WAVE_ADD_02:
		RET
/******************************************************************************
;	○ オートパンの処理
******************************************************************************/
public static void MDZ_AutoPan(MDZ_WORK work,MDZ_CNL cnlwork){
	if(!cnlwork.state.apan)return;
	MDZ_APAN apan=cnlwork.apan;
	if(apan.md_cnt==0)return;
	apan.md_cnt--;
	if(apan.md_cnt!=0)return;
	apan.md_cnt=1;
	apan.speed_cnt--;
	if(apan.speed_cnt!=0)return;
	apan.speed_cnt=apan.speed;
	apan.num+=apan.add;
	//
	work.setCnlPan(cnlwork.pcm_work,apan.num);
	//if(cnlwork.pcm_work!=null){
	//	cnlwork.pcm_work.pan=apan.num;
	//}
	//
	if(apan.dist_w!=0)return;
	if(apan.flg==0){
		//デュレイカウント
		apan.md_cnt=0;
	}else{
		apan.add=-apan.add;
		int n1=apan.sorc_w;
		int n2=apan.dist_w;
		apan.sorc_w=n2;
		apan.dist_w=n1;
	}
}
/*
AUTO_PAN:
		TEST	DWORD PTR [EBX+P_STATE],APAN_F
		JZ	AUTO_PAN_09
		;
		CMP	BYTE PTR [EBX+APAN_MD_CNT],0	;デュレイカウント
		JZ	AUTO_PAN_09
		DEC	BYTE PTR [EBX+APAN_MD_CNT]
		JNZ	AUTO_PAN_09
		MOV	BYTE PTR [EBX+APAN_MD_CNT],1
		DEC	BYTE PTR [EBX+APAN_SPEED_CNT]
		JNZ	AUTO_PAN_09
		MOV	AL,[EBX+APAN_SPEED]
		MOV	[EBX+APAN_SPEED_CNT],AL
		MOV	AL,[EBX+APAN_ADD]
		ADD	AL,[EBX+APAN_NUM]
		MOV	[EBX+APAN_NUM],AL
		;
		MOV	EDI,[EBX+P_PCM_WORK]		;DI PCM_WORK_ADR
		MOV	[EDI+PCMW_PAN],AL
		;
		CMP	AL,[EBX+APAN_DIST_W]
		JNZ	AUTO_PAN_09
		CMP	BYTE PTR [EBX+APAN_FLG],0
		JNZ	AUTO_PAN_02
		MOV	BYTE PTR [EBX+APAN_MD_CNT],0	;デュレイカウント
		JMP	AUTO_PAN_09
AUTO_PAN_02:
		NEG	BYTE PTR [EBX+APAN_ADD]
		MOV	AL,[EBX+APAN_SORC_W]
		XCHG	AL,[EBX+APAN_DIST_W]
		MOV	[EBX+APAN_SORC_W],AL
AUTO_PAN_09:
		RET
/******************************************************************************
;	○ 音程からそれぞれの周波数を求める
******************************************************************************/
public class MDZ_WAVEOCT{
	public int wave;
	public int oct;
	public MDZ_WAVEOCT(){}
	public MDZ_WAVEOCT(int _wave,int _oct){
		wave=_wave;
		oct=_oct;
	}
}
public static MDZ_WAVEOCT MDZ_getOntei(MDZ_WORK work,MDZ_CNL cnlwork,int ontei){
	ontei+=cnlwork.soutai_icho;
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :return MDZ_getOnteiFM(work,cnlwork,ontei);
		case MDZ_BGMDATA._SSG_F  :return MDZ_getOnteiSSG(work,cnlwork,ontei);
		case MDZ_BGMDATA._ADPCM_F:return MDZ_getOnteiADPCM(work,cnlwork,ontei);
		case MDZ_BGMDATA._PPZ8_F :return MDZ_getOnteiPPZ8(work,cnlwork,ontei);
	}
	return new MDZ_WAVEOCT();
}
public static MDZ_WAVEOCT MDZ_getOnteiFM(MDZ_WORK work,MDZ_CNL cnlwork,int ontei){
	//return MDZ_getOnteiPPZ8(work,cnlwork,ontei);
	int oct =ontei / 12;
	int note=ontei % 12;
	int n=fm_ontei_tbl[note];
	n=MDZ_WaveAdd(n,cnlwork.detune);
	n&=0x07ff;
	n|=oct << (3+8);
	return new MDZ_WAVEOCT(n,oct);
}
public static MDZ_WAVEOCT MDZ_getOnteiSSG(MDZ_WORK work,MDZ_CNL cnlwork,int ontei){
	/*
	int oct =ontei / 12;
	int note=ontei % 12;
	int n=ssg_ontei_tbl[note];
	n=MDZ_WaveAdd(n,cnlwork.detune);
	return n;
	*/
	//return MDZ_getOnteiPPZ8(work,cnlwork,ontei);
	int oct =ontei / 12;
	int note=ontei % 12;
	int n=ssg_ontei_tbl[note];
	n=MDZ_WaveAdd(n,cnlwork.detune);
	return new MDZ_WAVEOCT(n,oct);
}
public static MDZ_WAVEOCT MDZ_getOnteiADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int ontei){
	int oct =ontei / 12;
	int note=ontei % 12;
	
	return MDZ_getOnteiPPZ8(work,cnlwork,ontei);
}
//o4c(4*12)が基準
public static MDZ_WAVEOCT MDZ_getOnteiPPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int ontei){
	int oct =ontei / 12;
	int note=ontei % 12;
	int n=ppz8_ontei_tbl[note];
	n=n >> (7-oct);
	n=MDZ_WaveAdd(n,cnlwork.detune);
	return new MDZ_WAVEOCT(n,oct);
}


/*
ONTEI_GET:
		ADD	AL,[EBX+P_SOUTAI_ICHO]
		;
		XOR	AH,AH
		MOV	CL,12
		DIV	CL
		MOV	CL,AL
		MOVZX	EDI,AH
		MOV	EAX,[EDI*4+PCM_ONTEI_TBL]
		;
		XCHG	CH,CL
		MOV	CL,7
		SUB	CL,CH
		SHR	EAX,CL
		XCHG	CL,CH
		;
		MOV	DX,[EBX+P_DETUNE]
		CALL	WAVE_ADD
		;
		RET
/******************************************************************************
;	○ 音程の計算
******************************************************************************/
public static void MDZ_OnteiOut(MDZ_WORK work,MDZ_CNL cnlwork){
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_OnteiOutFM(work,cnlwork);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_OnteiOutSSG(work,cnlwork);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_OnteiOutADPCM(work,cnlwork);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_OnteiOutPPZ8(work,cnlwork);break;
	}
}
public static void MDZ_OnteiOutFM(MDZ_WORK work,MDZ_CNL cnlwork){
	//MDZ_OnteiOutPPZ8(work,cnlwork);
	int wave=cnlwork.wave;
	if(wave!=cnlwork.before_wave){
		cnlwork.before_wave=wave;
		int port=cnlwork.cnl_port_num;
		int reg0=cnlwork.fm_cnl_number+0xa0;
		int reg1=cnlwork.fm_cnl_number+0xa4;
		work.OutReg(port,reg1,(wave >> 8) & 0xff);
		work.OutReg(port,reg0, wave       & 0xff);
	}
}
public static void MDZ_OnteiOutSSG(MDZ_WORK work,MDZ_CNL cnlwork){
	//MDZ_OnteiOutPPZ8(work,cnlwork);
	
	int wave=cnlwork.wave >> cnlwork.oct_wk;
	if(wave!=cnlwork.before_wave){
		cnlwork.before_wave=wave;
		int reg=cnlwork.cnl_number*2;
		work.OutReg(reg+0,wave & 0xff);
		work.OutReg(reg+1,(wave >> 8) & 0xff);
	}
}
public static void MDZ_OnteiOutADPCM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_OnteiOutPPZ8(work,cnlwork);
}
public static void MDZ_OnteiOutPPZ8(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.wave!=cnlwork.before_wave){
		cnlwork.before_wave=cnlwork.wave;
		//
		/*
		int n=(cnlwork.pcm_work.src_rate*cnlwork.wave/work.dist_rate) << (4+1);
		//int low =n << 16;
		int low =n & 0xffff;
		int high=n >> 16;
		cnlwork.pcm_work.add_l=low;
		cnlwork.pcm_work.add_h=high;
		*/
		int wave=cnlwork.wave;
		work.setCnlNote(cnlwork.pcm_work,wave);
	}
}

/*
ONTEI_OUT:
		MOV	AX,[EBX+P_WAVE]
		CMP	AX,[EBX+P_BEFORE_WAVE]	;前と同じWAVEなら計算しない
		JZ	ONTEI_OUT_SKIP
		MOV	[EBX+P_BEFORE_WAVE],AX
		;
		MOV	EDI,[EBX+P_PCM_WORK]	;DI PCM_WORK_ADR
		MOVZX	EAX,AX
		MOVZX	EDX,WORD PTR [EDI+PCMW_SRC_RATE]
		MUL	EDX			;EAX SORC_RATE*WAVE/DIST_RATE
		DIV	DIST_RATE
		SHL	EAX,4+1
		MOV	ECX,EAX
		SHL	EAX,16			;下位
		SHR	ECX,16			;上位
		MOV	[EDI+PCMW_ADD_L],EAX
		MOV	[EDI+PCMW_ADD_H],ECX
ONTEI_OUT_SKIP:
		RET
/******************************************************************************
;	○ キーオフ
******************************************************************************/
public static void MDZ_keyOff(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.state.koff=true;
	cnlwork.state.kon =false;
	if(cnlwork.state.rest_off)return;
	//
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_keyOffFM(work,cnlwork);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_keyOffSSG(work,cnlwork);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_keyOffADPCM(work,cnlwork);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_keyOffPPZ8(work,cnlwork);break;
		case MDZ_BGMDATA._RITHM_F:MDZ_keyOffRITHM(work,cnlwork);break;
	}
}
public static void MDZ_keyOffEnv(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.env.rr==0){
		cnlwork.env.vol2=0;
	}
}
public static void MDZ_keyOffFM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keySubFM(work,cnlwork,0);
}
public static void MDZ_keySubFM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	int port=cnlwork.cnl_port_num;
	if(!work.HasPort(port))return;
	/*
	n|=(port << 2);
	n|=cnlwork.fm_cnl_number;
	work.OutReg(0x28,n);
	*/
	/*
	n|=cnlwork.fm_cnl_number;
	work.OutReg(port,0x28,n);
	*/
	MDZ_keySubFM2(work,port,cnlwork.fm_cnl_number,n);
}
//※本来はOPNAはport0、reg0x28に1～6チャネルの指定をする
public static void MDZ_keySubFM2(MDZ_WORK work,int port,int fm_cnl,int n){
	if(!work.HasPort(port))return;
	//※OPN2個だから
	int opn_type=work.getOPNType();
	if(opn_type==0){
	//OPNA
		n|=(fm_cnl | (port << 2));
		work.OutReg(0,0x28,n);
	}else{
	//OPN*2
		n|=fm_cnl;
		work.OutReg(port,0x28,n);
	}
}
public static void MDZ_keyOffSSG(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keyOffEnv(work,cnlwork);
	MDZ_volOut(work,cnlwork);
}
public static void MDZ_keyOffADPCM(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keyOffPPZ8(work,cnlwork);
}
public static void MDZ_keyOffPPZ8(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_keyOffEnv(work,cnlwork);
	MDZ_volOut(work,cnlwork);
}
public static void MDZ_keyOffRITHM(MDZ_WORK work,MDZ_CNL cnlwork){
}

/*
KEYOFF:
		CMP	DWORD PTR [EBX+P_STATE],REST_OFF_F
		JNZ	KEYOFF_01
		;
		AND	DWORD PTR [EBX+P_STATE],NOT KON_F	;KON_F  0
		OR	DWORD PTR [EBX+P_STATE],KOFF_F	;KOFF_F 1
		;
		CMP	BYTE PTR [EBX+ENV_RR],0
		JNZ	KEYOFF_01
		MOV	BYTE PTR [EBX+ENV_VOL2],0
KEYOFF_01:
/******************************************************************************
;	○ ソフトエンベロープの処理と出力
******************************************************************************/
public static void MDZ_volOut(MDZ_WORK work,MDZ_CNL cnlwork){
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_volOutFM(work,cnlwork);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_volOutSSG(work,cnlwork);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_volOutADPCM(work,cnlwork);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_volOutPPZ8(work,cnlwork);break;
		//case MDZ_BGMDATA._RITHM_F:MDZ_volOutRITHM(work,cnlwork);break;
	}
}
public static void MDZ_volOutFM(MDZ_WORK work,MDZ_CNL cnlwork){
	//MDZ_volOutPPZ8(work,cnlwork);
	int vol=cnlwork.vol;
	if(vol!=cnlwork.before_vol){
		cnlwork.before_vol=vol;
		int port=cnlwork.cnl_port_num;
		int alg=cnlwork.fm_alg;
		int reg=cnlwork.fm_cnl_number+0x40;
		int adr=cnlwork.fm_now_oto+0x4;
		for(int i=0;i<4;i++){
			if((alg & (1 << i))!=0){
				int vol2=vol;
				if(work.fm_vol_flg==0){
					//vol2+=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr);
				}
				work.OutReg(port,reg,vol2);
			}
			adr++;
			reg+=4;
		}
	}
}
public static void MDZ_volOutSSG(MDZ_WORK work,MDZ_CNL cnlwork){
	//MDZ_volOutPPZ8(work,cnlwork);
	int vol3=MDZ_SoftEnv(work,cnlwork);
	vol3=vol3*SSG_VOL_SCALE/100;
	if(vol3>15)vol3=15;
	
	if(cnlwork.state.mask){
		vol3=15;
	}
	
	
	int reg=cnlwork.cnl_number+8;
	work.OutReg(reg,vol3);
}
public static void MDZ_volOutADPCM(MDZ_WORK work,MDZ_CNL cnlwork){
//	MDZ_volOutPPZ8(work,cnlwork);
//	int vol3=cnlwork.vol*80/100;
//	if(vol3<0)vol3=0;
//	if(vol3>63)vol3=63;
	int vol3=adpcm_em_vol[cnlwork.vol & 0xff] << 2;
	vol3=vol3*ADPCM_VOL_SCALE/100;
	if(vol3>63)vol3=63;
	work.setCnlVol(cnlwork.pcm_work,vol3);
}
public static void MDZ_volOutPPZ8(MDZ_WORK work,MDZ_CNL cnlwork){
	int vol3=MDZ_SoftEnv(work,cnlwork);
	//
	if(vol3!=cnlwork.before_vol){
		cnlwork.before_vol=vol3;
		work.setCnlVol(cnlwork.pcm_work,vol3);
	}
}

/*
FM_VOL_OUT:
		MOV	DH,[BX+VOL]
		;
		CMP	OPNA_FLG,0
		JZ	FM_V_SPB_SKIP
		SUB	DH,02H
		JNC	FM_V_SPB_SKIP
		XOR	DH,DH
FM_V_SPB_SKIP:
		CMP	TIMER_FLG,0	;効果音だったらフェードしない
		JNZ	FM_VOL_OUT_01
		CMP	FADE_CNT,0
		JZ	FM_VOL_OUT_01
		MOV	AL,FADE_VOL
		SHL	AL,1
		ADD	AL,FADE_VOL
		ADD	DH,AL
		JNS	FM_VOL_OUT_01
		MOV	DH,127
FM_VOL_OUT_01:
		CMP	DH,[BX+BEFORE_VOL]
		JZ	FM_VOL_OUT_09
		MOV	[BX+BEFORE_VOL],DH
		;
		MOV	AL,[BX+ALG]
		MOV	DL,[BX+FM_CNL_NUMBER]
		ADD	DL,40H
		MOV	DI,[BX+FM_NOW_OTO]
		ADD	DI,4
		MOV	CX,4
FM_VOL_OUT_02:
		SHR	AL,1
		JNC	FM_VOL_OUT_04
		;
		PUSH	DX
		CMP	WORD PTR DS:[BP+FM_VOL_FLG],0
		JNZ	FM_VOL_OUT_03
		ADD	DH,[DI]
		JNS	FM_VOL_OUT_03
		MOV	DH,127
FM_VOL_OUT_03:
		CALL	OPN_OUT
		POP	DX
FM_VOL_OUT_04:
		INC	DI
		ADD	DL,4
		LOOP	FM_VOL_OUT_02
FM_VOL_OUT_09:
		RET
*/

/*
PCM_VOL_OUT:
		MOV	DH,[BX+VOL]
		;
		CMP	TIMER_FLG,0	;効果音だったらフェードしない
		JNZ	PCM_VOL_OUT_01
		;
		CMP	FADE_CNT,0
		JZ	PCM_VOL_OUT_01
		MOV	AL,FADE_VOL
		SHL	AL,3
		SUB	DH,AL
		JNC	PCM_VOL_OUT_01
		XOR	DH,DH
PCM_VOL_OUT_01:
		;CMP	DH,[BX+BEFORE_VOL]
		;JZ	PCM_VOL_OUT_09
		;MOV	[BX+BEFORE_VOL],DH
		;
		CMP	ADPCM_EM_FLG,0
		JNZ	EM__PCM_VOL
		CMP	B86_FLG,0
		JNZ	PCM_VOL_OUT_B86
		;
		MOV	DL,0BH
		JMP	OPN_OUT
PCM_VOL_OUT_09:
		RET
EM__PCM_VOL:
		MOV	DL,DH
		XOR	DH,DH
		MOV	AX,0707H
		PPZ8_FUNC
		RET
	;=======================================
	;	８６ボードＰＣＭの場合
	;=======================================
PCM_VOL_OUT_B86:
		MOV	AL,DH
		;CALL	B86_VOL_SET
		RET

*/
/******************************************************************************
;	○ ソフトエンベロープの処理と出力
******************************************************************************/
public static int MDZ_SoftEnv(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_ENV env=cnlwork.env;
	int ev=env.vol2;
	if(!cnlwork.state.kon_r){
		if(!cnlwork.state.koff){
			if(!cnlwork.env.flg.ar){
				ev+=env.ar;
				if(ev>255){
					ev=255;
					cnlwork.env.flg.ar=true;
				}
			}
			if(!cnlwork.env.flg.dr && cnlwork.env.flg.ar){
				ev-=env.dr;
				if(ev<=env.sl){
					ev=env.sl;
					cnlwork.env.flg.dr=true;
				}
			}
			if(!cnlwork.env.flg.sr && cnlwork.env.flg.dr){
				ev-=env.sr;
				if(ev<0){
					ev=0;
					cnlwork.env.flg.sr=true;
				}
			}
		}else{
			if(!cnlwork.env.flg.sr){
				ev-=env.rr;
				if(ev<0){
					ev=0;
					cnlwork.env.flg.sr=true;
				}
			}
		}
	}
	//ENV_OUT
	cnlwork.state.kon_r=false;
	env.vol2=ev;
	//フェード
	int vol3=((ev+1)*cnlwork.vol >> 8);
	if(work.fade_cnt!=0){
		vol3-=work.fade_vol;
		if(vol3<0)vol3=0;
	}
	return vol3;
}
/*
SOFT_ENV:
		MOV	AL,[EBX+ENV_VOL2]
		TEST	DWORD PTR [EBX+P_STATE],KON_R_F
		JNZ	ENV_OUT
		TEST	DWORD PTR [EBX+P_STATE],KOFF_F
		JNZ	RR_SKIP
		;
		TEST	DWORD PTR [EBX+P_STATE],AR_F
		JNZ	AR_SKIP
		ADD	AL,[EBX+ENV_AR]
		JNC	ENV_OUT
		MOV	AL,255
		OR	DWORD PTR [EBX+P_STATE],AR_F
AR_SKIP:
		TEST	DWORD PTR [EBX+P_STATE],DR_F
		JNZ	DR_SKIP
		SUB	AL,[EBX+ENV_DR]
		JC	SL_OVER
		CMP	AL,[EBX+ENV_SL]
		JA	ENV_OUT
SL_OVER:
		MOV	AL,[EBX+ENV_SL]
		OR	DWORD PTR [EBX+P_STATE],DR_F
DR_SKIP:
		TEST	DWORD PTR [EBX+P_STATE],SR_F
		JNZ	ENV_SKIP
		SUB	AL,[EBX+ENV_SR]
		JNC	ENV_OUT
		XOR	AL,AL
		OR	DWORD PTR [EBX+P_STATE],SR_F
		JMP	ENV_OUT
RR_SKIP:
		TEST	DWORD PTR [EBX+P_STATE],SR_F
		JNZ	ENV_SKIP
		SUB	AL,[EBX+ENV_RR]
		JNC	ENV_OUT
		XOR	AL,AL
		OR	DWORD PTR [EBX+P_STATE],SR_F
ENV_OUT:
		AND	DWORD PTR [EBX+P_STATE],NOT KON_R_F
		MOV	[EBX+ENV_VOL2],AL
		;
		XOR	AH,AH
		INC	AX
		XOR	DX,DX
		MOV	DL,[EBX+P_VOL]
		MUL	DX
		MOV	DH,AH
		;
		CMP	FADE_CNT,0
		JZ	ENV_FADE_SKIP
		SUB	DH,FADE_VOL
		JNS	ENV_FADE_SKIP
		XOR	DH,DH
ENV_FADE_SKIP:
		CMP	DH,[EBX+P_BEFORE_VOL]	;前と同じなら出力しない
		JZ	ENV_SKIP
		MOV	[EBX+P_BEFORE_VOL],DH
		;
		MOV	EDI,[EBX+P_PCM_WORK]	;EDI PCM_WORK_ADR
		MOV	[EDI+PCMW_VOL],DH
ENV_SKIP:
		RET

/******************************************************************************
;	○ リズムの出力
;					b:00000001b
;					s:00000010b
;					c:00000100b
;					h:00001000b
;					t:00010000b
;					r:00100000b
******************************************************************************/
public static void MDZ_OutRITHM(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=cnlwork.now_ontei;
	//RITHM_OUT:
	int bit=0x1;
	for(int i=0;i<6;i++){
		if((n & bit)!=0){
			int pcm_work=cnlwork.pcm_work+i;
			byte[] data=RhythmWave.getDataUint8(i);
			//音色アドレス設定
			int start  =0;
			int end    =data.Length;
			int loop   =0;
			int loopflg=0;
			int rate   =44100;
			int vol=cnlwork.rt_vol[i] & 63;
			vol=vol*RITHM_VOL_SCALE/100;
			if(vol>63)vol=63;
			int pan=g_ppz_pan_tbl[(cnlwork.rt_vol[i] >> 6) & 3];
			//int note=0x1000;
			int note=0x0800;
			int src_bit=8;
			int src_cnl=1;
			work.setCnlPan(pcm_work,pan);
			work.setCnlNote(pcm_work,note);
			work.setCnlVol(pcm_work,vol);
			if(!cnlwork.state.mask){
				work.cnlKeyOn(pcm_work,i,data,start,end,loop,loopflg,rate,src_bit,src_cnl);
			}
		}
		bit<<=1;
	}
	
	
}
/*
RITHM_OUT:
		OR	AL,AL
		JZ	RT_OUT_01
		OR	WORD PTR [BX+STATE],KON_F	;KON_F  1
		AND	WORD PTR [BX+STATE],NOT KOFF_F	;KOFF_F 0
		JMP	RT_OUT_02
RT_OUT_01:
		AND	WORD PTR [BX+STATE],NOT KON_F	;KON_F  0
		OR	WORD PTR [BX+STATE],KOFF_F	;KOFF_F 1
RT_OUT_02:
		MOV	DH,AL		;ALに出力するデータ
		MOV	DL,10H
		CALL	OPN_OUT
*/
	/*======================================
	;	リズムボリュームの出力
	;=======================================*/
//public static void MDZ_volOutRITHM(MDZ_WORK work,MDZ_CNL cnlwork){
	//MDZ_volOutPPZ8(work,cnlwork);
	//RITHM_VOL_OUT
//}
/*
RITHM_VOL_OUT:
		MOV	DH,[BX+VOL]
		CMP	FADE_CNT,0
		JZ	RT_VOL_OUT_01
		MOV	AL,FADE_VOL
		SHL	AL,1
		SHL	AL,1
		SUB	DH,AL
		JNC	RT_VOL_OUT_01
		XOR	DH,DH
RT_VOL_OUT_01:
		CMP	DH,[BX+BEFORE_VOL]
		JZ	RT_VOL_OUT_09
		MOV	[BX+BEFORE_VOL],DH
		;
		MOV	DL,11H
		JMP	OPN_OUT
RT_VOL_OUT_09:
		RET
*/
/*-----------------------------------------------------------------------------
;		リズムボリューム設定
;-----------------------------------------------------------------------------*/
public static void MDZ_setPanRITHM(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	
	if(n<0 || n>3){
		MDZDebug.Log("MDZ_setPanRITHM Error !!:"+n);
		return;
	}
	
//	int pan=g_ppz_pan_tbl[(n >> 6) & 3];
	n=(g_spb_pan_tbl[n & 3] << 6) & 0xc0;
	int and_n=0x3f;
	MDZ_VolSubRITHM(work,cnlwork,n,and_n);
	/*
	int n2=MDZ_getCommandUint8(work,cnlwork);
	int bit=1;
	for(int i=0;i<6;i++){
		if((n2 & bit)!=0){
			int v=cnlwork.rt_vol[i];
			v=(v & and_n) | n;
			cnlwork.rt_vol[i]=v;
		}
	}
	*/
/*
	//RT_PAN_SET
RT_PAN_SET:
		MOV	RT_VOL_JMP,OFFSET RT_PAN_SUB
		LODSB
		;
		AND	AX,3			;PAN修正
		MOV	DI,AX
		MOV	AL,[DI+SPB_PAN_TBL]
		;
		ROR	AL,1
		ROR	AL,1
		JMP	RT_VOL_SUB
*/
}
public static void MDZ_setVol2RITHM(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	if(n< 0)n=0;
	if(n>63)n=63;
	int and_n=0xc0;
	MDZ_VolSubRITHM(work,cnlwork,n,and_n);
/*
	//RT_VOL_SET:
RT_VOL_SET:
		MOV	RT_VOL_JMP,OFFSET RT_VSET_SUB
		LODSB
		JMP	RT_VOL_SUB
	
*/
}
public static void MDZ_VolSubRITHM(MDZ_WORK work,MDZ_CNL cnlwork,int n,int and_n){
	int n2=MDZ_getCommandUint8(work,cnlwork);
	int bit=1;
	for(int i=0;i<6;i++){
		if((n2 & bit)!=0){
			int v=cnlwork.rt_vol[i];
			v=(v & and_n) | n;
			cnlwork.rt_vol[i]=v;
		}
	}
/*
RT_VOL_SUB:
		MOV	AH,[SI]
		INC	SI
		MOV	DL,18H
		LEA	DI,[BX+RT_VOL]
		MOV	CX,6
RT_VOL_SUB_01:
		SHR	AH,1
		JNC	RT_VOL_SUB_02
		MOV	DH,[DI]
		CALL	[RT_VOL_JMP]
		MOV	[DI],DH
		CALL	OPN_OUT
RT_VOL_SUB_02:
		INC	DL
		INC	DI
		LOOP	RT_VOL_SUB_01
		RET
*/
}
/*
RT_PAN_SUB:
		AND	DH,00111111B
		OR	DH,AL
		RET

RT_VSET_SUB:
		AND	DH,11000000B
		OR	DH,AL
		RET
*/
/******************************************************************************
;	○ コマンドジャンプ
******************************************************************************/
public static void MDZ_jumpCommand(MDZ_WORK work,MDZ_CNL cnlwork,int command){
	switch(command){
		case 0x81:MDZ_setVol(work,cnlwork);break;			//0x81 音量セット
		case 0x82:MDZ_upVol(work,cnlwork);break;			//0x82 音量アップ
		case 0x83:MDZ_downVol(work,cnlwork);break;			//0x83 音量ダウン
		case 0x84:MDZ_setTimerB(work,cnlwork);break;		//0x84 タイマーセット
		case 0x85:MDZ_jumpCom(work,cnlwork);break;			//0x85 ジャンプ
		case 0x86:MDZ_loopCom(work,cnlwork);break;			//0x86 ループ
		case 0x87:MDZ_loopOut(work,cnlwork);break;			//0x87 ループアウト
		case 0x88:MDZ_setQuota(work,cnlwork);break;			//0x88 ゲートタイムセット
		case 0x89:MDZ_setDetune(work,cnlwork);break;		//0x89 ディチューン
		case 0x8A:MDZ_setLFO(work,cnlwork);break;			//0x8A LFOセット
		case 0x8B:MDZ_setLFOFlg(work,cnlwork);break;			//0x8B LFOON/OFF
		case 0x8D:MDZ_OtoCom(work,cnlwork);break;			//0x8D 音色セット
		case 0x8E:MDZ_setPan(work,cnlwork);break;			//0x8E PANセット
		case 0x8F:MDZ_setNoise(work,cnlwork);break;			//0x8F ノイズセット
		case 0x90:MDZ_setEnv(work,cnlwork);break;			//0x90 ソフトエンベロープのセット
		case 0x91:MDZ_setVol2(work,cnlwork);break;			//0x91 詳細音量セット
		case 0x92:MDZ_setTai(work,cnlwork);break;			//0x92 タイ
		case 0x93:MDZ_setLoop(work,cnlwork);break;			//0x93 ループ左カッコ
//		case 0x94:MDZ_SyncCom(work,cnlwork);break;			//0x94 シンクを送る
//		case 0x95:MDZ_WaitCom(work,cnlwork);break;			//0x95 シンクを待つ
		case 0x96:MDZ_fadeCom(work,cnlwork);break;			//0x96 フェードアウト
		case 0x97:MDZ_setVendOld(work,cnlwork);break;		//0x97 ベンド設定1
//		case 0x98:MDZ_PcmFset(work,cnlwork);break;			//0x98 PCM_F_SET
		case 0x99:MDZ_sendDataCom(work,cnlwork);break;		//0x99 データを送る
		case 0x9A:MDZ_SIcho(work,cnlwork);break;			//0x9A 相対移調
		case 0x9B:MDZ_setSura(work,cnlwork);break;			//0x9B スラー
		case 0x9C:MDZ_setDefLen(work,cnlwork);break;		//0x9C デフォルト音長の設定
		case 0x9D:MDZ_selectBank(work,cnlwork);break;		//0x9D バンクの設定
//		case 0x9E:											//0x9E MIDIEffect
//		case 0x9F:											//0x9F ベンドレンジ
//		case 0xA0:											//0xA0 ベロシティＵＰ
//		case 0xA1:											//0xA1 ベロシティＤＯＷＮ
//		case 0xA2:											//0xA2 チャネル番号設定
//		case 0xA3:											//0xA3 PPZのPAN設定
//		case 0xA4:											//0xA4 ベロシティセット
		case 0xA5:MDZ_setAutoPan(work,cnlwork);break;		//0xA5 オートパン設定
		case 0xA6:MDZ_restOffset(work,cnlwork);break;		//0xA6 休符でキーオフする
//		case 0xA7:MDZ_setTimerA(work,cnlwork);break;		//0xA7 TIMERA設定
		case 0xA8:MDZ_setTempo(work,cnlwork);break;			//0xA8 テンポ指定
		case 0xA9:MDZ_setVend(work,cnlwork);break;			//0xA9 ベンド設定2
		case 0xAA:MDZ_setLoopPoint(work,cnlwork);break;		//0xAA ループポインタ設定
		case 0xAB:MDZ_isLoop(work,cnlwork);break;			//0xAB ループだ
		default:
			{
			string name=MDZ_BGMDATA.getCommandName(command);
			if(name==null)name="---";
			//cnlwork.errorStop(work,UString.format("Unkown Command[%02x](%s)",command,name));
			}
			break;
	}
}
/******************************************************************************
;	○ チャネルの停止
******************************************************************************/
public static void MDZ_CnlStop(MDZ_WORK work,MDZ_CNL cnlwork){
	//ストップフラグ
	cnlwork.state.stop=true;
	//休符処理
	MDZ_rest(work,cnlwork);
	//PCM停止
	work.stopCnl(cnlwork.pcm_work);
}
/*
CNL_STOP_COM:
		POP	EAX		;CALL分のスタックを捨てる
CNL_STOP:
		OR	DWORD PTR [EBX+P_STATE],STOP_F	;ストップフラグ
		CALL	REST				;休符処理
		MOV	EDI,[EBX+P_PCM_WORK]	;PCM停止
		MOV	BYTE PTR [EDI+PCMW_STATE],0
CNL_STOP_02:
		RET
/******************************************************************************
;	○ 全チャネルの停止
******************************************************************************/
public static void MDZ_StopCom(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_stopBgm(work);
}
/*
STOP_COM:
		CALL	STOP_BGM
		RET
/******************************************************************************
;	○ 音長設定
******************************************************************************/
public static void MDZ_setDefLen(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint16(work,cnlwork);
	cnlwork.def_len=n;
}
/*
DEF_LEN_SET:
		MOV	AX,[ESI]
		ADD	ESI,2
		MOV	[EBX+P_DEF_LEN],AX
		RET
/******************************************************************************
;	○ テンポ設定
******************************************************************************/
public static void MDZ_setTempo(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint16(work,cnlwork);
	work.src_tempo=n;
}
//Timer B
public static void MDZ_setTimerB(MDZ_WORK work,MDZ_CNL cnlwork){
	int timer_b=MDZ_getCommandUint16(work,cnlwork);
	int tempo=833333/(-timer_b+256)/work.bgmr.base_cnt;
	work.src_tempo=tempo;
}
//Timer A
public static void MDZ_setTimerA(MDZ_WORK work,MDZ_CNL cnlwork){
	int timer_a=MDZ_getCommandUint16(work,cnlwork);
	int tempo=13333333/(-timer_a+1024)/work.bgmr.base_cnt;
	work.src_tempo=tempo;
}

/*
TEMPO_SET:
		MOVZX	EAX,WORD PTR [ESI]
		ADD	ESI,2
		MOV	SRC_TEMPO,EAX
		RET
/******************************************************************************
;	○ すべてのチャネルがループまたは終了したかチェック
******************************************************************************/
public static void MDZ_CheckOneLoop(MDZ_WORK work,MDZ_CNL cnlwork){
}
/*
CHECK_ONELOOP:
		RET
/******************************************************************************
;	○ ジャンプ、ループ命令
******************************************************************************/
//ループだ
public static void MDZ_isLoop(MDZ_WORK work,MDZ_CNL cnlwork){
	work.loop_is_flg=1;
}
//ジャンプコマンド
public static void MDZ_jumpCom(MDZ_WORK work,MDZ_CNL cnlwork){
	if(work.one_loop_flg!=0){
		cnlwork.state.oneloop=true;
		//停止
		//cnlwork.state.stop=true;
	}
	cnlwork.data_adr=MDZ_getCommandUint16(work,cnlwork);
	//
	//work.JumpCnlLoop(cnlwork.pcm_work,cnlwork.data_adr);
}
//ループ左括弧
public static void MDZ_setLoop(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.loop_adr++;
	cnlwork.loop_stack[cnlwork.loop_adr]=MDZ_getCommandUint8(work,cnlwork);
}
//ループ右括弧
public static void MDZ_loopCom(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.loop_adr<0){
		cnlwork.errorStop(work,"MDZ_loopCom("+cnlwork.loop_adr+")");
		return;
	}
	cnlwork.loop_stack[cnlwork.loop_adr]--;
	if(cnlwork.loop_stack[cnlwork.loop_adr]!=0){
		cnlwork.data_adr=MDZ_getCommandUint16(work,cnlwork);
	}else{
		cnlwork.data_adr+=2;
		cnlwork.loop_adr--;
	}
}
//ループアウト
public static void MDZ_loopOut( MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.loop_adr<0){
		cnlwork.errorStop(work,"MDZ_loopOut("+cnlwork.loop_adr+")");
		return;
	}
	if(cnlwork.loop_stack[cnlwork.loop_adr]!=1){
		cnlwork.data_adr+=2;
	}else{
		cnlwork.data_adr=MDZ_getCommandUint16(work,cnlwork);
		cnlwork.loop_adr--;
	}
}
/*
	;ループだ
LOOP_IS:
		MOV	LOOP_IS_FLG,1		;ループだ
		RET
	;ジャンプコマンド
JUMP_COM:
		CMP	ONE_LOOP_FLG,0		;一周フラグ有効?
		JZ	JUMP_COMS
		OR	DWORD PTR [EBX+P_STATE],ONELOOP_F
	;	CALL	CHECK_ONELOOP		;一周したかチェック
	;	OR	AL,AL
	;	JZ	JUMP_COMS
	;	POP	EAX			;CALL分POP
	;	RET
	;データアドレス変更
JUMP_COMS:
		MOVZX	EAX,WORD PTR [ESI]
		ADD	EAX,BGM_DATA_ADR
		MOV	ESI,EAX
		RET
	;ループ左括弧
LOOP_SET:
		INC	DWORD PTR [EBX+P_LOOP_ADR]	;STACK PUSH
		MOV	AL,[ESI]
		INC	ESI
		MOV	EDI,[EBX+P_LOOP_ADR]
		MOV	[EDI],AL
		RET
	;ループ右括弧
LOOP_COM:
		MOV	EDI,[EBX+P_LOOP_ADR]
		DEC	BYTE PTR [EDI]
		JNZ	JUMP_COMS
		ADD	ESI,2
LOOP_END:
		DEC	DWORD PTR [EBX+P_LOOP_ADR]	;STACK POP
		RET
	;ループアウト
LOOP_OUT:
		MOV	EDI,[EBX+P_LOOP_ADR]
		CMP	BYTE PTR [EDI],1
		JZ	LOOP_OUT2
		ADD	ESI,2
		RET
LOOP_OUT2:
		CALL	JUMP_COMS			;次のアドレスを求める
		JMP	LOOP_END
/******************************************************************************
;	○ ゲートタイムの設定
******************************************************************************/
public static void MDZ_setQuota(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	cnlwork.quota=n;
}
/*
QUOTA_SET:
		MOV	AL,[ESI]
		INC	ESI
		MOV	[EBX+P_QUOTA],AL
		RET
/******************************************************************************
;	○ タイ
******************************************************************************/
public static void MDZ_setTai(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.state.tai =true;
	cnlwork.state.sura=false;
}
/*
TAI_SET:
		OR	DWORD PTR [EBX+P_STATE],TAI_F
		AND	DWORD PTR [EBX+P_STATE],NOT SURA_F
		RET
/******************************************************************************
;	○ スラー
******************************************************************************/
public static void MDZ_setSura(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.state.tai =true;
	cnlwork.state.sura=true;
}
/*
SURA_SET:
		OR	DWORD PTR [EBX+P_STATE],TAI_F+SURA_F
		RET
/******************************************************************************
;	○ ディチューン
******************************************************************************/
public static void MDZ_setDetune(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandSint16(work,cnlwork);
	cnlwork.detune=n;
}
/*
DETUNE_SET:
		MOV	AX,[ESI]
		ADD	ESI,2
		MOV	[EBX+P_DETUNE],AX
		RET
/******************************************************************************
;	○ LFO設定
******************************************************************************/
public static void MDZ_setLFO(MDZ_WORK work,MDZ_CNL cnlwork){
	//波形番号
	int type    =MDZ_getCommandUint8(work,cnlwork);
	int md      =MDZ_getCommandUint8(work,cnlwork);
	int speed   =MDZ_getCommandUint8(work,cnlwork);
	int rate    =MDZ_getCommandSint16(work,cnlwork);
	int depth   =MDZ_getCommandUint8(work,cnlwork);
	int wave_num=MDZ_getCommandUint8(work,cnlwork);
	//MA,MHは対象外
	if(type>=3)return;
	cnlwork.state.lfo[type]=true;
	MDZ_LFO lfo=cnlwork.lfo[type];
	lfo.md      =md+1;
	lfo.speed   =speed;
	lfo.rate    =rate;
	lfo.depth   =depth;
	lfo.wave_num=wave_num;
	MDZ_LFOInit(cnlwork,type);
}
/*
LFO_SET:
		MOVZX	EAX,BYTE PTR [ESI]	;波形番号
		INC	ESI
		CMP	AL,3			;MA,MHは対象外
		JAE	LFO_SET_09
		;
		MOV	EDX,[EAX*4+LFO_COM_TBL]
		OR	DWORD PTR [EBX+P_STATE],EDX
		;
		MOV	EDI,[EAX*4+LFO_TBL]
		ADD	EDI,EBX
		MOV	AL,[ESI+0]
		INC	AL
		MOV	[EDI+LFO_MD],AL
		MOV	AL,[ESI+1]
		MOV	[EDI+LFO_SPEED],AL
		MOV	AX,[ESI+2]
		MOV	[EDI+LFO_RATE],AX
		MOV	AL,[ESI+4]
		MOV	[EDI+LFO_DEPTH],AL
		MOV	AL,[ESI+5]
		MOV	[EDI+LFO_WAVE_NUM],AL
		ADD	ESI,6
*/
	/*======================================
	;	LFO初期化サブ
	======================================*/
public static void MDZ_LFOInit(MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	lfo.md_cnt   =lfo.md;
	lfo.speed_cnt=lfo.speed;
	lfo.depth_cnt=(lfo.depth >> 1)+(lfo.depth & 1);
	int rate=lfo.rate;
	if(!(lfo.wave_num==0 || lfo.wave_num==3)){
		rate=rate*lfo.depth;
		if(lfo.wave_num==4){
			rate=(rate >> 1);
			lfo.depth_cnt=1;
		}
	}
	lfo.rate_sub=rate;
}
/*
LFO_INIT:
		MOV	AL,[EDI+LFO_MD]
		MOV	[EDI+LFO_MD_CNT],AL
		MOV	AL,[EDI+LFO_SPEED]
		MOV	[EDI+LFO_SPEED_CNT],AL
		MOV	AL,[EDI+LFO_DEPTH]
		SHR	AL,1
		JNZ	LFO_INIT_01
		ADC	AL,0
LFO_INIT_01:
		MOV	[EDI+LFO_DEPTH_CNT],AL
		;
		MOV	AX,[EDI+LFO_RATE]
		CMP	BYTE PTR [EDI+LFO_WAVE_NUM],0
		JZ	LFO_INIT_02
		CMP	BYTE PTR [EDI+LFO_WAVE_NUM],3
		JZ	LFO_INIT_02
		XOR	DX,DX
		MOV	DL,[EDI+LFO_DEPTH]
		IMUL	DX
		CMP	BYTE PTR [EDI+LFO_WAVE_NUM],4
		JNZ	LFO_INIT_02
		SAR	AX,1
		MOV	BYTE PTR [EDI+LFO_DEPTH_CNT],1
LFO_INIT_02:
		MOV	[EDI+LFO_RATE_SUB],AX
LFO_SET_09:
		RET
*/
	/*======================================
	;	LFO初期化
	======================================*/
public static void MDZ_AllLFOInit(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.state.lfo[0]){
		MDZ_LFOInit(cnlwork,0);
	}
	if(cnlwork.state.lfo[1]){
		MDZ_LFOInit(cnlwork,1);
	}
	if(cnlwork.state.lfo[2]){
		MDZ_LFOInit(cnlwork,2);
	}
	if(cnlwork.state.apan){
		MDZ_APanInit(work,cnlwork);
	}
}
/*
ALL_LFO_INIT:
		TEST	DWORD PTR [EBX+P_STATE],PLFO_F
		JZ	ALL_LFO_I_01
		LEA	EDI,[EBX+P_PLFO]
		CALL	LFO_INIT
ALL_LFO_I_01:
		TEST	DWORD PTR [EBX+P_STATE],QLFO_F
		JZ	ALL_LFO_I_02
		LEA	EDI,[EBX+P_QLFO]
		CALL	LFO_INIT
ALL_LFO_I_02:
		TEST	DWORD PTR [EBX+P_STATE],RLFO_F
		JZ	ALL_LFO_I_03
		LEA	EDI,[EBX+P_RLFO]
		CALL	LFO_INIT
ALL_LFO_I_03:
		TEST	DWORD PTR [EBX+P_STATE],APAN_F
		JZ	ALL_LFO_I_04
		CALL	APAN_INIT
ALL_LFO_I_04:
		RET
/******************************************************************************
;	○ LFOのON/OFF
******************************************************************************/
public static void MDZ_setLFOFlg(MDZ_WORK work,MDZ_CNL cnlwork){
	int type=MDZ_getCommandUint8(work,cnlwork);
	int flg =MDZ_getCommandUint8(work,cnlwork);
	if(type<3){
		if(flg==0){
			cnlwork.state.lfo[type]=false;
		}else{
			cnlwork.state.lfo[type]=true;
		}
	}else if(type==4){
		if(flg==0){
			cnlwork.state.alfo=false;
		}else{
			cnlwork.state.alfo=true;
		}
	}else if(type==5){
		if(flg==0){
			cnlwork.state.hlfo=false;
		}else{
			cnlwork.state.hlfo=true;
		}
	}
}
/*
LFO_COM:
		MOVZX	EAX,BYTE PTR [ESI]	;波形番号
		MOV	EDX,[EAX*4+LFO_COM_TBL]
		MOV	AL,[ESI+1]
		ADD	ESI,2
		OR	AL,AL
		JNZ	LFO_COM_01
		NOT	EDX
		AND	[EBX+P_STATE],EDX
		RET
LFO_COM_01:
		OR	[EBX+P_STATE],EDX
		RET
/******************************************************************************
;	○ ピッチベンドの指定
******************************************************************************/
public static void MDZ_setVendOld(MDZ_WORK work,MDZ_CNL cnlwork){
	int ontei =MDZ_getCommandUint8(work,cnlwork);
	int md_cnt=MDZ_getCommandUint8(work,cnlwork);
	int speed =MDZ_getCommandUint8(work,cnlwork);
	int rate  =MDZ_getCommandSint8(work,cnlwork);	//byte
	MDZ_setVendSub(work,cnlwork,ontei,md_cnt,speed,rate);
/*
		LODSB
		ADD	AL,[BX+SOUTAI_ICHO]
		MOV	[BX+VEND_ONTEI],AL
		CALL	ONTEI_GET
		MOV	[BX+VEND_WAVE],AX
		MOV	[BX+VEND_OCT],CL
		LODSB
		INC	AL
		MOV	[BX+VEND_MD_CNT],AL
		LODSB
		MOV	[BX+VEND_SPEED],AL
		MOV	[BX+VEND_SPEED_CNT],AL
		LODSB
		MOV	[BX+VEND_RATE],AL
		;
		OR	WORD PTR [BX+STATE],VEND_F
		RET
	
*/
}
public static void MDZ_setVend(MDZ_WORK work,MDZ_CNL cnlwork){
	int ontei =MDZ_getCommandUint8(work,cnlwork);
	int md_cnt=MDZ_getCommandUint8(work,cnlwork);
	int speed =MDZ_getCommandUint8(work,cnlwork);
	int rate  =MDZ_getCommandSint16(work,cnlwork);	//word
	//
	MDZ_setVendSub(work,cnlwork,ontei,md_cnt,speed,rate);
}
public static void MDZ_setVendSub(MDZ_WORK work,MDZ_CNL cnlwork,int ontei,int md_cnt,int speed,int rate){
	MDZ_VEND vend=cnlwork.vend;
	int new_ontei=ontei+cnlwork.soutai_icho;
	MDZ_WAVEOCT waveoct=MDZ_getOntei(work,cnlwork,new_ontei);
	vend.ontei    =ontei;
	vend.wave     =waveoct.wave;
	vend.oct_wk   =waveoct.oct;
	vend.md_cnt   =md_cnt+1;
	vend.speed    =speed;
	vend.speed_cnt=vend.speed;
	vend.rate     =rate;
	cnlwork.state.vend=true;
}
/*
VEND_SET:
		MOV	AL,[ESI+0]
		ADD	AL,[EBX+P_SOUTAI_ICHO]
		MOV	[EBX+VEND_ONTEI],AL
		CALL	ONTEI_GET
		MOV	[EBX+VEND_WAVE],AX
		MOV	AL,[ESI+1]
		INC	AL
		MOV	[EBX+VEND_MD_CNT],AL
		MOV	AL,[ESI+2]
		MOV	[EBX+VEND_SPEED],AL
		MOV	[EBX+VEND_SPEED_CNT],AL
		MOV	AX,[ESI+3]
		MOV	[EBX+VEND_RATE],AX
		OR	DWORD PTR [EBX+P_STATE],VEND_F
		ADD	ESI,5
		RET
*/
/******************************************************************************
;	○ ボリューム設定
******************************************************************************/
public static void MDZ_setVol(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_setVolFM(work,cnlwork,n);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_setVolSSG(work,cnlwork,n);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_setVolADPCM(work,cnlwork,n);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_setVolPPZ8(work,cnlwork,n);break;
		case MDZ_BGMDATA._RITHM_F:MDZ_setVolRITHM(work,cnlwork,n);break;
	}
}
public static void MDZ_setVolFM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	//MDZ_setVolPPZ8(work,cnlwork,n);
	if(n<0)n=0;
	if(n>15)n=15;
	cnlwork.vol=fm_vol_tbl[n];
}
public static void MDZ_setVolSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	//MDZ_setVolPPZ8(work,cnlwork,n);
	cnlwork.vol=n;
}
public static void MDZ_setVolRITHM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
//	MDZ_setVolPPZ8(work,cnlwork,n);
	cnlwork.vol=n;
}
public static void MDZ_setVolADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
//	MDZ_setVolPPZ8(work,cnlwork,n);
	cnlwork.vol=n;
}
public static void MDZ_setVolPPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	if(!work.p8_data){
		int vol=(n << 2)*SSGPPZ8_VOL_SCALE/100;
		if(vol>63)vol=63;
		cnlwork.vol=vol;
	}else{
		cnlwork.vol=n << 2;
	}
}
//==================
public static void MDZ_setVol2(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.cnl_cate==MDZ_BGMDATA._RITHM_F){
		MDZ_setVol2RITHM(work,cnlwork);
		return;
	}
	//
	int n=MDZ_getCommandUint8(work,cnlwork);
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_setVol2FM(work,cnlwork,n);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_setVol2SSG(work,cnlwork,n);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_setVol2ADPCM(work,cnlwork,n);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_setVol2PPZ8(work,cnlwork,n);break;
	}
}
public static void MDZ_setVol2FM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
//	n=((127-n) >> 1);
//	MDZ_setVol2PPZ8(work,cnlwork,n);
	cnlwork.vol=n;
}
public static void MDZ_setVol2SSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
//	n=n << 2;
//	MDZ_setVol2PPZ8(work,cnlwork,n);
	cnlwork.vol=n;
}
public static void MDZ_setVol2ADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
//	MDZ_setVol2PPZ8(work,cnlwork,n);
	cnlwork.vol=n;
}
public static void MDZ_setVol2PPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	if(!work.p8_data){
		int vol=(n << 2)*SSGPPZ8_VOL_SCALE/100;
		if(vol>63)vol=63;
		cnlwork.vol=vol;
	}else{
		cnlwork.vol=n << 2;
	}
}
/*
VOL_SET:
		MOV	AL,[ESI]
		INC	ESI
		SHL	AL,2
		MOV	[EBX+P_VOL],AL
		RET
VOL_SET2:
		MOV	AL,[ESI]
		INC	ESI
		MOV	[EBX+P_VOL],AL
		RET
/******************************************************************************
;	○ ボリュームのUP
******************************************************************************/
public static void MDZ_upVol(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	//
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_upVolFM(work,cnlwork,n);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_upVolSSG(work,cnlwork,n);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_upVolADPCM(work,cnlwork,n);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_upVolPPZ8(work,cnlwork,n);break;
		case MDZ_BGMDATA._RITHM_F:MDZ_upVolRITHM(work,cnlwork,n);break;
	}
}
public static void MDZ_upVolFM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol-=n;
	if(cnlwork.vol<0)cnlwork.vol=0;
}
public static void MDZ_upVolSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol+=n;
	if(cnlwork.vol>15)cnlwork.vol=0;
}
public static void MDZ_upVolADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol+=(n << 1);
	if(cnlwork.vol>255)cnlwork.vol=255;
}
public static void MDZ_upVolPPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol+=n;
	if(cnlwork.vol>63)cnlwork.vol=63;
}
public static void MDZ_upVolRITHM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol+=n;
	if(cnlwork.vol>63)cnlwork.vol=63;
}
/*
VOL_UP:
		MOV	AL,[ESI]
		INC	ESI
		ADD	[EBX+P_VOL],AL
		JC	VOL_UP_01
		CMP	BYTE PTR [EBX+P_VOL],64
		JB	VOL_UP_02
VOL_UP_01:
		MOV	BYTE PTR [EBX+P_VOL],64-1
VOL_UP_02:
		RET
/******************************************************************************
;	○ ボリュームのDOWN
******************************************************************************/
public static void MDZ_downVol(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	//
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_downVolFM(work,cnlwork,n);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_downVolSSG(work,cnlwork,n);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_downVolADPCM(work,cnlwork,n);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_downVolPPZ8(work,cnlwork,n);break;
		case MDZ_BGMDATA._RITHM_F:MDZ_downVolRITHM(work,cnlwork,n);break;
	}
}
public static void MDZ_downVolFM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol+=n;
	if(cnlwork.vol>127)cnlwork.vol=127;
}
public static void MDZ_downVolSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol-=n;
	if(cnlwork.vol<0)cnlwork.vol=0;
}
public static void MDZ_downVolADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol-=(n << 1);
	if(cnlwork.vol<0)cnlwork.vol=0;
}
public static void MDZ_downVolPPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol-=n;
	if(cnlwork.vol<0)cnlwork.vol=0;
}
public static void MDZ_downVolRITHM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.vol-=n;
	if(cnlwork.vol<0)cnlwork.vol=0;
}
/*
VOL_DOWN:
		MOV	AL,[ESI]
		INC	ESI
		SUB	[EBX+P_VOL],AL
		JNC	VOL_DOWN_01
		MOV	BYTE PTR [EBX+P_VOL],0
VOL_DOWN_01:
		RET
*/
/******************************************************************************
;	ノイズセット
******************************************************************************/
public static void MDZ_setNoise(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	work.ssg_noise=n;
}
/******************************************************************************
;	SSGのミキサー設定
******************************************************************************/
public static void MDZ_MixersetSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.pan=n & 3;
	int cnl=cnlwork.cnl_number;
	int al=ssg_mixer_tbl[cnlwork.pan] << cnl;	//ALに出力データ
	int ah=ssg_mixer_mask[cnl];					//AHにANDデータ(11110110B)
	work.ssg_mixer&=ah;
	work.ssg_mixer&=al;
}
/*
MIXER_SET:
		XOR	AX,AX
		MOV	AL,[BX+PAN]		;SSGのTONE,NOISEの設定
		MOV	DI,AX
		MOV	AL,[DI+mixer_tbl]
		MOV	CL,[BX+CNL_NUMBER]	;ALに出力データ
		SHL	AL,CL
		MOV	AH,11110110B		;AHにANDデータ
		ROL	AH,CL
		AND	DS:[BP+SSG_MIXER],AH	;ミキサー設定
		OR	DS:[BP+SSG_MIXER],AL
		;
		CALL	SSG_MASK_CHECK		;マスクチェック
		;
		RET
	;=======================================
	;	マスクチェック
	;=======================================
SSG_MASK_CHECK:
		CMP	EFFECT_FLG,0		;効果音が鳴ってなければ
		JZ	SSG_MASK_CK_01
		CMP	TIMER_FLG,0		;効果音だったら
		JNZ	SSG_MASK_CK_01
		MOV	AL,000001000B		;NOISE指定がなければ
		MOV	CL,[BX+CNL_NUMBER]
		SHL	AL,CL
		TEST	AL,BYTE PTR [BGM_WORKS+SSG_MIXER]
		JNZ	SSG_MASK_CK_01
		;
		CALL	NOISE_CHECK		;効果音でノイズが鳴ってなければ
		JNC	SSG_MASK_CK_01
		MOV	DL,[BX+CNL_NUMBER]	;消音
		ADD	DL,8
		XOR	DH,DH
		CALL	OPN_OUT
		MOV	OUT_FLG,1		;出力禁止
		STC
		RET
SSG_MASK_CK_01:
		CLC
		RET
	;=======================================
	;　効果音でノイズが鳴っているかチェック
	;	CY=0	ノイズが鳴っていない
	;	CY=1	ノイズが鳴っている
	;=======================================
NOISE_CHECK:
		CMP	EFFECT_FLG,0	;効果音は鳴っていないので関係なし
		JZ	NOISE_CK_NO
		;
		MOV	DI,OFFSET CNL_EFF_WK+3
		MOV	AL,00001000B
		MOV	CX,3
NOISE_CK_01:
		CMP	BYTE PTR [DI],0
		JZ	NOISE_CK_02
		TEST	AL,BYTE PTR [EFF_WORKS+SSG_MIXER]
		JZ	NOISE_CK_OK
NOISE_CK_02:
		SHL	AL,1
		INC	DI
		LOOP	NOISE_CK_01
NOISE_CK_NO:
		CLC
		RET
NOISE_CK_OK:
		STC
		RET
*/
	/*======================================
	;	ミキサーの音出力
	;======================================*/
public static void MDZ_MixerOutSSG(MDZ_WORK work){
	if(work.ssg_noise!=work.before_noise){
		work.before_noise=work.ssg_noise;
		work.OutReg(6,work.ssg_noise);
	}
	if(work.ssg_mixer!=work.before_mixer){
		work.before_mixer=work.ssg_mixer;
		work.OutReg(7,work.ssg_mixer);
	}
}
/*
MIXER_OUT:
		CMP	EFFECT_FLG,0		;効果音が鳴ってなければ
		JNZ	MIXER_OUT_20
		;
		MOV	AL,BYTE PTR [BGM_WORKS+SSG_NOISE]
		MOV	NOW_NOISE,AL
		MOV	AL,BYTE PTR [BGM_WORKS+SSG_MIXER]
		MOV	NOW_MIXER,AL
		;
		JMP	MIXER_OUT_30
MIXER_OUT_20:
		MOV	AL,BYTE PTR [BGM_WORKS+SSG_NOISE]
		MOV	NOW_NOISE,AL
		;
		CALL	NOISE_CHECK		;効果音でノイズが鳴っている
		JNC	MIXER_OUT_201
		;
		MOV	AL,BYTE PTR [EFF_WORKS+SSG_NOISE]
		MOV	NOW_NOISE,AL
MIXER_OUT_201:
		MOV	DI,OFFSET CNL_EFF_WK+3
		XOR	DH,DH
		MOV	DL,00001001B
		MOV	CX,3
MIXER_OUT_21:
		MOV	AL,BYTE PTR [BGM_WORKS+SSG_MIXER]
		CMP	BYTE PTR [DI],0
		JZ	MIXER_OUT_22
		MOV	AL,BYTE PTR [EFF_WORKS+SSG_MIXER]
MIXER_OUT_22:
		AND	AL,DL
		OR	DH,AL
		SHL	DL,1
		INC	DI
		LOOP	MIXER_OUT_21
		MOV	NOW_MIXER,DH
MIXER_OUT_30:
		
NOISE_MIXER_OUT:
		MOV	DH,NOW_NOISE
		CMP	DH,BEFORE_NOISE
		JZ	NOISE_NOT_OUT
		MOV	BEFORE_NOISE,DH
		MOV	DL,6
		CALL	OPN_OUT
NOISE_NOT_OUT:
		MOV	DH,NOW_MIXER
		CMP	DH,BEFORE_MIXER
		JZ	MIXER_NOT_OUT
		MOV	BEFORE_MIXER,DH
		MOV	DL,7
		CALL	OPN_OUT
MIXER_NOT_OUT:
		RET

*/

/******************************************************************************
;	○ PANの設定
******************************************************************************/
public static void MDZ_setPan(MDZ_WORK work,MDZ_CNL cnlwork){
	if(cnlwork.cnl_cate==MDZ_BGMDATA._RITHM_F){
		MDZ_setPanRITHM(work,cnlwork);
		return;
	}
	int n=MDZ_getCommandUint8(work,cnlwork);
	//
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_setPanFM(work,cnlwork,n);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_MixersetSSG(work,cnlwork,n);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_setPanADPCM(work,cnlwork,n);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_setPanPPZ8(work,cnlwork,n);break;
	}
}
public static void MDZ_setPanFM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	if(n<0 || n>3){
		MDZDebug.Log("MDZ_setPanFM Error !!:"+n);
		return;
	}
//	MDZ_setPanPPZ8(work,cnlwork,g_ppz_pan_tbl[n]);
	cnlwork.pan=n;
	int port=cnlwork.cnl_port_num;
	int reg=cnlwork.fm_cnl_number+0xb4;
	//int pan=cnlwork.pan & 3;
	//pan=g_spb_pan_tbl[pan & 3];
	//int val=pan << 6;
	//int val=g_spb_pan_tbl[cnlwork.pan & 3] << 6;
	int val=(cnlwork.pan & 3) << 6;
	work.OutReg(port,reg,val);
}
/*
	;=======================================
	;	ＦＭのパン設定
	;=======================================
SPB_PAN_TBL	DB	0,2,1,3		;SPBのPAN補正
FM_PAN_SET:
		MOV	DL,[BX+PAN]
		;
		AND	DX,3			;PAN修正
		MOV	DI,DX
		MOV	DH,[DI+SPB_PAN_TBL]
		;
		ROR	DH,1
		ROR	DH,1
		MOV	DL,[BX+FM_CNL_NUMBER]	//0-2
		ADD	DL,0B4H
		CALL	OPN_OUT
		RET

*/
//public static void MDZ_setPanSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
//	MDZ_setPanPPZ8(work,cnlwork,5);
//}
public static void MDZ_setPanADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	if(n<0 || n>3){
		MDZDebug.Log("MDZ_setPanADPCM Error !!:"+n);
		return;
	}
	MDZ_setPanPPZ8(work,cnlwork,g_ppz_pan_tbl[n]);
}
public static void MDZ_setPanPPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	if(n<0 || n>9){
		MDZDebug.Log("MDZ_setPanPPZ8 Error !!:"+n);
		return;
	}
	cnlwork.pan=n;
	cnlwork.state.apan=false;
	work.setCnlPan(cnlwork.pcm_work,cnlwork.pan);
	//if(cnlwork.pcm_work!=null){
	//	cnlwork.pcm_work.pan=cnlwork.pan;
	//}
}
/*
PAN_SET:
		MOV	AL,[ESI]
		INC	ESI
		MOV	[EBX+P_PAN],AL
		;
		AND	DWORD PTR [EBX+P_STATE],NOT APAN_F ;オートパン停止
PAN_SET_SUB:
		MOV	AL,[EBX+P_PAN]
		MOV	EDI,[EBX+P_PCM_WORK]		;DI PCM_WORK_ADR
		MOV	[EDI+PCMW_PAN],AL
		RET
/******************************************************************************
;	○ オートPANの設定
******************************************************************************/
public static void MDZ_setAutoPan(MDZ_WORK work,MDZ_CNL cnlwork){
	int md   =MDZ_getCommandUint8(work,cnlwork);
	int speed=MDZ_getCommandUint8(work,cnlwork);
	int sorc =MDZ_getCommandUint8(work,cnlwork);
	int dist =MDZ_getCommandUint8(work,cnlwork);
	int flg  =MDZ_getCommandUint8(work,cnlwork);
	//オートパン開始
	MDZ_APAN apan=cnlwork.apan;
	apan.md   =md+1;
	apan.speed=speed;
	apan.sorc =sorc;
	apan.dist =dist;
	apan.flg  =flg;
	cnlwork.state.apan=true;
	MDZ_APanInit(work,cnlwork);
}
/*
AUTO_PAN_SET:
		OR	DWORD PTR [EBX+P_STATE],APAN_F	;オートパン開始
		;
		MOV	AL,[ESI+0]
		INC	AL
		MOV	[EBX+APAN_MD],AL
		MOV	AL,[ESI+1]
		MOV	[EBX+APAN_SPEED],AL
		MOV	AL,[ESI+2]
		MOV	[EBX+APAN_SORC],AL
		MOV	AL,[ESI+3]
		MOV	[EBX+APAN_DIST],AL
		MOV	AL,[ESI+4]
		MOV	[EBX+APAN_FLG],AL
		ADD	ESI,5
		;
		JMP	APAN_INIT
*/
public static void MDZ_APanInit(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_APAN apan=cnlwork.apan;
	apan.md_cnt   =apan.md;
	apan.speed_cnt=apan.speed;
	apan.sorc_w   =apan.sorc;
	apan.num      =apan.sorc;
	apan.dist_w   =apan.dist;
	if(apan.sorc==apan.dist){
		cnlwork.state.apan=false;
	}else{
		if(apan.sorc<apan.dist){
			apan.add= 1;
		}else{
			apan.add=-1;
		}
		work.setCnlPan(cnlwork.pcm_work,apan.sorc);
		//if(cnlwork.pcm_work!=null){
		//	//cnlwork.pcm_work.pan=apan.add;
		//	cnlwork.pcm_work.pan=apan.sorc;
		//}
	}
}
/*
APAN_INIT:
		MOV	AL,[EBX+APAN_MD]
		MOV	[EBX+APAN_MD_CNT],AL
		MOV	AL,[EBX+APAN_SPEED]
		MOV	[EBX+APAN_SPEED_CNT],AL
		MOV	AL,[EBX+APAN_SORC]
		MOV	[EBX+APAN_SORC_W],AL
		MOV	[EBX+APAN_NUM],AL
		MOV	AH,[EBX+APAN_DIST]
		MOV	[EBX+APAN_DIST_W],AH
		MOV	DL,1
		CMP	AL,AH
		JZ	APAN_INIT_09
		JB	APAN_INIT_01
		NEG	DL
APAN_INIT_01:
		MOV	[EBX+APAN_ADD],DL
		;
		MOV	EDI,[EBX+P_PCM_WORK]		;EDI PCM_WORK_ADR
		MOV	[EDI+PCMW_PAN],DL
		RET
APAN_INIT_09:
		AND	DWORD PTR [EBX+P_STATE],NOT APAN_F ;オートパン停止
		RET
*/
/******************************************************************************
;	○ 休符でキーオフするか
******************************************************************************/
public static void MDZ_restOffset(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	if(n==0){
		cnlwork.state.rest_off=false;
	}else{
		cnlwork.state.rest_off=true;
	}
}
/*
REST_OFF_SET:
		MOV	AL,[ESI]
		INC	ESI
		OR	AL,AL
		JNZ	REST_OFF_SET_01
		AND	DWORD PTR [EBX+P_STATE],NOT REST_OFF_F
		RET
REST_OFF_SET_01:
		OR	DWORD PTR [EBX+P_STATE],REST_OFF_F
		RET
*/
/******************************************************************************
;	○ 音色切り替え
******************************************************************************/
public static void MDZ_OtoCom(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	switch(cnlwork.cnl_cate){
		case MDZ_BGMDATA._FM_F   :MDZ_OtosetFM(work,cnlwork,n);break;
		case MDZ_BGMDATA._SSG_F  :MDZ_OtosetSSG(work,cnlwork,n);break;
		case MDZ_BGMDATA._ADPCM_F:MDZ_OtosetADPCM(work,cnlwork,n);break;
		case MDZ_BGMDATA._PPZ8_F :MDZ_OtosetPPZ8(work,cnlwork,n);break;
	}
}
public static void MDZ_OtosetFM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.oto_num=n;
	cnlwork.fm_now_oto=work.bgmr.fm_oto+n*25;
	int port=cnlwork.cnl_port_num;
	int reg;
	//RR End
	reg=cnlwork.fm_cnl_number+0x80;
	for(int i=0;i<4;i++){
		work.OutReg(port,reg,15);
		reg+=4;
	}
	//
	int adr=cnlwork.fm_now_oto;
	reg=cnlwork.fm_cnl_number+0x30;
	for(int i=0;i<24;i++){
		int data=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr);
		work.OutReg(port,reg,data);
		reg+=4;
		adr++;
	}
	//ALG
	int alg=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr);
	reg+=0x20;
	work.OutReg(port,reg,alg);
	cnlwork.fm_alg=fm_alg_tbl[alg & 0x7];
	cnlwork.before_vol=255;
	//
	MDZ_volOutFM(work,cnlwork);
}
public static void MDZ_OtosetSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.oto_num=n;
	MDZ_ENV env=cnlwork.env;
	//
	int adr=work.bgmr.ssg_oto+n*6;
	int sv=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr+0);
	int ar=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr+1);
	int dr=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr+2);
	int sl=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr+3);
	int sr=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr+4);
	int rr=MDZ_BGMDATA.MDZ_getDataUint8(work.bgmr.data,adr+5);
	//
	env.sv=sv;
	env.ar=ar;
	env.dr=dr;
	env.sl=sl;
	env.sr=sr;
	env.rr=rr;
}
public static void MDZ_OtosetADPCM(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	MDZ_OtosetPPZ8(work,cnlwork,n);
}
public static void MDZ_OtosetPPZ8(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	if(cnlwork.oto_num!=n){
		cnlwork.oto_num=n;
		MDZ_setOto(work,cnlwork);
	}
}
/*
OTO_COM:
		MOV	AL,[ESI]
		INC	ESI
		CMP	AL,[EBX+P_OTO_NUM]
		JZ	OTO_COM_01
		MOV	[EBX+P_OTO_NUM],AL
		PUSH	ESI
		CALL	SET_OTO
		POP	ESI
OTO_COM_01:
		RET
*/

/******************************************************************************
;	○ バンク切り替え
******************************************************************************/
public static void MDZ_selectBank(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint16(work,cnlwork);
	//
	if(n<0 || n>=MDZ_BGMDATA.PZI_BANK_MAX){
		MDZDebug.Log("BankSel Bank["+n+"] Error !!");
	}
	if(cnlwork.oto_bank!=n){
		cnlwork.oto_bank=n;
		MDZ_setOto(work,cnlwork);
	}
}
/*
BANK_SEL:
		MOV	AX,[ESI]
		ADD	ESI,2
		CMP	AL,[EBX+P_OTO_BANK]
		JZ	BANK_SEL_01
		MOV	[EBX+P_OTO_BANK],AL
		PUSH	ESI
		CALL	SET_OTO
		POP	ESI
BANK_SEL_01:
		RET
*/
/******************************************************************************
;	○ PCMループポインタ設定
******************************************************************************/
public static void MDZ_setLoopPoint(MDZ_WORK work,MDZ_CNL cnlwork){
	int bank  =MDZ_getCommandUint8(work,cnlwork);	//0
	int num   =MDZ_getCommandUint8(work,cnlwork);	//1
	int start =MDZ_getCommandUint32(work,cnlwork);	//2,3
	int end   =MDZ_getCommandUint32(work,cnlwork);	//6,7
	//
	if(bank<0 || bank>=work.pzi_lp.Length){
		MDZDebug.Log("MDZ_setLoopPoint:Bank Error!!:bank("+bank+")");
		return;
	}
	if(num<0 || work.pzi_lp[bank].tbl==null || num>=work.pzi_lp[bank].tbl.Length){
		MDZDebug.Log("MDZ_setLoopPoint:Num Error!!:bank("+bank+"),num("+num+")");
		return;
	}
	
	work.pzi_lp[bank].tbl[num].start=start;
	work.pzi_lp[bank].tbl[num].end  =end;
	//
	//他のチャネルの音色も変更
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnlwork2=work.bgm[i];
		if(cnlwork2.state.stop)continue;
		if(cnlwork2.oto_bank==bank && cnlwork2.oto_num==num){
			MDZ_setOto(work,cnlwork2);
		}
	}

}
/*
LOOP_POINT_SET:
		MOVZX	EAX,BYTE PTR [ESI+0]	;BANK
		MOVZX	EDI,BYTE PTR [ESI+1]	;NUM
		SHL	EAX,10
		LEA	EDI,[EDI*8+EAX+PZI_LP_WORK]
		;
		MOV	EAX,[ESI+2]		;START_POINT
		MOV	[EDI+0],EAX
		MOV	EAX,[ESI+6]		;END_POINT
		MOV	[EDI+4],EAX
		MOV	AX,[ESI]		;AX BANK,NUM
		ADD	ESI,10
	;他のチャネルの音色も変更
		_PUSH	EBX,ESI
		MOV	EBX,OFFSET BGM_WORK
		MOV	ECX,BGM_CNL_MAX
LP_SET_01:
		TEST	DWORD PTR [EBX+P_STATE],STOP_F
		JNZ	LP_SET_02
		CMP	AL,[EBX+P_OTO_BANK]
		JNZ	LP_SET_02
		CMP	AH,[EBX+P_OTO_NUM]
		JNZ	LP_SET_02
		_PUSH	EAX,ECX
		CALL	SET_OTO
		_POP	EAX,ECX
LP_SET_02:
		ADD	EBX,BGM_WORK_ONE
		DEC	ECX
		JNZ	LP_SET_01
		_POP	EBX,ESI
		;
		RET
*/
/******************************************************************************
;	○ エンベロープ設定
******************************************************************************/
public static void MDZ_setEnv(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_ENV env=cnlwork.env;
	int sv=MDZ_getCommandUint8(work,cnlwork);
	int ar=MDZ_getCommandUint8(work,cnlwork);
	int dr=MDZ_getCommandUint8(work,cnlwork);
	int sl=MDZ_getCommandUint8(work,cnlwork);
	int sr=MDZ_getCommandUint8(work,cnlwork);
	int rr=MDZ_getCommandUint8(work,cnlwork);
	//
	env.sv=sv;
	env.ar=ar;
	env.dr=dr;
	env.sl=sl;
	env.sr=sr;
	env.rr=rr;
}
/*
ENV_SET:
		MOV	EAX,[ESI+0]
		MOV	CX,[ESI+4]
		MOV	[EBX+ENV_SV+0],EAX
		MOV	[EBX+ENV_SV+4],CX
		ADD	ESI,6
		RET
*/
/******************************************************************************
;	○ 相対移調
******************************************************************************/
public static void MDZ_SIcho(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandSint8(work,cnlwork);
	if(n==0){
		cnlwork.soutai_icho=0;
	}else{
		cnlwork.soutai_icho+=n;
	}
}
/*
S_ICHO:
		MOV	AL,[ESI]
		INC	ESI
		OR	AL,AL
		JNZ	S_ICHO_01
		MOV	[EBX+P_SOUTAI_ICHO],AL
		RET
S_ICHO_01:
		ADD	[EBX+P_SOUTAI_ICHO],AL
		RET
*/
/******************************************************************************
;	○ フェードアウト
******************************************************************************/
public static void MDZ_fadeCom(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	MDZ_fadeBgm(work,n);
}
/*
FADE_COM:
		MOV	AL,[ESI]
		INC	ESI
		JMP	FADE_INIT
*/
/******************************************************************************
;	○ 外部にデータを送る
******************************************************************************/
public static void MDZ_sendDataCom(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	work.sent_data=n;
}
/*
SENT_DATA_COM:
		MOV	AL,[ESI]
		INC	ESI
		MOV	SENT_DATA,AL
		RET
*/
/******************************************************************************
;	○ ダミー
******************************************************************************/
public static void MDZ_DummyCom(MDZ_WORK work,MDZ_CNL cnlwork){
}
/*
DUMMY_COM:
		RET
*/
/******************************************************************************
;		ワーク
******************************************************************************/
/*
;16bitステレオ.8bitモノラル
;16bitステレオ.8bitステレオ
;16bitステレオ.16bitモノラル
;16bitステレオ.16bitステレオ
;16bitステレオ.8bitモノラル
;16bitステレオ.8bitステレオ
DIST_CATE_SHIFT	DB	2,1,1,0,2,1		;
INIT_FLG		DB	0					;初期化フラグ
BGM_STATE		DB	0					;BGM演奏フラグ
BGM_DATA_ADR	DD	0				;BGMデータアドレス
BGM_DATA_SIZE	DD	0				;BGMデータサイズ
	public	_bgm_work
_bgm_work		label	byte
BGM_WORK		DB	BGM_WORK_SIZE DUP(?)	;BGMワーク
	PUBLIC	_pcmw_work
_pcmw_work		LABEL	BYTE
PCMW_WORK		DB	PCMW_WORK_SIZE DUP(?)	;PCMワーク
KEY_ON_TBL		DW	BGM_CNL_MAX	DUP(?)		;キーオンテーブル
DIST_CATE		DB	0						;PCMの種別

BGMR_WORK		DB	BGMR_WORK_SIZE DUP(?)	;BGMRワーク

SOUTAI_TEMPO	DD	0			;
SRC_TEMPO		DD	0			;元のテンポ
NOW_TEMPO		DD	0			;現在のテンポ
SENT_DATA		DB	0			;外部出力データ
DST_PZI_ADR		DD	0			;
FADE_CNT		DB	0			;フェードカウンタ
FADE_CNT2		DB	0			;フェードカウンタ2
FADE_VOL		DB	0			;フェードボリューム
FADE_FLG		DB	0			;フェードフラグ
KEY_CHECK_FLG	DB	0			;キーチェックフラグ
PAUSE_FLG		DB	0			;ﾎﾟｰｽﾞのフラグ
DIST_RATE		DD	0			;再生レート
NOW_CONV_PVI	DB	0			;現在コンバート中のPVI
ONE_LOOP_FLG	DB	0			;1回ループで終わる
;ONE_LOOP_END	DB	0			;1回ループで終わるフラグ
LOOP_IS_FLG		DB	0			;ループする
LOOP_IS_ADR		DD	0			;ループするアドレス
END_IS_ADR		DD	0			;ENDアドレス
PZI_BANK_TBL	DD	PZI_BANK_MAX	DUP(0)	;
	public	_pzi_lp_work
_pzi_lp_work	label	byte
PZI_LP_WORK	DB	PZIL_WORK_SIZE*PZI_BANK_MAX DUP(?)
PCM_BUFF_SIZE	DD	DEF_PBUFF_VOL		;PCMバッファの大きさ
PCM_BUFF_ADR	DD	0			;PCMバッファアドレス
PCM_BADR_WK		DD	0			;PCMバッファアドレス
PCM_BADR_WKS	DD	0			;PCMバッファアドレス
PCM_ONE_STEP	DD	0			;PCM1回の処理量
PCM_STEP_CNT	DD	0			;PCM1回の処理量のカウンタ
PCM_LEFT_CNT	DD	0			;PCM残りバッファ
PCM_DIST_ADR	DD	0			;
PCM_DIST_SIZE	DD	0			;
PCM_NOW_MAKESIZE DD	0			;
DECODE_PVI_SIZE	DD	0			;
DECODE_PZI_SIZE	DD	0			;
PCMW_VOL_WK	DD	0			;
	PUBLIC	_mdz_supply_flg
_mdz_supply_flg	DD	1
		;PCM変換時のワーク
NOW_ADPCM	DW	0			;現在 の ADPCM
DELTA_N		DW	0			;DELTA_N
X_N		DW	0,0			;Xn
F_TBL		DW	57*4,57*4,57*4,57*4,77*4,102*4,128*4,153*4
;LFOのオフセットとフラグ
LFO_TBL		DD	P_PLFO,P_QLFO,P_RLFO
LFO_COM_TBL	DD	PLFO_F,QLFO_F,RLFO_F,ALFO_F,HLFO_F
;コマンドテーブル 081H~0FFH
COMMAND_TBL	DD	VOL_SET		;81H 音量セット
		DD	VOL_UP		;82H 音量アップ
		DD	VOL_DOWN	;83H 音量ダウン
		DD	DUMMY_COM	;84H テンポセット
		DD	JUMP_COM	;85H ジャンプ
		DD	LOOP_COM	;86H ループ
		DD	LOOP_OUT	;87H ループアウト
		DD	QUOTA_SET	;88H ゲートタイムセット
		DD	DETUNE_SET	;89H ディチューン
		DD	LFO_SET		;8AH LFO セット
		DD	LFO_COM		;8BH LFO ON/OFF
		DD	DUMMY_COM	;8CH OPN 直接書き込み
		DD	OTO_COM		;8DH 音色セット
		DD	PAN_SET		;8EH PAN セット
		DD	DUMMY_COM	;8FH ノイズセット
		DD	ENV_SET		;90H ソフトエンベロープのセット
		DD	VOL_SET2	;91H 詳細音量セット
		DD	TAI_SET		;92H タイ
		DD	LOOP_SET	;93H ループ左カッコ
		DD	DUMMY_COM	;94H 同期信号をおくる
		DD	DUMMY_COM	;95H 同期信号がくるまで待つ
		DD	FADE_COM	;96H フェードアウト
		DD	DUMMY_COM	;97H ピッチベンド
		DD	DUMMY_COM	;98H PCM の周波数
		DD	SENT_DATA_COM	;99H データを送る
		DD	S_ICHO		;9AH 相対移調
		DD	SURA_SET	;9BH スラー
		DD	DEF_LEN_SET	;9CH デフォルト音長の設定
		DD	BANK_SEL	;9DH バンクの設定
		DD	DUMMY_COM	;9EH MIDIエフェクト
		DD	DUMMY_COM	;9FH ベンドレンジ
		DD	DUMMY_COM	;A0H ベロシティUP
		DD	DUMMY_COM	;A1H ベロシティDOWN
		DD	DUMMY_COM	;A2H チャネル番号設定
		DD	DUMMY_COM	;A3H PPZのPAN設定
		DD	DUMMY_COM	;A4H ベロシティセット
		DD	AUTO_PAN_SET	;A5H オートパン設定
		DD	REST_OFF_SET	;A6H 休符でキーオフする
		DD	DUMMY_COM	;A7H TIMERA指定
		DD	TEMPO_SET	;A8H テンポ指定
		DD	VEND_SET	;A9H ベンド設定2
		DD	LOOP_POINT_SET	;AAH ループポインタ設定
		DD	LOOP_IS		;ABH ループだ
	;音程のテーブル[o8]
PCM_ONTEI_TBL	DD	08000H		;00 c
		DD	087A6H		;01 d-
		DD	08FB3H		;02 d
		DD	09838H		;03 e-
		DD	0A146H		;04 e
		DD	0AADEH		;05 f
		DD	0B4FFH		;06 g-
		DD	0BFCCH		;07 g
		DD	0CB34H		;08 a-
		DD	0D747H		;09 a
		DD	0E418H		;10 b-
		DD	0F1A5H		;11 b
		;
PCM_VOL_TBL	LABEL	WORD			;ボリュームデータ
;		INCLUDE	VOL16_64.INC
		INCLUDE	VOL8_64.INC

PUZ_CATE_TBL	LABEL	WORD
		DW	0,0



/*******************************************************************************
;		おしまい
/******************************************************************************/
}


//======================
}
}
