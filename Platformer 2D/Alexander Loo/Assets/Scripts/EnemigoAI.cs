using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	public float rayLenght = 0.03f;
	public float speed;
	public LayerMask _mask;
	private Health health;
	private float previousHealth;
	private MeshRenderer meshRenderer;

	void Start(){
		_rigidbody = GetComponent<Rigidbody2D> ();
		health = GetComponent<Health> ();
		meshRenderer = GetComponent<MeshRenderer> ();
		previousHealth = health.health;
	}

	void Update(){
		
		//Color.Lerp sirve para cambio gradual del color y sólo hace el cálculo no lo transforma
		Color finalColor = Color.Lerp (meshRenderer.material.color, Color.red, Time.deltaTime * 10);
		meshRenderer.material.color = finalColor;
		if (health.health < previousHealth) {
			//new color(R,G,B) en el script los valores rgb no son de 0-255, sino de 0-1
			//new color(1,1,1) = rgb(255,255,255) = Color.white
			meshRenderer.material.color = new Color (1, 1, 1);
		}
		if (health.health <= 0) {
			Destroy (gameObject,0.01f);
		}
		previousHealth = health.health;
	}

	void FixedUpdate(){

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;

		//Vector3.up es un atajo por default
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, Vector3.up, rayLenght,_mask.value);
		if(hitInfo.collider != null){
			if (hitInfo.collider.CompareTag ("Player")) {
				//hitInfo.collider.GetComponent<Health> ().health -= 20;
			}
		}
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, Vector3.left, rayLenght,_mask.value);
		if (hitInfo.collider != null) {
			
			if (hitInfo.collider.CompareTag ("Player")) {
				//hitInfo.collider.GetComponent<Health> ().health -= 20;

			} else {
				speed = -speed;
			}
		}
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, Vector3.right, rayLenght,_mask.value);
		if (hitInfo.collider != null) {
			
			if (hitInfo.collider.CompareTag ("Player")) {
				//hitInfo.collider.GetComponent<Health> ().health -= 20;

			} else {
				speed = -speed;
			}
		}
		_rigidbody.velocity = new Vector3 (speed, 0, 0);
	}


		
}
