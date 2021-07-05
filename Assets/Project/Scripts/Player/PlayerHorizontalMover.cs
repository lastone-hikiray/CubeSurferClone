using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHorizontalMover : MonoBehaviour
{
    [SerializeField] private SliderJoystick sliderJoystick;
    [SerializeField] private Transform cachedTransform;
    [SerializeField] private float moveFromCenter = 2f;
    [SerializeField] private Player player;

    private bool controlled;
    private void Awake()
    {
        if (cachedTransform == null)
        {
            cachedTransform = this.transform;
        }
        if (player == null)
        {
            player = GetComponent<Player>();
        }
    }


    public void Update()
    {
        if (player.gameState == GameState.Started)
        {
            MoveH(sliderJoystick.HorizontalPosition);
        }
    }
    public void MoveH(float Position)
    {
        Position = Mathf.Clamp(Position, -1, 1);
        Vector3 nextPos = cachedTransform.localPosition;
        nextPos.x = Position * moveFromCenter;
        cachedTransform.localPosition = nextPos;
    }
}
