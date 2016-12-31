using UnityEngine;

public class StageInteractivePosition : MonoBehaviour
{
    // public static string TYPEA = "type_4x3";
    // public static string TYPEB = "type_16x10";

    public static string stageType = "none";

    // z position¿¡ µû¶ó ¹Ù²ñ.
    public static Vector3 positionChg_TR(Transform target, float addX = 1f)
    {
        if (stageType == "none") setScreenType();
        switch (stageType)
        {
            case "type_4x3":
                break;
            case "type_3x2":
                target.position = new Vector3(target.position.x * 1.071428571428571f * addX,
                    target.position.y, target.position.z);
                break;
            case "type_16x10":
                target.position = new Vector3(target.position.x * 1.21123595505618f * addX,
                    target.position.y, target.position.z);
                break;
            case "type_16x9":
                target.position = new Vector3(target.localPosition.x * 1.357303370786517f * addX,
                    target.position.y, target.position.z);
                break;
        }
        return target.localPosition;
    }

    public static string TYPEA()
    { return "type_4x3"; }
    public static string TYPEB()
    { return "type_3x2"; }
    public static string TYPEC()
    { return "type_16x10"; }
    public static string TYPED()
    { return "type_16x9"; }

    public static string setScreenType()
    {
        string type = "N";

        float _w = Screen.width;
        float _h = Screen.height;
        float size = _w / _h;

        if (size < 1.4f) { type = TYPEA(); }
        else if (size < 1.52f) { type = TYPEB(); }
        else if (size < 1.7f) { type = TYPEC(); }
        else if (size < 1.8f) { type = TYPED(); }
        stageType = type;
        Debug.Log("-------------" + stageType);
        return type;
    }

}