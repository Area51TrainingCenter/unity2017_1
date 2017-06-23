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

	public void EnableCanAttack(){
		playerObject.GetComponent<PlayerMovement> ().canAttack = true;
	}

	public void SetAttack1HitboxSize(){
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.024f, 1);
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.0123f, 0);

		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.024f, 1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.0123f, 0);

	}

	public void SetAttack2HitboxSize(){
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.127f, 0.05f);
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.3f, 0.5f);

		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.002f, 0.05f);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.55f, 0.5f);

	}

	public void SetAttack3HitboxSize(){
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.64f, 0.107f);
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (3.24f, 1.49f);

		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.58f, 0.107f);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (3.24f, 1.49f);

	}

	public void StopAnimator(){
		GetComponent<Animator> ().speed = 0;
		Invoke ("RestoreAnimatorSpeed", 1.0f);
	}

	void RestoreAnimatorSpeed(){
		GetComponent<Animator> ().speed = 1;
	}
}
