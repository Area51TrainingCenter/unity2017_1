using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	PlayerMovement _playerMovement;
	Animator _playerAnimator;
	Rigidbody2D _playerRigidBody2D;
	Transform _playerTransform;
	public bool _elevar;
	public bool _animar;
	public Camera _camera;
	ScoreManager _scoreManager;
	// Use this for initialization
	void Start () {	
		_scoreManager = GameObject.Find ("Score Manager").GetComponent<ScoreManager> ();;
	}

	
	// Update is called once per frame
	void Update () {
		if (_elevar) {
			Invoke ("Elevar", 2);
		}
		if (_animar) {
			if (_playerMovement.isGrounded) {
				IniciarAnimacion ();
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{		
		if (other.CompareTag ("Player")) {
			_playerTransform = other.GetComponent<Transform> ();
			_playerRigidBody2D = other.GetComponent<Rigidbody2D> ();
			_playerMovement = other.GetComponent<PlayerMovement> ();	
			_playerAnimator = other.GetComponentInChildren<Animator> ();
			_playerMovement.canControl = false;
			_animar = true;
		}
	}
	void IniciarAnimacion(){
		_camera.GetComponent<PlayerCamara> ().enabled = false;
		_playerRigidBody2D.velocity = new Vector2 (0, 0);
		_playerMovement.enabled = false;
		_playerAnimator.SetTrigger ("exit");
		_elevar = true;
		_animar = false;
	}
	void Elevar(){
		Vector3 moveVector = new Vector3 (0, 20, 0);
		_playerTransform.Translate (moveVector * Time.deltaTime);
		Invoke ("ChangeScene", 1);
	}
	public void ChangeScene(){
		PlayerPrefs.SetInt ("playerScore", _scoreManager.score);
		SceneManager.LoadScene ("WinScene");
	}
}