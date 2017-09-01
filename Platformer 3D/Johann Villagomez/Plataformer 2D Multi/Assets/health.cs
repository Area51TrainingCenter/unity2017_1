using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class health :NetworkBehaviour {
	[SyncVar]
	public float _health = 100;
	public float _maxHealth = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void TakeDamage (float damage) {
		if (isServer) {
			_health -= damage;
			Debug.Log ("damaged");
			if (_health <= 0) {
				gameObject.SetActive (false);
				Invoke ("RpcRespawn", 2);
				_health = _maxHealth;
				}
		}
	
	}
	[ClientRpc]
	void RpcRespawn() {
		if (isLocalPlayer) {
			gameObject.SetActive (true);
			transform.position = Vector3.zero;
		} else {
			GetComponent<NetworkTransform> ().interpolateMovement = 0;
			Invoke ("RestoreInterpolation", 0.1f);
		}
	}	
	void RestoreInterpolation () {
		GetComponent<NetworkTransform> ().interpolateMovement = 1;
	}
}
