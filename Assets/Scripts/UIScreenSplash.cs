using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenSplash : MonoBehaviour
{
    [SerializeField] private GameObject VictoryScreen = null;
    [SerializeField] private GameObject LostScreen = null;
    [SerializeField] private Text victoryText = null;
    [SerializeField] private Text lostText = null;

    private GameStateManager _gameStateManager;

    private void Awake()
    {
        _gameStateManager = GetComponent<GameStateManager>();
        _gameStateManager.OnVictory += OnVictory;
        _gameStateManager.OnLost += OnLost; 
    }

    private void OnLost(string condition)
    {
        lostText.text = condition;
        LostScreen.SetActive(true);
    }

    private void OnVictory(string condition)
    {
        victoryText.text = condition;
        VictoryScreen.SetActive(true);
    }
}
