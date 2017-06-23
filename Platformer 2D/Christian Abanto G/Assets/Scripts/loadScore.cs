using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadScore : MonoBehaviour {
	public Text _text;

	// Use this for initialization
	void Start () {
		// obtener componente tipo Text
		_text = GetComponent<Text>();
		// obtener datos que se guardaron en disco duro
		int score = PlayerPrefs.GetInt("playerScore",0);
		// asignar scrore al texto
		_text.text = "SCORE: " + score; 
	}
}
