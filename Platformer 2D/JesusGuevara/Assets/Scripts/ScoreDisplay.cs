using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	private Text _text;
	private ScoreManager _scoreManager; 

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text>();
		_scoreManager = GameObject.Find ("Score manager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = "SCORE: " + _scoreManager.score;
	}
}
