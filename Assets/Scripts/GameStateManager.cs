using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public event Action<string> OnVictory;
    public event Action<string> OnLost;

    public int PiecesCollected = 0;
    public int MaxPiecesCount = 3;

    public void ActivateVictory(string victory_message = "")
    {
        OnVictory?.Invoke(victory_message);
    }

    public void ActivateLost(string loss_message = "")
    {
        OnLost?.Invoke(loss_message);
    }

    public void AddPieceCollected()
    {
        PiecesCollected++;
        if(PiecesCollected >= MaxPiecesCount)
        {
            ActivateVictory("You collected all Pieces!\nHurray!!");
        }
    }

}
