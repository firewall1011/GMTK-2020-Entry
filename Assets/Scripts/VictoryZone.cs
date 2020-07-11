using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VictoryZone : MonoBehaviour
{
    private GameStateManager _gameStateManager;

    private void Awake()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameStateManager.ActivateVictory("You have reached a victory zone!");
        }
    }
}
