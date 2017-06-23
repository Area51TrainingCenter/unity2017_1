using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {
	private Text _text;
//	int i = 1;

	// Use this for initialization
	void Start () {

		int score = PlayerPrefs.GetInt("playerScore",0);	
		_text = GetComponent<Text>();
		_text.text = "SCORE: " + score;
	

	}
	
	// Update is called once per frame
	void Update () {
		/*i += 1;
		if (i % 2==0) {
			_text.enabled = true;	
		} else {
			_text.enabled = false;
		}*/
	}
}
