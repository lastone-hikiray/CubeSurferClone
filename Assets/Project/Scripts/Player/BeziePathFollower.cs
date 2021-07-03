using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class BeziePathFollower : MonoBehaviour
{
    [SerializeField] private BezierSpline bezierSpline;
    [SerializeField] private float speed;
    [SerializeField] private Player player;
    private float PassedT;
    private Transform cachedTransform;

    private void Start()
    {
        cachedTransform = this.transform;
    }
    private void Update()
    {
        SetNextPosition();
        SetNextRotation();
        player.LevelCompleteT(PassedT);
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
        var nextPos = bezierSpline.MoveAlongSpline(ref PassedT, speed * Time.deltaTime);
        cachedTransform.position = nextPos;
    }

    private void SetNextRotation()
    {
        BezierSpline.Segment segment = bezierSpline.GetSegmentAt(PassedT);
        var targetRotation = Quaternion.LookRotation(segment.GetTangent(), segment.GetNormal());
        cachedTransform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        
    }
}
