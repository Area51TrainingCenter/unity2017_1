using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBehaviour : StateMachineBehaviour {
	public float startTime;
	public float endTime;
	private PlayerControl playerScript;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (playerScript==null) {
			playerScript = animator.GetComponent<PlayerControl>();
		}
		animator.applyRootMotion = true;
		playerScript.canControl = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {		
		if (stateInfo.normalizedTime >= startTime) {
			playerScript._weapon.enabled = true;
		} 
		if (stateInfo.normalizedTime >= endTime) {
			playerScript._weapon.enabled = false;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.applyRootMotion = false;
		playerScript.canControl = true;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
