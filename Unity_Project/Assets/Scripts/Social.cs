using UnityEngine;
using System.Collections;
using cn.sharesdk.unity3d;

public class Social : MonoBehaviour {

	// Use this for initialization
	void ShareResultHandler (ResponseState state, PlatformType type, Hashtable shareInfo, Hashtable error, bool end)
	{
		if (state == ResponseState.Success)
		{
			print ("share result :");
			print (MiniJSON.jsonEncode(shareInfo));
		}
		else if (state == ResponseState.Fail)
		{
			print ("fail! error code = " + error["error_code"] + "; error msg = " + error["error_msg"]);
		}
	}

	void Start () {
		Debug.Log ("Hello");


		ShareSDK.setCallbackObjectName("Main Camera");
		ShareSDK.open ("api20");
		Hashtable sinaWeiboConf = new Hashtable();
		sinaWeiboConf.Add("app_key", "568898243");
		sinaWeiboConf.Add("app_secret", "38a4f8204cc784f81f9f0daaf31e02e3");
		sinaWeiboConf.Add("redirect_uri", "http://www.sharesdk.cn");
		ShareSDK.setPlatformConfig (PlatformType.SinaWeibo, sinaWeiboConf);

		Hashtable content = new Hashtable();
		content["content"] = "this is a test string.";
		content["image"] = "http://img.baidu.com/img/image/zhenrenmeinv0207.jpg";
		content["title"] = "test title";
		content["description"] = "test description";
		content["url"] = "http://sharesdk.cn";
		content["type"] = "sharesdk";
		content["siteUrl"] = "http://sharesdk.cn";
		content["site"] = "ShareSDK";
		content["musicUrl"] = "http://mp3.mwap8.com/destdir/Music/2009/20090601/ZuiXuanMinZuFeng20090601119.mp3";

		ShareResultEvent evt = new ShareResultEvent(ShareResultHandler);
		ShareSDK.showShareMenu (null, content, 100, 100, MenuArrowDirection.Up, evt);


	
	}

	void AuthResultHandler(ResponseState state, PlatformType type, Hashtable error)
	{
		if (state == ResponseState.Success)
		{
			print ("success !");
		}
		else if (state == ResponseState.Fail)
		{
			print ("fail! error code = " + error["error_code"] + "; error msg = " + error["error_msg"]);
		}
	}

	// Update is called once per frame
	void Update () {
		AuthResultEvent evt = new AuthResultEvent(AuthResultHandler);
		ShareSDK.authorize(PlatformType.SinaWeibo, evt);
	
	}
}
