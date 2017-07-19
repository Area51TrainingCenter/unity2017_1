using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	private GameObject _player;

	// Use this for initialization
	void Start () {
		_player = GameObject.Find("Ethan");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter ( Collider _other ) {
		if ( _other.CompareTag("Player") ) {
			_other.transform.Translate( 0, 1 ,0 );
			Invoke("SetVerticalSpeed", .005f );
			Debug.Log("Estoy aqui");
		}
	}

	void SetVerticalSpeed ( ) {
		_player.GetComponent<PlayerController>().verticalSpeed = 15;
	}
}
