using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity;
    public string VerticalAxis;
    public string HorizontalAxis;
    public string LeftTrap;
    public string BottomTrap;
    public string RightTrap;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=
            new Vector3(Input.GetAxis(HorizontalAxis), 0f, Input.GetAxis(VerticalAxis)) * velocity *
            Time.deltaTime;
    }
}