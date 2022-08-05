using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainTrigger : MonoBehaviour
{
    public Transform villainParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CEEKKKK COLLISION");
        if (collision.gameObject.tag == "Player" )
        {
            villainParent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CEEKKKK Trigger");
        if (other.tag == "Player")
        {
            villainParent.gameObject.SetActive(false);
        }
    }
}
