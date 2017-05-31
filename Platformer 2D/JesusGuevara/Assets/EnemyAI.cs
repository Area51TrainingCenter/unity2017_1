using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private Rigidbody2D _rigibody;
	public float speed;

	public float raylength = 0.6f;
	private bool _goToTheRight;

	public LayerMask _mask;
	// Use this for initialization
	void Start () {
		_rigibody = GetComponent<Rigidbody2D> ();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y,transform.localScale.z);// tamaño de la caja

		boxSize = boxSize * 0.99f;
		RaycastHit2D hitinfo;

		//bool hitUp = Physics2D.BoxCast(transform.position,boxSize,0,Vector3.up,out hitinfo ,Quaternion.identity,raylength); 
		 hitinfo = Physics2D.BoxCast(transform.position,boxSize,0,Vector3.up,raylength,_mask.value);  

		if(hitinfo.collider != null){			
			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				Destroy(hitinfo.collider.gameObject);
			}
		}

	
		//bool hitLeft = Physics.BoxCast(transform.position,boxSize/2,Vector3.left,out hitinfo ,Quaternion.identity,raylength); 
		hitinfo = Physics2D.BoxCast(transform.position,boxSize,0,Vector3.left,raylength,_mask.value);  
		if(hitinfo.collider != null ){

			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				Destroy(hitinfo.collider.gameObject);
			} else {
				speed = -speed;
			}
		}

		//bool hitRight = Physics.BoxCast(transform.position,boxSize/2,Vector3.right,out hitinfo ,Quaternion.identity,raylength); 
		hitinfo =  Physics2D.BoxCast(transform.position,boxSize,0,Vector3.right,raylength,_mask.value);
		if(hitinfo.collider != null ){
				
		
			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				Destroy(hitinfo.collider.gameObject);
			}else {
				speed = -speed;
			}
		}


		_rigibody.velocity = new Vector3 (speed, 0, 0);


	}



}
