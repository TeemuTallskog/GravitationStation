using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedCheker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor = 0.1f;
    float lastTimeGrounded;
    public float airJumps;
    float currentJumps;
    private SpriteRenderer playerSpriteRenderer;
    private Animator animator;
    List<Collider2D> colliding = new List<Collider2D>();
    public static bool upDown;
    private bool isWalking = false;


   // [SerializeField] private Oxygen m;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

       // m.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        upDown = Gravity.UpDown;
        Move();
        Jump();
        CheckIfGrounded();
        Animate();
        ActivationKey();
        Sound();
    }

    void Move() //Left and right movement
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }


    void Jump() //Jumping
    {
        if (Input.GetKeyDown(KeyCode.Space) && ((isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor) || currentJumps < airJumps)) //rememberGroundedfor adds "coyote time" alloving the player to jump a tiny moment after falling off a ledge
        {
            if (upDown == true) //If gravity is reversed, jumpForce is inverted as well
            {
                rb.velocity = new Vector2(rb.velocity.x, (jumpForce * -1));
                currentJumps = currentJumps + 1;
                SoundController.PlaySound("jump");
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                currentJumps = currentJumps + 1;
                SoundController.PlaySound("jump");
            }
        }
    }

    void Animate() //Player walking animations
    {
        if (Input.GetKey(KeyCode.Space) && !isGrounded) //Walk animations are only played if the player is on the ground
        {
            animator.Play("Jump");
            isWalking = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerSpriteRenderer.flipX = false;
            if (isGrounded) animator.Play("Walk");
            if(isGrounded) isWalking = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerSpriteRenderer.flipX = true;
            if (isGrounded) animator.Play("Walk");
            if(isGrounded) isWalking = true;
        }
        if (!Input.anyKey && isGrounded) //Stops the animation if no key is pressed
        {
            animator.Play("Idle");
            isWalking = false;
        }
    }

    private void Sound() //Plays walking sound if the player is walking and is grounded.
    {
        if (isWalking && isGrounded)
        {
            SoundController.PlaySound("walk");
        }
    }

    void CheckIfGrounded() //Checks if the player is on the ground, and if not, how long ago were they on the ground
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedCheker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
            currentJumps = 0;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }


    void ActivationKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            colliding.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver)); //if player collides with an object with trigger and press "E" it will send it a "Use" message. If the obejct has a script with a Use() function, it will be run.
        }
    }

    void OnTriggerEnter2D(Collider2D collider) // If Player collides with a collider that has a trigger it will be added to a list.
    {
        colliding.Add(collider);
    }

    void OnTriggerExit2D(Collider2D collider)  // If the Player is no more in collistion with a trigger it will be removed from the list.
    {
        colliding.Remove(collider);
    }
   
    public void ToggleUpDown()
    {
        upDown = !upDown;
    }

}