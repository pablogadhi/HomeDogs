using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cilindro : MonoBehaviour
{
	public GameObject perro;
	public GameObject mordida;
	public GameObject objetivo = null;
	public float velocidad = 2f;
	public float bitime = 1f;
	public float currentbitime = 0;
	public bool isbiting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (isbiting)
		{
			perro.SendMessage("EstaParado");
			currentbitime += Time.deltaTime;
			if (currentbitime > 0.5)
				mordida.SendMessage("stopIt");
			if (currentbitime > bitime)
				isbiting = false;

		}
		else
		{
			if (objetivo != null)
			{
				perro.SendMessage("EstaAtacando");
				perro.transform.LookAt(objetivo.transform);
				perro.transform.eulerAngles = new Vector3(90, perro.transform.eulerAngles.y, perro.transform.eulerAngles.z);
				perro.transform.position = Vector3.MoveTowards(perro.transform.position, objetivo.transform.position, velocidad);
			}
			else
			{
				perro.SendMessage("EstaParado");
				perro.transform.LookAt(transform.position);
				perro.transform.eulerAngles = new Vector3(90, perro.transform.eulerAngles.y, perro.transform.eulerAngles.z);
				perro.transform.position = Vector3.MoveTowards(perro.transform.position, gameObject.transform.position, velocidad);
			}
		}
    }
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject == objetivo)
			objetivo = null;
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemigo")
		{
			if (objetivo == null)
			{
				objetivo = other.gameObject;
			}
			else
			{
				float distanciaOA = Vector3.Distance(objetivo.transform.position, transform.position);
				float distanciaNO = Vector3.Distance(other.gameObject.transform.position, transform.position);
				if (distanciaNO < distanciaOA)
				{
					objetivo = other.gameObject;
				}
			}
		}
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemigo")
		{
			if (objetivo == null)
			{
				objetivo = other.gameObject;
			}
		}
	}
	public void attack()
	{
		if (!isbiting)
		{
			currentbitime = 0;
			isbiting = true;
			mordida.SendMessage("doBite");
		}
	}
}
