using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rbPlayer;
    public SpriteRenderer playerSprite;

    public float bounce;
    public float yVelocity;
    public float jumpSpeed;
    public float runSpeed;
    private float xVelocity;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        yVelocity = 0;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity", rbPlayer.velocity.y);

        //look left when going left
        if (Input.GetAxis("Horizontal") < 0)
        {
            playerSprite.flipX = true;
            bounce = 5;
        }
        //look right when going right
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerSprite.flipX = false;
            bounce = -5;
        }

        Move(); 
    }

    public void Move()
    {
        //xVelocity = Input.GetAxis("Horizontal") * runSpeed + rbPlayer.position.x;
        //Mathf.Clamp(xVelocity, -2*runSpeed, 2*runSpeed);

        //move left/right
        //rbPlayer.velocity = (new Vector2(xVelocity, rbPlayer.velocity.y));
        //rbPlayer.MovePosition(new Vector2(xVelocity, 0)+ rbPlayer.velocity);
        gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * runSpeed*Time.deltaTime, 0));

        if (rbPlayer.velocity.x != 0)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x +(Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime), rbPlayer.velocity.y);
        }
        //rbPlayer.AddForce(new Vector2(Input.GetAxis("Horizontal")*runSpeed, 0));
    }

    public void StopRunning()
    {
        animator.SetBool("running", false);
    }

    /*
        public void SwitchState()
        {
            if (yVelocity < -0.01)
            {
                currentState = State.Down;
                return;
            }

            switch (currentState)
            {
                case State.Idle:

                    if (Input.GetAxis("Vertical") > 0.01)
                    {
                        rbPlayer.velocity = (new Vector2(rbPlayer.velocity.x, jumpSpeed));
                        currentState = State.Up;
                    }
                    else if (Input.GetAxis("Horizontal") != 0)
                    {
                        currentState = State.Running;
                    }
                        break;
                case State.Running:
                    if (Input.GetAxis("Vertical") > 0.01)
                    {
                        rbPlayer.velocity = (new Vector2(rbPlayer.velocity.x, jumpSpeed));
                        currentState = State.Up;
                    } else if (Input.GetAxis("Horizontal") == 0)
                    {
                        currentState = State.Idle;
                    }
                    break;
                case State.Up:

                    break;
                case State.Down:
                    if (yVelocity >= -0.01)
                    {
                        currentState = State.Idle;
                    }
                    break;
            }
        }*/
}
