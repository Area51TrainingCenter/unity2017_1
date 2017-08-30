using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadCheckpoint : MonoBehaviour {

	public GameObject _playerobject;

	// Use this for initialization
	void Start () {

		float _checkpointx = PlayerPrefs.GetFloat ("checkpointx",-999);
		float _checkpointy = PlayerPrefs.GetFloat ("checkpointy",-999);

		Vector2 newposition = new Vector2 (_checkpointx, _checkpointy);

		if (_checkpointx!= -999 && _checkpointy!= -999) {

			_playerobject.transform.Translate (newposition);

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.U)) {
			PlayerPrefs.DeleteAll();
		}		
	}
}
