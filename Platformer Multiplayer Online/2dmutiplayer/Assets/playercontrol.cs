using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playercontrol : NetworkBehaviour {

	public GameObject _circle;
	public Transform _gun;

	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {

		if (isLocalPlayer) {
			if (Input.GetButtonDown ("Fire1")) {

				Cmdbullet ();
		
			}
		}

		
	}

	[Command]

	void Cmdbullet(){

		GameObject newBullet = (GameObject)Instantiate (_circle, _gun.position, Quaternion.identity);
		if (transform.localScale.x>0) {

			newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2(10,0);

		}
		if (transform.localScale.x<0) {

			newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2(-10,0);

		}

		NetworkServer.Spawn (newBullet);

			
	}
}
