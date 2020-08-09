using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public State currentState;

    private Animator animator;
    public Rigidbody2D rbPlayer;
    public SpriteRenderer playerSprite;

    public float jumpSpeed;
    public float runSpeed;
    public float climbSpeed;
    public bool canClimb;
    
    public Vector3 moveTowards;

    private bool died = false;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        rbPlayer.velocity = new Vector2(0,0);
        animator.SetBool("running", false);
        animator.SetBool("climbing", false);
    }

    private void FixedUpdate()
    {
        if (!died)
        {
            animator.SetFloat("yVelocity", rbPlayer.velocity.y);

            //look left when going left
            if (Input.GetAxis("Horizontal") < 0)
            {
                playerSprite.flipX = true;
            }
            //look right when going right
            else if (Input.GetAxis("Horizontal") > 0)
            {
                playerSprite.flipX = false;
            }

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Climbing"))
            {
                Move();
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            died = true;
        }
    }

    
    public void OnTriggerExit2D(Collider2D collision)
    {
        //if the player isn't touching anything
        if ((GetComponent<Collider2D>().GetContacts(new ContactPoint2D[4]) <= 0))
        {
            //if the player was climbing
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Climbing"))
            {
                animator.SetBool("climbing", false);
            }
            canClimb = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.y > gameObject.transform.position.y)
            canClimb = true;
    }

    private void Move()
    {
        moveTowards = new Vector3(Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime, 0);
        if (animator.GetBool("climbing"))
        {
            return;
        }
        gameObject.transform.Translate(moveTowards); 
    }

}
