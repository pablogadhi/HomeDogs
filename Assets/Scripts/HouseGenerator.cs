using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HouseGenerator : MonoBehaviour
{
    public int GridSize;
    public int LargeAmount;
    public int MediumAmount;
    public GameObject LargeRoom;
    public GameObject MediumRoom;
    public GameObject SmallRoom;

    private bool[,] houseGrid;
    private Dictionary<String, int>[,] realPositions;

    // Start is called before the first frame update
    void Start()
    {
        houseGrid = new bool[GridSize + 1, GridSize + 1];
        realPositions = new Dictionary<string, int>[GridSize + 1, GridSize + 1];
        for (int i = 0; i <= GridSize; i++)
        {
            for (int j = 0; j <= GridSize; j++)
            {
                realPositions[i, j] = new Dictionary<string, int>();
                realPositions[i, j].Add("x", (i - GridSize / 2) * 10);
                realPositions[i, j].Add("z", (j - GridSize / 2) * 10);
            }
        }

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (var i = 0; i < LargeAmount; i++)
        {
            TryToCreateRooms(Size.Large);
        }

        for (var i = 0; i <= GridSize; i++)
        {
            for (int j = 0; j <= GridSize; j++)
            {
                if (PositionsAreFree(i, j, Size.Small))
                {
                    InstantiateRoom(i, j, Size.Small);
                }
            }
        }
    }

    private void TryToCreateRooms(Size size)
    {
        while (true)
        {
            var posX = Random.Range(0, GridSize);
            var posZ = Random.Range(0, GridSize);

            if (PositionsAreFree(posX, posZ, size))
            {
                InstantiateRoom(posX, posZ, size);
            }
            else
            {
                if (!HasSpace()) return;
                Debug.Log("Putting");
                continue;
            }

            break;
        }
    }

    private void InstantiateRoom(int posX, int posZ, Size size)
    {
        var offsetX = 0;
        var offsetZ = 0;
        var objectToInstantiate = SmallRoom;

        switch (size)
        {
            case Size.Large:
                offsetX = 5;
                offsetZ = 5;
                objectToInstantiate = LargeRoom;
                break;
        }

        Instantiate(objectToInstantiate,
            new Vector3(realPositions[posX, posZ]["x"] + offsetX, 0f,
                realPositions[posX, posZ]["z"] + offsetZ), Quaternion.identity, transform);
        OcuppyGridPositions(posX, posZ, size);
    }

    private bool HasSpace()
    {
        for (var i = 0; i < GridSize; i++)
        {
            for (var j = 0; j < GridSize; j++)
            {
                if (!houseGrid[i, j]) return true;
            }
        }

        return false;
    }

    private void OcuppyGridPositions(int posX, int posZ, Size size)
    {
        switch (size)
        {
            case Size.Large:
                houseGrid[posX, posZ] = true;
                houseGrid[posX + 1, posZ] = true;
                houseGrid[posX, posZ + 1] = true;
                houseGrid[posX + 1, posZ + 1] = true;
                break;
            case Size.Small:
                houseGrid[posX, posZ] = true;
                break;
        }
    }

    private bool PositionsAreFree(int posX, int posZ, Size roomSize)
    {
        switch (roomSize)
        {
            case Size.Large:
                return !houseGrid[posX, posZ] &&
                       !houseGrid[posX + 1, posZ] &&
                       !houseGrid[posX, posZ + 1] &&
                       !houseGrid[posX + 1, posZ + 1];
            case Size.Small:
                return !houseGrid[posX, posZ];
        }

        return false;
    }
}