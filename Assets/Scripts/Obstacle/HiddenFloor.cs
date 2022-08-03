using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenFloor : MonoBehaviour
{

    void ActivateGameobject (bool b)
    {
        Transform child = gameObject.transform.GetChild(0);
        child.gameObject.SetActive(b);
    }

    IEnumerator WaitForShowGameobject(int second)
    {
        yield return new WaitForSeconds(second);
        ActivateGameobject(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("coliision");
        ActivateGameobject(false);
        StartCoroutine(WaitForShowGameobject(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        ActivateGameobject(false);
        StartCoroutine(WaitForShowGameobject(5));
    }
}
