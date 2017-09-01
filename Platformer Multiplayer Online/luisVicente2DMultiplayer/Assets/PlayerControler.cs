using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerControler : NetworkBehaviour {
	public GameObject _Bola;
	public Transform _transfor;
	private Rigidbody2D  _rigibody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			if (Input.GetKeyDown (KeyCode.E)) {
				CmdShoot ();
			}
		}
	}
		[Command]
		void CmdShoot(){
		GameObject bala = (GameObject)Instantiate (_Bola, _transfor.position, _transfor.rotation);
			if (transform.localScale.x > 0) {
				bala.GetComponent<Rigidbody2D> ().velocity = Vector2.right * 20;
			}if(transform.localScale.x < 0){
				bala.GetComponent<Rigidbody2D> ().velocity = Vector2.left * 20;
		}
		NetworkServer.Spawn (bala);
	}
} 

