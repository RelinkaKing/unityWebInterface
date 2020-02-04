using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZenFulcrum.EmbeddedBrowser;

public class LoadHtmlUI : MonoBehaviour {

	public GameObject cube ;
	public Text web_text;
	public Browser unity_browser;
	public string fileLocalStreamingPath;

	void Start () {
		fileLocalStreamingPath = "file://" + Application.streamingAssetsPath + "/";
		unity_browser.pub_url=fileLocalStreamingPath+"a.html";
		unity_browser.RegisterFunction("unparsed", args => {
			web_text.text=args[0];
			DebugLog.DebugLogInfo("00ff00","change url index :"+args[0]);
		});	
		unity_browser.RegisterFunction("ShowModel", args => {
			cube.SetActive(!cube.activeSelf);
		});	
	}

    public void CreateWebView()
    {

    }


	public void SendMessageToWeb()
	{
		// unity_browser.onLoad += info => {
			unity_browser.CallFunction("setDisplayedUrl", "hello world");
		// };
	}

	public void ChangeBrowserUrl()
	{

	}

}