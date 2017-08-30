using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float checkpointX = PlayerPrefs.GetFloat ("checkpointX",-999);
		float checkpointY = PlayerPrefs.GetFloat ("checkpointY",-999);
		if (checkpointX != -999 && checkpointY != -999) {
			Vector2 pos = new Vector2 (checkpointX, checkpointY);
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.transform.position = pos;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.U)) {
			PlayerPrefs.DeleteAll ();
		}
	}
}
