using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//no olvidar crear la libreria 
using UnityEngine.UI;

public class loadScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//funcion guarda disco duro
		int score = PlayerPrefs.GetInt("playerScore", 0);
		GetComponent<Text> ().text = " Score:  " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
