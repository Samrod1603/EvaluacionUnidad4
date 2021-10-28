using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStoping : MonoBehaviour
{
    public GameObject myCar;
    GameObject goInFront;
    Trafficlight Tlight;
    CarsMoving carEngine;

    CarsMoving frontCarEngine;

    private void Start()
    {
        carEngine = myCar.GetComponent<CarsMoving>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("semaforo"))
        {
            goInFront = other.gameObject;
            Tlight = goInFront.GetComponent<Trafficlight>();
            if(carEngine.semToFollowX)
            {
                switch(Tlight.SemXColor)
                {
                    case 1:
                        StartCoroutine(waitABitToStart());
                        //carEngine.moving = true;
                        break;
                    default:
                        carEngine.moving = false;
                        break;
                }
            }
            else
            {
                switch(Tlight.SemZColor)
                {
                    case 1:
                        StartCoroutine(waitABitToStart());
                        //carEngine.moving = true;
                        break;
                    default:
                        carEngine.moving = false;
                        break;
                }
            }
        }

        if(other.gameObject.CompareTag("car"))
        {
            goInFront = other.gameObject;
            frontCarEngine = goInFront.GetComponent<CarsMoving>();
            if (!frontCarEngine.moving)
                carEngine.moving = false;
            else
                StartCoroutine(waitABitToStart());
            //carEngine.moving = true;
        }

        if(other.CompareTag("Person"))
        {
            carEngine.moving = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        goInFront = null;
        frontCarEngine = null;

        if(other.CompareTag("Person"))
        {
            carEngine.moving = true;
        }
    }

    IEnumerator waitABitToStart()
    {
        yield return new WaitForSeconds(0.38f);
        carEngine.moving = true;
    }
}
