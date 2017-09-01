using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public Transform spawnPos;
	public GameObject _ball;
	public float speed;

	void Update(){

		if (isLocalPlayer && Input.GetButtonDown ("Fire1")) {
			CmdShoot ();
		}
	}
	//Las funciones Command se ejecutan en el servidor(sólo en el servidor) pero son llamados desde el cliente...el nombre de la función debe comenzar con "Cmd"
	[Command]
	void CmdShoot(){

		//para guardar un gameObject de un Instantiate en una variable
		//Instantiate devuelve un 'Object'...usamos (GameObject) para especificar su tipo
		GameObject newBullet = (GameObject)Instantiate (_ball, spawnPos.position, spawnPos.rotation);
		//Si la escala en X del player es positivo..lanzamos la bola hacia la derecha
		if (transform.localScale.x > 0) {
			newBullet.GetComponent<Rigidbody2D> ().velocity = Vector3.right * speed;
		}
		//Si la escala en X del player es negativo...lanzamos la bola hacia la izquierda
		if (transform.localScale.x < 0) {
			newBullet.GetComponent<Rigidbody2D> ().velocity = -Vector3.right * speed;
		}
		//El servidor spawnea la bala en todos los clientes!!!!
		NetworkServer.Spawn (newBullet);
	}
}
