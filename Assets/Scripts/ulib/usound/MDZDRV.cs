/*-----------------------------------------------------------------------------
;	MDZ�h���C�o�[
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
public const int BGM_CNL_MAX			=16;			//BGM�`���l����
public const int PZI_BANK_MAX		=4;				//�o���N��
//public const int X_N0				=0x80;			//Xn �̏����l
//public const int DELTA_N0			=127;			//DELTA_N �̏����l
//public const int DEF_PBUFF_VOL		=0x400;			//�����o�b�t�@�̑傫��
public const int DEF_TEMPO			=120;			//�f�t�H���g�e���|
public const int TEMPO_MIN			=30;
public const int TEMPO_MAX			=1024;
public const int CNL_LOOPSTACK_MAX	=20;			//���[�v�X�^�b�N��


public const int ADPCM_VOL_SCALE			=150;
public const int SSG_VOL_SCALE			=85;
public const int RITHM_VOL_SCALE			=110;
public const int SSGPPZ8_VOL_SCALE		=150;

/******************************************************************************
;	PVI&PZI�f�[�^�t�H�[�}�b�g
******************************************************************************/
//public const  int PZI_TBL_NUM		=128;			//PZI�e�[�u���̐�
/*
public const  int PVI_NUM_MAX		=0x0B;		//PVI�f�[�^�̒�`��
public const  int PVI_TBL_NUM		=128;			//PVI�e�[�u����
public const  int PVI_TBL_TOP		=0x010;		//PVI�e�[�u���̐擪
public const  int PVI_DATA_TOP		=0x210;		//ADPCM�f�[�^�̐擪
public const  int PVIT_WORK_ONE		=4;			//

public const  int PZI_NUM_MAX		=0x0B;		//PZI�f�[�^�̒�`��
public const  int PZI_TBL_TOP		=0x020;		//PZI�e�[�u���̐擪
public const  int PZI_DATA_TOP		=0x920;		//PCM�f�[�^�̐擪

public const  int PZIT_START			=0x00;		//
public const  int PZIT_END			=0x04;		//
public const  int PZIT_LOOP_START	=0x08;		//
public const  int PZIT_LOOP_END		=0x0C;		//
public const  int PZIT_RATE			=0x10;		//
public const  int PZIT_WORK_ONE		=0x12;		//PZI_TBL�T�C�Y

public const  int PZIL_START			=0;			//
public const  int PZIL_END			=4;			//
public const  int PZIL_WORK_ONE		=8;			//PZI_LOOP�T�C�Y
public const  int PZIL_WORK_SIZE		=(PZIL_WORK_ONE*PZI_TBL_NUM);	//���[�v�e�[�u��
/******************************************************************************
;		�X�e�[�^�X�̃t���O
******************************************************************************/
/*
//�X�e�[�^�X
//					FEDCBA9876543210FEDCBA9876543210
public const int TAI_F		=0x00000001;	//00000000000000000000000000000001 �^�C
public const int TAI_F2		=0x00000002;	//00000000000000000000000000000010 �^�C2
public const int STOP_F		=0x00000004;	//00000000000000000000000000000100 ��~
public const int REST_F		=0x00000008;	//00000000000000000000000000001000 �x��
public const int KON_F		=0x00000010;	//00000000000000000000000000010000 �L�[�I��
public const int KOFF_F		=0x00000020;	//00000000000000000000000000100000 �L�[�I�t
public const int START_F		=0x00000040;	//00000000000000000000000001000000 �X�^�[�g
public const int VEND_F		=0x00000080;	//00000000000000000000000010000000 �x���h
public const int PLFO_F		=0x00000100;	//00000000000000000000000100000000 P_LFO
public const int QLFO_F		=0x00000200;	//00000000000000000000001000000000 Q_LFO
public const int RLFO_F		=0x00000400;	//00000000000000000000010000000000 R_LFO
public const int ALFO_F		=0x00000800;	//00000000000000000000100000000000 A_LFO
public const int HLFO_F		=0x00001000;	//00000000000000000001000000000000 H_LFO
public const int KON_R_F		=0x00002000;	//00000000000000000010000000000000 �L�[�I��
public const int SURA_F		=0x00004000;	//00000000000000000100000000000000 �X���[
public const int SURA_F2		=0x00008000;	//00000000000000001000000000000000 �X���[�Q
public const int APAN_F		=0x00010000;	//00000000000000010000000000000000 APAN
public const int AR_F		=0x00020000;	//00000000000000100000000000000000 AR
public const int DR_F		=0x00040000;	//00000000000001000000000000000000 DR
public const int SR_F		=0x00080000;	//00000000000010000000000000000000 SR
public const int REST_OFF_F	=0x00100000;	//00000000000100000000000000000000 REST_OFF
public const int ONELOOP_F	=0x00200000;	//00000000001000000000000000000000 1������
*/
/******************************************************************************
;		�`���l�����Ƃ̃��[�N
******************************************************************************/
/*
public const int P_LOOP_STACK	=0;			//20byte ���[�v�X�^�b�N
public const int P_LOOP_ADR		=20;		//4byte  ���[�v�X�^�b�N�̃A�h���X
public const int P_DATA_ADR		=24;		//4byte  �f�[�^�A�h���X
public const int P_PCM_WORK		=28;		//4byte  PCM���[�N�A�h���X
public const int P_STATE			=32;		//4byte  �X�e�[�^�X
public const int P_DEF_LEN		=36;		//2byte  �f�t�H���g�̉���
public const int P_LEN_WK		=38;		//2byte  �����̃J�E���^
public const int P_WAVE			=40;		//2byte  ���݂̎��g��
public const int P_BEFORE_WAVE	=42;		//2byte  �O�̎��g��
public const int P_QUOTA_WK		=44;		//2byte  �Q�[�g�^�C���J�E���^
public const int P_DETUNE		=46;		//2byte  �f�B�`���[��
public const int P_CNL_NUMBER	=48;		//1byte  �`���l���ԍ�
public const int P_QUOTA			=49;		//1byte  �Q�[�g�^�C��
public const int P_NOW_ONTEI		=50;		//1byte  ���݂̉���
public const int P_BEFORE_ONTEI	=51;		//1byte  �O�̉���
public const int P_VOL			=52;		//1byte  �{�����[��
public const int P_BEFORE_VOL	=53;		//1byte  �O�̉���
public const int P_SOUTAI_ICHO	=54;		//1byte  ���Έڒ��̒l
public const int P_PAN			=55;		//1byte  PAN
public const int P_OTO_NUM		=56;		//1byte  ���F�ԍ�
public const int P_OTO_BANK		=57;		//1byte  �o���N�ԍ�
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

public const int BGM_WORK_ONE	=160;		//���[�N�̑傫��
public const int BGM_WORK_SIZE	=(BGM_WORK_ONE*BGM_CNL_MAX);	//
*/
/******************************************************************************
;	LFO,VEND,ENV,APAN�֌W
******************************************************************************/
/*
public const int LFO_MD			=0;			//	LFO�f�F���C
public const int LFO_MD_CNT		=1;			//	LFO�f�F���C�J�E���^
public const int LFO_SPEED		=2;			//	LFO�X�s�[�h
public const int LFO_SPEED_CNT	=3;			//	LFO�X�s�[�h�J�E���^
public const int LFO_RATE		=4;			//2byte	LFO�傫��
public const int LFO_RATE_SUB	=6;			//2byte	LFO�傫���T�u
public const int LFO_DEPTH		=8;			//	LFO�[��
public const int LFO_DEPTH_CNT	=10;		//	LFO�[���J�E���^
public const int LFO_WAVE_NUM	=11;		//	LFO�̔g�`�ԍ�
public const int LFO_SIZE		=12;		//	LFO�̃��[�N�̑傫��

public const int VEND_MD_CNT		=P_VEND+0;	//	�s�b�`�x���h�̃f�����C
public const int VEND_SPEED		=P_VEND+1;	//	�s�b�`�x���h�̃X�s�[�h
public const int VEND_SPEED_CNT	=P_VEND+2;	//	�s�b�`�x���h�̃X�s�[�h�J�E���^
public const int VEND_ONTEI		=P_VEND+3;	//	�s�b�`�x���h�̉���
public const int VEND_RATE		=P_VEND+4;	//2byte	�s�b�`�x���h�̑傫��
public const int VEND_WAVE		=P_VEND+6;	//2byte	�s�b�`�x���h�̖ڕW���g��
public const int VEND_SIZE		=8;			//	�x���h�̃��[�N�̑傫��

public const int ENV_VOL2		=P_ENV+0;		//	�G���x���[�v�p�{�����[��
public const int ENV_SV			=P_ENV+1;		//	�G���x���[�v�p�X�^�[�g�{�����[
public const int ENV_AR			=P_ENV+2;		//	�A�^�b�N���[�g
public const int ENV_DR			=P_ENV+3;		//	�f���P�C���[�g
public const int ENV_SL			=P_ENV+4;		//	�T�X�e�B�����x��
public const int ENV_SR			=P_ENV+5;		//	�T�X�e�B�����[�g
public const int ENV_RR			=P_ENV+6;		//	�����[�X���[�g
public const int ENV_SIZE		=8;				//	�G���x���[�v�̃��[�N�̑傫��

public const int APAN_MD			=P_APAN+0;	//	�f�����C
public const int APAN_MD_CNT		=P_APAN+1;	//	�f�����C
public const int APAN_SPEED		=P_APAN+2;	//	�X�s�[�h
public const int APAN_SPEED_CNT	=P_APAN+3;	//	�X�s�[�h�J�E���^
public const int APAN_SORC		=P_APAN+4;	//	PAN�\�[�X
public const int APAN_DIST		=P_APAN+5;	//	PAN�f�B�X�g
public const int APAN_SORC_W		=P_APAN+6;	//	PAN�\�[�X
public const int APAN_DIST_W		=P_APAN+7;	//	PAN�f�B�X�g
public const int APAN_NUM		=P_APAN+8;	//	���݂�PAN
public const int APAN_ADD		=P_APAN+9;	//	PAN���Z����
public const int APAN_FLG		=P_APAN+10;	//	PAN�̎��
public const int APAN_SIZE		=12;		//
*/
/******************************************************************************
;	PCM�`���l�����[�N
******************************************************************************/
/*
public const int PCMW_STATE		=0;		//1byte �X�e�[�^�X
public const int PCMW_VOL		=1;		//1byte ����
public const int PCMW_PAN		=2;		//1byte �p��
public const int PCMW_LOOP_FLG	=3;		//1byte ���[�v�t���O
public const int PCMW_KEYON		=4;		//1byte KEYON_FLG
public const int PCMW_SRC_RATE	=6;		//2byte ���f�[�^ڰ�
public const int PCMW_ADD_L		=8;		//4byte �A�h���X������ LOW
public const int PCMW_ADD_H		=12;		//4byte �A�h���X������ HIGH
public const int PCMW_NOW_XOR	=16;		//4byte ���݂̃A�h���X,�����_��
public const int PCMW_NOW_ADR	=20;		//4byte ���݂̃A�h���X,������
public const int PCMW_END_ADR	=24;		//4byte ���݂̏I���A�h���X
public const int PCMW_LOOP_ADR	=28;		//4byte ���[�v�J�n�A�h���X

public const int PCMW_START_ADR	=32;		//4byte

public const int PCMW_WORK_ONE	=36;		//PCM���[�N�T�C�Y
public const int PCMW_WORK_SIZE	=(PCMW_WORK_ONE*PCM_CNL_MAX);	//�`���l������PCM���[�N
*/
/******************************************************************************
;	BGM���
******************************************************************************/
/*
public const int BGMR_PCM1_FILE	=0x00;		//;
public const int BGMR_PCM1_CATE	=0x04;		//;
public const int BGMR_PCM2_FILE	=0x08;		//;
public const int BGMR_PCM2_CATE	=0x0C;		//;
public const int BGMR_COMMENT	=0x10;		//;
public const int BGMR_QFLG		=0x14;		//;
public const int BGMR_CNL_NUM	=0x18;		//;
public const int BGMR_BASE_CNT	=0x1C;		//;��{�J�E���^
public const int BGMR_WORK_SIZE	=0x20;		//;
*/

