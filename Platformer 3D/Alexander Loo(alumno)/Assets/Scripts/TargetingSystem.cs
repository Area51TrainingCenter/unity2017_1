using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {

	//para mostrar un slider en el editor con un rango
	[Range(1,10)]
	public float distance;
	[Range(0,180)]
	public float angle;
	public Transform _target;

	void FixedUpdate(){

		Transform newTarget = null;
		//Se crea una esfera alrededor del player(devuelve una lista de colliders)
		//opcional se puede poner que capa detecta (LayerMask)
		Collider[] hits = Physics.OverlapSphere (transform.position, distance);
		float minAngle = 999;
		//por cada objeto que se detecta dentro de la esfera..solo nos interesa que tenga tag enemigo
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].CompareTag("Enemy")) {
				//Este vector es la dirección entre el enemigo detectado y el player
				Vector3 dirToEnemy = hits [i].transform.position - transform.position;
				//Ignoramos el eje 'Y' del vector
				dirToEnemy.y = 0;
				//Vector3.Angle sirve para obtener el angulo entre dos vectores(número absoluto)
				float angleToEnemy = Vector3.Angle (dirToEnemy, transform.forward);
				if (angleToEnemy <= angle) {
					//Debug.Log (hits[i].name);
					//Si el ángulo del enemigo es menor que el ángulo minimo...se establece ese numero como el ángulo minimo
					//de esta forma se busca cual es el angulo minimo(enemigo mas cercano)
					if (angleToEnemy < minAngle) {
						minAngle = angleToEnemy;
						newTarget = hits[i].transform;
					}
				}
			}
		}
		_target = newTarget;
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
