using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    // Start is called before the first frame update
	private float deltaMovement = 6f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Movimiento ();
    }

	void OnCollisionEnter(Collision col){
		if (col.gameObject.layer == gameObject.layer) {
			Debug.Log("YE BOI");
		}
	}

	void Movimiento(){
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * deltaMovement * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.back * deltaMovement * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * deltaMovement * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * deltaMovement * Time.deltaTime);
		}
	}
}
