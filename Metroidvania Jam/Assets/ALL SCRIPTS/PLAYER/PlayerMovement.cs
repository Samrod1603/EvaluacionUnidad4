using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Pinput;
    public Rigidbody2D RgidBody;
    public float speed;
    public bool grounded;
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
    static public bool dashLock = true;             // ESTO ACTIVA EL DASH
    public float dashTime;
    public bool alreadyDashed;
    public bool canDashAgain;
    static public bool canWallJump = false;         // ESTO ACTIVA EL WALL JUMP
    public Transform WallGrab;
    private bool Walled;
    public LayerMask whatIsWalls;
    public float checkRadiusWall;
    private bool WallReleased;
    private float grabWallAgain;
    public static Animator Animator;
    private bool groundAnim;
    public Transform feetAnim;

    void Start()
    {
        RgidBody = GetComponent<Rigidbody2D>();
        speed = 10;
        grounded = true;
        turnAround = true;
        StateMachine = GetComponent<StateMachinePlayer>();
        attackable = true;
        //dashLock = true;
        alreadyDashed = false;
        //canWallJump = true;
        WallReleased = true;
        Animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            Pinput = Input.GetAxisRaw("Horizontal");
            RgidBody.velocity = new Vector2(Pinput * speed, RgidBody.velocity.y);
            Animator.SetFloat("move", Mathf.Abs(Pinput));
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            dashLock = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            canWallJump = true;
        }

        if (knockbackCounter>0)
        {
            knockbackCounter -= Time.deltaTime;
            if (facingRIGHT == true)
            {
                RgidBody.velocity = new Vector2(-15, 10);
            }
            else
            {
                RgidBody.velocity = new Vector2(15, 10);
            }           
        }

        if (countAttackable>0)
        {
            countAttackable -= Time.deltaTime;
        }
        else
        {
            attackable = true;
        }

        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            if (facingLEFT == true)
            {
                RgidBody.velocity = Vector2.left * 23;
            }
            else
            {
                RgidBody.velocity = Vector2.left * -23;
            }
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

        if (StateMachine.state == 1)
        {
            if (dashLock == false && alreadyDashed == false && Input.GetKeyDown(KeyCode.C) && canDashAgain == true)
            {
                StateMachine.state = 4;
                StateMachine.attackState = 2;
                dashTime = 0.18f;
                canDashAgain = false;
            }
            if (grounded == true)
            {
                canDashAgain = true;
            }
        }

        HandleAnimations();
    }



    public void Movement() // STATE 1
    {
        canMove = true;
        turnAround = true;
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);
        groundAnim = Physics2D.OverlapCircle(feetAnim.position, checkRadius, whatisground);

        if (grounded == true && Input.GetKey(KeyCode.Z))
        {
            RgidBody.velocity = Vector2.up * jumpForce;
            jumping = true;
            jumpTimeCounter = jumpTime;
            Animator.SetBool("jump", true);
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
                Animator.SetBool("jump", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            jumping = false;
            Animator.SetBool("jump", false);
        }

        if (canWallJump==true)
        {
            Walled = Physics2D.OverlapCircle(WallGrab.position, checkRadiusWall, whatIsWalls);
            if (grounded == false && Walled == true && WallReleased==true)
            {
                canMove = false;
                RgidBody.velocity = Vector2.up * 0.48f;
                Animator.SetLayerWeight(2, 1);
                Animator.SetBool("wallGrab", true);

                if (Input.GetKey(KeyCode.Z))
                {
                    if (facingRIGHT == true && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                    {
                        RgidBody.velocity = new Vector2(31, 25);
                        Debug.Log("You just wall Jumped to left");
                        canMove = true;
                        canDashAgain = true;
                        Animator.SetLayerWeight(2, 0);
                        Animator.SetBool("wallGrab", false);
                    }
                    else if (facingLEFT == true && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                    {
                        RgidBody.velocity = new Vector2(-31, 25);
                        Debug.Log("You just wall Jumped to right");
                        canMove = true;
                        canDashAgain = true;
                        Animator.SetLayerWeight(2, 0);
                        Animator.SetBool("wallGrab", false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    canMove = true;
                    WallReleased = false;
                    StartCoroutine(waitSec());
                }
            }
            if (grounded == true)
            {
                WallReleased = true;
            }
        }
    }

    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(0.27f);
        WallReleased = true;
    }

    public void JustDashed() // STATE 4
    {
        canMove = false;
        turnAround = false;
        alreadyDashed = true;
        jumping = false;
        Animator.SetBool("dash", true);

        if (dashTime<=0)
        {
            StateMachine.attackState = 1;
            StateMachine.state = 1;
            alreadyDashed = false;
            Animator.SetBool("dash", false);
        }
    }


    public void EnemyKnockback() //STATE 2
    {
        //Time.timeScale = 0.65f;
        canMove = false;
        countAttackable = 1;
        attackable = false;
        jumping = false;
        Animator.SetBool("jump", false);
    }

    public void StayStill() // STATE 3
    {
        canMove = false;
        turnAround = false;
    }

    void HandleAnimations()
    {
        if (!groundAnim)
        {
            Animator.SetBool("isGrounded", false); 
            Animator.SetFloat("velocityY", 1 * Mathf.Sign(RgidBody.velocity.y));
        }

        //groundAnim

        if (groundAnim)
        {
            Animator.SetBool("isGrounded", true);
            Animator.SetFloat("velocityY", 0);
        }
    }
}