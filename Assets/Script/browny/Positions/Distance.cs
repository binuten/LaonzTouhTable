using System;
using UnityEngine;

public class Distance

{

    public static float Between2DLocalPosition(Transform trans1, Transform trans2)
    {

        float num = 0f;
        num = Mathf.Sqrt(Mathf.Pow((trans1.localPosition.x - trans2.localPosition.x), 2f) + Mathf.Pow((trans1.localPosition.y - trans2.localPosition.y), 2f));

        return num;

    }

    public static float Between2DPosition(Transform trans1, Transform trans2 = null)
    {

        float num = 0f;

        if (trans2 != null)
            num = Mathf.Sqrt(Mathf.Pow((trans1.position.x - trans2.position.x), 2) + Mathf.Pow((trans1.position.y - trans2.position.y), 2));
        else num = Mathf.Sqrt(Mathf.Pow((trans1.position.x), 2) + Mathf.Pow((trans1.position.y), 2));
        return num;
    }

    public static float Between2DPoint(Vector2 t1, Vector2 t2)
    {
        float num = 0f;
        num = Mathf.Sqrt(Mathf.Pow((t1.x - t2.x), 2) + Mathf.Pow((t1.y - t2.y), 2));
        return num;
    }

    public static int negativeInt(float num)
    {
        int _num = 1;
        if (num < 0) _num = -1;
        return _num;
    }
}
