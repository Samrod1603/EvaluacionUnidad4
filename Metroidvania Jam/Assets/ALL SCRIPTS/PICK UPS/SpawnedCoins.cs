using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedCoins : MonoBehaviour
{
    private float Xrandom;
    private float Yrandom;
    PickUp1 Pick;
    int bounces;
    int bounceForce;
    public Rigidbody2D rigidCoin;

    void Start()
    {
        bounces = 0;
        bounceForce = 12;
        Pick = GetComponent<PickUp1>();
        rigidCoin = GetComponent<Rigidbody2D>();

        StartCoroutine(shootedcoins());
    }


    IEnumerator shootedcoins()
    {
        Xrandom = UnityEngine.Random.Range(-6, 6);
        Yrandom = UnityEngine.Random.Range(10, 17);
        yield return new WaitForSeconds(0.08f);

        rigidCoin.velocity = new Vector2(Xrandom, Yrandom);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            bounces++;
            rigidCoin.velocity = new Vector2(rigidCoin.velocity.x, bounceForce);
            bounceForce -= 2;
            if (bounces > 7)
            {
                rigidCoin.velocity = new Vector2(rigidCoin.velocity.x, 0);
            }
        }
    }
}
