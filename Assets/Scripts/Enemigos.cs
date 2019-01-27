using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    public int health;
    
    private NavMeshAgent myNavMeshAgent;
    private Vector3 goalPosition;
    
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        goalPosition = new Vector3(0f, 0f, 0f);
        myNavMeshAgent.SetDestination(goalPosition);
        health = 5;
    }
    
    void OnCollisionEnter (Collision col)
    {

        if(col.gameObject.tag == "Bala")
        {
            health--;
        }
        
        else if(col.gameObject.tag == "Ataque")
        {
            health -= 2;
        }
        
        else if(col.gameObject.tag == "Piso")
        {
            myNavMeshAgent.speed = 0.5f;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void Update()
    {
    
    }

}
