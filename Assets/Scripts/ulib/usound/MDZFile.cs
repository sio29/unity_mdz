/******************************************************************************
;	MDZ File
******************************************************************************/
using System.IO;
using System.Collections;
using UnityEngine;
//using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;

namespace ulib{
namespace usound{
//======================
public class MDZFile{
	public static byte[] ReadAllBytes(string filename){
		/*
		if(filename.Contains("://")) {
			//WWW request = new WWW(filename);
			//yield return request;
			//return request.bytes;
			IEnumerator coroutine = ReadAllBytesFromWeb(filename);
			yield return coroutine;
			return coroutine.Current;
		}else{
			return File.ReadAllBytes(filename);
		}
		*/
			return File.ReadAllBytes(filename);
	}
	/*
	public static IEnumerator ReadAllBytesFromWeb(string filename){
		WWW request = new WWW(filename);
		yield return request;
		return request.bytes;
	}
	*/
	
	
	static void Start() {
		//StartCoroutine(GetText());
	}
	
	public static IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
		yield return www.SendWebRequest();
		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}else{
			// 結果をテキストとして表示します
			Debug.Log(www.downloadHandler.text);
			//  または、結果をバイナリデータとして取得します
			byte[] results = www.downloadHandler.data;
		}
	}
}
//======================
}
}
