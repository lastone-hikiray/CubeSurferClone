using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubesPool))]
public class Player : MonoBehaviour
{
    public event Action Died;
    [SerializeField] private int startCount;
    private CubesPool pool;

    
    private void Awake()
    {
        pool = GetComponent<CubesPool>();

        for (int i = 0; i < startCount; i++)
        {
            pool.AddCube();
        }
    }

    private void OnEnable()
    {
        pool.CubesCountChainged += OnCubesCountChaing;
    }

    private void OnDisable()
    {
        pool.CubesCountChainged -= OnCubesCountChaing;

    } 

    private void OnCubesCountChaing(int count)
    {
        if (count <= 0)
        {
            Die();   
        }
    }

    private void Die()
    {
        Died?.Invoke();

    }
}
