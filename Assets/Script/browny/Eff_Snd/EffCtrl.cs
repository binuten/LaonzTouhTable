using UnityEngine;
using System.Collections;

public class EffCtrl : MonoBehaviour
{
    public static Transform smoke, smokeBack, shine, shineAll;
    public Transform _smoke, _smokeBack, _shine, _shineAll;
    void Start()
    {
        smoke = _smoke;
        smokeBack = _smokeBack;
        shine = _shine;
        shineAll = _shineAll;
    }


    public static void addSmoke(Vector3 _position)
    {
        PositionUtil.setPosition(smoke, _position.x, _position.y);
        smoke.GetComponent<ParticleSystem>().Play();
    }

    public static void addSmokeBack(Vector3 _position)
    {
        PositionUtil.setPosition(smokeBack, _position.x, _position.y);
        smokeBack.GetComponent<ParticleSystem>().Play();
    }

    public static void addShine(Vector3 _position)
    {
        PositionUtil.setPosition(shine, _position.x, _position.y);
        shine.GetComponent<ParticleSystem>().Play();
    }
    public static void addShineAll(Vector3 _position)
    {
        PositionUtil.setPosition(shineAll, _position.x, _position.y);
        shineAll.GetComponent<ParticleSystem>().Play();
    }


}
