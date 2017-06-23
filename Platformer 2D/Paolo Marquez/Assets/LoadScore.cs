using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {
	private Text _text;
	private ScoreManager _score;
	// Use this for initialization
	void Start () {
		Debug.Log ("El score total es:" + _score);
		_text = GetComponent<Text> ();
		_score = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		int score=PlayerPrefs.GetInt ("playerScore",_score.score);
		_text.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
