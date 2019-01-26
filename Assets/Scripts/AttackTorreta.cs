using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTorreta : MonoBehaviour
{
	public GameObject objetivoActual = null;
	public GameObject bala;
	public float reloadTime = 1f;
	public float currentReload = 0f;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		if (objetivoActual != null)
		{
		transform.LookAt(objetivoActual.transform);
		if (currentReload < reloadTime)
		{
			currentReload += Time.deltaTime;
		}
		else
		{
			currentReload = 0f;
			Instantiate(bala,new Vector3(0,0,0),new Quaternion(0,0,0,0),transform);
		}
		}  
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemigo")
		{
			if (objetivoActual == null)
			{
				objetivoActual = other.gameObject;
			}
		}

	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == objetivoActual)
			objetivoActual = null;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemigo")
		{
			if (objetivoActual == null)
			{
				objetivoActual = other.gameObject;
			}
			else
			{
				float distanciaOA = Vector3.Distance(objetivoActual.transform.position, transform.position);
				float distanciaNO = Vector3.Distance(other.gameObject.transform.position, transform.position);
				if (distanciaNO < distanciaOA)
				{
					objetivoActual = other.gameObject;
				}
			}
		}
	}
}
