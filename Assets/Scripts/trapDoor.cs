using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDoor : MonoBehaviour
{
	public float tiempoDeTrampa = 4f;
	Collider activador;
    // Start is called before the first frame update
    void Start()
    {
		activador = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
		if (activador.enabled == false)
		{
			tiempoDeTrampa -= Time.deltaTime;
		}
		if (tiempoDeTrampa <= 0)
		{
			Destroy(gameObject);
		}
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemigo")
		{
			activador.enabled = false;

		}
	}
}
