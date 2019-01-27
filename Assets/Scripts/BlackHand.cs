using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHand : MonoBehaviour
{
	
	public GameObject torreta;
	//public GameObject pato;
	//public GameObject trampa;

	Vector3 direction = new Vector3(0,-1f,0);


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown("space"))

    	{
    		int layerMask = 1 << 9;

    		RaycastHit hit;
	        
	        if (Physics.Raycast(transform.position, direction, out hit, 50, layerMask))
	        {
	            //Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);

	            Instantiate(torreta, new Vector3(transform.position.x, 0, transform.position.z),  Quaternion.identity);
	        }

    	}
     
    }
}
