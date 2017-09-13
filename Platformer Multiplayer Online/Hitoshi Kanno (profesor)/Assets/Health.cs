using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	[SyncVar]
	public float _health = 100;
	public float _maxHealth = 100;
	// Use this for initialization
	void Start () {
		
	}

	public void TakeDamage(float damage) {
		//si no estamos en el server ... salimos de la funcion
		if (!isServer) {
			//return hace que la funcion termine aqui y ya no ejecuta nada más abajo
			return;
		}

		_health -= damage;
		//_health = _health - damage;
		if (_health <= 0) {
			_health = _maxHealth;
			RpcRespawn ();
		}	

	}

	//las funciones RPC se llaman en el server pero se ejecutan en los clientes
	//los nombres de estas funciones deben comenzar con "Rpc"
	[ClientRpc]
	void RpcRespawn(){
		//como esta funcion se ejecuta en TODOS los clientes... tenemos que 
		//filtrar y asegurarnos que solo el cliente dueño de este player lo mueva
		if (isLocalPlayer) {
			//lo movemos a la posicion cero
			transform.position = Vector3.zero;
		} else {
			//quitamos la interpolacion del NetworkTransform para que el player 
			// no se "deslice" a la posicion cero..sino se teletransporte.
			GetComponent<NetworkTransform> ().interpolateMovement = 0;
			//esperamos 0.1 segundos y le restauramos la interpolacion
			Invoke ("RestoreInterpolation", 0.1f);
		}
	}

	void RestoreInterpolation(){
		GetComponent<NetworkTransform> ().interpolateMovement = 1;
	}
}
