using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{
 [SerializeField] private float _rotateSpeed = 0.4f;
 [SerializeField] private RoadGenerator _generator;

    private float _rot;

    void Update()
    {
        _rot += Time.deltaTime;
        RenderSettings.skybox.SetFloat("_Rotation", _rot * _rotateSpeed * _generator.Speed);
    }
}
