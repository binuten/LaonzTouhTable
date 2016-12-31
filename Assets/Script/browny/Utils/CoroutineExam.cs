using UnityEngine;
using System.Collections;

public class CoroutineExam : MonoBehaviour
{

    void Awake()
    {
        StartCoroutine(MyFunction(false, 1f));
        StartCoroutine(MyFunction(false, 2f));
        StartCoroutine(MyFunction(false, 5f));
    }

    public bool isStop;

    IEnumerator MyFunction(bool status, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Debug.Log("del---" + delayTime);
        if (isStop) StopAllCoroutines();
        // Now do your thing here
    }


}
