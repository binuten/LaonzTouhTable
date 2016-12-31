using UnityEngine;
using System.Collections;

public class PositionUtil : MonoBehaviour
{

    public static void setPosition(Transform target, float tx = 9999, float ty = 9999, float tz = 9999, bool isLocal = true)
    {
        // null ---- 9999
        float _x;
        float _y;
        float _z;

        if (isLocal)
        {
            if (tx == 9999) _x = target.localPosition.x;
            else _x = tx;
            if (ty == 9999) _y = target.localPosition.y;
            else _y = ty;
            if (tz == 9999) _z = target.localPosition.z;
            else _z = tz;
            target.localPosition = new Vector3(_x, _y, _z);
        }
        else
        {
            if (tx == 9999) _x = target.position.x;
            else _x = tx;
            if (ty == 9999) _y = target.position.y;
            else _y = ty;
            if (tz == 9999) _z = target.position.z;
            else _z = tz;
            target.position = new Vector3(_x, _y, _z);
        }
    }

    public static void addPosition(Transform target, float tx = 9999, float ty = 9999, float tz = 9999, bool isLocal = true)
    {
        float _x;
        float _y;
        float _z;
        if (isLocal)
        {
            if (tx == 9999) _x = target.localPosition.x;
            else _x = target.localPosition.x + tx;
            if (ty == 9999) _y = target.localPosition.y;
            else _y = target.localPosition.y + ty;
            if (tz == 9999) _z = target.localPosition.z;
            else _z = target.localPosition.z + tz;
            target.localPosition = new Vector3(_x, _y, _z);
        }
        else
        {
            if (tx == 9999) _x = target.position.x;
            else _x = target.position.x + tx;
            if (ty == 9999) _y = target.position.y;
            else _y = target.position.y + ty;
            if (tz == 9999) _z = target.position.z;
            else _z = target.position.z + tz;
            target.position = new Vector3(_x, _y, _z);
        }



    }
}
