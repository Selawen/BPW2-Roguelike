using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBehaviour : StateMachineBehaviour
{
    private Player player;
    ContactPoint2D[] contactPoints = new ContactPoint2D[4];

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.gameObject.GetComponent<Player>();
        }
        animator.SetBool("running", false);
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        if (player.GetComponent<Collider2D>().GetContacts(contactPoints) > 0)
        {
            foreach (ContactPoint2D contactPoint in contactPoints)
            {
                if (contactPoint.point.y < (player.gameObject.transform.position.y - 0.5) || contactPoint.point.y > (player.gameObject.transform.position.y + 0.5))
                {
                    contactPoints = new ContactPoint2D[4];
                    //animator.SetFloat("yVelocity", -0.002f);
                    return;
                }
            }

            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("climbing", true);
                player.rbPlayer.velocity = (new Vector2(0, 0));
            }
            else if (Input.GetAxis("Vertical") > 0.3)
            {
                player.rbPlayer.velocity = (new Vector2(0, player.jumpSpeed));
            }   
        }
    }
}
