using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour {
	public float startTime;
	public float endTime;

	private PlayerControl _playerScript;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.applyRootMotion = true;
		animator.GetComponent<PlayerControl> ().canControl = false;
		//solo es necesario asignar la referencia al script del player una vez
		if (_playerScript == null) {
			_playerScript = animator.GetComponent<PlayerControl> ();
		}
		_playerScript.EnableWeaponTrail ();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.normalizedTime > startTime && stateInfo.normalizedTime < endTime) {
			_playerScript._weapon.enabled = true;

		} else {
			_playerScript._weapon.enabled = false;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.applyRootMotion = false;
		animator.GetComponent<PlayerControl> ().canControl = true;
		_playerScript.DisableWeaponTrail ();

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
