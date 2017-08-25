using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarCheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float checkPointX = PlayerPrefs.GetFloat ("CoorX",-999);
		float checkPointY=PlayerPrefs.GetFloat ("CoorY",-999);
		if (checkPointX!=-999 && checkPointY!=-999) {
			Vector2 pos = new Vector2 (checkPointX, checkPointY);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.transform.position = pos;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
