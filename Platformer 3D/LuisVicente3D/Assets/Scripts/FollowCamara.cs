using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour {
	public Transform player;
	public Vector3 Distancia;
	// Use this for initialization
	void Start () {
		Distancia = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player) {
			transform.position = player.position + Distancia;
		}
	}
}
