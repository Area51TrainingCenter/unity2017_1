using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour {

	public float speed = 8;
	private GameObject player;
	private ScoreManager _scoreManager;

	private bool goUp = false;
	private bool touchedTigger = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		_scoreManager = GameObject.Find ("Score manager").GetComponent<ScoreManager>();
	}
	

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){
			// hacemos esto para que el player ya no se pueda mover 
			// en horizontal y para permitir que salga el otro 
			player.GetComponent<Movimiento> ().controlPlayer = false;
			touchedTigger = true;

		}

	}


	void Update () {

		if (player.GetComponent<Movimiento> ().isGrounded && touchedTigger) {
			
			player.GetComponent<Movimiento> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponentInChildren<Animator> ().SetTrigger ("exit");
			Invoke ("StartUp", 0.5f);
			Invoke ("ChangeScene", 2.4f);
			// regresamos esto a falso para que ya 
			// animator = 0 ,getcomponente<aniamtor> speed = 0 , invo 
			touchedTigger = false;
		}

		if(goUp){
			player.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
		}

	}


	void StartUp(){
		goUp = true;
	}




	void ChangeScene(){
		PlayerPrefs.SetInt("playerScore",_scoreManager.score);

		SceneManager.LoadScene ("winScreen");
	}

}