/******************************************************************************
;		PCM�`���l�����[�N
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
	short pcm2_name;					//0x1a PCM2�̖��O
	short comment;						//0x1c �R�����g
	byte[] dummy3=new byte[6];			//
	short cnl_num;						//0x24 �`���l����
	short pcm1_name;					//0x26 PCM1�̖��O
	byte[] dummy4=new byte[2];			//
	short pcm1_cate;					//0x2a PCM1�̃^�C�v
	byte[] dummy5=new byte[4];			//
	short pcm1_cate_;					//0x2a
	//
	MDZ_HEADTBL[] tbl=new MDZ_HEADTBL[BGM_CNL_MAX];	//
};
*/


/*
//PZI�̈�̃f�[�^
static class PZIT{
	int start;					//�J�n�ʒu
	int end;					//�I���ʒu
	int loop_start;				//���[�v�J�n�ʒu
	int loop_end;				//���[�v�I���ʒu
	int rate;					//�����[�g
};
//PZI�̃w�b�_�[
static class PZIHEAD{
//	byte[] m=new byte[4];						//�w�b�_�[����
//	byte[] dummy=new byte[0x20-4];				//�_�~�[
	PZIT[] tbl=new PZIT[PZI_TBL_NUM];			//���F�e�[�u��
	byte[] pcmdata;
};
*/

//�p���e�[�u��
public static readonly int[] g_ppz_pan_tbl={0,1,9,5};

//FM�����̉����e�[�u��(618,1272,2.05825)
public static readonly int[] fm_ontei_tbl={
	0x026A,0x028F,0x02B6,0x02DF,0x030B,0x0339,
	0x036A,0x039E,0x03D5,0x0410,0x044E,0x048F
};
//SSG�̉����e�[�u��(3816,2022,1.8872403560830860534124629080119)
public static readonly int[] ssg_ontei_tbl={
	0x0EE8,0x0E12,0x0D48,0x0C89,0x0BD5,0x0B2B,
	0x0A8A,0x09F3,0x0964,0x08DD,0x085E,0x07E6
};
//ADPCM�̉����e�[�u��
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
//�����e�[�u��
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

//FM�����̉��ʃe�[�u��
public static readonly int[] fm_vol_tbl={
	0x38,0x34,0x30,0x2A,0x28,0x25,0x22,0x20,
	0x1D,0x1A,0x18,0x15,0x12,0x10,0x0D,0x09,
};
//SSG�̃~�L�T�[�o�̓f�[�^�쐬�e�[�u��
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
//FM�����̃A���S���Y���e�[�u��
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

public static readonly int[] g_spb_pan_tbl={0,2,1,3};		//SPB��PAN�␳


