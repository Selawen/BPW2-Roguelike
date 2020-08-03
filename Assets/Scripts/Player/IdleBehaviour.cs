﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private Player player;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.gameObject.GetComponent<Player>();
        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxis("Vertical") > 0.3 || Input.GetKey(KeyCode.Space))
        {
            player.rbPlayer.velocity = (new Vector2(player.rbPlayer.velocity.x, player.jumpSpeed));
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("running", true);
        }
    }
}