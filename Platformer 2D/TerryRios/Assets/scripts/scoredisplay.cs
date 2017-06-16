using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoredisplay : MonoBehaviour {

	private Text _text;
	private score_manager _scoremanager;

	// Use this for initialization
	void Start ()
	{
		_text = GetComponent<Text> ();
		_scoremanager = GameObject.Find ("score manager").GetComponent<score_manager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		_text.text = "SCORE:" + _scoremanager.score;


	}
}
