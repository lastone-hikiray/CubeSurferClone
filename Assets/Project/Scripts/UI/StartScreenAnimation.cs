using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenAnimation : MonoBehaviour
{
    [SerializeField] private Player player;
    void Update()
    {
        if (player.gameState == GameState.Started)
        {
            gameObject.SetActive(false);
        }
    }
}
