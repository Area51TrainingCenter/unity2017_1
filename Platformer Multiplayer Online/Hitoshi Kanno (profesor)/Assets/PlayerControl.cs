using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerControl : NetworkBehaviour {
	public GameObject _bulletPrefab;
	public Transform _shootPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			if (Input.GetMouseButtonDown(0)) {
				CmdShoot ();
			}
		}
	}
	//las funciones command se ejecutan en el servidor...obligatoriamente su nombre debe comenzar con "Cmd"
	[Command]
	void CmdShoot(){
		GameObject newBullet = (GameObject) Instantiate (_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
		//dependiendo si el player mira hacia la derecha o izquierda... le damos una velocida a la bala
		if (transform.localScale.x > 0) {
			newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (20, 0);
		} else {
			newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-20, 0);
		}
		//el servidor se encarga de que la bala aparezca en todos los clientes
		NetworkServer.Spawn (newBullet);
	}
}
