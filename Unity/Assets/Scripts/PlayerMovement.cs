using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed;
    public float jumpSpeed;
    private State state; //for animation
    private bool facingRight;
    private bool isGrounded;

    private enum State
    {
        Idle,
        Walking,
        Jumping
    }

    // Use this for initialization
    void Start()
    {
        state = State.Idle;
        facingRight = true;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        
        if (Input.GetKey("a"))
        {
            facingRight = false; //for animation
            transform.position = new Vector2(transform.position.x - (walkSpeed * Time.deltaTime), transform.position.y);//, transform.position.z);
        }
        if (Input.GetKey("d"))
        {
            facingRight = true; //for animation
            transform.position = new Vector2(transform.position.x + (walkSpeed * Time.deltaTime), transform.position.y);//, transform.position.z);
        }
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            isGrounded = false;
            state = State.Jumping;
            transform.position = new Vector2(transform.position.x, rigidbody.velocity.y + jumpSpeed );//, transform.position.z);
        }
        if (IsGrounded())
        {
            isGrounded = true;
        }
    }

    bool IsGrounded()
    {
        return (rigidbody.velocity.y==0);
    }

}
