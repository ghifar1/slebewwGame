using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenFloor2 : MonoBehaviour
{
    bool isTriggered = false;

    void ActivateGameobject(bool b)
    {
        Transform child = gameObject.transform.GetChild(0);
        child.gameObject.SetActive(b);
    }

    IEnumerator WaitToActivateObject(float hideSec, float showSec)
    {
        yield return new WaitForSecondsRealtime(hideSec);
        ActivateGameobject(false);
        yield return new WaitForSecondsRealtime(showSec);
        ActivateGameobject(true);
        isTriggered = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isTriggered)
        {
            isTriggered = true;
            StartCoroutine(WaitToActivateObject(0.5f, 1));
        }
    }
}
