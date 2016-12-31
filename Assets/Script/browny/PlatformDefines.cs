using UnityEngine;
using System.Collections;


public class PlatformDefines : MonoBehaviour
{
    void Start()
    {
        //   WWW www = new WWW(url);

#if UNITY_EDITOR || UNITY_STANDALONE
        Debug.Log("Unity Editor");
#endif

#if UNITY_ANDROID
        Debug.Log("Unity Editor");
#endif

#if UNITY_IOS
      Debug.Log("Iphone");
#endif

#if UNITY_IPHONE
      Debug.Log("Iphone");
#endif

        //#if UNITY_STANDALONE_OSX
        //    Debug.Log("Stand Alone OSX");
        //#endif

        //#if UNITY_STANDALONE_WIN
        //      Debug.Log("Stand Alone Windows");
        //#endif

    }
}
