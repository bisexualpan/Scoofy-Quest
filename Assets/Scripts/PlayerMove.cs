using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Walk();
        Reflect();
        //Jump();
        CheckingGround();
    }

    public Vector2 moveVector;
    public float speed = 2f;

    public bool faceRight = true;
    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        // rb.AddForce(moveVector * speed);
    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) ||  (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    /* контрол прыжок
    public float jumpForce = 210f;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround) { jumpControl = true; }
        }
        else { jumpControl = false; }

        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
            {
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else { jumpIteration = 0; }
    }
    
    /* просто прыжок
    public float jumpForce = 210f;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround) 
        { 
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    */
    /* двойной прыжок
    public float jumpForce = 210f;
    private int jumpCount = 0;
    public int maxJumpValue = 2;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || (++jumpCount < maxJumpValue)))
        { 
            rb.AddForce(Vector2.up * jumpForce);
        }
        
        if (onGround) { jumpCount = 0; }
    }
     */
    /* контр + двойной прыжок
    public float jumpForce = 40f;
    private int jumpCount = 0;
    public int maxJumpValue = 2;
    public bool jumpControl;
    public float jumpTime = 0;
    public float jumpControlTime = 0.7f;
    public float doubleJumpVelocity = 10f;
     void Jump()
    {
        //---------------
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                jumpControl = true;
            }    
        }
        else { jumpControl = false; }
        //---------------
        if (Input.GetKeyDown(KeyCode.Space) && !onGround && (++jumpCount < maxJumpValue))
        {
            rb.velocity = new Vector2(0, doubleJumpVelocity);
        }
        //----------------
        if (onGround) { jumpCount = 0; }
        //----------------
        if (jumpControl)
        {
            if ((jumpTime += Time.deltaTime) < jumpControlTime)
            { 
                rb.AddForce(Vector2.up * jumpForce / (jumpTime * 10));
            }
        }
        else { jumpTime = 0; }
    }
    */
     


    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }
}
