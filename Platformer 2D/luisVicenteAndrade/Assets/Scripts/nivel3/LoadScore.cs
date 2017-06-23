using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {
	public Text _text;
	// Use this for initialization
	void Start () {
		int Score =  PlayerPrefs.GetInt ("PlayerScore",0);
		_text = GetComponent<Text> ();
		_text.text = "Score: " + Score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
