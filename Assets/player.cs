using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    public float horizontal;
    private bool flipRight = true;
    public Animator animator;
    public int jumpForce = 10;
    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    private Vector3 respawnPoint;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        respawnPoint = transform.position;
    }

   
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("moveX", Mathf.Abs (horizontal));

     /*   if(horizontal > 0 && !flipRight)
        {
            Flip();
        }else if(horizontal < 0 && flipRight)
        {
            Flip();
        }
     */
     if((horizontal > 0 && !flipRight) || (horizontal < 0 && flipRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            flipRight = !flipRight;
        }

        Jump();
        CheckingGround();

        
    }
 /* void Flip()
    {
        flipRight = !flipRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
 */
 void Jump()
    {
        if(onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}

