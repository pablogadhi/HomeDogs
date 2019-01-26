using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public GameObject enemy;
    public float position_x;
    public float position_z;

    private Vector3 spawnPosition;
    private int counter;
    private float gameTime;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(gameObject.transform.position.x + position_x, 0f, gameObject.transform.position.z + position_z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime >= 5f)
        {
            Instantiate(enemy, spawnPosition,  Quaternion.identity);
            gameTime = 0f;
        }
        
        gameTime += Time.deltaTime;
    }
}
