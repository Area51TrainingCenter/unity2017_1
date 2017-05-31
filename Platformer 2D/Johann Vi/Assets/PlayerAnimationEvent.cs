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
	public void EnablePlayerControl(){
		Control.GetComponent<PlayerMovement> ().NoControl = false;
	}
	public void DisablePlaverControl() {
		Control.GetComponent<PlayerMovement> ().NoControl = true;
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
