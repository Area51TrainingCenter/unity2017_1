using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	public PlayerMovement playercontrol;
	public BoxCollider2D _colliderRight;
	public BoxCollider2D _colliderLeft;

	public void EnablePlayerControl(){
		
		playercontrol.controlPlayer = true;
	}

	public void DisablePlayerControl(){

		playercontrol.controlPlayer = false;
	}

	public void EnableCollider(){

		if (playercontrol._spriteRenderer.flipX) {
			_colliderLeft.enabled = true;
		} else {
			_colliderRight.enabled = true;
		}
	}

	public void DisableCollider(){

		_colliderLeft.enabled = false;
		_colliderRight.enabled = false;
	}
}
