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

	public void EnablePlayerControl()
	{
		playerObject.GetComponent<PlayerMovement> ().canControl = true;
	}

	public void DisablePlayerControl()
	{
		playerObject.GetComponent<PlayerMovement> ().canControl = false;
	}

	public void canattack()
	{
		playerObject.GetComponent<PlayerMovement> ().canAttack = true;
	}



	public void EnableHitboxes()
	{
		if (_spriteRenderer.flipX) 
		{
			leftHitbox.GetComponent<Collider2D> ().enabled = true;
		} else {
			rightHitbox.GetComponent<Collider2D> ().enabled = true;
		}
	}

	public void DisableHitboxes()
	{
		rightHitbox.GetComponent<Collider2D> ().enabled = false;
		leftHitbox.GetComponent<Collider2D> ().enabled = false;

	}

	public void setattack1hitboxsize()
	{
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.040424f,1);
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.02021223f,0);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.040424f,1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.02021223f,0);
	}

	public void setattack2hitboxsize()
	{
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.677679f,1);
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.2984148f,0);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.677679f,1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.2984148f,0);
	}

	public void setattack3hitboxsize()
	{
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.799706f,1);
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.3526492f,0);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1.799706f,1);
		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.3526492f,0);
	}

}
