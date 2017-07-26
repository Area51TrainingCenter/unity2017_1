using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distancia=5f;
	public float angulo = 90f;
	public float anguloV = 90f;
	public float sensibilidadMouse = 10f;
	public float anguloVMin=0f;
	public float anguloVMax=90f;
	private float currentDistancia;
	private float targetDistancia;
	private Vector3 currentVelocity;

	// Use this for initialization
	void Start () {
		//distancia = transform.position - target.position;
		//offset = new Vector3(0,3,0);
		currentDistancia=distancia;
	}

	public void rotacionHorizontal(){
		float mouseX = Input.GetAxis ("Mouse X");
		angulo += mouseX*sensibilidadMouse;
		anguloV=Mathf.Clamp(anguloV,anguloVMin,anguloVMax);
		Quaternion newRotation = Quaternion.Euler (anguloV,angulo,0);
		//el vector se rota de acuerdo a la nueva rotacion y se guarda en la variable behind
		Vector3 behind = newRotation*Vector3.forward;
		targetDistancia=Mathf.Lerp(currentDistancia,distancia,Time.deltaTime*10);
		Vector3 finalPos = target.position +offset+behind*currentDistancia;
		transform.position = Vector3.SmoothDamp (transform.position,finalPos,ref currentVelocity,0.2f);
		transform.LookAt (target.position+offset);

	}

	public void rotacionVertical(){
		float mouseY = Input.GetAxis ("Mouse Y");
		anguloV += mouseY*sensibilidadMouse;
//		if (anguloV<anguloVMin) {
//			anguloV=anguloVMin;
//		}
//		if (anguloV>anguloVMax) {
//			anguloV=anguloVMax;
//		}
		anguloV=Mathf.Clamp(anguloV,anguloVMin,anguloVMax);
		Quaternion newRotation = Quaternion.Euler (anguloV,angulo,0);
			//el vector se rota de acuerdo a la nueva rotacion y se guarda en la variable behind
			Vector3 behind = newRotation*Vector3.forward;
		   targetDistancia=Mathf.Lerp(currentDistancia,distancia,Time.deltaTime*10);
			Vector3 finalPos = target.position +offset+behind*currentDistancia;
			transform.position = Vector3.SmoothDamp (transform.position,finalPos,ref currentVelocity,0.2f);
			transform.LookAt (target.position+offset);
	}

	void FixedUpdate(){
		RaycastHit colisionInfo;
		Vector3 targetPos=target.position+offset;
		bool camaraChocoPared=false;
		//para calcular el vector entre dos puntos
		//restas las coordenadas de ambos puertos
		//tomando en cuenta que es: destino-origen
		Vector3 direction=targetPos-transform.position;
		if (Physics.Raycast(targetPos,direction,out colisionInfo,direction.magnitude)) {
			Debug.DrawRay(transform.position,direction,Color.blue);
			camaraChocoPared=true;
		}
		else Debug.DrawRay(transform.position,direction,Color.red);

		if (camaraChocoPared) {
			currentDistancia-=Time.fixedDeltaTime;
		} else {
			if (!Physics.Raycast(targetPos,direction,out colisionInfo,currentDistancia+1)) {
				currentDistancia+=Time.fixedDeltaTime*5;
				//Debug.DrawRay(transform.position,direction,Color.blue);
				if (currentDistancia>distancia) {
					currentDistancia=distancia;
				}
			}


		}
	}

	
	// Update is called once per frame
	void Update () {
		if (target) {
			rotacionHorizontal();
			rotacionVertical();
		}

	}


}
