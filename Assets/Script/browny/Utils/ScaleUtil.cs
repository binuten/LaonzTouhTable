using UnityEngine;
using System.Collections;

public class ScaleUtil : MonoBehaviour
{

    public static void setScale(Transform target, float tx, float ty = 9999f, float tz = 9999f)
    {
        // null ---- 9999
        float _x;
        float _y;
        float _z;

        if (tx == 9999) _x = target.localScale.x;
        else _x = tx;
        if (ty == 9999) _y = target.localScale.y;
        else _y = ty;
        if (tz == 9999) _z = target.localScale.z;
        else _z = tz;
        target.localScale = new Vector3(_x, _y, _z);
    }

    public static void addScale(Transform target, float tx, float ty = 9999f, float tz = 9999f)
    {
        float _x;
        float _y;
        float _z;
        if (tx == 9999) _x = target.localScale.x;
        else _x = target.localScale.x + tx;
        if (ty == 9999) _y = target.localScale.y;
        else _y = target.localScale.y + ty;
        if (tz == 9999) _z = target.localScale.z;
        else _z = target.localScale.z + tz;
        target.localScale = new Vector3(_x, _y, _z);
    }
}
