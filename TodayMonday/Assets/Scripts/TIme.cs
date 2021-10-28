using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIme : MonoBehaviour
{
    public int hourDuration=8;
    public int hours;
    public static int day=1;
    public static int currentTime;
    CarsGenerator CarsGenCode;

    bool PassedDay = false;
    bool skipDelay=true;
    public uint dayTime=1;

    private void Start()
    {
        hours = 12;
        StartCoroutine(MovingHours(hourDuration));
        CarsGenCode = GameObject.Find("GENERATOR X").GetComponent<CarsGenerator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && skipDelay)
        {
            StartCoroutine(RestartedTimeMover());
            skipDelay = false;
        }

        if (hours >= 6 && hours < 12)
        {

            dayTime = 1;

            currentTime = 1;
            //mañana
        }
        else if (hours>=12 && hours <=18)
        {

            dayTime = 2;

            currentTime = 2;
            //tarde 
        }
        else if (hours>18 && hours != 100)
        {

            dayTime = 3;

            currentTime = 3;
            //noche
            if (hours>24 && hours != 100)
            {
                hours = 1;
                PassedDay = true;
                day++;
                if (hours==2)
                {
                    StartCoroutine(RestartedTimeMover());
                    skipDelay = false;
                }
            }
        }

        switch (day)
        {
            case 1:
                //lunes
                break;
            case 2:
                //martes
                break;
            case 3:
                //miercoles
                break;
            case 4:
                //jueves
                break;
            case 5:
                //viernes
                break;
            case 6:
                //sabado
                break;
            case 7:
                //domingo
                break;
            default:
                day = 1;
                break;
        }
    }

    IEnumerator MovingHours(int HourDuration)
    {
        Debug.Log("Started coroutine");
        while (hours <= 24 && hours != 100)
        {
            hours++;
            if(hours==7 || hours==18)
            {
                CarsGenCode.BusGenerator();
            }
            yield return new WaitForSeconds(HourDuration);
        }
    }

    IEnumerator RestartedTimeMover()
    {
        if (PassedDay)
        {
            hours = 100;
            StopCoroutine(MovingHours(hourDuration));
            Debug.Log("Cargando pal nuevo dia");
            yield return new WaitForSeconds(3);
            dayTime = 1; // puede dar error
            hours = 7;
            StartCoroutine(MovingHours(hourDuration));
            PassedDay = false;
        }
        else
        {
            hours = 100;
            StopCoroutine(MovingHours(hourDuration));

            Debug.Log("Cargando pal nuevo dia");
            yield return new WaitForSeconds(3);
            hours = 6;
            day++;
            dayTime = 1; // puede dar error
            StartCoroutine(MovingHours(hourDuration));
        }
        StartCoroutine(DelayToSkipAgain());
    }

    IEnumerator DelayToSkipAgain()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("can skip Again");
        skipDelay = true;
    }
}
