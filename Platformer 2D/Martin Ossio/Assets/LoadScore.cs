using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

	public int score;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("playerScore",0);
		GetComponent<Text> ().text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
//		score -= 1;
//		GetComponent<Text> ().text = "Score: " + score;
	}
}
