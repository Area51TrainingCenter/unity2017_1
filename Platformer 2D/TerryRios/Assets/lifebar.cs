using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importar cosas que no estan por defecto
using UnityEngine.UI;

public class lifebar : MonoBehaviour {

	private GameObject _lifezero;
	private float _actuallifezero;

	// Use this for initialization
	void Start () 
	{
		_lifezero.GetComponent<health> ().Health;
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		float _resultado = _lifezero.GetComponent<health>().Health / _lifezero.GetComponent<health>().maxHealth ;
			
	   


		GetComponent<Image>().fillAmount = _resultado;
		
	}
}
