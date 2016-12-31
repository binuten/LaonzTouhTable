using UnityEngine;
using System.Collections;

public class TouchParent : MonoBehaviour
{
    public bool isMulti = true;

    //#if UNITY_IOS || UNITY_IPHONE || UNITY_ANDROID
    void Update()
    {
        if (isMulti) multiTouch();
        else singleTouch();
    }

    void multiTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                //touch.fingerId;
                Vector3 touchPosition = touch.position;
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                    //RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                    Transform hitTrans = Physics2D.GetRayIntersection(ray, Mathf.Infinity).transform;

                    RaycastHit hitObj;
                    if (hitTrans == null && Physics.Raycast(ray, out hitObj))
                    { if (hitObj.transform.GetComponent<TouchObj>() != null) hitObj.transform.GetComponent<TouchObj>().startDrag(touch.fingerId); }
                    else if (hitTrans.transform != null && hitTrans.GetComponentInParent<TouchObj>())
                        hitTrans.GetComponentInParent<TouchObj>().startDrag(touch.fingerId);
                    else if (hitTrans.transform != null && hitTrans.GetComponent<TouchObj>() != null) hitTrans.GetComponent<TouchObj>().startDrag(touch.fingerId);

                }
            }
        }
    }
    //#endif


    void ScreenTouch()
    {
        //////////////////////////TODO Smoke 플레이 구현
    }

    private Transform toDrag;
    private float dist;
    Vector3 v3;
    private Vector3 offset;
    private bool dragging = false;

    void singleTouch()
    {
        if (Input.touchCount > 0)
        {
            ////for
            Touch touch = Input.touches[0];
            Vector3 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {

                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                if (hit.transform != null)
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(touchPosition.x, touchPosition.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;

                }
            }

            if (dragging && touch.phase == TouchPhase.Moved)
            {
                v3 = new Vector3(touchPosition.x, touchPosition.y, dist);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                toDrag.position = v3 + offset;
            }
            if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            {
                dragging = false;
                toDrag = null;
            }
        }


    }
}
