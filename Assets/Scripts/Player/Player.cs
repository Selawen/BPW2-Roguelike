﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rbPlayer;
    public SpriteRenderer playerSprite;

    public float yVelocity;
    public float jumpSpeed;
    public float runSpeed;
    public float climbSpeed;
    
    public Vector3 moveTowards;

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
        }
        //look right when going right
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerSprite.flipX = false;
        }

        Move(); 
    }

    public void Move()
    {
        moveTowards = new Vector3(Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime, 0);
        if (animator.GetBool("climbing"))
        {
            return;
        }
        gameObject.transform.Translate(moveTowards); 
    }
}
