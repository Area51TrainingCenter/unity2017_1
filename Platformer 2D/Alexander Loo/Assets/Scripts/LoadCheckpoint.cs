using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour {



	void Start(){

		//Para obtener los datos guardados en la memoria se usa Get...
		float checkpointX = PlayerPrefs.GetFloat ("checkpointX",-999);
		float checkpointY = PlayerPrefs.GetFloat ("checkpointY",-999);

		//Sólo si hay datos del checkpoint(datos guardados en la memoria)...spawneamos al player en el checkpoint
		if (checkpointX != -999 && checkpointY != -999) {

			Vector3 playerNewPosition = new Vector3 (checkpointX, checkpointY,0);
			Transform playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
			playerPosition.position = playerNewPosition;
		}	
	}

	void Update(){

		if (Input.GetKeyDown(KeyCode.U)) {

			//para borrar todos los datos en la memoria
			PlayerPrefs.DeleteAll();
		}
	}
}
