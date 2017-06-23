using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

	private Text _text;


	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		int score = PlayerPrefs.GetInt ("playerscore", 0);
		_text.text = "Score: " + score;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
