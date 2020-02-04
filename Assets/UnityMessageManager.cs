using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ICODES.STUDIO.WWebView;
using UnityEngine.UI;

public class UnityMessageManager : MonoBehaviour {

 	public static UnityMessageManager Instance { get; private set; }
	public Browser main_browser;  //网页主入口
    public WWebView webView = null;

    private void Awake() {
		Instance = this;
        DontDestroyOnLoad(this);
	}


    public void LoadLocalFile()
    {
        webView.NavigateFile("demo.html");
        Show();
    }

    public void Navigate(string url)
    {
        webView.Navigate(url);
        Show();
    }

    public void Navigate()
    {
        Navigate("https://www.baidu.com");
    }

    public Text showText = null;
    protected bool showFlag = false;
    public void Show()
    {
        webView.Show();
        showFlag = true;

        if (showText != null)
            showText.text = "Hide";
    }

    public void SetStyle(Browser browser,Vector4 position)
	{
		//设置网页窗体大小位置
	}

	public void RegisterWebFunction()
	{
		main_browser.RegisterFunction("sendWebMessage", args => {
			DebugLog.DebugLogInfo("00ff00","change url index :"+args[0]);
		});	
	}

	public void SendMessageToWeb(string msg)
	{
		main_browser.CallFunction("setDisplayedUrl", msg);
	}
}

public class MessageHandler
{
    public int id;
    public string seq;
    public String name;
    private JToken data;
    
    public static MessageHandler Deserialize(string message)
    {
        JObject m = JObject.Parse(message);
        MessageHandler handler = new MessageHandler(
            m.GetValue("id").Value<int>(),
            m.GetValue("seq").Value<string>(),
            m.GetValue("name").Value<string>(),  
            m.GetValue("data")
        );
        return handler;
    }

    public T getData<T>()
    {
        return data.Value<T>();
    }
    
    public MessageHandler(int id, string seq, string name, JToken data)
    {
        this.id = id;
        this.seq = seq;
        this.name = name;
        this.data = data;
    }

    public void send(object data)
    {
        JObject o = JObject.FromObject(new
        {
            name = name,
            data = data
        });
        UnityMessageManager.Instance.SendMessageToWeb(o.ToString());
    }
}

public class UnityMessage
{
    public String name;
    public JObject data;
    public Action<object> callBack;
}