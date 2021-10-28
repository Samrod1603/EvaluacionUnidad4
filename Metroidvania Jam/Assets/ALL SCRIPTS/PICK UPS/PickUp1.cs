using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp1 : MonoBehaviour
{
    Inventory invScript;
    public GameObject Player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            invScript = Player.GetComponent<Inventory>();
            invScript.GetMoney();
        }
    }
}
