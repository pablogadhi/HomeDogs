﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBasico : MonoBehaviour
{
	public float velocidad=6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))*velocidad*Time.deltaTime);


	}
}
