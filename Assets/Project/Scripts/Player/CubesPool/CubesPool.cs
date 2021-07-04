using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPool : MonoBehaviour
{
    public event Action<int> CubesCountChainged;

    [SerializeField] private CollectedCube cubePrefab;
    [SerializeField] private Transform CubeSpawnPosition;

    private List<CollectedCube> attachedCubes = new List<CollectedCube>();
    private Queue<CollectedCube> unusedCubes = new Queue<CollectedCube>();
    private int cubesCount = 0;
    public void AddCube()
    {
        CollectedCube newCube;
        Vector3 spawnPosition = GetLocalSpawnPosition();

        if (TryGetUnusedCube(out CollectedCube cube))
        {
            cube.gameObject.SetActive(true);
            newCube = cube;
        }
        else
        {
            newCube = Instantiate(cubePrefab);
        }
        newCube.Init(this, spawnPosition, Quaternion.identity, this.transform);
        attachedCubes.Add(newCube);
        cubesCount++;
        CubesCountChainged?.Invoke(cubesCount);
    }

    public void RemoveCube(CollectedCube cube)
    {
        attachedCubes.Remove(cube);
        cube.gameObject.transform.SetParent(null);
        cubesCount--;
        StartCoroutine(cube.AfterRemove(AddToUnused));
        CubesCountChainged?.Invoke(cubesCount);
    }


    private Vector3 GetLocalSpawnPosition()
    {
        Vector3 spawnPoint = CubeSpawnPosition.localPosition;
        CubeSpawnPosition.localPosition += Vector3.up;
        return spawnPoint;
    }

    private bool TryGetUnusedCube(out CollectedCube cube)
    {
        if (unusedCubes.Count > 0)
        {
            cube = unusedCubes.Dequeue();
        }
        else
        {
            cube = null;
        }
        return cube != null;
    }

    private void AddToUnused(CollectedCube cube)
    {
        unusedCubes.Enqueue(cube);
    }

}
