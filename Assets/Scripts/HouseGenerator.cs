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

        houseGrid[5, 5] = true;

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        //LargeRooms
        for (var i = 0; i < LargeAmount; i++)
        {
            TryToCreateRooms(Size.Large);
        }

        for (int i = 0; i < MediumAmount; i++)
        {
            TryToCreateRooms(Size.Medium);
        }

        //Fill the rest with small rooms
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
            var rotate = false;

            if (size == Size.Medium)
            {
                rotate = Random.Range(0, 2) == 0;
            }

            if (PositionsAreFree(posX, posZ, size, rotate))
            {
                InstantiateRoom(posX, posZ, size, rotate);
            }
            else
            {
                if (!HasSpace()) return;
                Debug.Log("Trying Again");
                continue;
            }

            break;
        }
    }

    private void InstantiateRoom(int posX, int posZ, Size size, bool rotate = false)
    {
        var offsetX = 0;
        var offsetZ = 0;
        var objectToInstantiate = SmallRoom;
        var rotation = Quaternion.identity;

        switch (size)
        {
            case Size.Large:
                offsetX = 5;
                offsetZ = 5;
                objectToInstantiate = LargeRoom;
                break;
            case Size.Medium:
                if (rotate)
                {
                    offsetZ = 5;
                    rotation = Quaternion.Euler(0f, 90f, 0f);
                }
                else
                {
                    offsetX = 5;
                }

                objectToInstantiate = MediumRoom;
                break;
        }

        Instantiate(objectToInstantiate,
            new Vector3(realPositions[posX, posZ]["x"] + offsetX, 0f,
                realPositions[posX, posZ]["z"] + offsetZ), rotation, transform);
        OcuppyGridPositions(posX, posZ, size, rotate);
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

    private void OcuppyGridPositions(int posX, int posZ, Size size, bool rotate = false)
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
            case Size.Medium:
                houseGrid[posX, posZ] = true;
                if (rotate)
                {
                    houseGrid[posX, posZ + 1] = true;
                }
                else
                {
                    houseGrid[posX + 1, posZ] = true;
                }

                break;
        }
    }

    private bool PositionsAreFree(int posX, int posZ, Size roomSize, bool rotated = false)
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
            case Size.Medium:
                if (rotated) return !houseGrid[posX, posZ] && !houseGrid[posX, posZ + 1];
                return !houseGrid[posX, posZ] && !houseGrid[posX + 1, posZ];
        }

        return false;
    }
}