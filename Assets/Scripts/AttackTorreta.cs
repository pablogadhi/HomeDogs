using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTorreta : MonoBehaviour
{
	public GameObject objetivoActual = null;
	public GameObject bala;
	public float reloadTime = 1f;
	public float currentReload = 0f;

	Vector3 worldUp;

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
	{
		if (objetivoActual != null)
		{
			Vector3 objetivePos = new Vector3(objetivoActual.transform.position.x,objetivoActual.transform.position.y,objetivoActual.transform.position.z);
			transform.LookAt(objetivePos);
			transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, transform.eulerAngles.z);
			//transform.LookAt(objetivoActual.transform);
		//transform.rotation()
		
			if (currentReload < reloadTime)
			{
				currentReload += Time.deltaTime;
			}
			else
			{
				currentReload = 0f;
				Instantiate(bala,new Vector3(transform.position.x,1,transform.position.z),new Quaternion(0,0,0,0),transform);
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
