using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorColor : MonoBehaviour
{
	public float timer;
	public Color colR = Color.red;
	public Color colG = Color.blue;
	public Color colB = Color.green;
	public Color colY = Color.yellow;
	public Renderer rend;
	private float t = 0;

	// Start is called before the first frame update
	void Start()
	{

		bool rojo = false;
		bool azul = false;
		bool amarillo = false;
		bool verde = false;
		t = timer;

		//Chequear el layer del suelo
		if (gameObject.layer == LayerMask.NameToLayer ("Rojo")) {
			rojo = true;
		}
		if (gameObject.layer == LayerMask.NameToLayer ("Azul")) {
			azul = true;
		}
		if (gameObject.layer == LayerMask.NameToLayer ("Amarillo")) {
			amarillo = true;
		}
		if (gameObject.layer == LayerMask.NameToLayer ("Verde")) {
			verde = true;
		}

		//Cambiar el color del suelo con respecto a su layer

		if (rojo == true) {
			rend = GetComponent<Renderer> ();
			rend.material.color = colR;
		}

		if (verde == true) {
			rend = GetComponent<Renderer> ();
			rend.material.color = colG;
		}

		if (azul == true) {
			rend = GetComponent<Renderer> ();
			rend.material.color = colB;
		}

		if (amarillo == true) {
			rend = GetComponent<Renderer> ();
			rend.material.color = colY;
		}

		Debug.Log (gameObject.layer);
	}

	// Update is called once per frame
	void Update()
	{

		//timer para cambiar de color
		timer -= Time.deltaTime;
		if (timer < 0) {
			ChangeFloor ();
			timer = t;
			Debug.Log (gameObject.layer);
		}

	}



	void ChangeFloor(){
		var num = Random.Range (0, 4);

		//cambiar el color
		//rojo = 0
		//azul = 1
		//amarillo = 2
		//verde = 3
		if (num == 0) {
			gameObject.layer = LayerMask.NameToLayer ("Rojo");
			rend.material.color = colR;
		}
		if (num == 1) {
			gameObject.layer = LayerMask.NameToLayer ("Azul");
			rend.material.color = colB;
		}
		if (num == 2) {
			gameObject.layer = LayerMask.NameToLayer ("Amarillo");
			rend.material.color = colY;
		}
		if (num == 3) {
			gameObject.layer = LayerMask.NameToLayer ("Verde");
			rend.material.color = colG;
		}


	}
}
