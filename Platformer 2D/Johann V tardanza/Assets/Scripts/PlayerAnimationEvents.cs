﻿using System.Collections;
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
	public void CongelarAnimacionyDescongelar(){
		GetComponent<Animator> ().speed = 0;
		Invoke ("descongelar", 1f);
	}
	public void descongelar (){
	GetComponent<Animator> ().speed = 1;
		}
	}
