using UnityEngine;
using System.Collections;

public class JPGLoader : MonoBehaviour
{

    public string url = "http://t1.daumcdn.net/news/201610/14/xportsnews/20161014130922679ocox.jpg";
    IEnumerator Start()
    {
        //GetComponent<Renderer>
        GetComponent<Renderer>().material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
        while (true)
        {
            WWW www = new WWW(url);
            yield return www;
            www.LoadImageIntoTexture((Texture2D)GetComponent<Renderer>().material.mainTexture);
        }
    }

    //public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";

    //IEnumerator loadroutine()
    //{
    //    Debug.Log("loaded");
    //    WWW www = new WWW(url);
    //    yield return www;
    //    Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

    //    gameObject.AddComponent<SpriteRenderer>();
    //    GetComponent<SpriteRenderer>().sprite = sprite;

    //    Debug.Log("loaded");
    //}

    //// IEnumerator loadroutine;


    //void Start()
    //{
    //    //  Invoke("loadStart", 2f);
    //}

    //public void loadStart(string _url = "test")
    //{
    //    if (_url != "test") url = _url;
    //    StartCoroutine("loadroutine");
    //}
}
