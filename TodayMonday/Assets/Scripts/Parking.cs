using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parking : MonoBehaviour
{
    public GameObject[] cars=new GameObject[6];
    public Transform[] slots = new Transform[7];
    bool[] used=new bool[7];
    bool[] carAlreadyParked = new bool[6];
    int numCars;

    void Start()
    {
        numCars = Random.Range(0, 6);

        for (int i = 0; i < used.Length; i++)
        {
            used[i] = false;
        }

        for (int i = 0; i < carAlreadyParked.Length; i++)
        {
            carAlreadyParked[i] = false;
        }

        ParkingCars();
    }


    void ParkingCars()
    {
        for (int i = 0; i < numCars; i++)
        {
            parkingGenerator();
        }
    }

    void parkingGenerator()
    {
        int whichCar = Random.Range(0, 6);
        int whichSlot = Random.Range(0, 6);

        if (!used[whichSlot] && !carAlreadyParked[whichCar])
        {
            Instantiate(cars[whichCar], slots[whichSlot]);
            used[whichSlot] = true;
            carAlreadyParked[whichCar] = true;
        }
        else
            parkingGenerator();
    }

}
