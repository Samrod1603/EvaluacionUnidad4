using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleStoping : MonoBehaviour
{
    //public GameObject myCar;
    public GameObject thispana;

    //GameObject goInFront;
    public GameObject stuffInFront;

    Trafficlight Tlight;
    //CarsMoving carEngine;
    WalkingPeople walkinPersonThis;

    //CarsMoving frontCarEngine;
    WalkingPeople codeOfWalkingPeop;

    bool alreadyStoppedBySem;

    private void Start()
    {
        walkinPersonThis = thispana.GetComponent<WalkingPeople>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("semaforo") && !alreadyStoppedBySem)
        {
            stuffInFront = other.gameObject;
            Tlight = stuffInFront.GetComponent<Trafficlight>();
            if (walkinPersonThis.semToFollowX)
            {
                switch (Tlight.SemXColor)
                {
                    case 1:
                        StartCoroutine(waitABitToStart());
                        break;
                    default:
                        walkinPersonThis.imWalking = false;
                        break;
                }
            }
            else
            {
                switch (Tlight.SemZColor)
                {
                    case 1:
                        StartCoroutine(waitABitToStart());
                        break;
                    default:
                        walkinPersonThis.imWalking = false;
                        break;
                }
            }
        }

        /*if (other.gameObject.CompareTag("Person"))
        {
            stuffInFront = other.gameObject;
            codeOfWalkingPeop = stuffInFront.GetComponent<WalkingPeople>();
            if (!codeOfWalkingPeop.imWalking)
                walkinPersonThis.imWalking = false;
            else
                StartCoroutine(waitABitToStart());
            //carEngine.moving = true;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        stuffInFront = null;
        codeOfWalkingPeop = null;
        if(other.CompareTag("semaforo"))
        {
            alreadyStoppedBySem = true;
        }
    }

    IEnumerator waitABitToStart()
    {
        yield return new WaitForSeconds(0.38f);
        walkinPersonThis.imWalking = true;
    }
}
