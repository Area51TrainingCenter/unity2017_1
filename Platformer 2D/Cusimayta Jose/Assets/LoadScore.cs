using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScore : MonoBehaviour {
	int ScoreGlobal=0;
	int score;
	bool finishScore;
	Text _text;
	// Use this for initialization
	void Start () {
		score=PlayerPrefs.GetInt ("playerScore",99);
		_text = GetComponent<Text> ();
		_text.text = "Score: "+score;
		Invoke ("RandomScore", 0.1f);
		Invoke ("SetScore", 3);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			finishScore = true;
		}
		if (finishScore) {		
			ScoreGlobal = score;	
			_text.text = "Score: " + ScoreGlobal;
			finishScore = false;
		}

	}

	void RandomScore(){
		if (!finishScore && (ScoreGlobal < score)) {
			ScoreGlobal = Random.Range (0, 100);
			//ScoreGlobal=Random.Range (ScoreGlobal, score);
			//ScoreGlobal++;
			_text.text = "Score: " + ScoreGlobal;
			Invoke ("RandomScore", 0.1f);
		}

	}
	void SetScore(){
		ScoreGlobal = score;	
		_text.text = "Score: " + ScoreGlobal;
		finishScore = false;
	}
}
