using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Vida : NetworkBehaviour {
	[SyncVar]
	public float vida = 100;
	public float vidaMax = 100;
	// Use this for initialization
	void Start () {
		
	}


	public void CambioDeSalud(float Damage){      
		if (!isServer) {
			return;
		}
		vida -= Damage;
		if (vida <= 0) {
			vida = vidaMax;
			RpcRespawn ();
		}
	}

	[ClientRpc]
	void RpcRespawn(){
		if (isLocalPlayer) {
			transform.position = Vector3.zero;
		} else {
			GetComponent <NetworkTransform> ().interpolateMovement = 0;
			Invoke ("RestaurarInterpolacion", 0.1f);
		}
	
	}

	void RestaurarInterpolacion(){
		GetComponent <NetworkTransform> ().interpolateMovement = 1;
	}
}
