using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour {
	public GameObject pelota;
	public GameObject disparador;
	public float velocidad=5f;
	public Health saludPlayer;
	private float danio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			
			if (Input.GetKeyDown(KeyCode.E)) {
				CmdInvocarPelota ();
		    }
		}
			


	}
	[Command] //se procesa en el server 
	void CmdInvocarPelota(){

			GameObject newBullet=Instantiate (pelota, disparador.transform.position, disparador.transform.rotation);
			if (transform.localScale.x>0) {
				newBullet.GetComponent<Rigidbody2D> ().velocity=Vector2.right*velocidad;
			}
			if (transform.localScale.x<0) {
				newBullet.GetComponent<Rigidbody2D> ().velocity=Vector2.left*velocidad;
			}
			//newBullet.transform.Translate (15,0);
			NetworkServer.Spawn (newBullet);
		

	}
}
