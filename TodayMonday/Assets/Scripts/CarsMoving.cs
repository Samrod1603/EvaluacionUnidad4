using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMoving : MonoBehaviour
{
    Rigidbody rgbody;
    Trafficlight Tlight;
    public bool moving=true;
    public Vector3 actualVector;
    public bool semToFollowX;
    TIme CodeOfTime;
    public GameObject[] lights;
    bool lightsOn;

    void Start()
    {
        rgbody = gameObject.GetComponent<Rigidbody>();
        Tlight = GameObject.Find("Sems").GetComponent<Trafficlight>();
        CodeOfTime = GameObject.Find("Sun&Moon").GetComponent<TIme>();
    }

    private void FixedUpdate()
    {
        if (moving)
            rgbody.velocity = actualVector;
        else
            rgbody.velocity = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(!lightsOn && CodeOfTime.hours>=18)
        {
            PutTheLightsOn();
            lightsOn = true;
        }

        if(CodeOfTime.hours>6 && CodeOfTime.hours<18)
        {
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            lights[2].SetActive(false);
            lights[3].SetActive(false);
            lightsOn = false;
        }
    }

    void PutTheLightsOn()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
