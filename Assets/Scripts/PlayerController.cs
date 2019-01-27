using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int layerToHit;
    public float velocity;
    public string VerticalAxis;
    public string HorizontalAxis;
    public string LeftTrap;
    public string BottomTrap;
    public string RightTrap;
    public GameObject torreta;
    //public GameObject pato;
    //public GameObject trampa;

    Vector3 direction = new Vector3(0,-1f,0);

    void Start()
    {
    }

    // Update is called once per frame-1.575
    void Update()
    {
        transform.position +=
            new Vector3(Input.GetAxis(HorizontalAxis), 0f, Input.GetAxis(VerticalAxis)) * velocity *
            Time.deltaTime;

        if (Input.GetAxis(LeftTrap) != 0)

        {
            int layerMask = 1 << layerToHit;

            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, direction, out hit, 50, layerMask))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.yellow);
                Debug.Log("Hit");

                Instantiate(torreta, new Vector3(transform.position.x, 0, transform.position.z),  Quaternion.identity);
            }

        }
    }
}