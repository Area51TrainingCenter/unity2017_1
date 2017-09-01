using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
	public GameObject _sphere;
	public GameObject _SpherePosition; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			if (Input.GetKeyDown(KeyCode.J)) {
				CmdShoot();

			}
		}
	}
	[Command]
	void CmdShoot ()  {
		GameObject newbullet = (GameObject) Instantiate (_sphere, _SpherePosition.transform.position, transform.rotation);
		if (transform.localScale.x > 0) {
			newbullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0) ;
		} else {
			newbullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-10, 0)  ;	
		}
		NetworkServer.Spawn (newbullet);
	}
}
