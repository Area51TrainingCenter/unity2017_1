using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {
	[Range(1,20)]
	public float _distance = 10;
	[Range(0,180)]
	public float _angle = 45;

	public Transform _target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//OverlapSphere crea una esfera invisible que detecta todos los elementos
		//con colisión dentro de ella
		Collider[] hits = Physics.OverlapSphere (transform.position, _distance);
		Transform newTarget = null;
		float minAngle = 999;
		//usamos un for para recorrer el arreglo de elementos que nos bota el OverlapSphere
		for (int i = 0; i < hits.Length; i++) {
			//chequeamos si el tag del objeto es "enemy"
			if (hits[i].CompareTag("enemy")) {
				//calculamos el vector desde el player hacia el enemigo y lo llamamos 
				//dirToEnemy
				Vector3 dirToEnemy = hits [i].transform.position - transform.position;
				dirToEnemy.y = 0;
				//calculamos el angulo entre dirToEnemy y el forward del player
				float angle = Vector3.Angle (dirToEnemy, transform.forward);
				//si el angulo esta dentro del limite del cono...
				//entonces ahí hacemos targeting al enemigo
				if (angle <= _angle) {
					//buscamos cual de todos los enemigos tiene el angulo
					//menor hacia el player
					if (angle < minAngle) {
						minAngle = angle;
						newTarget = hits [i].transform;
					}
				}
			}
		}
		_target = newTarget;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, _distance);
	
		Vector3 leftSideCone = Quaternion.Euler (0, -_angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, leftSideCone * _distance);

		Vector3 rightSideCone = Quaternion.Euler (0, _angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, rightSideCone * _distance);
	}
}
