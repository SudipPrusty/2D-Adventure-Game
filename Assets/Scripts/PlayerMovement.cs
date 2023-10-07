using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;                                         //private is used so that no other class members can access them
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;              //datatype for a layer is LayerMask     //jumpableGround is the variable name

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;                //SerializeField is used to get the required field in unity window under the script component
    [SerializeField] private float jumpForce = 15f;

    private enum MovementState { Idle, Run, Jump, Fall }           //enum is a value type defined by a set of named constants of the integral numeric type

    [SerializeField] private AudioSource jumpSoundEffect;

    //Start is called before the first frame update
    private void Start()                                            //void is used to specify that the method doesn't return a value
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        
        if (dirX > 0f)                                      //for rightward movement
        {
            state = MovementState.Run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)                                 //for leftward movement
        {
            state = MovementState.Run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)                            //0 isn't used bcz here a little amount of force is needed as we are not standing idle
        {
            state = MovementState.Jump;
        }
        else if(rb.velocity.y < -.1f)                       // -.1f is used as downward force is needed
        {
            state = MovementState.Fall;
        }

        anim.SetInteger("state", (int)state);               //int is used in order to maintain the state values in integral type for enum
    }

    private bool IsGrounded()                               //Here, return type is bool
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
