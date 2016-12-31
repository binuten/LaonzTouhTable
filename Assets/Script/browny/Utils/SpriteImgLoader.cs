using UnityEngine;
using System.Collections;

public class SpriteImgLoader : MonoBehaviour
{
    // The source image
    //public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";

    //public bool isIcon;
    //public bool isList;

    //IEnumerator loadroutine(GameObject[] parms)
    //{
    //    //yield return null;

    //    WWW www = new WWW(url);
    //    yield return www;
    //    if (www.error == null)
    //    {
    //        Texture2D tex = www.texture;

    //        //Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    //        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 1));

    //        parms[0].AddComponent<SpriteRenderer>();
    //        parms[0].GetComponent<SpriteRenderer>().sprite = sprite;

    //        //GetComponent<ImgLoader>().loaded(parms[0], new Vector2(tex.width, tex.height));
    //    }
    //    else
    //    {
    //        Debug.Log("imgLoadERR---- " + www.error);
    //    }
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


    //public void loadGameObject(string _url = "test", GameObject _parent = null)
    //{

    //    StopCoroutine("loadroutine");
    //    if (_url != "test") url = _url;
    //    GameObject[] parms = new GameObject[1];
    //    parms[0] = _parent;
    //    StartCoroutine("loadroutine", parms);
    //}


    //public void close() { StopCoroutine("loadroutine"); }
}
