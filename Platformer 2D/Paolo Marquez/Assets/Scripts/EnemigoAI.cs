using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
	private Rigidbody _rigidbody;
	public float rayLenght=0.6f;
	public float speedX=-2f;
	
	// Use this for initialization
	void Start () {
		_rigidbody=GetComponent<Rigidbody>();
	}
	void Update(){
		
		Vector3 mov1=new Vector3(speedX,0,0)* Time.deltaTime;
		transform.Translate(mov1);
		/*if(speedX<=-2f){
			speedX++;
			Vector3 mov1=new Vector3(speedX,0,0)* Time.deltaTime;
		    transform.Translate(mov1);
		}
		if(speedX>=2f){
			speedX--;
			Vector3 mov1=new Vector3(speedX,0,0)* Time.deltaTime;
		    transform.Translate(mov1);
		}*/
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z);
		boxSize *= 0.99f;
		RaycastHit hitInfo;
		bool hitUp=Physics.BoxCast (transform.position, boxSize/2, Vector3.up,out hitInfo,Quaternion.identity,rayLenght);
		if(hitUp){
			Debug.Log("Golpie a algo");
			if(hitInfo.collider.gameObject.CompareTag("Player")){
				Debug.Log("Golpie a enemigo");
				Destroy(gameObject);
			}

		}
		bool hitDer=Physics.BoxCast (transform.position, boxSize/2, Vector3.right,out hitInfo,Quaternion.identity,rayLenght);
		if(hitDer){
			Debug.Log("Golpie a algo a la derecha");
			if(hitInfo.collider.gameObject.CompareTag("Player")){
				Debug.Log("Golpie a enemigo");
				Destroy(hitInfo.collider.gameObject);
			}
			if(hitInfo.collider.gameObject.CompareTag("pared")){
				Debug.Log("Golpie a pared derecha");
				speedX=-speedX;
			}
		}
		bool hitIzq=Physics.BoxCast (transform.position, boxSize/2, Vector3.left,out hitInfo,Quaternion.identity,rayLenght);
		if(hitIzq){
			Debug.Log("Golpie a algo a la izquierda");
			if(hitInfo.collider.gameObject.CompareTag("Player")){
				Debug.Log("Golpie a enemigo");
				Destroy(hitInfo.collider.gameObject);
			}
			if(hitInfo.collider.gameObject.CompareTag("pared")){
				Debug.Log("Golpie a pared derecha");
				speedX=-speedX;
			}
		}
	}
}
