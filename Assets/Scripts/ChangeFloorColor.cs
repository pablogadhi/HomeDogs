using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorColor : MonoBehaviour
{
	public float timer;
<<<<<<< HEAD
	public Color colR = Color.red;
	public Color colG = Color.blue;
	public Color colB = Color.green;
	public Color colY = Color.yellow;
=======
	public Color colR = new Color(0.9339f,0.5154f,0.5154f,1f);
	public Color colG = new Color(0.6962f,1f,06367f,1f);
	public Color colB = new Color(0.5279f,0.5279f,0.9905f,1f);
	public Color colY = new Color(0.9716f,0.9384f,0.5637f,1f);
>>>>>>> Jorge
	public Renderer rend;
	private float t = 0;

	// Start is called before the first frame update
	void Start()
	{
<<<<<<< HEAD

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
=======
		rend = GetComponent<Renderer> ();
		t = timer;

		//Chequear el layer del suelo y setear el color conrespecto del layer
		if (gameObject.layer == LayerMask.NameToLayer ("Rojo")) {			
			rend.material.color = new Color (0.9339f, 0.5154f, 0.5154f, 1f);
		}
		if (gameObject.layer == LayerMask.NameToLayer ("Azul")) {
			rend.material.color = new Color(0.5279f,0.5279f,0.9905f,1f);
		}
		if (gameObject.layer == LayerMask.NameToLayer ("Amarillo")) {
			rend.material.color = new Color(0.9716f,0.9384f,0.5637f,1f);
		}
		if (gameObject.layer == LayerMask.NameToLayer ("Verde")) {
			rend.material.color = new Color(0.6962f,1f,06367f,1f);
		}
>>>>>>> Jorge
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
<<<<<<< HEAD
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
=======
			rend.material.color = new Color(0.9339f,0.5154f,0.5154f,1f);
		}
		if (num == 1) {
			gameObject.layer = LayerMask.NameToLayer ("Azul");
			rend.material.color = new Color(0.5279f,0.5279f,0.9905f,1f);
		}
		if (num == 2) {
			gameObject.layer = LayerMask.NameToLayer ("Amarillo");
			rend.material.color = new Color(0.9716f,0.9384f,0.5637f,1f);
		}
		if (num == 3) {
			gameObject.layer = LayerMask.NameToLayer ("Verde");
			rend.material.color = new Color(0.6962f,1f,06367f,1f);
>>>>>>> Jorge
		}


	}
}
