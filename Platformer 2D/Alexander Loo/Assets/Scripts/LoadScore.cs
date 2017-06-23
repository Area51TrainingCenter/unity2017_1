using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

	void Start(){
		//PlayerPrefs.GetInt sirve para acceder a una variable tipo INT guardado previamente en la memoria
		int score = PlayerPrefs.GetInt ("playerScore", 0);
		GetComponent<Text> ().text = "Score: " + score;
	}
}
