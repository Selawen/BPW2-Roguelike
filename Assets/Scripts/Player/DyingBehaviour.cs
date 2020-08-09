using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : StateMachineBehaviour
{
    private Player player;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.gameObject.GetComponent<Player>();
        }
        animator.SetBool("running", false);
        animator.SetBool("climbing", false);
        animator.SetFloat("yVelocity", 0);
    }
}
