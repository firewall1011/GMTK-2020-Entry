using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DeathZone : MonoBehaviour
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
            other.gameObject.SetActive(false);
            _gameStateManager.ActivateLost("Oh no! Death Zone!");
        }
    }
}
