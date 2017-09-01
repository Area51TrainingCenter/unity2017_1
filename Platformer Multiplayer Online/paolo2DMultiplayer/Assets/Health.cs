using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	//etiqueta para sincronizar la variable con el server
	[SyncVar]
	public float health=100f;
	public float healthMax=100f;

	// Use this for initialization
	void Start () {
		
	}

	public void TakeDamage(float damage){
		if(!isServer) {
			return;
		}
		health -= damage;
		if (health<=0) {
			health = healthMax;
			//Destroy (gameObject);
			RpcRespawn ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void reiniciarInterpolacion(){
		GetComponent<NetworkTransform> ().interpolateMovement = 1;
	}

	//las funciones rpc se llaman en el server pero se ejecutan en los clientes
	[ClientRpc]
	void RpcRespawn () {
		//si el jugador es duenio del player se ejecutara la accion
		if (isLocalPlayer) {
			transform.position=Vector3.zero;
		}else {
			//quitamos la interpolacion para que el player no se deslice a la posicion zero, sino se teletransporte
			GetComponent<NetworkTransform> ().interpolateMovement = 0;
			Invoke ("reiniciarInterpolacion",0.2f);
		}
	}
}
