using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotePlayer : MonoBehaviour {
	public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.position-Player.forward+new Vector3(0,0,0);
		transform.rotation = new Quaternion(0,Player.rotation.y,0,Player.rotation.w);

	}
}
