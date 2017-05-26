using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private Rigidbody _rigibody;
	public float speed;

	public float raylength = 0.6f;
	private bool _goToTheRight;

	// Use this for initialization
	void Start () {
		_rigibody = GetComponent<Rigidbody> ();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y,transform.localScale.z);// tamaño de la caja
		boxSize = boxSize * 0.99f;
		RaycastHit hitinfo;

		bool hitUp = Physics.BoxCast(transform.position,boxSize/2,Vector3.up,out hitinfo ,Quaternion.identity,raylength); 

		if(hitUp){
			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				Destroy(gameObject);
			}
		}

	
		bool hitLeft = Physics.BoxCast(transform.position,boxSize/2,Vector3.left,out hitinfo ,Quaternion.identity,raylength); 
		if(hitLeft){

			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				Destroy(hitinfo.collider.gameObject);
			} else {
				speed = -speed;
			}
		}

		bool hitRight = Physics.BoxCast(transform.position,boxSize/2,Vector3.right,out hitinfo ,Quaternion.identity,raylength); 
		if(hitRight){
				
		
			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				Destroy(hitinfo.collider.gameObject);
			}else {
				speed = -speed;
			}
		}


		_rigibody.velocity = new Vector3 (speed, 0, 0);


	}



}
