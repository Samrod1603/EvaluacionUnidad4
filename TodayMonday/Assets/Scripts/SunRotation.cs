using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    TIme TimeCode;
    public Transform pos1;
    public float theta;

    void Start()
    {
        TimeCode = gameObject.GetComponent<TIme>();

    }

    void Update()
    {
        this.transform.RotateAround(pos1.position, Vector3.right, theta);
    }


    
}
