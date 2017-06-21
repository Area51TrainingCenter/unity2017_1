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
		//Debug.Log (playercontrol.controlPlayer);
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

	public void CanAttack(){
		playercontrol.canAttack = true;
	}

	public void SetAttack1HitboxSize(){

		_colliderRight.size = new Vector2(1.18f,1);
		_colliderRight.offset = new Vector2 (0.06f, 0);
		_colliderLeft.size = new Vector2(1.18f,1);
		_colliderLeft.offset = new Vector2 (0.06f, 0);
	}

	public void SetAttack2HitboxSize(){

		_colliderRight.size = new Vector2(1.78f,1);
		_colliderRight.offset = new Vector2 (0.38f, 0);
		_colliderLeft.size = new Vector2(1.78f,1);
		_colliderLeft.offset = new Vector2 (0.38f, 0);

	}

	public void SetAttack3HitboxSize(){

		_colliderRight.size = new Vector2 (1.78f, 1.18f);
		_colliderRight.offset = new Vector2 (0.36f, 0.03f);
		_colliderLeft.size = new Vector2 (1.78f, 1.18f);
		_colliderLeft.offset = new Vector2 (0.36f, 0.03f);
	}


}
