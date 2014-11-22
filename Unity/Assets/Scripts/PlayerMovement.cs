using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 4.0f;
    public float jumpSpeed = 8.0f;
    public float jumpHeight = 2.0f;
    public bool canJump = true;

    Animator anim;

    private State state; //for animation
    private bool facingRight;
    private bool isGrounded;

        

    private enum State
    {
        Idle = 0,
        Walking = 1,
        Jumping = 2,
        Falling = 3,
        Flying = 4,
        Kick = 5
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void Awake()
    {
    }


    // Use this for initialization
    void Start()
    {
        // Get the Animator component from your gameObject
        anim = GetComponent<Animator>();
        state = State.Idle;
        facingRight = true;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        animationHandling();
        if (isGrounded)
        {
            Debug.Log("just grounded");
            anim.SetBool("isFalling", false);
            anim.SetBool("isGrounded", true);
        }
    }

    void CheckInput()
    {

        if (Input.GetKey("a"))
        {
            facingRight = false; //for animation
            transform.position = new Vector2(transform.position.x - (walkSpeed * Time.deltaTime), transform.position.y);
            if (isGrounded)
            {
                state = State.Walking;
            }
        }
        if (Input.GetKey("d"))
        {
            facingRight = true; //for animation
            transform.position = new Vector2(transform.position.x + (walkSpeed * Time.deltaTime), transform.position.y);
            if (isGrounded)
            {
                state = State.Walking;
            }
        }
        if (Input.GetKeyDown("space"))
        {
            isGrounded = false;
            state = State.Jumping;
            
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }
    }

   /* bool IsGrounded()
    {
        return (rigidbody.velocity.y == 0);
    }*/

    void animationHandling()
    {
        // ANIMATION sector
        if (anim)
        {
            //Debug.Log("in the animator");
            if (state == State.Jumping)
            {
                //change to jump animation
                if (rigidbody.velocity.y > 0.0f && !isGrounded)
                {
                    anim.SetBool("isJumping", true);
                    anim.SetBool("isFalling", false);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isGrounded", false);
                }
                if (rigidbody.velocity.y < 0.0f && !isGrounded)
                {
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isFalling", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isGrounded", false);
                }
            }
            else if (state == State.Walking)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isWalking", true);
                if (rigidbody.velocity.x == 0.0f) {
                    anim.SetBool("isWalking", false);
                }
                //change to walk animation

            }
            else if (state == State.Kick)
            {
                //change to walk animation
            }
            else if (state == State.Idle)
            {
                //change to walk animation
            }
            else if (state == State.Flying)
            {
                //change to walk animation
            }
        }
    }
}
