using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perro : MonoBehaviour
{
	public GameObject cilindro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemigo")
			cilindro.SendMessage("attack");
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Enemigo")
			cilindro.SendMessage("attack");
	}
}
