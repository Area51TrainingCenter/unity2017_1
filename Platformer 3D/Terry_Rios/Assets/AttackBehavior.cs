using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour {

	public float StartTime;
	public float EndTime;

	private PlayerControl _playerscript;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.applyRootMotion = true;
		animator.GetComponent<PlayerControl> ().cancontrol = false;

		if (_playerscript == null) {

			_playerscript = animator.GetComponent<PlayerControl> ();

		}

    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		if (stateInfo.normalizedTime > StartTime && stateInfo.normalizedTime < EndTime) {

			_playerscript._weapon.enabled = true;
			_playerscript.EnableWeaponTrail ();
		} else {

			_playerscript._weapon.enabled = false;
			_playerscript.DisableWeaponTrail ();

		}

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		animator.applyRootMotion = false;
		animator.GetComponent<PlayerControl> ().cancontrol = true;

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
