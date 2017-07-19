using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	public float jumpForce = 20;
	private GameObject _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			_player.transform.Translate (0, 1, 0);
			Invoke ("SetVerticalSpeed", 0.01f);
		}	
	}

	void SetVerticalSpeed(){
		_player.GetComponent<PlayerControl> ().verticalSpeed = jumpForce;
	}
}

