using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	public GameObject _player;
	public SpriteRenderer _flip;

	public GameObject _rightHitbox;
	public GameObject _leftHitbox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnabledPlayerControl() {
		_player.GetComponent<Movement> ().canControl = true;
	}

	public void DisabledPlayerControl() {
		_player.GetComponent<Movement> ().canControl = false;
	}

	public void EnabledPlayerAtack() {
		if (_flip.flipX == true) {
			_leftHitbox.GetComponent<Collider2D> ().enabled = true;
		} else {
			_rightHitbox.GetComponent<Collider2D> ().enabled = true;
		}
	}

	public void DisabledPlayerAtack() {
		_leftHitbox.GetComponent<Collider2D> ().enabled = false;
		_rightHitbox.GetComponent<Collider2D> ().enabled = false;
	}

	//_spriterender.flipX = true;
}
