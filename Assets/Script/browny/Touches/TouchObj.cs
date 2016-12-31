using UnityEngine;
using System.Collections;

public class TouchObj : MonoBehaviour
{

    public virtual void onDowns()
    {
    }
    public virtual void onMoves()
    {
    }
    public virtual void onUps() { }


    public bool activate = false, isDown;

    public Vector3 curScreenSpace, offset;

    public bool getCollenAble()
    {

        bool _bool;
        if (GetComponent<Collider>() != null) _bool = GetComponent<Collider>().enabled;
        else _bool = GetComponent<Collider2D>().enabled;


        return _bool;
    }

#if UNITY_EDITOR || UNITY_STANDALONE

    public virtual IEnumerator OnMouseDown()
    {

        if (activate)
        {
            Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));

            curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
            curScreenSpace = Camera.main.ScreenToWorldPoint(curScreenSpace);

            dragging = true;

            if (!isDown) onDowns();
            isDown = true;

            EffCtrl.addSmoke(curScreenSpace);

            while (Input.GetMouseButton(0) && getCollenAble() && dragging)
            {
                curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
                curScreenSpace = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

                transform.position = new Vector3(curScreenSpace.x, curScreenSpace.y, -.3f);
                //PositionUtil.setPosition(transform, 9999, 9999, -.3f, false);
                onMoves();

                yield return null;
            }
        }
    }

    void OnMouseUp()
    {
        dragging = isDown = false;
        if (activate) onUps();
    }
#endif

    public bool dragging;

//#if UNITY_IOS || UNITY_IPHONE || UNITY_ANDROID

    Touch touch;
    float dist;
    int fingerID = 999;

   public virtual void Update()
    {
        if (dragging && fingerID != 999)
        {
            foreach (Touch _t in Input.touches)
                if (_t.fingerId == fingerID) { touch = _t; break; }

            if (touch.phase == TouchPhase.Moved)
            {
                curScreenSpace = new Vector3(touch.position.x, touch.position.y, dist);
                curScreenSpace = Camera.main.ScreenToWorldPoint(curScreenSpace);
                if (Mathf.Sqrt(Mathf.Pow((curScreenSpace.x - transform.position.x), 2f) + Mathf.Pow((curScreenSpace.y - transform.position.y), 2f)) < 2.2f)
                    transform.position = curScreenSpace + offset;

                onMoves();
            }
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                dragging = false;
                fingerID = 999;
                isDown = false;
                onUps();
            }
        }
    }

    public virtual void startDrag(int _touchID)
    {
        if (activate)
        {
            fingerID = _touchID;
            touch = Input.GetTouch(_touchID);
            dragging = true;
            dist = transform.position.z - Camera.main.transform.position.z;
            curScreenSpace = new Vector3(touch.position.x, touch.position.y, dist);
            curScreenSpace = Camera.main.ScreenToWorldPoint(curScreenSpace);
            offset = transform.position - curScreenSpace;
            if (!isDown) onDowns();
            isDown = true;

            EffCtrl.addSmoke(curScreenSpace);
        }
    }

//#endif
}
