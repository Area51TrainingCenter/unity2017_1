using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour {
	public GameObject Control;
	public GameObject BoxRight;
	public GameObject BoxLeft;
	public SpriteRenderer _spriterenderer;


	// Use this for initialization
	void Start () {
		_spriterenderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void EnablecanAttack() {
		Control.GetComponent<PlayerMovement> ().canAttack = true;
	}
	public void DisablecanAttack() {
		Control.GetComponent<PlayerMovement> ().canAttack = false ;
	}
	public void DisablePlayerControl(){
		Debug.Log ("mal");
		Control.GetComponent<PlayerMovement> ().canControl = false;
	}
	public void EnablePlayerControl() {
		Control.GetComponent<PlayerMovement> ().canControl = true;
		Debug.Log ("malx2");
	}
	public void TunOnHitBox()  {
		if (_spriterenderer.flipX == true) {
			BoxLeft.GetComponent<Collider2D> ().enabled = true;

		} else {
			BoxRight.GetComponent<Collider2D> ().enabled = true;
		} 
	} 
	public void TunOffHitBox()  {
		BoxRight.GetComponent<Collider2D> ().enabled = false;
		BoxLeft.GetComponent<Collider2D> ().enabled = false;
	}

	}
