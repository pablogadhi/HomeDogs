using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorColor : MonoBehaviour
{
    public float timer;
    public Color colR = new Color(0.9339f, 0.5154f, 0.5154f, 1f);
    public Color colG = new Color(0.6962f, 1f, 06367f, 1f);
    public Color colB = new Color(0.5279f, 0.5279f, 0.9905f, 1f);
    public Color colY = new Color(0.9716f, 0.9384f, 0.5637f, 1f);
    public Renderer rend;
    private float t = 0;
    private List<Renderer> childrenRender = new List<Renderer>();

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        t = timer;

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            childrenRender.Add(child.GetComponent<Renderer>());
        }

        ChangeFloor();
    }

    // Update is called once per frame
    void Update()
    {
        //timer para cambiar de color
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            ChangeFloor();
            timer = t;
            Debug.Log(gameObject.layer);
        }
    }

    private void ChangeChildrenColors(Color color, LayerMask layer)
    {
        foreach (var child in childrenRender)
        {
            child.material.color = color;
            child.gameObject.layer = layer;
        }
    }


    void ChangeFloor()
    {
        var num = Random.Range(0, 4);

        if (num == 0)
        {
            var layer = LayerMask.NameToLayer("Rojo");
            ChangeChildrenColors(new Color(0.9339f, 0.5154f, 0.5154f, 1f), layer);
        }

        if (num == 1)
        {
            var layer = LayerMask.NameToLayer("Azul");
            ChangeChildrenColors(new Color(0.5279f, 0.5279f, 0.9905f, 1f), layer);
        }

        if (num == 2)
        {
            var layer = LayerMask.NameToLayer("Amarillo");
            ChangeChildrenColors(new Color(0.9716f, 0.9384f, 0.5637f, 1f), layer);
        }

        if (num == 3)
        {
            var layer = LayerMask.NameToLayer("Verde");
            ChangeChildrenColors(new Color(0.6962f, 1f, 06367f, 1f), layer);
        }
    }
}