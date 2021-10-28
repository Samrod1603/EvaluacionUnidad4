using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    public float Pinput;
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

    void Start()
    {
        RgidBody = GetComponent<Rigidbody2D>();
        speed = 10;
        grounded = true;
    }

    void FixedUpdate()
    {
        Pinput = Input.GetAxisRaw("Horizontal");
        RgidBody.velocity = new Vector2(Pinput * speed, RgidBody.velocity.y);

    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            RgidBody.velocity = Vector2.up * jumpForce;
            jumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && jumping == true)
        {
            if(jumpTimeCounter>0)
            {
                RgidBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
            jumping = false;

        if (Pinput<0)
        {
            transform.eulerAngles = new Vector3(0, 180,0);
        }

        if (Pinput>0)
        {
            transform.eulerAngles = new Vector3(0, 0,0);
        }
    }

}
