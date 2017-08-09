using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour {

	public float startTime;
	public float endTime;
	private PlayerControl _playerScript;

	//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//Se ejecuta cada vez que inicia la transición
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//si la variable _playerScript no tiene información(null),se asigna...esto sirve para evitar hacer GetComponent 
		//cada vez que se inicia la transición
		if (_playerScript == null) {

			_playerScript = animator.GetComponent<PlayerControl> ();
		}
		_playerScript.canControl = false;
		//applyRootMotion activado sirve para que el modelo 3d se pueda move(En este caso para acomodar bien la animación)
		animator.applyRootMotion = true;
		_playerScript.EnableWeaponTrail ();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//stateInfo de devuelve el estado actual de la animación
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//stateInfo.normalizedTime es el porcentaje de la animación(va de 0 a 1)(sacar porcentaje '/100')
		//si el estado de la animación esta entre el rango de los parámetros...se prende el collider 
		if (stateInfo.normalizedTime > startTime && stateInfo.normalizedTime < endTime) {
			//alterar la velocidad del animator(funciona casi igual que el Time.timeScale)
			animator.speed = 0.8f;
			_playerScript.weapon.enabled = true;

		} else {
			
			animator.speed = 0.3f;
			_playerScript.weapon.enabled = false;
		}
		_playerScript.FaceTarget ();
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	// cuando sale de la transicion
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		animator.applyRootMotion = false;
		_playerScript.canControl = true;
		animator.speed = 1;
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
