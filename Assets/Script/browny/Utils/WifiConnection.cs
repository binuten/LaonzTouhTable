using UnityEngine;
using System.Collections;

public class WifiConnection : MonoBehaviour
{


   // void Start() { InvokeRepeating("chk2", 0, 2f); }


    void chk2()
    {
        Debug.Log("-----" + chk());
    }

    public static bool chk()
    {

        bool _bool = false;

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            //Debug.Log("Error. Check internet connection!");
            _bool = true;
        }
        //else
        //{
        //    //Debug.Log("internet connection!");
        //}

        return _bool;


    }



}
