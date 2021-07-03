using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    [SerializeField] private float moveFromCenter = 2f;
    public float targetPositionX { get; private set; }
    private Transform cachedTransform;
    private void Awake()
    {
        cachedTransform = transform;
        targetPositionX = Mathf.Clamp(cachedTransform.localPosition.x, -1, 1);
    }
    public void MoveH(float moveT)
    {
        moveT = Mathf.Clamp(moveT, -1, 1);
        targetPositionX = moveT;
        Vector3 nextPos = cachedTransform.localPosition;
        nextPos.x = moveT * moveFromCenter;
        cachedTransform.localPosition = nextPos;
    }
}
