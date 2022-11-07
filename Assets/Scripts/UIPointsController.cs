using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPointsController : MonoBehaviour
{
    public static UIPointsController Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _animText;

    public GameObject EndPoint;
    public float Duration;
    
    public int _currentPoints;

    public void ChangeNumOfPoints(int points)
    {
        PointsAddAnimation(points);
        _currentPoints += points;
        _pointsText.text = _currentPoints.ToString();
    }

    public void PointsAddAnimation(int points)
    {
        var newObj = Instantiate(_animText, _startPoint.position, Quaternion.identity);
        newObj.transform.SetParent(_canvas.gameObject.transform);
        var text = _animText.GetComponentInChildren<TMP_Text>();
        text.text = points.ToString();
    }
    
    
}
