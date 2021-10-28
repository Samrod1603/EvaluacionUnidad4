using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    static public int health = 5;
    public GameObject[] lifes;
    private Rigidbody2D rgidBody;

    // Start is called before the first frame update
    void Start()
    {
        rgidBody = GetComponent<Rigidbody2D>();
        lifes[0] = GameObject.Find("life (1)");
        lifes[1] = GameObject.Find("life (2)");
        lifes[2] = GameObject.Find("life (3)");
        lifes[3] = GameObject.Find("life (4)");
        lifes[4] = GameObject.Find("life (5)");
        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            PlayerDied();
        }

        switch(health)
        {
            case 1:
                lifes[0].SetActive(true);
                lifes[1].SetActive(false);
                lifes[2].SetActive(false);
                lifes[3].SetActive(false);
                lifes[4].SetActive(false);
                break;
            case 2:
                lifes[0].SetActive(true);
                lifes[1].SetActive(true);
                lifes[2].SetActive(false);
                lifes[3].SetActive(false);
                lifes[4].SetActive(false);
                break;
            case 3:
                lifes[0].SetActive(true);
                lifes[1].SetActive(true);
                lifes[2].SetActive(true);
                lifes[3].SetActive(false);
                lifes[4].SetActive(false);
                break;
            case 4:
                lifes[0].SetActive(true);
                lifes[1].SetActive(true);
                lifes[2].SetActive(true);
                lifes[3].SetActive(true);
                lifes[4].SetActive(false);
                break;
            case 5:
                lifes[0].SetActive(true);
                lifes[1].SetActive(true);
                lifes[2].SetActive(true);
                lifes[3].SetActive(true);
                lifes[4].SetActive(true);
                break;
            case 6:
                break;
            case 7:
                break;
            default:
                lifes[0].SetActive(false);
                lifes[1].SetActive(false);
                lifes[2].SetActive(false);
                lifes[3].SetActive(false);
                lifes[4].SetActive(false);
                break;
        }
    }

    void PlayerDied()
    {
        //animación de morir
        //rgidBody.position = ;
    }

    public void LoseHealth()
    {
        health--;
    }
}
