using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShape : MonoBehaviour
{
    private float _scale = 100f;
    private SkinnedMeshRenderer meshRenderer = null;
    [SerializeField] private float scaleRate = 0.01f;

    private void Awake()
    {
        _scale = 100f;
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    public void Scale()
    {
        if(_scale < 1f)
        {
            CancelInvoke("Scale");
            meshRenderer.SetBlendShapeWeight(0, 0.0f);
        }
        meshRenderer.SetBlendShapeWeight(0, _scale--);
    }

    private void OnEnable()
    {
        InvokeRepeating("Scale", 0.0f, scaleRate);
    }

    private void OnDisable()
    {
        _scale = 100f;
        meshRenderer.SetBlendShapeWeight(0, _scale);
    }

}
