using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public float rayLength = 0.03f;
    public LayerMask _mask;
    private bool _goToTheRight;
    private Rigidbody2D _rigidbody;
	private Health _healthScript;
	public float velocidadX=5;
	private float previousHealth;
	private Renderer _renderer;
	private float targetR=0;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_healthScript = GetComponent<Health> ();
		_renderer = GetComponent<MeshRenderer> ();
	}

    void Update()
	{
		Hurt ();
		if (_healthScript.health <= 0) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.up, rayLength, _mask.value);
       
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
              
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.right, rayLength, _mask.value);
        
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
                
			} else {
				_goToTheRight = !_goToTheRight;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.left, rayLength, _mask.value);
        
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
               
			} else {
				_goToTheRight = !_goToTheRight;
			}
		}

		Vector3 moveVector = new Vector3 (velocidadX, 0, 0);
		if (_goToTheRight) {
			moveVector *= -1;
		}
		_rigidbody.velocity = moveVector;
	}
	void Hurt(){
		//si la vida actual es menor a la vida que teniamos antes
		//significa que hemos recibido daño
		if (_healthScript.health < previousHealth) {
			//Se cambia el color del cubo a blanco
			_renderer.material.color=new Color(1,1,1);
		}
		//Ahora se cambia lentamente el color de blanco a rojo
		_renderer.material.color= Color.Lerp (_renderer.material.color, new Color (1, 0, 0), Time.deltaTime * 10);
		//despues actualizamos la variable previousHealth
		previousHealth = _healthScript.health;

	}
}