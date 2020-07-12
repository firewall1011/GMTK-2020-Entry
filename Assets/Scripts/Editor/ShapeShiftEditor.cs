using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShapeShift))]
public class ShapeShiftEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ShapeShift shapeShift = (ShapeShift) target;

        if(GUILayout.Button("Shape Shift to next"))
        {
            shapeShift.ShiftToNextShape();
        }
    }
}
