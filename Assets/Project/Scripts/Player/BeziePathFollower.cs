using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;
using System;

public class BeziePathFollower : MonoBehaviour
{
    public float PassedPath => passedPath;
    public event Action PathCompleted;

    [SerializeField] private BezierSpline bezierSpline;
    [SerializeField] private float speed;
    [SerializeField] private Player player;

    private float passedPath;
    private Transform cachedTransform;
    private bool IsPathCompleted;
    private void Start()
    {
        cachedTransform = this.transform;
    }
    private void Update()
    {
        if (player.gameState == GameState.Started)
        {
            TryMove();
        }
    }

    private bool TryMove()
    {
        if (!IsPathCompleted)
        {
            SetNextPosition();
            SetNextRotation();

            if (passedPath > 1)
            {
                PathCompleted?.Invoke();
                IsPathCompleted = true;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnEnable()
    {
        player.Died += Stop;
    }

    private void OnDisable()
    {
        player.Died -= Stop;
    }

    private void Stop()
    {
        speed = 0;
    }
    private void SetNextPosition()
    {
        var nextPos = bezierSpline.MoveAlongSpline(ref passedPath, speed * Time.deltaTime);
        cachedTransform.position = nextPos;
    }

    private void SetNextRotation()
    {
        BezierSpline.Segment segment = bezierSpline.GetSegmentAt(passedPath);
        var targetRotation = Quaternion.LookRotation(segment.GetTangent(), segment.GetNormal());
        cachedTransform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

    }
}
