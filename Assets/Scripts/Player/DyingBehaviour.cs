using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingBehaviour: StateMachineBehaviour
{
    private Player player;
    UIPanels panels;

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

        GameObject.Find("GameManager").GetComponent<SaveGame>().MissionFailed();
        panels = GameObject.Find("Canvas").GetComponent<UIPanels>();
        panels.deathPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
