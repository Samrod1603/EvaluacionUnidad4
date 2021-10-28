using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peoplegenerator : MonoBehaviour
{
    public GameObject[] AllPersons;
    int randPerson;
    int randPerson2;
    int peopleNum;
    int peopleNum2;
    float secondsToWait;
    float secondsToWait2;
    public Transform Spawnpoint;
    public Transform Spawnpoint2;
    TIme Tcode;
    GameObject thisPerson;
    GameObject thisPerson2;
    WalkingPeople peoplewalkCode;
    WalkingPeople peoepleCodeWalk2;
    float randToPosition;
    float randToPosition2;
    float speed;
    float speed2;

    void Start()
    {
        Tcode = GameObject.Find("Sun&Moon").GetComponent<TIme>();
        StartCoroutine(Generator());
        StartCoroutine(Generator2());
    }

    IEnumerator Generator()
    {
        peopleNum = Random.Range(1, 6);

        for (int i = 0; i < peopleNum; i++)
        {
            speed = Random.Range(1.13f, 1.69f);
            randToPosition = Random.Range(-0.279f, 0.3f);
            randPerson = Random.Range(0, 7);
            secondsToWait = Random.Range(0.6f, 2.3f);
            thisPerson = Instantiate(AllPersons[randPerson], Spawnpoint);
            peoplewalkCode = thisPerson.GetComponent<WalkingPeople>();
            if (gameObject.CompareTag("GenX"))
            {
                peoplewalkCode.actualVec = new Vector3(speed, 0, 0);
                peoplewalkCode.semToFollowX = true;
            }
            else
            {
                peoplewalkCode.actualVec = new Vector3(0, 0, speed);
                peoplewalkCode.semToFollowX = false;

            }
            thisPerson.transform.position = new Vector3(thisPerson.transform.position.x + randToPosition, thisPerson.transform.position.y, thisPerson.transform.position.z + randToPosition);
            yield return new WaitForSeconds(secondsToWait);
        }

        StartCoroutine(waitToRestart1());
    }

    IEnumerator Generator2()
    {
        peopleNum2 = Random.Range(1, 6);

        for (int i = 0; i < peopleNum2; i++)
        {
            speed2 = Random.Range(1.13f, 1.69f);
            randToPosition2 = Random.Range(-0.279f, 0.3f);
            randPerson2 = Random.Range(0, 7);
            secondsToWait2 = Random.Range(0.6f, 2.3f);
            thisPerson2 = Instantiate(AllPersons[randPerson2], Spawnpoint2);
            peoepleCodeWalk2 = thisPerson2.GetComponent<WalkingPeople>();
            if (gameObject.CompareTag("GenX"))
            {
                peoepleCodeWalk2.actualVec = new Vector3(-speed2, 0, 0);
                peoepleCodeWalk2.semToFollowX = true;
            }
            else
            {
                peoepleCodeWalk2.actualVec = new Vector3(0, 0, -speed2);
                peoepleCodeWalk2.semToFollowX = false;

            }
            thisPerson2.transform.position = new Vector3(thisPerson2.transform.position.x + randToPosition2, thisPerson2.transform.position.y, thisPerson2.transform.position.z + randToPosition2);
            yield return new WaitForSeconds(secondsToWait2);
        }

        StartCoroutine(waitToRestart2());
    }


    IEnumerator waitToRestart1()
    {
        float secsTowait = Random.Range(3.3f, 7.3f);
        yield return new WaitForSeconds(secsTowait);
        StartCoroutine(Generator());
    }

    IEnumerator waitToRestart2()
    {
        float secsTowait = Random.Range(3.8f, 7.9f);
        yield return new WaitForSeconds(secsTowait);
        StartCoroutine(Generator2());
    }
}
