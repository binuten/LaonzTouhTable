using UnityEngine;

public class RandomUtil : MonoBehaviour
{


    public static bool percent(int _percent)
    {
        bool _bool = false;
        int ran = Random.Range(0, 101);
        if (ran < _percent) _bool = true;

        return _bool;
    }


    public static int plusminus()
    {
        int _int = 1;
        if (percent(50)) _int = -1;

        return _int;
    }


}
