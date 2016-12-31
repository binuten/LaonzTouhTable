using System;
using UnityEngine;

public class SpriteUtil
{
    internal static void alpha(Transform _target, float _alpha)
    {
        Color _col = _target.GetComponent<SpriteRenderer>().material.color;
        _target.GetComponent<SpriteRenderer>().material.color = new Color(_col.r, _col.g, _col.b, _alpha);
    }

    internal static void tint(Transform _target, float _num = 5, float _alpha = 1)
    {
        _target.GetComponent<SpriteRenderer>().material.color = new Color(_num, _num, _num, _alpha);

    }
}