//���[�v�e�[�u��
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
//PCM�쐬�̃p�����[�^
public class MDZ_MakePara{
	public int loopadr;			//���[�v�A�h���X
	public int endadr;				//�I���A�h���X
	public int nowsize;			//���݂̃T�C�Y
	public bool play_flg;		//�Đ��I���t���O
};
/******************************************************************************
;	BGM�`�����l�����[�N
******************************************************************************/
//�`�����l���t���O
public class MDZ_CNLFLG{
	public bool tai;			//�^�C
	public bool tai2;		//�^�C2
	public bool stop;		//��~
	public bool rest;		//�x��
	public bool kon;			//�L�[�I��
	public bool koff;		//�L�[�I�t
	public bool start;		//�X�^�[�g
	public bool vend;		//�x���h
	public bool[] lfo=new bool[3]; //P,Q,R LFO
	public bool alfo;		//A_LFO
	public bool hlfo;		//H_LFO
	public bool kon_r;		//�L�[�I��
	public bool sura;		//�X���[
	public bool sura2;		//�X���[�Q
	public bool apan;		//APAN
	public bool rest_off;	//REST_OFF
	public bool oneloop;	//1������
	public bool onteiout;	//
	public bool mask;		//�`���l���}�X�N
	//
	public void Init(){
		tai=false;			//�^�C
		tai2=false;			//�^�C2
		stop=true;			//��~
		rest=false;			//�x��
		kon=false;			//�L�[�I��
		koff=false;			//�L�[�I�t
		start=false;		//�X�^�[�g
		vend=false;			//�x���h
		for(int i=0;i<lfo.Length;i++){
			lfo[i]=false;
		}
		alfo=false;			//A_LFO
		hlfo=false;			//H_LFO
		kon_r=false;		//�L�[�I��
		sura=false;			//�X���[
		sura2=false;		//�X���[�Q
		apan=false;			//APAN
		rest_off=false;		//REST_OFF
		oneloop=false;		//1������
		mask=false;			//
	}
};
//LFO
public class MDZ_LFO{
	public int md;				//LFO�f�F���C
	public int md_cnt;			//LFO�f�F���C�J�E���^
	public int speed;			//LFO�X�s�[�h
	public int speed_cnt;		//LFO�X�s�[�h�J�E���^
	public int rate;			//LFO�傫��
	public int rate_sub;		//LFO�傫���T�u
	public int depth;			//LFO�[��
	public int depth_cnt;		//LFO�[���J�E���^
	public int wave_num;		//LFO�̔g�`�ԍ�
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
	public int md_cnt;			//�s�b�`�x���h�̃f�����C
	public int speed;			//�s�b�`�x���h�̃X�s�[�h
	public int speed_cnt;		//�s�b�`�x���h�̃X�s�[�h�J�E���^
	public int ontei;			//�s�b�`�x���h�̉���
	public int rate;			//�s�b�`�x���h�̑傫��
	public int wave;			//�s�b�`�x���h�̖ڕW���g��
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
	public int vol2;			//�G���x���[�v�p�{�����[��
	public int sv;				//�G���x���[�v�p�X�^�[�g�{�����[
	public int ar;				//�A�^�b�N���[�g
	public int dr;				//�f���P�C���[�g
	public int sl;				//�T�X�e�B�����x��
	public int sr;				//�T�X�e�B�����[�g
	public int rr;				//�����[�X���[�g
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
//�I�[�gPAN
public class MDZ_APAN{
	public int md;				//�f�����C
	public int md_cnt;			//�f�����C
	public int speed;			//�X�s�[�h
	public int speed_cnt;		//�X�s�[�h�J�E���^
	public int sorc;			//PAN�\�[�X
	public int dist;			//PAN�f�B�X�g
	public int sorc_w;			//PAN�\�[�X
	public int dist_w;			//PAN�f�B�X�g
	public int num;				//���݂�PAN
	public int add;				//PAN���Z����
	public int flg;				//PAN�̎��
	//
	public void Init(){
		md=0;
		md_cnt=0;
	}
};
//�L�[�I����PCM�o�^�p���[�N
public class MDZ_PCMTone{
	public int start;			//�X�^�[�g
	public int end;				//�G���h
	public int loop;			//���[�v
	public int loopflg;			//���[�v�t���O
	public int rate;			//���[�g
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
		//���[�v���Ȃ��ꍇ
			this.loopflg=0;
			this.loop   =-1;
		}else{
		//���[�v����ꍇ
			this.loopflg=1;
			//���[�v�J�n�ʒu�̸د��ݸ�
			int loop=pzit.start+pzilt.start;
			if(loop>=pzit.end){
				loop=pzit.end-1;
			}
			this.loop=loop;
			//���[�v�I���ʒu�̸د��ݸ�
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
LOOP_STACK		EQU	00	;20byte	���[�v�X�^�b�N
LOOP_ADR		EQU	20	;2byte	���݂̃��[�v�X�^�b�N�A�h���X
DAT_ADR			EQU	22	;2byte	���݂̃f�[�^�A�h���X
STATE			EQU	24	;2byte	�X�e�[�^�X
DEF_LEN			EQU	26	;2byte	�f�t�H���g�̉���
LEN_WK			EQU	28	;2byte	�����O�X�J�E���^
WAVE			EQU	30	;4byte	���݂̎��g��
BEFORE_WAVE		EQU	34	;4byte	�O�̎��g��
QUOTA_WK		EQU	36	;2byte	�p�J�E���^
DETUNE			EQU	40	;2byte	�f�B�e���[��
CNL_CATE		EQU	42	;	�`���l���̎��
CNL_NUMBER		EQU	43	;	�`���l���ԍ�
CNL_PORT_NUM	EQU	44	;	�A�N�Z�X����|�[�g�ԍ�
QUOTA			EQU	45	;	�p
OCT_WK			EQU	46	;	���݂̃I�N�^�[�u
NOW_ONTEI		EQU	47	;	���݂̉���
BEFORE_ONTEI	EQU	48	;	�O�̉���
VOL				EQU	49	;	�{�����[��
BEFORE_VOL		EQU	50	;	�O�̉���
SOUTAI_ICHO		EQU	51	;	���Έڒ��̒l
PAN				EQU	52	;	�o�`�m
OTO_NUM			EQU	53	;	���F�ԍ�
STATE2			EQU	54	;2byte	�X�e�[�^�X�Q
REST_OFF_FLG	EQU	56	;	�x���ŃL�[�I�t���邩

;�g��
PLFO			EQU	60	;12byte	LFO1
QLFO			EQU	72	;12byte	LFO2
RLFO			EQU	84	;12byte	LFO3
VEND			EQU	96	;08byte	VEND

;FM�������[�N
ALFO			EQU	104	;08byte	LFOA
HLFO			EQU	112	;00byte	LFOH
FM_NOW_OTO		EQU	112	;2byte	FM�����̌��݂̉��F�A�h���X
FM_CNL_NUMBER	EQU	114	;	FM�����̔ԍ�
ALG				EQU	115	;	�A���S���Y��
;SSG���[�N
ENV				EQU	104	;08byte ENV
;���Y�����[�N
RT_VOL			EQU	60	;6byte	���Y���̃{�����[��
;PCM���[�N
PCM_START_ADR	EQU	104	;2byte	PCM�̊J�n�A�h���X
PCM_END_ADR		EQU	106	;2byte	PCM�̏I���A�h���X
PCM_DELTA_N		EQU	108	;2byte	PCM�̂c�d�k�s�`�Q�m
;PPZ8���[�N
APAN			EQU	104	;8byte	�I�[�gPAN


*/
//�`���l�����[�N
public class MDZ_CNL{
	//��{
	public int[] loop_stack=new int[CNL_LOOPSTACK_MAX];//���[�v�X�^�b�N
	public int loop_adr;						//���[�v�X�^�b�N�̃A�h���X
	public int data_adr;						//�f�[�^�A�h���X
	public MDZ_CNLFLG state=new MDZ_CNLFLG();	//�X�e�[�^�X
	public int def_len;							//�f�t�H���g�̉���
	public int len_wk;							//�����̃J�E���^
	public int wave;							//���݂̎��g��
	public int oct_wk;							//���݂̎��g��
	public int before_wave;						//�O�̎��g��
	public int quota_wk;						//�Q�[�g�^�C���J�E���^
	public int detune;							//�f�B�`���[��
	public int cnl_cate;						//�`���l�����
	public int cnl_number;						//�`���l���ԍ�
	public int cnl_port_num;					//�`���l���|�[�g�ԍ�
	public int quota;							//�Q�[�g�^�C��
	public int now_ontei;						//���݂̉���
	public int before_ontei;					//�O�̉���
	public int vol;								//�{�����[��
	public int before_vol;						//�O�̉���
	public int soutai_icho;						//���Έڒ��̒l
	public int pan;								//PAN
	public int oto_num;							//���F�ԍ�
	//�g��
	public MDZ_LFO[] lfo=new MDZ_LFO[3];		//LFO
	public MDZ_VEND vend=new MDZ_VEND();		//�s�b�`�x���h
	//FM
	public int fm_cnl_number;					//
	public int fm_now_oto;						//FM�����̌��݂̉��F�A�h���X
	public int fm_alg;							//�A���S���Y��
	//SSG/PPZ8
	public MDZ_ENV env=new MDZ_ENV();			//�G���x���[�v
	//���Y��
	public int[] rt_vol=new int[6];				//���Y���̃{�����[��
	//PPZ8
	public MDZ_APAN apan=new MDZ_APAN();			//�I�[�g�p��
	public MDZ_PCMTone pcmtone=new MDZ_PCMTone();	//PCM���F
	public int oto_bank;							//�o���N�ԍ�
	public int pcm_work;							//�g�p����PCM�`���l��
	//
	public MDZ_CNL(){
		for(int i=0;i<lfo.Length;i++){
			lfo[i]=new MDZ_LFO();
		}
		init();
	}
	public void init(){
		state.stop=true;
		loop_adr  =-1;				//(byte *)((int)&cnl.stack-1);//LOOP������
		data_adr  =0;				//�`���l���f�[�^
		state.Init();
		def_len   =0x30;			//�f�t�H���g�̉���
		len_wk    =1;				//�����J�E���^
		wave      =0;				//���݂̎��g��
		before_wave=0xffff;			//�O�̎��g��
		quota_wk  =1;				//Q�J�E���^
		detune    =0;				//�f�B�`���[��
		cnl_cate  =MDZ_BGMDATA._PPZ8_F;		//�`���l��Index
		cnl_number=0;				//�`���l��Index
		cnl_port_num=0;				//�`���l��Index
		quota     =1;				//Q
		now_ontei =0;				//���݂̉���
		before_ontei=0xffff;		//�O�̉���
		vol       =63;				//VOL
		before_vol=-1;				//�O�̉���
		soutai_icho=0;				//
		pan        =5;				//
		oto_num    =-1;				//���ԍ�
		//
		oto_bank   =0;				//�o���N�ԍ�
		pcm_work  =-1;				//�g�p����PCM�`���l��
		for(int i=0;i<lfo.Length;i++){
			lfo[i].Init();
		}
		vend.Init();				//�G���x���[�v������
		env.Init();					//�G���x���[�v������
		apan.Init();				//�G���x���[�v������
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
;		MDZ��
******************************************************************************/
public class MDZ_WORK{
	public byte[] keyon_tbl=new byte[BGM_CNL_MAX];
	public PZIL[] pzi_lp=new PZIL[PZI_BANK_MAX];
	public MDZ_CNL[] bgm=new MDZ_CNL[BGM_CNL_MAX];
	public MDZ_BGMDATA bgmr;
	public int soutai_tempo;					//���΃e���|
	public int fade_cnt;						//�t�F�[�h�J�E���^
	public int fade_cnt2;						//
	public int fade_vol;						//
	public int src_tempo;						//���̃e���|
	public int now_tempo;						//���ۂ̃e���|
	public int init_flg;						//���������ꂽ
	public int bgm_state;						//BGM��~
	public int loop_is_flg;						//���[�v�N���A
	public int loop_is_adr;						//���[�v�A�h���X
	public int end_is_adr;						//���t�I���A�h���X
	public int pause_flg;						//�|�[�Y�t���O
	public int one_loop_flg;					//
	public int sent_data;						//�O���o�̓f�[�^
	public int key_check_flg;					//�L�[�`�F�b�N�t���O
	public int ssg_noise;						//
	public int ssg_mixer;						//
	public int before_noise;					//
	public int before_mixer;					//
	//public int timer_flg;						//���݂̃^�C�}�[�̊��荞��
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
;	MDZ������
******************************************************************************/
public static bool MDZ_initWork(MDZ_WORK work){
	MDZ_initBgmWork(work);
	work.soutai_tempo=0;				//���΃e���|
	work.fade_cnt=0;					//�t�F�[�h�J�E���^
	work.fade_cnt2=0;
	work.fade_vol =0;
	work.src_tempo=DEF_TEMPO;			//���̃e���|
	work.now_tempo=DEF_TEMPO;			//���ۂ̃e���|
	work.key_check_flg=0;					//�L�[�`�F�b�N�t���O
	work.init_flg=1;					//���������ꂽ
	work.bgm_state=0;					//BGM��~
	work.loop_is_flg=0;					//���[�v�N���A
	work.loop_is_adr=-1;				//���[�v���A�h���X
	work.end_is_adr=-1;					//���t�I���A�h���X
	work.pause_flg=0;
	work.one_loop_flg=0;
	work.sent_data=0;					//�O���o�̓f�[�^
	work.key_check_flg=0;				//�L�[�`�F�b�N�t���O
	return true;
}
/******************************************************************************
;	BGM_WORK�̏�����
******************************************************************************/
public static bool MDZ_initBgmWork(MDZ_WORK work){
	work.bgm_state=0;					//BGM��~
	//ZeroMemory(work.bgm,sizeof(MDZ_CNL)*BGM_CNL_MAX);
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnl=work.bgm[i];
		cnl.init();
		cnl.state.stop=true;
	}
	return true;
}
/******************************************************************************
;	���ׂĂ�PZI���[�v�|�C���^�̏�����
******************************************************************************/
public static void MDZ_initLoopAll(MDZ_WORK work){
	for(int i=0;i<PZI_BANK_MAX;i++){
		MDZ_initLoopOne(work,i);
	}
}
/******************************************************************************
;	���PZI�̃��[�v�|�C���^�̏�����
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
;	�� ���t�J�n
;	void mus_play(void *mdz_data);
;	out	0 ����I��
;		1 �ُ�I��
******************************************************************************/
public static bool MDZ_playBgm(MDZ_WORK work,MDZ_BGMDATA bgmdata){
	if(work==null)return false;
	if(bgmdata==null)return false;
	//
	//���t��~
	MDZ_stopBgm(work);
	//BGM���[�N�̏�����
	MDZ_initBgmWork(work);
	work.p8_data=true;
	//�w�b�_�[�`�F�b�N
	//if(!MDZ_CheckHeader(work.bgmr,data))return false;
	//if(!work.bgmr.setData(data))return false;
	work.bgmr=bgmdata;
	int pcm_cnl_cnt=0;
	//BGM���[�N��������
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
		//�ŏ��̃f�[�^����~��������
		//byte *cdat;
		//cdat=(byte *)((int)mdzh+htbl.off);
		//if(*cdat==0xff)continue;
		//PPZ8�`���l���ȊO�X�L�b�v
		//if(htbl.type!=_PPZ8_F)continue;
		//�`�����l���I�[�o�[
		//if(htbl.cnl>=BGM_CNL_MAX)continue;
		//
		//ZeroMemory(cnl,sizeof(MDZ_CNL));
		cnl.state.stop=false;
		cnl.data_adr  =cnl_offset;		//�`���l���f�[�^
		cnl.cnl_cate  =cnl_type;		//�`���l��Index
		cnl.cnl_number=cnl_index;		//�`���l��Index
		cnl.quota     =work.bgmr.qflg;		//Q
		cnl.len_wk    =1;					//�����J�E���^
		cnl.def_len   =0x30;				//�f�t�H���g�̉���
		cnl.quota_wk  =1;					//Q�J�E���^
		cnl.pan       =5;						//PAN
		cnl.vol       =63;						//VOL
		cnl.loop_adr  =-1;				//(byte *)((int)&cnl.stack-1);//LOOP������
		cnl.soutai_icho=0;				//
		cnl.now_ontei =0;				//���݂̉���
		cnl.before_vol=-1;
		cnl.before_ontei=0xffff;		//�O�̉���
		cnl.before_wave=0xffff;			//�O�̎��g��
		cnl.wave      =0;						//���݂̎��g��
		cnl.detune    =0;					//�f�B�`���[��
		cnl.oto_num   =-1;				//���ԍ�
		//cnl.env.sv=0xff;				//SV
		//cnl.env.ar=0xff;				//AR
		//cnl.env.dr=0xff;				//DR
		//cnl.env.sl=0xff;				//SL
		//cnl.env.rr=0xff;				//RR
		cnl.env.Init();					//�G���x���[�v������
		for(int j=0;j<6;j++){
			cnl.rt_vol[j]=0xdf;		//11011111B
		}
		//PCMW�ݒ�
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
	//�L�[�I��&�{�����[���e�[�u���N���A
	//ZeroMemory(bgmr.keyon,sizeof(byte)*BGM_CNL_MAX);
	for(int i=0;i<BGM_CNL_MAX;i++){
		work.keyon_tbl[i]=0;
	}
	//PZI���[�v�|�C���^�̏�����
	MDZ_initLoopAll(work);
	//���̑��S�̃��[�N������
	work.soutai_tempo=0;				//���΃e���|
	work.fade_cnt=0;					//�t�F�[�h�J�E���^
	work.src_tempo=DEF_TEMPO;			//���̃e���|
	work.now_tempo=DEF_TEMPO;			//���ۂ̃e���|
	MDZ_setTimer(work);
	work.bgm_state=1;					//���t�t���O 1
	work.loop_is_flg=0;					//���[�v�N���A
	work.loop_is_adr=-1;				//���[�v���A�h���X
	work.end_is_adr=-1;					//���t�I���A�h���X
	//
	work.startPCMBuffer();
	//FM�p��������
	work.OutReg(0,0xb4,0xc0);
	work.OutReg(0,0xb5,0xc0);
	work.OutReg(0,0xb6,0xc0);
	work.OutReg(1,0xb4,0xc0);
	work.OutReg(1,0xb5,0xc0);
	work.OutReg(1,0xb6,0xc0);
	
	//SSG�~�L�T�[������
	
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
		cnl.fm_cnl_number=cnl.cnl_number;	//FM�����̃`���l��
		cnl.cnl_port_num =0;				//�A�N�Z�X�|�[�g
	}else{
		cnl.fm_cnl_number=cnl.cnl_number-3;	//FM�����̃`���l��
		cnl.cnl_port_num =1;				//�A�N�Z�X�|�[�g
	}
	return true;
}
public static bool MDZ_initCnlSSG(MDZ_CNL cnl){
	cnl.cnl_port_num=0;		//�A�N�Z�X�|�[�g
	cnl.env.Init();
	cnl.before_vol=0;
	cnl.before_wave=-1;
	cnl.vol=15;
	cnl.pan=1;
	return true;
}
public static bool MDZ_initCnlRITHM(MDZ_CNL cnl){
	cnl.cnl_port_num=0;			//�A�N�Z�X�|�[�g
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
		MOV	BYTE PTR [BX+CNL_PORT_NUM],1	;�A�N�Z�X�|�[�g
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
		MOV	AX,1801H		;ADPCM�G�~�����[�g������
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
;	���t�I��
******************************************************************************/
public static bool MDZ_stopBgm(MDZ_WORK work){
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnl=work.bgm[i];
		cnl.state.stop=true;
		work.stopCnl(cnl.pcm_work);
	}
	work.bgm_state=0;	//BGM��~
	//FM�X�g�b�v
	MDZ_stopFM(work,0);
	MDZ_stopFM(work,1);
	MDZ_stopFM2(work,0);
	MDZ_stopFM2(work,1);
	
	//SSG��~
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
	//RR��~
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
;		�|�[�YON/OFF
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
;		���ʉ��̓o�^
;	void mdz_play_eff(
;		int cnl;		//�`���l��
;		int bank;		//PCM�o���N
;		int oto;		//PCM���F�ԍ�
;		int vol;		//����
;		int pan;		//�p��
;		int rate;		//�Đ�ڰ� 1000H �Ō���
;	);
;	ECX	cnl
;	EDX	BANK
;	ESP+4	OTO
;	ESP+8	VOL
;	ESP+12	PAN
;	ESP+16	RATE
;	out	0 ����I��
;		1 �Đ��o���Ȃ�����
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
		CALL	GET_PCMCNL		;EBX PCM�`���l��
		POP	EDX
		OR	EBX,EBX
		JZ	PLAY_EFF_09
		;
		MOV	EAX,[EBP+8]		;VOLUME�ݒ�
		MOV	[EBX+PCMW_VOL],AL
		MOV	EAX,[EBP+12]		;PAN�ݒ�
		MOV	[EBX+PCMW_PAN],AL
		;
		MOV	EDI,[EDX*4+PZI_BANK_TBL]	;EDI BANK�A�h���X
		MOV	EAX,[EBP+4]			;OTO
		LEA	EAX,[EAX*8+EAX]
		LEA	ESI,[EAX*2+EDI+PZI_TBL_TOP]	;ESI PZI�e�[�u��
		ADD	EDI,PZI_DATA_TOP		;EDI PZI�f�[�^�擪
		MOV	EAX,[ESI+PZIT_START]		;START�A�h���X�ݒ�
		ADD	EAX,EDI
		MOV	[EBX+PCMW_NOW_ADR],EAX
		MOV	DWORD PTR [EBX+PCMW_NOW_XOR],0	;�A�h���X�����_��
		ADD	EAX,[ESI+PZIT_END]		;END�A�h���X�ݒ�
		MOV	[EBX+PCMW_END_ADR],EAX
		MOV	BYTE PTR [EBX+PCMW_LOOP_FLG],0	;���[�v���Ȃ�
		MOV	AX,[ESI+PZIT_RATE]		;���̃��[�g
		MOV	[EBX+PCMW_SRC_RATE],AX
		;
		MOV	EAX,[EBP+16]			 ;EAX WAVE
		MOVZX	EDX,WORD PTR [EBX+PCMW_SRC_RATE] ;EDX SRC_RATE
		MUL	EDX			;EAX SORC_RATE*WAVE/DIST_RATE
		DIV	DIST_RATE
		SHL	EAX,4
		MOV	ECX,EAX
		SHL	EAX,16			;����
		SHR	ECX,16			;���
		MOV	[EBX+PCMW_ADD_L],EAX
		MOV	[EBX+PCMW_ADD_H],ECX
		;
		MOV	BYTE PTR [EBX+PCMW_KEYON],1	;KEYON
		MOV	BYTE PTR [EBX+PCMW_STATE],1	;PCM���~
		;
		XOR	EAX,EAX
		_POP	ESI,EDI,EBP
		RET	(24-8)
PLAY_EFF_09:
		MOV	EAX,1
		_POP	ESI,EDI,EBP
		RET	(24-8)
/******************************************************************************
;		���ʉ��̒�~
;	int mdz_stop_eff(int cnl);
;	cnl	0~eff_cnl_max-1 �w��`���l���̒�~
;		-1		�S�`���l���̒�~
******************************************************************************/
/*
public static void MDZ_StopEff(MDZ_WORK work,int cnl){
		work.StopEff(cnl);
}
/******************************************************************************
;		PIZ/PVI�f�[�^�̓ǂݍ���
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
;		pzi�f�[�^�̐ݒ�
;	int mdz_set_pzi(int bank,void *data);
;	out	0 ����I��
;		1 �ُ�I��
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
		MOV	EAX,ECX				;���[�v���[�N������
		CALL	INIT_LOOP_ONE
		XOR	EAX,EAX
		RET
SET_PZI_09:
		MOV	DWORD PTR [ECX*4+PZI_BANK_TBL],0
		MOV	EAX,1
		RET
/******************************************************************************
;	PVI����PZI�̃R���o�[�g�̃T�C�Y
;	int mdz_decode_pvisize(void *data,int size,int *pzisize);
;	out	0 ����I��
;		1 �ُ�I��
******************************************************************************/
/*
public static bool MDZ_DecodePVISize(byte[] data,int[] pvisize){
	return false;
}
*/
/*
@mdz_decode_pvisize@12:
		MOV	EAX,[ECX]		;PVI�̃`�F�b�N
		AND	EAX,0FFFFFFH
		CMP	EAX,'IVP'
		JNZ	DEC_PVISIZE_ERR1
		MOV	EBX,[ESP+4]		;EBX PZISIZE�A�h���X
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
;	PVI�f�[�^�̐ݒ�
;	int mdz_decode_pvi(
;		void *pvi_data,int pvi_size,
;		void *pzi_data,int pzi_size);
;	out	0 ����I��
;		1 �ُ�I��
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
		MOV	EBX,ECX			;EBX PVI�擪
		MOV	EBP,EDX			;EBP PZI�擪
		;
		MOV	EAX,[EBX]		;PVI�̃`�F�b�N
		AND	EAX,0FFFFFFH
		CMP	EAX,'IVP'
		JNZ	DEC_PVI_ERR1
	;=======================================
	;PZI�e�[�u��������
	;=======================================
		MOV	EDI,EBP			;PZI�w�b�_�[0�N���A
		XOR	EAX,EAX
		MOV	ECX,PZI_DATA_TOP/4
		REP	STOSD
		MOV	DWORD PTR DS:[EBP],'0IZP' ;�uPZI0�v
		;
		;PZI<=PVI�w�b�_�[�ɕϊ�
		LEA	ESI,[EBX+PVI_TBL_TOP]
		LEA	EDI,[EBP+PZI_TBL_TOP]
		MOV	ECX,PVI_TBL_NUM
DEC_PVI_01:
		MOVZX	EAX,WORD PTR [ESI+0]	;EAX �擪�A�h���X
		MOVZX	EDX,WORD PTR [ESI+2]	;EDX �I���A�h���X
		SUB	EDX,EAX			;SIZE=�I��-�擪
		SHL	EAX,6			;*32
		SHL	EDX,6			;*32
		MOV	[EDI+PZIT_START],EAX
		MOV	[EDI+PZIT_END],EDX
		MOV	EAX,-1			;���[�v���Ȃ��Ƃ���
		MOV	[EDI+PZIT_LOOP_START],EAX
		MOV	[EDI+PZIT_LOOP_END],EAX
		MOV	WORD PTR [EDI+PZIT_RATE],16000	;16KHz�f�t�H���g
		ADD	ESI,PVIT_WORK_ONE
		ADD	EDI,PZIT_WORK_ONE
		DEC	ECX
		JNZ	DEC_PVI_01
	;=======================================
	;ADPCM.PCM�R���o�[�g
	;=======================================
;		LEA	EDI,[EBP+PZI_DATA_TOP]	;EDI �f�[�^�擪
;		MOV	NOW_CONV_PVI,0		;���݃R���o�[�g����PVI=0
;PVI_LOAD_12:
;		MOV	X_N,X_N0*256		;�\���l�̏�����
;		MOV	DELTA_N,DELTA_N0	;DELTA_N�̏�����
;		;
;		MOVZX	ESI,NOW_CONV_PVI	;BX=BX*18+PZI_TBL_TOP
;		LEA	ESI,[ESI*8+ESI]
;		LEA	ESI,[ESI*2+PZI_TBL_TOP]
;		ADD	ESI,DST_PZI_ADR
;		;
;		MOV	ECX,[ESI+4]		;���[�v��
;		SHR	ECX,1
;		INC	ECX
;		;
;		INC	NOW_CONV_PVI		;PVI�̔ԍ���+1
;PVI_LOAD_13:
;		MOV	AL,[ESI]		;���4bit�̕ϊ�
;		SHR	AL,4
;		CALL	PCM_CONV		;ADPCM>PCM�֕ϊ�
;		MOV	[EDI],AL
;		MOV	AL,[ESI]
;		CALL	PCM_CONV		;ADPCM>PCM�֕ϊ�
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
;		CMP	AL,NOW_CONV_PVI		;�f�[�^�����z������I��
;		JNZ	PVI_LOAD_12
	;=======================================
	;ADPCM.PCM�R���o�[�g
	;=======================================
		MOV	X_N,X_N0*256		;�\���l�̏�����
		MOV	DELTA_N,DELTA_N0	;DELTA_N�̏�����
		LEA	ESI,[EBX+PVI_DATA_TOP]
		LEA	EDI,[EBP+PZI_DATA_TOP]	;EDI �f�[�^�擪
		MOV	ECX,DECODE_PVI_SIZE
		SUB	ECX,PVI_DATA_TOP
DEC_PVI_11:
		MOV	AL,[ESI]		;���4bit�̕ϊ�
		SHR	AL,4
		CALL	PCM_CONV		;ADPCM>PCM�֕ϊ�
		MOV	[EDI],AL
		MOV	AL,[ESI]
		CALL	PCM_CONV		;ADPCM>PCM�֕ϊ�
		MOV	[EDI+1],AL
		INC	ESI
		ADD	EDI,2
		DEC	ECX
		JNZ	DEC_PVI_11
	;=======================================
	;�I��
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
;		�\���l�Ɨʎq���������߂�
;		�j��	AX
;		���[�N	NOW_ADPCM,DELTA_N,X_N,F_TBL
******************************************************************************/
/*
PCM_CONV:
		_PUSH	EBX,EDX
		;
		AND	AX,0FH
		MOV	NOW_ADPCM,AX
		AND	AX,07H
		;
		SHL	AX,1		;8�{
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
;	�� �t�F�[�h�A�E�g
;	void mdz_fade(int speed);
******************************************************************************/
public static void MDZ_fadeBgm(MDZ_WORK work,int speed){
	//�t�F�[�h������
	if(work.fade_cnt==0){
		work.fade_cnt =speed;
		work.fade_cnt2=speed;
		work.fade_vol =0;
	}
}
/*******************************************************************************
;	�� BGM���t�`�F�b�N
;	int mdz_check_bgm(void);
;	out	0 �I��
;		1 ���t��
;		2 PAUSE��
******************************************************************************/
public static int MDZ_checkBgm(MDZ_WORK work){
	if(work.bgm_state==0)return 0;
	if(work.pause_flg==0)return 1;
	return 2; 
}
/*******************************************************************************
;	�� ���΃e���|�w��
;	void mdz_add_tempo(int add_tempo);
;	add_tempo	-128~0~127���΃e���|
******************************************************************************/
public static void MDZ_addTempo(MDZ_WORK work,int n){
	work.soutai_tempo=n;
}
/*******************************************************************************
;	�� �`���l���}�X�N
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
;	�� PCM�̎�ސݒ�
;	void mdz_set_pcmcate(int cate,int rate,int size,void *buff);
;	in	cate	0:8bit mono
;			1:8bit stareo
;			2:16bit mono
;			3:16bit stereo
;			4:8bit mono(puz)
;			5:8bit stareo(puz)
;		rate	�Đ����[�g
;		size	�Đ��o�b�t�@�T�C�Y
;		buff	�����o�b�t�@
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
;		PCM�쐬�̃p�����[�^
;	int mdz_get_makepara(int *loopadr,int *endadr,int *nowsize);
;	OUT	EAX	0:�p��
;			1:�I��
******************************************************************************/
public static MDZ_MakePara MDZ_getMakePara(MDZ_WORK work){
	MDZ_MakePara para=new MDZ_MakePara();
	para.loopadr=work.loop_is_adr;
	para.endadr =work.end_is_adr;
	para.nowsize=0;
	para.nowsize=work.getNowMakePCMSize();
	//�I���A�h���X�����܂���?
	if(work.end_is_adr==-1){
		para.play_flg=true;		//�p��
	}else{
		para.play_flg=false;		//�I��
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
		XOR	EAX,EAX			;�p��
		CMP	END_IS_ADR,-1		;�I���A�h���X�����܂���?
		JZ	GET_MAKEPARA_01
		MOV	EAX,1			;�I��
GET_MAKEPARA_01:
		RET	(12-8)
*/
/*******************************************************************************
;	�� PCM�����̃p�����[�^
;	int mdz_loop_mode(int mode);
;	mode	0:���ʂɃ��[�v
;			1:���ׂẴ`���l�������[�v������I��
******************************************************************************/
public static void MDZ_setLoopMode(MDZ_WORK work,int n){
	work.one_loop_flg=n;
}

/******************************************************************************
;	�� �쐬�����wavpcm�f�[�^�T�C�Y
;	int mdz_get_wavsize(int loop,int fade);
;	loop��
;	fade�X�s�[�h
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
;		�쐬�����puzpcm�f�[�^�T�C�Y
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
		
		CMP	END_IS_ADR,-1		;���łɏI���A�h���X��ݒ肵��?
		JNZ	MAKE_PCM_01
		CMP	BGM_STATE,0		;���t�I��?
		JNZ	MAKE_PCM_01
		MOV	EAX,PCM_BADR_WK		;END�A�h���X�ݒ�
		MOV	END_IS_ADR,EAX
		JMP	GET_PUZSIZE_01
GET_PUZSIZE_09:
		
		
		RET
/******************************************************************************
;	�� �e���|�v�Z
;	IN	RATE		�T���v�����O���[�g
;		TEMPO		�e���|
;		BASE		��{�J�E���g�l�i�S�����̃J�E���g���j
;	OUT	ONE_STEP	1�ï�߂̏�����
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
;	�� BGM���t�����Ăяo��
******************************************************************************/
public static void MDZ_playMain(MDZ_WORK work){
	MDZ_driverMain(work);
}
public static bool MDZ_isCnlStop(MDZ_CNL cnlwork){
	return (cnlwork.state.stop || cnlwork.state.oneloop);
}
//�S�Ẵ`���l�����X�g�b�v����?
public static bool MDZ_checkAllCnlStop(MDZ_WORK work){
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_CNL cnlwork=work.bgm[i];
		if(!MDZ_isCnlStop(cnlwork))return false;
	}
	return true;
}
public static void MDZ_getLoopAdr(MDZ_WORK work){
	//���łɃ��[�v�|�C���^��ݒ肵��?
	if(work.loop_is_adr==-1){
		//[���[�v��!]��������?
		if(work.loop_is_flg!=0){
			work.loop_is_adr=work.getPCMBufferAdr();//���[�v�A�h���X�ݒ�
		}
	}
	//���łɏI���A�h���X��ݒ肵��?
	if(work.end_is_adr==-1){
		//���t�I��?
		if(work.bgm_state==0){
			work.end_is_adr=work.getPCMBufferAdr();//END�A�h���X�ݒ�
		}
	}
}
public static void MDZ_driverMain(MDZ_WORK work){
	if(work.bgm_state==0)return;
	//�`���l�����Ƃ̏�����
	for(int i=0;i<BGM_CNL_MAX;i++){
		MDZ_driverCom(work,work.bgm[i]);
	}
	//���ׂẴ`���l�����I���܂��̓��[�v����
	if(MDZ_checkAllCnlStop(work)){
		work.bgm_state=0;		//���t�t���OOFF
		//MDZDebug.Log("AllCnlStop");
		return;
	}
	/*======================================
	;	�~�L�T�[�o��
	;=====================================*/
	MDZ_MixerOutSSG(work);
	/*======================================
	;	�e���|�v�Z
	;=====================================*/
	int tempo=work.src_tempo+work.soutai_tempo;
	if(tempo<TEMPO_MIN)tempo=TEMPO_MIN;
	if(tempo>TEMPO_MAX)tempo=TEMPO_MAX;
	work.now_tempo=tempo;
	/*======================================
	;	�t�F�[�h�A�E�g����
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
	;	������&���t��~
	;=====================================*/
	//�L�[�`�F�b�N���邩�H
	/*
	if(work.key_check_flg!=0){
		MDZ_stopBgm(work);		//���t��~
	}else{
		work.now_tempo=255;
	}
	*/
	MDZ_setTimer(work);
	//���[�v�A�h���X�̊l��
	MDZ_getLoopAdr(work);
}
/*
DRIVER_MAIN:
		CMP	BGM_STATE,0		;���t����ĂȂ����
		JNZ	DR_BGM_01		;�������^�[��
		RET
DR_BGM_01:
		MOV	EBX,OFFSET BGM_WORK
		MOV	ECX,BGM_CNL_MAX
DR_BGM_02:
		PUSH	ECX
		CALL	DRIVER_COM		;�`���l�����Ƃ̏�����
		POP	ECX
		ADD	EBX,BGM_WORK_ONE
		DEC	ECX
		JNZ	DR_BGM_02
		;���t�I���`�F�b�N
		MOV	EBX,OFFSET BGM_WORK
		MOV	ECX,BGM_CNL_MAX
DR_BGM_04:
		TEST	DWORD PTR [EBX+P_STATE],STOP_F+ONELOOP_F
		JZ	DR_BGM_06
		ADD	EBX,BGM_WORK_ONE
		DEC	ECX
		JNZ	DR_BGM_04
		;���ׂẴ`���l�����I���܂��̓��[�v����
		MOV	BGM_STATE,0		;���t�t���OOFF
		RET
DR_BGM_06:
	;=======================================
	;	�e���|�v�Z
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
	;	�t�F�[�h�A�E�g����
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
		MOV	FADE_CNT,0		;�t�F�[�h�I��
		CALL	STOP_BGM		;���t��~
		RET
FADE_SKIP:
	;=======================================
	;	������&���t��~
	;=======================================
		CMP	KEY_CHECK_FLG,0		;�L�[�`�F�b�N���邩�H
		JZ	KEY_CK_SKIP
		CALL	STOP_BGM		;���t��~
		JMP	KEY_CK_SKIP
CTRL_GRPH:
		MOV	NOW_TEMPO,255
KEY_CK_SKIP:
		CALL	TIMER_SET
		RET
/******************************************************************************
;	�� �`���l�����Ƃ̃R�}���h���s
******************************************************************************/
public static void MDZ_driverCom(MDZ_WORK work,MDZ_CNL cnlwork){
	//��~���Ă���?
	if(cnlwork.state.stop)return;
	//�L�[�I���N���A
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
	//��~���Ă�����I���R�}���h�I��(oneloop����?)
	if(MDZ_isCnlStop(cnlwork)){
		//�S�Ẵ`���l����~?
		if(MDZ_checkAllCnlStop(work)){
			return;
		}
	}
	//��
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
;	�� �R�}���h����
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
		//�R�}���h�W�����v
		MDZ_jumpCommand(work,cnlwork,n);
		//��~���Ă�����I���R�}���h�I��(oneloop����?)
		if(MDZ_isCnlStop(cnlwork)){
			//�S�Ẵ`���l����~?
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
		CMP	AL,_STOP_COM		;0FFH �f�[�^�G���h
		JZ	CNL_STOP
		CMP	AL,_COM_TOP		;00H~7FH ����,80H �x��
		JB	GET_COM_SKIP
		SUB	AL,_COM_TOP		;81H~FEH �R�}���h
		MOVZX	EAX,AL
		CALL	[EAX*4+COMMAND_TBL]
		JMP	GET_COM_01
GET_COM_SKIP:
/******************************************************************************
;	�� �����R�}���h
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
;	�� �����̃`�F�b�N�Ƌx������
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
		//�s�b�`�x���h�̏ꍇ�A�O�̉���
		//�̓x���h�̖ڕW�����ƂȂ�
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
		MOV	DL,[EBX+VEND_ONTEI]	;�s�b�`�x���h�̏ꍇ�A�O�̉���
		MOV	[EBX+P_BEFORE_ONTEI],DL	;�̓x���h�̖ڕW�����ƂȂ�
		CMP	[EBX+VEND_ONTEI],AL
		JAE	NOT_VEND
		NEG	WORD PTR [EBX+VEND_RATE]
NOT_VEND:
		TEST	WORD PTR [EBX+P_STATE],TAI_F2
		JZ	NOT_TAI
		MOV	EDX,[EBX+P_STATE]
		AND	DWORD PTR [EBX+P_STATE],NOT SURA_F2 ;�X���[�N���A
		CMP	AL,AH
		JZ	LFO_MAIN
		TEST	DX,SURA_F2
		JZ	NOT_TAI
		CALL	KEYOFF
NOT_TAI:
/******************************************************************************
;	�� �L�[�I��������
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
		MOV	AL,[EBX+P_NOW_ONTEI]		;��������WAVE�����߂�
		CALL	ONTEI_GET
		MOV	[EBX+P_WAVE],AX
		//LFO�̏�������
		CALL	ALL_LFO_INIT
/******************************************************************************
;	�� �L�[�I������
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
	//���F�A�h���X�ݒ�
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
	//�����A�{�����[���ݒ�
	MDZ_OnteiVolOut(work,cnlwork);		//�����A�{�����[���ݒ�
}
/*
KEYON:
		OR	DWORD PTR [EBX+P_STATE],KON_F+KON_R_F	;KON_F  1
		AND	DWORD PTR [EBX+P_STATE],NOT KOFF_F	;KOFF_F 0
		AND	DWORD PTR [EBX+P_STATE],NOT (AR_F+DR_F+SR_F) ;ENV 0
		MOV	AL,[EBX+ENV_SV]			;VOL2<=SV
		MOV	[EBX+ENV_VOL2],AL
	;=======================================
	;	���F�A�h���X�ݒ�
	;=======================================
		MOV	EDI,[EBX+P_PCM_WORK]		;EDX PCM_WORK_ADR
		MOV	BYTE PTR [EDI+PCMW_STATE],1	;�Đ��J�n
		MOV	BYTE PTR [EDI+PCMW_KEYON],1	;KEYON
		MOV	EAX,[EBX+P_PCM_START]
		MOV	[EDI+PCMW_START_ADR],EAX	;�X�^�[�g�ۑ�
		MOV	[EDI+PCMW_NOW_ADR],EAX		;�����ʒu
		MOV	DWORD PTR [EDI+PCMW_NOW_XOR],0	;�����_�ʒu=0
		MOV	EAX,[EBX+P_PCM_END]		;�I���A�h���X
		MOV	[EDI+PCMW_END_ADR],EAX
		MOV	AL,[EBX+P_PCM_LOOPFLG]		;LOOP�t���O
		MOV	[EDI+PCMW_LOOP_FLG],AL
		MOV	EAX,[EBX+P_PCM_LOOP]		;LOOP�A�h���X
		MOV	[EDI+PCMW_LOOP_ADR],EAX
		MOV	AX,[EBX+P_PCM_RATE]		;SRC_RATE
		MOV	[EDI+PCMW_SRC_RATE],AX
	;=======================================
	;	�����A�{�����[���ݒ�
	;=======================================
		CALL	ONTEI_VOL_OUT			;�����A�{�����[���ݒ�
		RET
/******************************************************************************
;	�� ���F�ݒ�T�u
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
	//���[�v���Ȃ��ꍇ
		cnlwork.pcmtone.loopflg=0;
		cnlwork.pcmtone.loop   =0;
	}else{
	//���[�v����ꍇ
		cnlwork.pcmtone.loopflg=1;
		//���[�v�J�n�ʒu�̸د��ݸ�
		int loop=pzit.start+pzilt.start;
		if(loop>=pzit.end){
			loop=pzit.end-1;
		}
		cnlwork.pcmtone.loop=loop;
		//���[�v�I���ʒu�̸د��ݸ�
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
		MOV	ESI,[EAX*4+PZI_BANK_TBL]	;ESI PZI�f�[�^
		SHL	EAX,10				;BANK*1028
		LEA	EBP,[ESI+PZI_DATA_TOP]		;EBP PZI�f�[�^�擪
		LEA	ECX,[EDX*8+EAX+PZI_LP_WORK]	;ECX ���[�v���[�N
		LEA	EDX,[EDX*8+EDX]			;EDX 12H=(NUM*9)*2
		LEA	ESI,[EDX*2+ESI+PZI_TBL_TOP]	;ESI PZI�e�[�u��
		;
		MOV	AX,[ESI+PZIT_RATE]	;�����g���ݒ�
		MOV	[EBX+P_PCM_RATE],AX
		MOV	EAX,[ESI+PZIT_START]	;�J�n�A�h���X�ݒ�
		ADD	EAX,EBP
		MOV	[EBX+P_PCM_START],EAX
		ADD	EAX,[ESI+PZIT_END]	;�I���A�h���X�ݒ�
		MOV	[EBX+P_PCM_END],EAX
		;
		MOV	EAX,[ECX+PZIL_START]	;���[�v�`�F�b�N
		AND	EAX,[ECX+PZIL_END]
		INC	EAX
		JNZ	SET_OTO_10
	;=======================================
	;���[�v���Ȃ��ꍇ
	;=======================================
		MOV	BYTE PTR [EBX+P_PCM_LOOPFLG],0
		RET
	;=======================================
	;	���[�v����ꍇ
	;=======================================
SET_OTO_10:
		MOV	BYTE PTR [EBX+P_PCM_LOOPFLG],1
		;
		MOV	EAX,[ECX+PZIL_START]	;���[�v�J�n�ʒu�̃N���b�s���O
		ADD	EAX,[EBX+P_PCM_START]
		CMP	EAX,[EBX+P_PCM_END]
		JB	SET_OTO_11
		MOV	EAX,[EBX+P_PCM_END]
		DEC	EAX
SET_OTO_11:
		MOV	[EBX+P_PCM_LOOP],EAX
		;
		MOV	EAX,[ECX+PZIL_END]	;���[�v�I���ʒu�̃N���b�s���O
		ADD	EAX,[EBX+P_PCM_START]
		CMP	EAX,[EBX+P_PCM_END]	;�I���ʒu�ȑO�Ȃ�OK
		JBE	SET_OTO_12
		MOV	EAX,[EBX+P_PCM_END]
SET_OTO_12:
		CMP	EAX,[EBX+P_PCM_LOOP]	;���[�v�J�n�����ɂ����OK
		JA	SET_OTO_13
		MOV	EAX,[EBX+P_PCM_LOOP]
		INC	EAX
SET_OTO_13:
		MOV	[EBX+P_PCM_END],EAX	;�I���A�h���X
		RET
/******************************************************************************
;	�� LFO�̏���
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
		CALL	PITCH_VEND	;�s�b�`�x���h����
		CALL	AUTO_PAN	;�I�[�g�p������
*/
public static void MDZ_OnteiVolOut(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_OnteiOut(work,cnlwork);
	MDZ_volOut(work,cnlwork);
}
/*
ONTEI_VOL_OUT:
		CALL	ONTEI_OUT	;�����o��
		JMP	SOFT_ENV	;�{�����[���o��
/******************************************************************************
;	�� LFO�̉��Z����
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
		CMP	BYTE PTR [EDI+LFO_MD_CNT],0	;�f�����C
		JZ	LFO_SKIP
		DEC	BYTE PTR [EDI+LFO_MD_CNT]
		JNZ	LFO_SKIP
		MOV	BYTE PTR [EDI+LFO_MD_CNT],1
		DEC	BYTE PTR [EDI+LFO_SPEED_CNT]	;�X�s�[�h
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
	;	[0]�O�p�g
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
	;	[1]�̂�����g
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
	;	[2]���`�g
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
	;	[3]�|���^�����g
	;=====================================*/
public static void MDZ_LFOWave3(MDZ_WORK work,MDZ_CNL cnlwork,int type){
	MDZ_LFO lfo=cnlwork.lfo[type];
	cnlwork.wave=MDZ_WaveAdd(cnlwork.wave,lfo.rate_sub);
	if(lfo.depth_cnt!=0)return;
	lfo.md_cnt=0;	//�I��
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
		MOV	BYTE PTR [EDI+LFO_MD_CNT],0	;�I��
		RET
*/
	/*======================================
	;	[4]�K�i�g
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
;	�� �s�b�`�x���h�̏���
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
		TEST	DWORD PTR [EBX+P_STATE],VEND_F	;�x���h����Ȃ����
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
		CALL	WAVE_ADD			;�g�`���Z
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
;	�� �����𑫂�
;		IN	AX	WAVE
;			DX	���Z�l
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
		;+�̏ꍇ
		ADD	AX,DX		;WAVE=WAVE+���Z�l
		JNC	WAVE_ADD_02
		MOV	AX,-1
		RET
		;-�̏ꍇ
WAVE_ADD_01:
		NEG	DX
		SUB	AX,DX
		JNC	WAVE_ADD_02
		XOR	AX,AX
WAVE_ADD_02:
		RET
/******************************************************************************
;	�� �I�[�g�p���̏���
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
		//�f�����C�J�E���g
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
		CMP	BYTE PTR [EBX+APAN_MD_CNT],0	;�f�����C�J�E���g
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
		MOV	BYTE PTR [EBX+APAN_MD_CNT],0	;�f�����C�J�E���g
		JMP	AUTO_PAN_09
AUTO_PAN_02:
		NEG	BYTE PTR [EBX+APAN_ADD]
		MOV	AL,[EBX+APAN_SORC_W]
		XCHG	AL,[EBX+APAN_DIST_W]
		MOV	[EBX+APAN_SORC_W],AL
AUTO_PAN_09:
		RET
/******************************************************************************
;	�� �������炻�ꂼ��̎��g�������߂�
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
//o4c(4*12)���
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
;	�� �����̌v�Z
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
		CMP	AX,[EBX+P_BEFORE_WAVE]	;�O�Ɠ���WAVE�Ȃ�v�Z���Ȃ�
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
		SHL	EAX,16			;����
		SHR	ECX,16			;���
		MOV	[EDI+PCMW_ADD_L],EAX
		MOV	[EDI+PCMW_ADD_H],ECX
ONTEI_OUT_SKIP:
		RET
/******************************************************************************
;	�� �L�[�I�t
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
//���{����OPNA��port0�Areg0x28��1�`6�`���l���̎w�������
public static void MDZ_keySubFM2(MDZ_WORK work,int port,int fm_cnl,int n){
	if(!work.HasPort(port))return;
	//��OPN2������
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
;	�� �\�t�g�G���x���[�v�̏����Əo��
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
		CMP	TIMER_FLG,0	;���ʉ���������t�F�[�h���Ȃ�
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
		CMP	TIMER_FLG,0	;���ʉ���������t�F�[�h���Ȃ�
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
	;	�W�U�{�[�h�o�b�l�̏ꍇ
	;=======================================
PCM_VOL_OUT_B86:
		MOV	AL,DH
		;CALL	B86_VOL_SET
		RET

*/
/******************************************************************************
;	�� �\�t�g�G���x���[�v�̏����Əo��
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
	//�t�F�[�h
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
		CMP	DH,[EBX+P_BEFORE_VOL]	;�O�Ɠ����Ȃ�o�͂��Ȃ�
		JZ	ENV_SKIP
		MOV	[EBX+P_BEFORE_VOL],DH
		;
		MOV	EDI,[EBX+P_PCM_WORK]	;EDI PCM_WORK_ADR
		MOV	[EDI+PCMW_VOL],DH
ENV_SKIP:
		RET

/******************************************************************************
;	�� ���Y���̏o��
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
			//���F�A�h���X�ݒ�
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
		MOV	DH,AL		;AL�ɏo�͂���f�[�^
		MOV	DL,10H
		CALL	OPN_OUT
*/
	/*======================================
	;	���Y���{�����[���̏o��
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
;		���Y���{�����[���ݒ�
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
		AND	AX,3			;PAN�C��
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
;	�� �R�}���h�W�����v
******************************************************************************/
public static void MDZ_jumpCommand(MDZ_WORK work,MDZ_CNL cnlwork,int command){
	switch(command){
		case 0x81:MDZ_setVol(work,cnlwork);break;			//0x81 ���ʃZ�b�g
		case 0x82:MDZ_upVol(work,cnlwork);break;			//0x82 ���ʃA�b�v
		case 0x83:MDZ_downVol(work,cnlwork);break;			//0x83 ���ʃ_�E��
		case 0x84:MDZ_setTimerB(work,cnlwork);break;		//0x84 �^�C�}�[�Z�b�g
		case 0x85:MDZ_jumpCom(work,cnlwork);break;			//0x85 �W�����v
		case 0x86:MDZ_loopCom(work,cnlwork);break;			//0x86 ���[�v
		case 0x87:MDZ_loopOut(work,cnlwork);break;			//0x87 ���[�v�A�E�g
		case 0x88:MDZ_setQuota(work,cnlwork);break;			//0x88 �Q�[�g�^�C���Z�b�g
		case 0x89:MDZ_setDetune(work,cnlwork);break;		//0x89 �f�B�`���[��
		case 0x8A:MDZ_setLFO(work,cnlwork);break;			//0x8A LFO�Z�b�g
		case 0x8B:MDZ_setLFOFlg(work,cnlwork);break;			//0x8B LFOON/OFF
		case 0x8D:MDZ_OtoCom(work,cnlwork);break;			//0x8D ���F�Z�b�g
		case 0x8E:MDZ_setPan(work,cnlwork);break;			//0x8E PAN�Z�b�g
		case 0x8F:MDZ_setNoise(work,cnlwork);break;			//0x8F �m�C�Y�Z�b�g
		case 0x90:MDZ_setEnv(work,cnlwork);break;			//0x90 �\�t�g�G���x���[�v�̃Z�b�g
		case 0x91:MDZ_setVol2(work,cnlwork);break;			//0x91 �ڍ׉��ʃZ�b�g
		case 0x92:MDZ_setTai(work,cnlwork);break;			//0x92 �^�C
		case 0x93:MDZ_setLoop(work,cnlwork);break;			//0x93 ���[�v���J�b�R
//		case 0x94:MDZ_SyncCom(work,cnlwork);break;			//0x94 �V���N�𑗂�
//		case 0x95:MDZ_WaitCom(work,cnlwork);break;			//0x95 �V���N��҂�
		case 0x96:MDZ_fadeCom(work,cnlwork);break;			//0x96 �t�F�[�h�A�E�g
		case 0x97:MDZ_setVendOld(work,cnlwork);break;		//0x97 �x���h�ݒ�1
//		case 0x98:MDZ_PcmFset(work,cnlwork);break;			//0x98 PCM_F_SET
		case 0x99:MDZ_sendDataCom(work,cnlwork);break;		//0x99 �f�[�^�𑗂�
		case 0x9A:MDZ_SIcho(work,cnlwork);break;			//0x9A ���Έڒ�
		case 0x9B:MDZ_setSura(work,cnlwork);break;			//0x9B �X���[
		case 0x9C:MDZ_setDefLen(work,cnlwork);break;		//0x9C �f�t�H���g�����̐ݒ�
		case 0x9D:MDZ_selectBank(work,cnlwork);break;		//0x9D �o���N�̐ݒ�
//		case 0x9E:											//0x9E MIDIEffect
//		case 0x9F:											//0x9F �x���h�����W
//		case 0xA0:											//0xA0 �x���V�e�B�t�o
//		case 0xA1:											//0xA1 �x���V�e�B�c�n�v�m
//		case 0xA2:											//0xA2 �`���l���ԍ��ݒ�
//		case 0xA3:											//0xA3 PPZ��PAN�ݒ�
//		case 0xA4:											//0xA4 �x���V�e�B�Z�b�g
		case 0xA5:MDZ_setAutoPan(work,cnlwork);break;		//0xA5 �I�[�g�p���ݒ�
		case 0xA6:MDZ_restOffset(work,cnlwork);break;		//0xA6 �x���ŃL�[�I�t����
//		case 0xA7:MDZ_setTimerA(work,cnlwork);break;		//0xA7 TIMERA�ݒ�
		case 0xA8:MDZ_setTempo(work,cnlwork);break;			//0xA8 �e���|�w��
		case 0xA9:MDZ_setVend(work,cnlwork);break;			//0xA9 �x���h�ݒ�2
		case 0xAA:MDZ_setLoopPoint(work,cnlwork);break;		//0xAA ���[�v�|�C���^�ݒ�
		case 0xAB:MDZ_isLoop(work,cnlwork);break;			//0xAB ���[�v��
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
;	�� �`���l���̒�~
******************************************************************************/
public static void MDZ_CnlStop(MDZ_WORK work,MDZ_CNL cnlwork){
	//�X�g�b�v�t���O
	cnlwork.state.stop=true;
	//�x������
	MDZ_rest(work,cnlwork);
	//PCM��~
	work.stopCnl(cnlwork.pcm_work);
}
/*
CNL_STOP_COM:
		POP	EAX		;CALL���̃X�^�b�N���̂Ă�
CNL_STOP:
		OR	DWORD PTR [EBX+P_STATE],STOP_F	;�X�g�b�v�t���O
		CALL	REST				;�x������
		MOV	EDI,[EBX+P_PCM_WORK]	;PCM��~
		MOV	BYTE PTR [EDI+PCMW_STATE],0
CNL_STOP_02:
		RET
/******************************************************************************
;	�� �S�`���l���̒�~
******************************************************************************/
public static void MDZ_StopCom(MDZ_WORK work,MDZ_CNL cnlwork){
	MDZ_stopBgm(work);
}
/*
STOP_COM:
		CALL	STOP_BGM
		RET
/******************************************************************************
;	�� �����ݒ�
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
;	�� �e���|�ݒ�
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
;	�� ���ׂẴ`���l�������[�v�܂��͏I���������`�F�b�N
******************************************************************************/
public static void MDZ_CheckOneLoop(MDZ_WORK work,MDZ_CNL cnlwork){
}
/*
CHECK_ONELOOP:
		RET
/******************************************************************************
;	�� �W�����v�A���[�v����
******************************************************************************/
//���[�v��
public static void MDZ_isLoop(MDZ_WORK work,MDZ_CNL cnlwork){
	work.loop_is_flg=1;
}
//�W�����v�R�}���h
public static void MDZ_jumpCom(MDZ_WORK work,MDZ_CNL cnlwork){
	if(work.one_loop_flg!=0){
		cnlwork.state.oneloop=true;
		//��~
		//cnlwork.state.stop=true;
	}
	cnlwork.data_adr=MDZ_getCommandUint16(work,cnlwork);
	//
	//work.JumpCnlLoop(cnlwork.pcm_work,cnlwork.data_adr);
}
//���[�v������
public static void MDZ_setLoop(MDZ_WORK work,MDZ_CNL cnlwork){
	cnlwork.loop_adr++;
	cnlwork.loop_stack[cnlwork.loop_adr]=MDZ_getCommandUint8(work,cnlwork);
}
//���[�v�E����
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
//���[�v�A�E�g
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
	;���[�v��
LOOP_IS:
		MOV	LOOP_IS_FLG,1		;���[�v��
		RET
	;�W�����v�R�}���h
JUMP_COM:
		CMP	ONE_LOOP_FLG,0		;����t���O�L��?
		JZ	JUMP_COMS
		OR	DWORD PTR [EBX+P_STATE],ONELOOP_F
	;	CALL	CHECK_ONELOOP		;����������`�F�b�N
	;	OR	AL,AL
	;	JZ	JUMP_COMS
	;	POP	EAX			;CALL��POP
	;	RET
	;�f�[�^�A�h���X�ύX
JUMP_COMS:
		MOVZX	EAX,WORD PTR [ESI]
		ADD	EAX,BGM_DATA_ADR
		MOV	ESI,EAX
		RET
	;���[�v������
LOOP_SET:
		INC	DWORD PTR [EBX+P_LOOP_ADR]	;STACK PUSH
		MOV	AL,[ESI]
		INC	ESI
		MOV	EDI,[EBX+P_LOOP_ADR]
		MOV	[EDI],AL
		RET
	;���[�v�E����
LOOP_COM:
		MOV	EDI,[EBX+P_LOOP_ADR]
		DEC	BYTE PTR [EDI]
		JNZ	JUMP_COMS
		ADD	ESI,2
LOOP_END:
		DEC	DWORD PTR [EBX+P_LOOP_ADR]	;STACK POP
		RET
	;���[�v�A�E�g
LOOP_OUT:
		MOV	EDI,[EBX+P_LOOP_ADR]
		CMP	BYTE PTR [EDI],1
		JZ	LOOP_OUT2
		ADD	ESI,2
		RET
LOOP_OUT2:
		CALL	JUMP_COMS			;���̃A�h���X�����߂�
		JMP	LOOP_END
/******************************************************************************
;	�� �Q�[�g�^�C���̐ݒ�
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
;	�� �^�C
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
;	�� �X���[
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
;	�� �f�B�`���[��
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
;	�� LFO�ݒ�
******************************************************************************/
public static void MDZ_setLFO(MDZ_WORK work,MDZ_CNL cnlwork){
	//�g�`�ԍ�
	int type    =MDZ_getCommandUint8(work,cnlwork);
	int md      =MDZ_getCommandUint8(work,cnlwork);
	int speed   =MDZ_getCommandUint8(work,cnlwork);
	int rate    =MDZ_getCommandSint16(work,cnlwork);
	int depth   =MDZ_getCommandUint8(work,cnlwork);
	int wave_num=MDZ_getCommandUint8(work,cnlwork);
	//MA,MH�͑ΏۊO
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
		MOVZX	EAX,BYTE PTR [ESI]	;�g�`�ԍ�
		INC	ESI
		CMP	AL,3			;MA,MH�͑ΏۊO
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
	;	LFO�������T�u
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
	;	LFO������
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
;	�� LFO��ON/OFF
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
		MOVZX	EAX,BYTE PTR [ESI]	;�g�`�ԍ�
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
;	�� �s�b�`�x���h�̎w��
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
;	�� �{�����[���ݒ�
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
;	�� �{�����[����UP
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
;	�� �{�����[����DOWN
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
;	�m�C�Y�Z�b�g
******************************************************************************/
public static void MDZ_setNoise(MDZ_WORK work,MDZ_CNL cnlwork){
	int n=MDZ_getCommandUint8(work,cnlwork);
	work.ssg_noise=n;
}
/******************************************************************************
;	SSG�̃~�L�T�[�ݒ�
******************************************************************************/
public static void MDZ_MixersetSSG(MDZ_WORK work,MDZ_CNL cnlwork,int n){
	cnlwork.pan=n & 3;
	int cnl=cnlwork.cnl_number;
	int al=ssg_mixer_tbl[cnlwork.pan] << cnl;	//AL�ɏo�̓f�[�^
	int ah=ssg_mixer_mask[cnl];					//AH��AND�f�[�^(11110110B)
	work.ssg_mixer&=ah;
	work.ssg_mixer&=al;
}
/*
MIXER_SET:
		XOR	AX,AX
		MOV	AL,[BX+PAN]		;SSG��TONE,NOISE�̐ݒ�
		MOV	DI,AX
		MOV	AL,[DI+mixer_tbl]
		MOV	CL,[BX+CNL_NUMBER]	;AL�ɏo�̓f�[�^
		SHL	AL,CL
		MOV	AH,11110110B		;AH��AND�f�[�^
		ROL	AH,CL
		AND	DS:[BP+SSG_MIXER],AH	;�~�L�T�[�ݒ�
		OR	DS:[BP+SSG_MIXER],AL
		;
		CALL	SSG_MASK_CHECK		;�}�X�N�`�F�b�N
		;
		RET
	;=======================================
	;	�}�X�N�`�F�b�N
	;=======================================
SSG_MASK_CHECK:
		CMP	EFFECT_FLG,0		;���ʉ������ĂȂ����
		JZ	SSG_MASK_CK_01
		CMP	TIMER_FLG,0		;���ʉ���������
		JNZ	SSG_MASK_CK_01
		MOV	AL,000001000B		;NOISE�w�肪�Ȃ����
		MOV	CL,[BX+CNL_NUMBER]
		SHL	AL,CL
		TEST	AL,BYTE PTR [BGM_WORKS+SSG_MIXER]
		JNZ	SSG_MASK_CK_01
		;
		CALL	NOISE_CHECK		;���ʉ��Ńm�C�Y�����ĂȂ����
		JNC	SSG_MASK_CK_01
		MOV	DL,[BX+CNL_NUMBER]	;����
		ADD	DL,8
		XOR	DH,DH
		CALL	OPN_OUT
		MOV	OUT_FLG,1		;�o�͋֎~
		STC
		RET
SSG_MASK_CK_01:
		CLC
		RET
	;=======================================
	;�@���ʉ��Ńm�C�Y�����Ă��邩�`�F�b�N
	;	CY=0	�m�C�Y�����Ă��Ȃ�
	;	CY=1	�m�C�Y�����Ă���
	;=======================================
NOISE_CHECK:
		CMP	EFFECT_FLG,0	;���ʉ��͖��Ă��Ȃ��̂Ŋ֌W�Ȃ�
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
	;	�~�L�T�[�̉��o��
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
		CMP	EFFECT_FLG,0		;���ʉ������ĂȂ����
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
		CALL	NOISE_CHECK		;���ʉ��Ńm�C�Y�����Ă���
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
;	�� PAN�̐ݒ�
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
	;	�e�l�̃p���ݒ�
	;=======================================
SPB_PAN_TBL	DB	0,2,1,3		;SPB��PAN�␳
FM_PAN_SET:
		MOV	DL,[BX+PAN]
		;
		AND	DX,3			;PAN�C��
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
		AND	DWORD PTR [EBX+P_STATE],NOT APAN_F ;�I�[�g�p����~
PAN_SET_SUB:
		MOV	AL,[EBX+P_PAN]
		MOV	EDI,[EBX+P_PCM_WORK]		;DI PCM_WORK_ADR
		MOV	[EDI+PCMW_PAN],AL
		RET
/******************************************************************************
;	�� �I�[�gPAN�̐ݒ�
******************************************************************************/
public static void MDZ_setAutoPan(MDZ_WORK work,MDZ_CNL cnlwork){
	int md   =MDZ_getCommandUint8(work,cnlwork);
	int speed=MDZ_getCommandUint8(work,cnlwork);
	int sorc =MDZ_getCommandUint8(work,cnlwork);
	int dist =MDZ_getCommandUint8(work,cnlwork);
	int flg  =MDZ_getCommandUint8(work,cnlwork);
	//�I�[�g�p���J�n
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
		OR	DWORD PTR [EBX+P_STATE],APAN_F	;�I�[�g�p���J�n
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
		AND	DWORD PTR [EBX+P_STATE],NOT APAN_F ;�I�[�g�p����~
		RET
*/
/******************************************************************************
;	�� �x���ŃL�[�I�t���邩
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
;	�� ���F�؂�ւ�
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
;	�� �o���N�؂�ւ�
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
;	�� PCM���[�v�|�C���^�ݒ�
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
	//���̃`���l���̉��F���ύX
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
	;���̃`���l���̉��F���ύX
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
;	�� �G���x���[�v�ݒ�
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
;	�� ���Έڒ�
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
;	�� �t�F�[�h�A�E�g
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
;	�� �O���Ƀf�[�^�𑗂�
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
;	�� �_�~�[
******************************************************************************/
public static void MDZ_DummyCom(MDZ_WORK work,MDZ_CNL cnlwork){
}
/*
DUMMY_COM:
		RET
*/
/******************************************************************************
;		���[�N
******************************************************************************/
/*
;16bit�X�e���I.8bit���m����
;16bit�X�e���I.8bit�X�e���I
;16bit�X�e���I.16bit���m����
;16bit�X�e���I.16bit�X�e���I
;16bit�X�e���I.8bit���m����
;16bit�X�e���I.8bit�X�e���I
DIST_CATE_SHIFT	DB	2,1,1,0,2,1		;
INIT_FLG		DB	0					;�������t���O
BGM_STATE		DB	0					;BGM���t�t���O
BGM_DATA_ADR	DD	0				;BGM�f�[�^�A�h���X
BGM_DATA_SIZE	DD	0				;BGM�f�[�^�T�C�Y
	public	_bgm_work
_bgm_work		label	byte
BGM_WORK		DB	BGM_WORK_SIZE DUP(?)	;BGM���[�N
	PUBLIC	_pcmw_work
_pcmw_work		LABEL	BYTE
PCMW_WORK		DB	PCMW_WORK_SIZE DUP(?)	;PCM���[�N
KEY_ON_TBL		DW	BGM_CNL_MAX	DUP(?)		;�L�[�I���e�[�u��
DIST_CATE		DB	0						;PCM�̎��

BGMR_WORK		DB	BGMR_WORK_SIZE DUP(?)	;BGMR���[�N

SOUTAI_TEMPO	DD	0			;
SRC_TEMPO		DD	0			;���̃e���|
NOW_TEMPO		DD	0			;���݂̃e���|
SENT_DATA		DB	0			;�O���o�̓f�[�^
DST_PZI_ADR		DD	0			;
FADE_CNT		DB	0			;�t�F�[�h�J�E���^
FADE_CNT2		DB	0			;�t�F�[�h�J�E���^2
FADE_VOL		DB	0			;�t�F�[�h�{�����[��
FADE_FLG		DB	0			;�t�F�[�h�t���O
KEY_CHECK_FLG	DB	0			;�L�[�`�F�b�N�t���O
PAUSE_FLG		DB	0			;�߰�ނ̃t���O
DIST_RATE		DD	0			;�Đ����[�g
NOW_CONV_PVI	DB	0			;���݃R���o�[�g����PVI
ONE_LOOP_FLG	DB	0			;1�񃋁[�v�ŏI���
;ONE_LOOP_END	DB	0			;1�񃋁[�v�ŏI���t���O
LOOP_IS_FLG		DB	0			;���[�v����
LOOP_IS_ADR		DD	0			;���[�v����A�h���X
END_IS_ADR		DD	0			;END�A�h���X
PZI_BANK_TBL	DD	PZI_BANK_MAX	DUP(0)	;
	public	_pzi_lp_work
_pzi_lp_work	label	byte
PZI_LP_WORK	DB	PZIL_WORK_SIZE*PZI_BANK_MAX DUP(?)
PCM_BUFF_SIZE	DD	DEF_PBUFF_VOL		;PCM�o�b�t�@�̑傫��
PCM_BUFF_ADR	DD	0			;PCM�o�b�t�@�A�h���X
PCM_BADR_WK		DD	0			;PCM�o�b�t�@�A�h���X
PCM_BADR_WKS	DD	0			;PCM�o�b�t�@�A�h���X
PCM_ONE_STEP	DD	0			;PCM1��̏�����
PCM_STEP_CNT	DD	0			;PCM1��̏����ʂ̃J�E���^
PCM_LEFT_CNT	DD	0			;PCM�c��o�b�t�@
PCM_DIST_ADR	DD	0			;
PCM_DIST_SIZE	DD	0			;
PCM_NOW_MAKESIZE DD	0			;
DECODE_PVI_SIZE	DD	0			;
DECODE_PZI_SIZE	DD	0			;
PCMW_VOL_WK	DD	0			;
	PUBLIC	_mdz_supply_flg
_mdz_supply_flg	DD	1
		;PCM�ϊ����̃��[�N
NOW_ADPCM	DW	0			;���� �� ADPCM
DELTA_N		DW	0			;DELTA_N
X_N		DW	0,0			;Xn
F_TBL		DW	57*4,57*4,57*4,57*4,77*4,102*4,128*4,153*4
;LFO�̃I�t�Z�b�g�ƃt���O
LFO_TBL		DD	P_PLFO,P_QLFO,P_RLFO
LFO_COM_TBL	DD	PLFO_F,QLFO_F,RLFO_F,ALFO_F,HLFO_F
;�R�}���h�e�[�u�� 081H~0FFH
COMMAND_TBL	DD	VOL_SET		;81H ���ʃZ�b�g
		DD	VOL_UP		;82H ���ʃA�b�v
		DD	VOL_DOWN	;83H ���ʃ_�E��
		DD	DUMMY_COM	;84H �e���|�Z�b�g
		DD	JUMP_COM	;85H �W�����v
		DD	LOOP_COM	;86H ���[�v
		DD	LOOP_OUT	;87H ���[�v�A�E�g
		DD	QUOTA_SET	;88H �Q�[�g�^�C���Z�b�g
		DD	DETUNE_SET	;89H �f�B�`���[��
		DD	LFO_SET		;8AH LFO �Z�b�g
		DD	LFO_COM		;8BH LFO ON/OFF
		DD	DUMMY_COM	;8CH OPN ���ڏ�������
		DD	OTO_COM		;8DH ���F�Z�b�g
		DD	PAN_SET		;8EH PAN �Z�b�g
		DD	DUMMY_COM	;8FH �m�C�Y�Z�b�g
		DD	ENV_SET		;90H �\�t�g�G���x���[�v�̃Z�b�g
		DD	VOL_SET2	;91H �ڍ׉��ʃZ�b�g
		DD	TAI_SET		;92H �^�C
		DD	LOOP_SET	;93H ���[�v���J�b�R
		DD	DUMMY_COM	;94H �����M����������
		DD	DUMMY_COM	;95H �����M��������܂ő҂�
		DD	FADE_COM	;96H �t�F�[�h�A�E�g
		DD	DUMMY_COM	;97H �s�b�`�x���h
		DD	DUMMY_COM	;98H PCM �̎��g��
		DD	SENT_DATA_COM	;99H �f�[�^�𑗂�
		DD	S_ICHO		;9AH ���Έڒ�
		DD	SURA_SET	;9BH �X���[
		DD	DEF_LEN_SET	;9CH �f�t�H���g�����̐ݒ�
		DD	BANK_SEL	;9DH �o���N�̐ݒ�
		DD	DUMMY_COM	;9EH MIDI�G�t�F�N�g
		DD	DUMMY_COM	;9FH �x���h�����W
		DD	DUMMY_COM	;A0H �x���V�e�BUP
		DD	DUMMY_COM	;A1H �x���V�e�BDOWN
		DD	DUMMY_COM	;A2H �`���l���ԍ��ݒ�
		DD	DUMMY_COM	;A3H PPZ��PAN�ݒ�
		DD	DUMMY_COM	;A4H �x���V�e�B�Z�b�g
		DD	AUTO_PAN_SET	;A5H �I�[�g�p���ݒ�
		DD	REST_OFF_SET	;A6H �x���ŃL�[�I�t����
		DD	DUMMY_COM	;A7H TIMERA�w��
		DD	TEMPO_SET	;A8H �e���|�w��
		DD	VEND_SET	;A9H �x���h�ݒ�2
		DD	LOOP_POINT_SET	;AAH ���[�v�|�C���^�ݒ�
		DD	LOOP_IS		;ABH ���[�v��
	;�����̃e�[�u��[o8]
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
PCM_VOL_TBL	LABEL	WORD			;�{�����[���f�[�^
;		INCLUDE	VOL16_64.INC
		INCLUDE	VOL8_64.INC

PUZ_CATE_TBL	LABEL	WORD
		DW	0,0



/*******************************************************************************
;		�����܂�
/******************************************************************************/
}


//======================
}
}
