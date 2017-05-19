using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
	private Rigidbody _rigidbody;
	public float rayLength = 0.3f;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent <Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z); 
		boxSize = boxSize * 0.99f;
		RaycastHit hitInfo;
		bool hitUp = Physics.BoxCast (transform.position, boxSize/2, Vector3.up,out hitInfo, Quaternion.identity, rayLength);
		if (hitUp) { 
			if(hitInfo.collider.gameObject.CompareTag("Player")) 	{
				Destroy (gameObject);
			}
		}
		bool hitLeft = Physics.BoxCast (transform.position, boxSize/2, Vector3.left,out hitInfo, Quaternion.identity, rayLength);
		if (hitLeft) { 
			if(hitInfo.collider.gameObject.CompareTag("Player")) 	{
				Destroy (hitInfo.collider.gameObject);
				}
		}
		bool hitRight = Physics.BoxCast (transform.position, boxSize/2, Vector3.right,out hitInfo, Quaternion.identity, rayLength);
		if (hitRight) { 
			if(hitInfo.collider.gameObject.CompareTag("Player")) 	{
				Destroy (hitInfo.collider.gameObject);
					}	
			}


				}
}
