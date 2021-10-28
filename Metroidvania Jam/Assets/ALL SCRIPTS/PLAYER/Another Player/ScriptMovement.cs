using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement : MonoBehaviour
{
    /*public float Pinput;
    private Rigidbody2D RgidBody;
    public float speed;

    private bool grounded;
    public float checkRadius;
    public Transform feetPos;
    public LayerMask whatisground;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool jumping;
    private bool facingRIGHT;
    private bool facingLEFT;
    public float knockback;
    public float knockbackCounter;
    private bool canMove;
    private bool turnAround;
    StateMachinePlayer StateMachine;
    public bool attackable;
    private float countAttackable;

    void Start()
    {
        RgidBody = GetComponent<Rigidbody2D>();
        speed = 10;
        grounded = true;
        turnAround = true;
        StateMachine = GetComponent<StateMachinePlayer>();
        attackable = true;
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            Pinput = Input.GetAxisRaw("Horizontal");
            RgidBody.velocity = new Vector2(Pinput * speed, RgidBody.velocity.y);
        }
    }


    void Update()
    {
        if (knockbackCounter >= 0)
        {
            knockbackCounter -= Time.deltaTime;
        }

        if (turnAround == true)
        {
            if (Pinput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                facingLEFT = true;
                facingRIGHT = false;
            }

            if (Pinput > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRIGHT = true;
                facingLEFT = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.state = 3;
        }

        if (countAttackable > 0)
        {
            countAttackable -= Time.deltaTime;
        }
        if (countAttackable <= 0)
        {
            attackable = true;
        }
    }



    public void Movement() // STATE 1
    {
        canMove = true;
        turnAround = true;
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        if (grounded == true && Input.GetKeyDown(KeyCode.Z))
        {
            RgidBody.velocity = Vector2.up * jumpForce;
            jumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Z) && jumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                RgidBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
            jumping = false;
    }

    public void EnemyKnockback() //STATE 2
    {
        Time.timeScale = 0.65f;
        canMove = false;
        countAttackable = 1;
        attackable = false;
        if (facingLEFT == true)
        {
            RgidBody.velocity = new Vector2(knockback, knockback);
        }
        else
        {
            RgidBody.velocity = new Vector2(-knockback, knockback);
        }

        if (knockbackCounter <= 0)
        {
            StateMachine.state = 1;
            Time.timeScale = 1;
        }
    }

    public void StayStill() // STATE 3
    {
        canMove = false;
        turnAround = false;
    }*/
}
