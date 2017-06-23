using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int score = PlayerPrefs.GetInt ("playerScore", 0);
		GetComponent<Text>().text = "score: " +  score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
