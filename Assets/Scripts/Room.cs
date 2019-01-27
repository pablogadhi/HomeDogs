using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Size
{
    Small,
    Medium,
    Large
}

public class Room : MonoBehaviour
{
    public Size size;
    private NavMeshSurface surface;

    private void Start()
    {
//        surface = transform.Find("Plane").GetComponent<NavMeshSurface>();
//        Debug.Log(surface);
    }

    public void GenerateNavMesh()
    {
//        surface.BuildNavMesh();
    }
}