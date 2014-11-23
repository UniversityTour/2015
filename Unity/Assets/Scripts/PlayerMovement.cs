using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 4.0f;
    public float jumpSpeed = 8.0f;
    public float jumpHeight = 2.0f;
    public bool canJump = true;
    public bool isDead = false;

    Animator anim;

    private State state; //for animation
    private bool facingRight;
    private bool isGrounded;
    private bool inFrontOfDoor=false;
    private float maxLeftPos;
    public Transform spawnPoint;
    public GameObject explosionPrefab;


    private int numLives = 5;
    private int points = 0;


    private enum State
    {
        Idle = 0,
        Walking = 1,
        Jumping = 2,
        Falling = 3,
        Flying = 4,
        Kick = 5
    }


    // Use this for initialization
    void Start()
    {
        // Get the Animator component from your gameObject
        anim = GetComponent<Animator>();
        state = State.Idle;
        facingRight = true;
        isGrounded = false;
        //jumpSound = GameObject.Find("AudioJump");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(numLives < 0)
            Application.LoadLevel(0);
        CheckInput();
        animationHandling();
        if (isGrounded)
        {
            //Debug.Log("just grounded");
            anim.SetBool("isFalling", false);
            anim.SetBool("isGrounded", true);
        }
    }

    void CheckInput()
    {
        // go left
        if (Input.GetKey("a"))
        {
            facingRight = false; //for animation
            transform.position = new Vector2(transform.position.x - (walkSpeed * Time.deltaTime), transform.position.y);

            
            if (transform.position.x < maxLeftPos - 3.0f)
            {
                transform.position = new Vector2(maxLeftPos - 3.0f, transform.position.y);
            }
            if (isGrounded)
            {
                state = State.Walking;
            }
        }
        //go right
        if (Input.GetKey("d"))
        {
            facingRight = true; //for animation
            transform.position = new Vector2(transform.position.x + (walkSpeed * Time.deltaTime), transform.position.y);
            maxLeftPos = transform.position.x;
            if (isGrounded)
            {
                state = State.Walking;
            }
        }
        // jump
        if (Input.GetKeyDown("space") && !(anim.GetBool("isJumping") || anim.GetBool("isFalling")))
        {
            isGrounded = false;
            state = State.Jumping;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            audio.Play();
        }
        // enter door
        if (Input.GetKeyDown("w"))
        {
            Debug.Log("w pressed");
            if (((DoorScript)GameObject.FindGameObjectWithTag("door").GetComponent<DoorScript>()).getTriggerStateDoor())
            {
                //level completed
                //load new level
                ((Animator)GameObject.FindGameObjectWithTag("door").GetComponent<Animator>()).SetBool("justOpened",true);         
            }
        }
    }

    // handles the animation with the animator
    void animationHandling()
    {
        // ANIMATION sector
        if (anim)
        {
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
                //change to fall animation
                if (rigidbody.velocity.y < 0.0f && !isGrounded)
                {
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isFalling", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isGrounded", false);
                }
            }
            // change to walk animation
            else if (state == State.Walking)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isWalking", true);
                if (rigidbody.velocity.x == 0.0f)
                {
                    anim.SetBool("isWalking", false);
                }
                //change to walk animation

            }
            else if (state == State.Kick)
            {
                //change to kick animation, roundhousekick
            }
            else if (state == State.Idle)
            {
                //change to walk animation
                // changes yet automatically
            }
            else if (state == State.Flying)
            {
                //change to fly animation with jetpack
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "fallgrube")
        {
            Debug.Log("TOOOOOT!!!");
            
            anim.SetBool("isDead", true);
            
            //animation.Play(animation.clip.name);
            // hier explosion abspielen
            //maxLeftPos = spawnPoint.position.x;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "Enemy")
        {
            //points += 20;
        }
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    //setze spieler und kamera zurück an spawnpoint
    void respawnPlayer()
    {
        numLives--;
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;//new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        GameObject.FindGameObjectWithTag("MainCamera").transform.position =
            new Vector3(spawnPoint.position.x + 4.0f, spawnPoint.position.y + 2.0f, spawnPoint.position.z - 10.0f);
        anim.SetBool("isDead", false);        
    }

    void OnGUI()
    {
        var prev = GUI.skin;
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment =  TextAnchor.MiddleRight;
        GUI.Label(new Rect(Screen.width - 70, 15, 60, 30), numLives + "   Leben", centeredStyle);
        //GUI.Label(new Rect(Screen.width - 200, 30, 190, 30), points + "  Points",centeredStyle);
        GUI.skin = prev;
    }

}
