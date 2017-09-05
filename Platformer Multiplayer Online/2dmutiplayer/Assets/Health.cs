using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	
	[SyncVar]
	public float _health = 100;
	public float _Maxhealth = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void TakeDamage (float damage) {

		if (isServer) {

			_health = _health - damage;

			if (_health <= 0) {
				
				_health = _Maxhealth;
				RpcRespawn ();

				Debug.Log ("ded");

			}			
		}
	}

	[ClientRpc]
	void RpcRespawn(){

		if (isLocalPlayer) {

			transform.position = Vector3.zero;

		} else {

			GetComponent<NetworkTransform>().interpolateMovement = 0;

			Invoke ("RestoreInterpolation", 0.1f);

		}
			
	}

	void RestoreInterpolation(){

		GetComponent<NetworkTransform>().interpolateMovement = 1;
	}
}
