using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	private Text _text;
	private ScoreManager _score;
	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		_score = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text ="Score: "+ _score.score;
	}
}
