using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {
	public GameObject playerObject;

	public GameObject rightHitbox;
	public GameObject leftHitbox;

	private SpriteRenderer _spriteRenderer;
	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnablePlayerControl(){
		playerObject.GetComponent<PlayerMovement> ().canControl = true;
	}

	public void DisablePlayerControl(){
		playerObject.GetComponent<PlayerMovement> ().canControl = false;
	}

	public void EnableHitboxes(){
		if (_spriteRenderer.flipX) {
			leftHitbox.GetComponent<Collider2D> ().enabled = true;
		} else {
			rightHitbox.GetComponent<Collider2D> ().enabled = true;
		}
	}

	public void DisableHitboxes(){
		rightHitbox.GetComponent<Collider2D> ().enabled = false;
		leftHitbox.GetComponent<Collider2D> ().enabled = false;

	}



	public void EnablePlayerCanControl(){
		playerObject.GetComponent<PlayerMovement> ().canAttack = true;
	}

	public void DisablePlayerCanControl(){
		playerObject.GetComponent<PlayerMovement> ().canAttack = false;
	}

	public void SetAttack1_HitBoxesSize(){

		if (_spriteRenderer.flipX==false) {
			rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2(1.437286f,1);
			rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2(0.2186431f,0);
		} else {
			leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2(0.9502258f,1.202816f);
			leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2(-0.04147813f,0.1014079f);
		}

	}

	public void SetAttack2_HitBoxesSize(){
		if (_spriteRenderer.flipX==false) {
			rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2(2.412771f,0.5692301f);
			rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2(0.7063857f,-0.01958036f);
		} else {
			leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2(1.597287f,0.6040268f);
			leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2(-0.3650087f,0.02414489f);
		}

	}

	public void SetAttack3_HitBoxesSize(){
		if (_spriteRenderer.flipX==false) {
			rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2(2.782783f,1);
			rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2(0.8913916f,0);
		} else {
			leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2(2.244348f,1.492552f);
			leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2(-0.6885393f,0.07243443f);
		}

	}


}
