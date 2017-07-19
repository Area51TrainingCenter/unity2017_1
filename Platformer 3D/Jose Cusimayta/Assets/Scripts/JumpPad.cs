using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	public Player player;
	public int trampolinForce=5;
	public bool tocar;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
			Invoke ("salto", 0.01f);

	}
	void salto(){
		player.transform.position += Vector3.up;
		player.verticalSpeed = trampolinForce;
	}
}
