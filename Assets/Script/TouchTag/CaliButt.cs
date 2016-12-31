using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaliButt : MonoBehaviour
{

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(click);
    }


    public void click()
    {
        //Debug.Log("name---- " + transform.name);
        Info.tagData.buttReceive(transform.name);
    }
}
