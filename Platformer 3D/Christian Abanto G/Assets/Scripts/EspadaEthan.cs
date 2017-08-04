using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaEthan : MonoBehaviour {
	public float ataque = 20;
	public GameObject efectoAtaque;
	public float fuerzaAtaque;
	public Transform owner;

	public string targetTag = "enemy";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag(targetTag)) {
			other.GetComponent<Vida> ().CambioDeVida ( ataque );
			Quaternion rotacion = Quaternion.Euler(0, 0 ,0);
			Instantiate(efectoAtaque,transform.position,rotacion);


			//
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize(); // solo para normalizar y obtener la direccion del Vector

			// como este script sera usado tato por el player como por el enemigo
			// es posible que _enemyScript sea nulo
			EnemyAi _enemyScript = other.GetComponent<EnemyAi>();
			// debido a esto hacemos este chequeo para evitar errores
			if (_enemyScript != null ){
				_enemyScript.GetComponent<EnemyAi>().AddImpact(dir,fuerzaAtaque);
			}
		
		}

	}
}
