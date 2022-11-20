using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    public int hp = 3;

    // These are all Components that we are going to be editing in the script
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;

    // This will be used to help us tell the editor what counts as ground in our scene
    public LayerMask groundLayer;


    // A bool is a true/false statement
    public bool isGrounded;
    public bool isDead = false;

    // A float is a number slot that can allow decimal values
    public float speed;

    public bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        myAnimator.SetFloat("CurrentSpeed", Mathf.Abs(myRigidbody.velocity.x));
        myAnimator.SetFloat("VerticalVelocity", myRigidbody.velocity.y);
        mySpriteRenderer.flipX = !movingRight;

        myRigidbody.velocity = new Vector2(speed * (movingRight? 1f : -1f), myRigidbody.velocity.y);
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

    public void OnHit()
    {
        if (isDead)
        {
            return;
        }
        Debug.Log("OnHit");

        hp -= 1;
        if (hp == 0) 
        {
            OnDeath();
        }
    }
    
    public void OnDeath()
    {
        isDead = true;
        Debug.Log("Death");
        
        // Set the Current Speed in the Animator to 0...
        myAnimator.SetFloat("CurrentSpeed", 0);
        // and Set the Player's Horizontal Velocity to 0
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isDead)
        {
            //myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
            return;
        }
        else
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Vector2 surfaceNormal = contact.normal;

                if (movingRight && surfaceNormal.x < -0.9f)
                {
                    movingRight = false;
                    return;
                }
                else if (!movingRight && surfaceNormal.x > 0.9f)
                {
                    movingRight = true;
                    return;

                }
            }
        }
    }

}
