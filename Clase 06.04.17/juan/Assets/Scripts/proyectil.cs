using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {
    public float speed = 2.0f;
    public GameObject destroi;
    public string targetTag;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {

            Destroy(other.gameObject);

            Destroy(gameObject);

            
        }
    }
}
