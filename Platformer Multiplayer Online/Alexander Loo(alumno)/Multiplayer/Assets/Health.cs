using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	//SyncVar es una variable que sincroniza el valor de la variable del servidor en todos los clientes(Tiene prioridad el servidor)
	[SyncVar]
	public float health = 100;
	[System.NonSerialized]
	public float maxHealth = 100;

	public void TakeDamage(float damage){
		//Si es el servidor
		if (isServer) {
			health -= damage;
			if (health <= 0) {
				RpcRespawn ();
				health = maxHealth;
			}
		}
		/*otra forma de hacerlo:
		if (!isServer) {
			return;
		}
		health -= damage;
		if (health <= 0) {
			Debug.Log ("Player ha muerto");	
		}*/
	}

	//Al contrario de Command las funciones Rpc se llaman en el server pero se ejecutan en los clientes
	//Los nombres de estas funciones deben comenzar con Rpc..
	[ClientRpc]
	void RpcRespawn(){
		//como esta función se ejecuta en TODOS los clientes...tenemos que filtrar y asegurarnos que solo el cliente dueño de este player lo mueva 
		if (isLocalPlayer) {
			transform.position = Vector3.zero;
		}
	}
}
