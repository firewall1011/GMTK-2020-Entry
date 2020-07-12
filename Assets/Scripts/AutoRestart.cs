using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRestart : MonoBehaviour
{
    GameStateManager manager;
    void Awake()
    {
        manager = GetComponent<GameStateManager>();
        manager.OnLost += AutoRestart_OnLost;
        manager.OnVictory += Manager_OnVictory;
    }

    private void Manager_OnVictory(string obj)
    {
        FindObjectOfType<PauseMenu>().PauseToEndGame(obj);
    }

    private void AutoRestart_OnLost(string obj)
    {
        FindObjectOfType<PauseMenu>().RestartLevel();
    }

    private void OnDisable()
    {
        manager.OnLost -= AutoRestart_OnLost;
    }
}
