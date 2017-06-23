using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	private Text _text;
	private ScoreManager _score;

	void Start(){
		_score = GameObject.Find ("Score Manager").GetComponent<ScoreManager> ();
		_text = GetComponent<Text> ();
		_text.text = "Score: 0";
	}
	void Update(){
		_text.text = "Score: " + _score.score;
	}
}
