using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour {

	private Image _barradevida;
	public GameObject _player;
	// Use this for initialization
	void Start () {
		_barradevida = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		float SaludTotal = _player.GetComponent<Vida> ().vida / _player.GetComponent<Vida> ().vidaMax;
		_barradevida.fillAmount = SaludTotal;
	}
}
