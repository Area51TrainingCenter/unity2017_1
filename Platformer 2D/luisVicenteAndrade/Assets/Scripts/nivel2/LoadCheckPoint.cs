using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckPoint : MonoBehaviour {
	public GameObject _player;
	// Use this for initialization
	void Start () {
		float CheckPointX = PlayerPrefs.GetFloat ("CheckPointX", -999);
		float CheckPointY = PlayerPrefs.GetFloat ("CheckPointY", -999);

		if (CheckPointX != -999 && CheckPointY != - 999) {
			Vector2 Posicion = new Vector2 (CheckPointX, CheckPointY);
			_player.transform.position = Posicion;
		}
	}
	
	// Update is called once per frame
	void Update () {
	//	PlayerPrefs.DeleteKey ("CheckPointX");
	//	PlayerPrefs.DeleteKey ("CheckPointY");
		if (Input.GetKeyDown(KeyCode.R)) {
			PlayerPrefs.DeleteAll ();

		}
	}
}
