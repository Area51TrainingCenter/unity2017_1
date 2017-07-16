using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform Player;
	public Vector3 distancia;
	// Use this for initialization
	void Start () {
		distancia = transform.position - Player.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player) {
			transform.position = Player.position + distancia;
		}
	}
}
