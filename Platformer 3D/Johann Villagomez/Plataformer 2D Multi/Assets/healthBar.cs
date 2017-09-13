using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
	public GameObject _player;
	private float targetAlpha;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float porcentaje = _player.GetComponent<health>()._health / _player.GetComponent<health>()._maxHealth ;
		GetComponent<Image> ().fillAmount = porcentaje;
		if (porcentaje < 0.5f) {
			GetComponent<Image> ().color = Color.gray;
			Color newColor = GetComponent<Image> ().color;
			newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);
			if (newColor.a < 0.05) {
				targetAlpha = 1;
			}
			if (newColor.a > 0.95f) {
				targetAlpha = 0;
			}
			GetComponent<Image> ().color = newColor;	


		}
	}
}
