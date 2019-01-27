using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bite : MonoBehaviour
{
	Collider mordida;
    // Start is called before the first frame update
    void Start()
    {
		mordida = GetComponent<BoxCollider>();
		mordida.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void doBite()
	{
		mordida.enabled = true;
	}
	public void stopIt()
	{
		mordida.enabled = false;
	}
}
