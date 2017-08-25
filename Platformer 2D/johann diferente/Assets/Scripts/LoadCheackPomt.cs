using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheackPomt : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		float checkpointX = PlayerPrefs.GetFloat ("checkpointX", -999);
		float checkpointY = PlayerPrefs.GetFloat ("checkpointY", -999);
		if (checkpointX != -999 && checkpointY != -999) {
			Vector2 CheckpointPosition = new Vector2 (checkpointX, checkpointY);
			player = GameObject.FindGameObjectWithTag ("Player");
			player.transform.position = CheckpointPosition;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B)) {
			PlayerPrefs.DeleteKey ("checkpointX");
			PlayerPrefs.DeleteKey ("checkpointY");
			PlayerPrefs.DeleteAll();
		}
	
	}
}
