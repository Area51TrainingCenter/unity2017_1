using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour {

	private PlayerControl _playerScript;

	void Start(){
		//para encontrar el componente de un gameobject
		_playerScript = GameObject.FindObjectOfType<PlayerControl> ();
	}

	void OnTriggerEnter(Collider other){

		if (other.CompareTag ("Player")) {
			other.transform.Translate (0, 1, 0);
			Invoke ("JumpUp", 0.01f);
		}
	}
	void JumpUp(){
		_playerScript.verticalSpeed = _playerScript.jumpForce;
	}
}
