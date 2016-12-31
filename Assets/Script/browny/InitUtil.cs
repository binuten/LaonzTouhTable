using UnityEngine;
using System.Collections;

public class InitUtil : MonoBehaviour
{
    public bool MouseHide, isFullScreen, touchEnable;
    public int DefaultAppfps = 300;

    void Awake()
    {
        Application.targetFrameRate = DefaultAppfps;
        if (MouseHide) Cursor.visible = false;
        if (touchEnable) gameObject.AddComponent<TouchParent>();

    }

    public void mustExcute()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
