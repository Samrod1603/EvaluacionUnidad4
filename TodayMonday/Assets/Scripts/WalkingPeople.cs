using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPeople : MonoBehaviour
{
    public bool imWalking = true;
    Rigidbody rgidb;
    public Vector3 actualVec;
    public bool semToFollowX;


    void Start()
    {
        rgidb = gameObject.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (imWalking)
            rgidb.velocity = actualVec;
        else
            rgidb.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("calle"))
        {
            transform.position = new Vector3(transform.position.x, -0.2f, transform.position.z);
        }

        if(other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("calle"))
            transform.position = new Vector3(transform.position.x, -0.1f, transform.position.z);
    }

}
