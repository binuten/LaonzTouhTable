
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

using System.Diagnostics;


[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class tTouchData
{
    public int m_x;
    public int m_y;
    public int m_ID;
    public int m_Time;
};


public class TouchNativeParent : MonoBehaviour
{
    [DllImport("TouchOverlay", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int Initialise(string Str);

    [DllImport("TouchOverlay")]
    public static extern int GetTouchPointCount();

    [DllImport("TouchOverlay")]
    public static extern void GetTouchPoint(int i, tTouchData n);


    bool isOne, isTwo;

    public string productName;

    void Awake()
    {
        Initialise(productName);
        //    Invoke("delayT", 7f);
    }

    int NumTouch = 0;

    void Update()
    {

        if (!isStart)
        {
            // 터치 초기화 오류 재정의
            NumTouch = GetTouchPointCount();
            if (NumTouch > 0)
            {
                isStart = true;
                Invoke("delayT", .2f);
            }
        }
        else
        { if (NumTouch == 0) isStart = false; }


    }


    void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus) { isStart = false; }
    }


    void delayT()
    {
        Initialise(productName);
    }


    bool isStart;
}
