using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour {
	public float StartTime;
	public float EndTime;
	private PlayerControler _PlayerScript;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.applyRootMotion = true;
		animator.GetComponent<PlayerControler>().canControl = false;
		if (_PlayerScript == null) {
			_PlayerScript = animator.GetComponent<PlayerControler> ();
		}
		_PlayerScript.EnableWeaponTrail ();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.normalizedTime > StartTime && stateInfo.normalizedTime < EndTime) {
			_PlayerScript._weapon.enabled = true;
		} else {
			_PlayerScript._weapon.enabled = false;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.applyRootMotion = false;
		_PlayerScript.canControl = true;
		_PlayerScript.DisableWeaponTrail ();
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
