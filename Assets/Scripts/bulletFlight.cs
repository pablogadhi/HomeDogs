using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFlight : MonoBehaviour
{
	public GameObject objetivoActual;
	public float velocidad = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.forward*velocidad*Time.deltaTime);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemigo" || other.gameObject.tag=="Pared")
		{
			Destroy(gameObject);
		}
	}
}
