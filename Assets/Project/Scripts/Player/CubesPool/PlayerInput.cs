using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(HorizontalMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float ScreenPart = 0.3f;
    [SerializeField] private HorizontalMover playerMover;
    [SerializeField] private Player player;

    private float joysticCenter;
    private float screenWidth = Screen.width;
    private float JoystickToScreenPoint { get { return (screenWidth / 2 * ScreenPart); } }

    void Update()
    {
        if (true)
        {

        }
        if (Input.GetMouseButtonDown(0))
        {
            joysticCenter = Input.mousePosition.x - playerMover.targetPositionX * JoystickToScreenPoint;
        }

        if (Input.GetMouseButton(0))
        {
            float distanceNormallized = (Input.mousePosition.x - joysticCenter) / JoystickToScreenPoint;

            if (distanceNormallized > 1)
            {
                joysticCenter += (distanceNormallized - 1) * JoystickToScreenPoint;
                distanceNormallized = 1;
            }
            else if (distanceNormallized < -1)
            {
                joysticCenter += (distanceNormallized + 1) * JoystickToScreenPoint;
                distanceNormallized = -1;
            }
            playerMover.MoveH(distanceNormallized);
        }
    }
}
