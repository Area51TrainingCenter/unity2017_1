using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBehaviour : StateMachineBehaviour {
	public float startTime;
	public float endTime;
	private Movimiento playerScript;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		//solo es necesario referenciarla una vez
		if (playerScript==null) {
			playerScript = animator.GetComponent<Movimiento> ();
		}
		animator.applyRootMotion = true;
		playerScript.canControl = false;
		playerScript._weapon1.GetComponent<BoxCollider>().enabled=true;
		playerScript._weapon2.GetComponent<BoxCollider>().enabled=true;
		playerScript.EnableWeaponTrail();
		playerScript.EnableWeaponTrail2();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (playerScript==null) {
			playerScript = animator.GetComponent<Movimiento> ();
		}
		Debug.Log("Inicio:"+startTime+" end: "+endTime+ "tiempo normalizado: "+stateInfo.normalizedTime);
		if (stateInfo.normalizedTime>startTime && stateInfo.normalizedTime<endTime) {
			playerScript._weapon1.enabled = true;
			playerScript._weapon2.enabled = true;
		}
		else {
			playerScript._weapon1.enabled = false;
			playerScript._weapon2.enabled = false;
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//solo es necesario referenciarla una vez
		if (playerScript==null) {
			playerScript = animator.GetComponent<Movimiento> ();
		}
		animator.applyRootMotion = false;
		animator.GetComponent<Movimiento> ().canControl = true;
		playerScript._weapon1.GetComponent<BoxCollider>().enabled=false;
		playerScript._weapon2.GetComponent<BoxCollider>().enabled=false;
		playerScript.DisableWeaponTrail();
		playerScript.DisableWeaponTrail2();
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
