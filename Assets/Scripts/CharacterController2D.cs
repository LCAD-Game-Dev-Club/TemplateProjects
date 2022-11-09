using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // This section is used to define all of the variables you need for your script to work
    // If a variable starts with the word "public" that means that you can see and edit the values in the Inspector, as well as from other scripts

    // These are all Components that we are going to be editing in the script
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;

    // This will be used to help us tell the editor what counts as ground in our scene
    public LayerMask groundLayer;

    // A bool is a true/false statement
    public bool isGrounded;
    public bool controlEnabled = true;

    // A float is a number slot that can allow decimal values
    public float speed;
    public float jumpForce;

    // Start is called before the first frame update
    private void Start()
    {
        // These look for the Components on our Game Object and assigns them to the proper variable slots we defined above
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {           
        // If Control Enabled is false...
        if (!controlEnabled)
        {
            // ... don't run anything past this line in Update
            return;
        }

        // This makes a new float, then sets the value of that float to the value of the current Horizontal input (Left/Right OR A/D)
        // These inputs are tracked as a scale from -1 to 1, where -1 is fully pressing a left input and 1 is fully pressing a right input
        float horizontalInput = Input.GetAxis("Horizontal");

        // If the player inputs any kind of Horizontal motion then move the character left and right accordingly
        myRigidbody.velocity = new Vector2(speed * horizontalInput, myRigidbody.velocity.y);

        myAnimator.SetFloat("CurrentSpeed", Mathf.Abs(myRigidbody.velocity.x));
        myAnimator.SetFloat("VerticalVelocity", myRigidbody.velocity.y);

        // If the player is inputting any kind of Horizontal motion...
        if (horizontalInput != 0)
        {
            // ... Set the bool for flipping the character sprite on the X axis to true if moving left, set to false if moving right
            mySpriteRenderer.flipX = (horizontalInput < 0);
        }
        
        // If the player presses the Jump button and the character is on the ground...
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            // ... Play the animation for launching into the air...
            myAnimator.Play("Launch");
            // ... And launch the character into the air
            myRigidbody.velocity = new Vector2(0, jumpForce);
        }   


    }

    // Fixed update is called at a fixed interval, regardless of game frame rate
    // This is usually where you want to do physics calculations
    private void FixedUpdate()
    {
        // This calls the function that checks to see if the character is on the ground
        GroundCheck();
    }

    // This function casts a ray from the center of the character to just below the character and checks to see if any Game Objects that the ray touches have the "Ground" tag
    // This is used to decide whether or not the player is allowed to jump
    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .1f, groundLayer);

        // If the ray hits something tagged "Ground", then the character is grounded
        if (hit.collider != null)
        {
            isGrounded = true;
        }

        // If the ray does not hit something tagged "Ground", the the character is not grounded
        else
        {
            isGrounded = false;
        }

        // Set the "OnGround" bool in the Animator to match the value of the "isGrounded" bool we just set above
        myAnimator.SetBool("OnGround", isGrounded);
    }

    public void OnGameOver()
    {
        controlEnabled = false;
        myAnimator.SetFloat("CurrentSpeed", 0);
        myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
    }
}
