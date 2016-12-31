using UnityEngine;
using System.Collections;
using System.IO;

public class ImgUtil : MonoBehaviour
{
    //public ImgUtil instance;
    //void Awake() { instance = this; }

    public void loadImgURL(string URL = "") { StartCoroutine(loadURLImg(URL)); }

    IEnumerator loadURLImg(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            //Texture2D tex = www.texture;
            //    Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
            //    gameObject.AddComponent<SpriteRenderer>();
            //    GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else { Debug.Log("err----" + www.error); }
    }

    void loadImgLocal(string filePath = "")
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);

            tex = new Texture2D(4, 4);
            tex.LoadImage(fileData);
        }
        //GetComponent<Renderer>().material.mainTexture = tex;
    }

    //void Foo()
    //{
    //    StartCoroutine(Bar((myReturnValue) =>
    //    {
    //        if (myReturnValue) { }
    //    }));
    //}
    //IEnumerator Bar(System.Action<bool> callback)
    //{
    //    yield return null;
    //    callback(true);
    //}
}
