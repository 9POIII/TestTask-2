using System;
using UnityEngine;

public class FovConroller : MonoBehaviour
{
    public static FovConroller Instance;
    
    [SerializeField] private float _maxFOV;
    [SerializeField] private float _minFOV;
    
    [SerializeField] private Camera _mainCamera;

    public float _t;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void AddFov()
    {
        _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _maxFOV, _t);
    }
    
    public void MinusFov()
    {
        _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _minFOV, _t);
    }
}
