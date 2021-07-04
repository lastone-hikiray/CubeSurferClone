using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Died;
    public GameState gameState { get; private set; } = GameState.NotStarted;

    [SerializeField] private int startCubesCount;
    [SerializeField] private CubesPool pool;
    [SerializeField] private BeziePathFollower pathFolower;
    [SerializeField] private SliderJoystick SliderJoystick;

    private void Awake()
    {
        if (pool == null)
        {
            pool = GetComponentInChildren<CubesPool>();
        }
        if (pathFolower == null)
        {
            pathFolower = GetComponentInParent<BeziePathFollower>();
        }
    }

    private void Start()
    {
        for (int i = 0; i < startCubesCount; i++)
        {
            pool.AddCube();
        }
    }
    private void OnEnable()
    {
        pool.CubesCountChainged += OnCubesCountChaing;
        pathFolower.PathCompleted += LevelComplete;
        SliderJoystick.FirstTouch += GameStart;
    }

    private void OnDisable()
    {
        pool.CubesCountChainged -= OnCubesCountChaing;
        pathFolower.PathCompleted -= LevelComplete;
        SliderJoystick.FirstTouch -= GameStart;

    }

    private void LevelComplete()
    {
        gameState = GameState.LevelEnded;
        Died?.Invoke();
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
        gameState = GameState.PlayerDied;
        Died?.Invoke();
    }

    private void GameStart()
    {
        gameState = GameState.Started;
    }
}
