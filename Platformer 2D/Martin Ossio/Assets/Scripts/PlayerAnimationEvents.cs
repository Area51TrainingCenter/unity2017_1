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
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.0123f, 1);

		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.024f, 1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.0123f, 1);
	}

	public void SetAttack2HitboxSize(){
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.43f, 1);
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.19f, 1);

		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.024f, 1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.25f, 1);
	}

	public void SetAttack3HitboxSize(){
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (0.99f, 1);
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.05f, 1);

		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (0.99f, 1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.01f, 1);
	}
}
