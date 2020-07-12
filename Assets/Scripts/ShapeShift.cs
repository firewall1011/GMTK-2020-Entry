using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShift : MonoBehaviour
{
    public event Action<int> OnShapeShift;

    [SerializeField] private GameObject[] Shapes = null;
    [SerializeField] private int InitialShape = 0;
    [SerializeField] private int BeatsPerChange = 4;

    public int ActiveShapeIndex { get => _activeShapeIndex; }

    private int _activeShapeIndex = 0;
    private int _beatCount = 0;

    private void Awake()
    {
        for(int i = 0; i < Shapes.Length; i++)
        {
            Shapes[i].SetActive(false);
        }
        Shapes[InitialShape].SetActive(true);
        _activeShapeIndex = InitialShape;

        OnShapeShift?.Invoke(_activeShapeIndex);
    }

    public void ShiftShape(int index)
    {
        Shapes[index].SetActive(true);
        Shapes[_activeShapeIndex].SetActive(false);
        _activeShapeIndex = index;

        OnShapeShift?.Invoke(_activeShapeIndex);
    }

    public void ShiftToNextShape()
    {
        int index = (_activeShapeIndex + 1) % Shapes.Length;
        ShiftShape(index);
    }

    public void OnBeat()
    {
        if (PauseMenu.GameIsPaused)
        {
            return;
        }
        _beatCount++;
        if(_beatCount >= BeatsPerChange)
        {
            _beatCount = 0;
            ShiftToNextShape();
        }
    }

}
