using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// importamos el codigo para tener acceso
// a los elementos de UI
using UnityEngine.UI;

public class TextScore : MonoBehaviour {
	private Text _text;
	private ScoreManager _score;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
		_score = GameObject.Find ("Score Manager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = "SCORE: " + _score.score; 
	}
}
