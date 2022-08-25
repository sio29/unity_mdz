/******************************************************************************
;	MDZ Debug
******************************************************************************/
namespace ulib{
namespace usound{
//======================
public delegate void MDZLogger(string m);
public class MDZDebug{
	public static MDZLogger logger=null;
	public static void Log(string m){
		if(logger!=null){
			logger(m);
		}
	}
}
//======================
}
}
