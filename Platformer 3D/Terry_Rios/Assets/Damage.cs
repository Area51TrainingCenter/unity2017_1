using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	
	public Transform owner;
	public float _damage = 20;
	public string _target = "Enemy";
	public GameObject _particulas;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag(_target)) {

			other.GetComponent<health> ().ChangeHealth (_damage);
			Instantiate (_particulas, transform.position, transform.rotation);
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize();
			enemigo_ai _enemyScript = other.GetComponent<enemigo_ai> ();
			if (_enemyScript != null) {
				_enemyScript.AddImpact (dir, 30);
			}

			PlayerControl _playerScript = other.GetComponent<PlayerControl> ();
			if (_playerScript != null) {

				_playerScript.AddImpact (dir, 30);
			}
				
		}
			
	}
}
