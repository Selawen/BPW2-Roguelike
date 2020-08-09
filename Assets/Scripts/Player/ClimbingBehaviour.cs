using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingBehaviour : StateMachineBehaviour
{
    private Player player;
    ContactPoint2D[] contactPoints = new ContactPoint2D[4];

   [SerializeField] private bool alongCeiling;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.gameObject.GetComponent<Player>();
        }
        animator.SetBool("running", false);
        player.rbPlayer.gravityScale = 0;
        player.rbPlayer.velocity = new Vector2(0, 0);
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("climbing", false);
            return;
        }
    
        if (player.GetComponent<Collider2D>().GetContacts(contactPoints) > 0)
        {
            
            //checks if player is touching walls
            foreach (ContactPoint2D contactPoint in contactPoints)
            {
                if (contactPoint.point.y > (player.gameObject.transform.position.y + 0.4))
                {
                    alongCeiling = true;
                }
                else
                {
                    alongCeiling = false;
                }
            }
        }

        //move up or down along wall
        if (Input.GetAxis("Vertical") > 0.3 || Input.GetAxis("Vertical") < -0.3)
        {
            player.transform.Translate(new Vector3(0, Input.GetAxis("Vertical")*Time.deltaTime*player.climbSpeed));
        }

        //move sideways along ceiling
        if (alongCeiling && (Input.GetAxis("Horizontal") > 0.3 || Input.GetAxis("Horizontal") < -0.3))
        {
            player.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * player.climbSpeed, 0.0f));
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.rbPlayer.gravityScale = 1;
    }
}
