using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float rayLength = 0.03f;
	public LayerMask _mask;
	private bool _goToTheRight;
	private Rigidbody2D _rigidbody;
	private Health _healthScript;
	private MeshRenderer _renderer;

	private float previousHealth;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_healthScript = GetComponent<Health> ();
		_renderer = GetComponent<MeshRenderer> ();
	}

	void Update(){
		//detectamos cuando han lastimado al enemigo
		if (_healthScript.health < previousHealth) {
			//cambiamos el color del material a blanco DE GOLPE
			_renderer.material.color = new Color (1, 1, 1);
		}
		//gradualmente hacemos que el color vuelva a ser rojo
		Color finalColor = Color.Lerp (_renderer.material.color, Color.red, Time.deltaTime * 10);
		_renderer.material.color = finalColor;
		previousHealth = _healthScript.health;

		//matamos al enemigo cuando tenga vida cero
		if (_healthScript.health <= 0) {
			//le damos un pequeño retraso al Destroy para que
			//el script ScoreWhenDead tenga tiempo de subir el score
			//antes que el enemigo se destruya
			Destroy (gameObject,0.1f);
		}
	}

	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.up, rayLength,_mask.value);

//		if (hitInfo.collider != null) {
//			if (hitInfo.collider.gameObject.CompareTag("Player")) {
//				hitInfo.collider.GetComponent<Health> ().ChangeHealth(20);
//			}
//		}
//
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.right, rayLength,_mask.value);

		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
			//	hitInfo.collider.GetComponent<Health> ().ChangeHealth(20);
			} else {
				_goToTheRight = !_goToTheRight;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.left, rayLength,_mask.value);
		if (hitInfo.collider !=null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
			//	hitInfo.collider.GetComponent<Health> ().ChangeHealth (20);
			}
			else {
				_goToTheRight = !_goToTheRight;
			}
		}

		Vector3 moveVector = new Vector3 (-0, 0, 0);
		if (_goToTheRight) {
			moveVector *= -1;
		}
		_rigidbody.velocity = moveVector;

	}
}
