using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	private ScoreManager _scoreManager;
	private Text _text;
	// Use this for initialization
	void Start () {
		_scoreManager = GameObject.Find ("Score Manager").GetComponent<ScoreManager> ();
		_text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = "Score: "+ _scoreManager.score;
	}
}