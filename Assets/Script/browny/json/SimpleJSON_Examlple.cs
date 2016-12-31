using UnityEngine;
using System.Collections;
using System.IO;

using SimpleJSON;

public class SimpleJSON_Examlple : MonoBehaviour
{





    void loadLocal()
    {

        StreamReader r = new StreamReader(Application.streamingAssetsPath + "/json/root.json");
        string jsonStr = r.ReadToEnd();
        JSONNode json = JSON.Parse(jsonStr);

        //Debug.Log(json["name"].Value);
        //Debug.Log(json["name"][0].Value);
        //Debug.Log(json["name"][0].Count);
    }

    void loadUrl() { StartCoroutine(GetJsonFile()); }

    IEnumerator GetJsonFile()
    {
        WWW www = new WWW("http://69.232.221.11:8080/organi");
        yield return www;

        if (www.error == null)
        {
            Debug.Log("loaded");
            JSONNode json = JSON.Parse(www.text);

            //Debug.Log(json["name"].Value);
            //Debug.Log(json["name"][0].Value);
            //Debug.Log(json["name"][0].Count);
        }

    }
}
