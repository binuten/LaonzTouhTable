

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

using System.Diagnostics;



[StructLayout(LayoutKind.Sequential, Pack = 1)]

public class RectObj : MonoBehaviour
{

    public Transform tip1, tip2, tip3, tip4;

    //public bool m_Initialised;

    [DllImport("TouchOverlay", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int Initialise(string Str);

    [DllImport("TouchOverlay")]
    public static extern int GetTouchPointCount();

    [DllImport("TouchOverlay")]
    public static extern void GetTouchPoint(int i, tTouchData n);

    //public TextMesh txt;
    // Use this for initialization
    void Start()
    {
        //UnityEditor.EditorWindow

        //m_Initialised = false;
    }

    // Update is called once per frame
    void Update()
    {
        NumTouch = GetTouchPointCount();
        if (NumTouch > 1)
        {
            tTouchData TouchData = new tTouchData();
            GetTouchPoint(0, TouchData);
            Vector3 scrSpace = Camera.main.WorldToScreenPoint(tip1.position);
            Vector3 touchPosition = new Vector3(TouchData.m_x * 0.01f, 1080 - TouchData.m_y * 0.01f);
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            Transform hitTrans = Physics2D.GetRayIntersection(ray, Mathf.Infinity).transform;
            if (hitTrans != null && hitTrans.tag == "touchRect")
            {
                touchPosition.z = scrSpace.z;
                tip1.position = Camera.main.ScreenToWorldPoint(touchPosition);
                tip3.gameObject.SetActive(true);
            }

            GetTouchPoint(1, TouchData);
            scrSpace = Camera.main.WorldToScreenPoint(tip2.position);
            Vector3 touchPosition2 = new Vector3(TouchData.m_x * 0.01f, 1080 - TouchData.m_y * 0.01f);
            ray = Camera.main.ScreenPointToRay(touchPosition2);

            hitTrans = Physics2D.GetRayIntersection(ray, Mathf.Infinity).transform;
            if (hitTrans != null && hitTrans.tag == "touchRect")
            {
                touchPosition2.z = scrSpace.z;
                tip2.position = Camera.main.ScreenToWorldPoint(touchPosition2);
                tip4.gameObject.SetActive(true);
            }

            Info.tagData.currentDistance = Distance.Between2DPoint(touchPosition, touchPosition2);
        }
        else
        {
            //tip1.gameObject.SetActive(false);
            //tip2.gameObject.SetActive(false);
            tip3.gameObject.SetActive(false);
            tip4.gameObject.SetActive(false);
        }

        //txt.text = NumTouch.ToString();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    txt.text = Input.mousePosition.x.ToString() + "," + Input.mousePosition.y.ToString();
        //    Vector3 scrSpace = Camera.main.WorldToScreenPoint(tip1.position);
        //    Vector3 touchPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        //    Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        //    Transform hitTrans = Physics2D.GetRayIntersection(ray, Mathf.Infinity).transform;
        //    if (hitTrans != null && hitTrans.tag == "touchRect")
        //    {
        //        UnityEngine.Debug.Log("ray~~~");
        //        touchPosition.z = scrSpace.z;
        //        tip1.position = Camera.main.ScreenToWorldPoint(touchPosition);
        //    }
        //}
    }

    int NumTouch = 0;

    void OnGUI()
    {
        //if (!m_Initialised)
        //{
        //    Str = "LaonzTouhLib2";
        //    if (Initialise(Str) < 0)
        //    {
        //        // ERROR STATE
        //    }
        //    m_Initialised = true;
        //}

        GUI.Label(new Rect(10, 10, 150, 40), NumTouch.ToString());

        for (int p = 0; p < NumTouch; p++)
        {
            tTouchData TouchData = new tTouchData();
            GetTouchPoint(p, TouchData);
            GUI.Label(new Rect(10, 10 + (p + 1) * 40, 200, 40),
                "ID:" + TouchData.m_ID +
                "Time:" + TouchData.m_Time.ToString() +
                "(" + (TouchData.m_x * 0.01f).ToString() + "," + (TouchData.m_y * 0.01f).ToString() + ")");
        }
    }



}


//using UnityEngine;
//using System.Collections;
//using UnityEngine.EventSystems;

//public class RectObj : MonoBehaviour
//{

//    public Transform tip1, tip2, tip3, tip4;
//    public TextMesh txt;
//    // Use this for initialization
//    void Start()
//    {

//        gameObject.AddComponent<EventSystem>();
//        gameObject.AddComponent<StandaloneInputModule>().forceModuleActive = true;
//        //gameObject.AddComponent<TouchInputModule>();

//        dist = transform.position.z - Camera.main.transform.position.z;
//        tip1.gameObject.SetActive(false);
//        tip2.gameObject.SetActive(false);
//        tip3.gameObject.SetActive(false);
//        tip4.gameObject.SetActive(false);
//    }
//    Touch t1, t2;
//    float distance, dist;

//    // Update is called once per frame
//    void Update()
//    {

//        //Debug.Log("---" + Input.touches.Length);


//        //if (Input.GetMouseButtonDown(0))
//        //{
//        //    Debug.Log("slkidjskldjsd");
//        //}
//        //if (Input.GetMouseButtonDown(1))
//        //{
//        //    Debug.Log("111111");
//        //}

//        //Debug.Log("------- " + Input.touches.Length);
//        Debug.Log("------- " + Input.touches.Length);

//        //txt.text = Input.touchCount.ToString();

//        if (Input.touchCount > 1)
//        {

//            t1 = Input.touches[0];
//            t2 = Input.touches[1];

//            tip1.position = t1.position;
//            tip2.position = t2.position;

//            distance = Distance.Between2DPoint(t1.position, t2.position);

//            tip1.gameObject.SetActive(true);
//            tip2.gameObject.SetActive(true);
//            tip3.gameObject.SetActive(true);
//            tip4.gameObject.SetActive(true);
//        }

//    }

//    public void closeTip()
//    {
//        tip1.gameObject.SetActive(false);
//        tip2.gameObject.SetActive(false);
//        tip3.gameObject.SetActive(false);
//        tip4.gameObject.SetActive(false);
//    }
//}
