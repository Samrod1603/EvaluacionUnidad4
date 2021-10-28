using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trafficlight : MonoBehaviour
{
    public uint lightColour=1;   //0 apagado    1 rojo   2 amarillo    3 verde    4 titilando
    public GameObject redCube;
    public GameObject yellowCube;
    public GameObject greenCube;

    public uint SemXColor;
    public uint SemZColor;


    void Start()
    {
        StartCoroutine(SemaforoChimba());
    }

    IEnumerator SemaforoChimba()  //0 = ROJO     1 = VERDE    2 = TITILA      3 = AMARILLO
    {
        SemXColor = 0;
        SemZColor = 1;
        yield return new WaitForSeconds(3);
        SemZColor = 2;
        yield return new WaitForSeconds(0.5f);
        SemZColor = 3;
        yield return new WaitForSeconds(0.4f);
        SemZColor = 0;
        yield return new WaitForSeconds(0.28f);
        SemXColor = 1;
        yield return new WaitForSeconds(3);
        SemXColor = 2;
        yield return new WaitForSeconds(0.5f);
        SemXColor = 3;
        yield return new WaitForSeconds(0.4f);
        SemXColor = 0;
        yield return new WaitForSeconds(0.27f);

        StartCoroutine(SemaforoChimba());
    }

    IEnumerator traficLights()
    {
        lightColour = 1;
        redCube.SetActive(false);
        yellowCube.SetActive(true);
        greenCube.SetActive(true);
        yield return new WaitForSeconds(3);

        lightColour = 3;
         redCube.SetActive(true);
         yellowCube.SetActive(true);
         greenCube.SetActive(false);

        yield return new WaitForSeconds(4);

        for (int i = 0; i < 5; i++)
        {
            redCube.SetActive(true);
            yellowCube.SetActive(true);
            greenCube.SetActive(true);
            lightColour = 0;
            yield return new WaitForSeconds(0.5f);
             redCube.SetActive(true);
             yellowCube.SetActive(false);
             greenCube.SetActive(true);
             lightColour = 4;
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(traficLights());
    }
}
