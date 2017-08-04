using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {

	//para mostrar un slider en el editor con un rango
	[Range(1,10)]
	public float distance;
	[Range(0,180)]
	public float angle;

	void FixedUpdate(){

		//Se crea una esfera alrededor del player(devuelve una lista de colliders)
		//opcional se puede poner que capa detecta (LayerMask)
		Collider[] hits = Physics.OverlapSphere (transform.position, distance);
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].CompareTag("Enemy")) {
				Debug.Log (hits [i].name);
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, distance);

		Vector3 leftSideCone = Quaternion.Euler (0, -angle, 0) * transform.forward;
		Vector3 rightSideCone = Quaternion.Euler (0, angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, leftSideCone * distance);
		Gizmos.DrawRay (transform.position, rightSideCone * distance);
	}
}
