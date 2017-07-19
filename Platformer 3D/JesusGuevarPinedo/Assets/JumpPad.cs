using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	public GameObject _player;
	public float speed=5; 
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("jugador");
				
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);



		if (other.gameObject.tag == "jugador")
		{
			
			_player.transform.Translate (0, 1, 0);
			Invoke ("SetVerticalSpeed",0.01f);

		}
	}


	void SetVerticalSpeed(){
		_player.GetComponent<PlayerControl> ().verticalSpeed = speed;
	}		




}
