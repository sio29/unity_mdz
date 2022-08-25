/******************************************************************************
;	PZI Player
******************************************************************************/

namespace ulib{
namespace usound{
public class PZIPlayer{
	public double sampleRate;
	private bool play_flg=false;
	private int play_off=0;
	private PZIDATATBL play_tbl;
	
	public void stop(){
		play_flg=false;
	}
	public void play(PZIDATA pzidata,int index){
		play_tbl=pzidata.tbl[index];
		play_flg=true;
		play_off=0;
		
	}
	
	public void makePCM(float[] data, int channels){
		if(!play_flg)return;
		int sample_num = data.Length / channels;
		PZIDATATBL tbl=play_tbl;
		int off=play_off;
		for(int i=0;i<sample_num;i++){
			int n0=tbl.wave[tbl.start+off];
			float n=(float)(n0-128)/128.0f;
			
			
			for(int j=0;j<channels;j++){
				data[i * channels + j] += n;
			}
			off++;
			if(off>=tbl.end){
				//play_flg=false;
				off=0;
				break;
			}
		}
		if(play_flg){
			play_off=off;
		}
	}
}
}
}
