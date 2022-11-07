using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance;

    public int Speed;

    private bool _canItAddPoints = true;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        Speed = (int)Move.Instance.RbPlayer.velocity.magnitude;
        if (Speed >= 30 && _canItAddPoints)
        {
            StartCoroutine(AddPoints());
        }
    }

    public void MinusPoints()
    {
        if (UIPointsController.Instance._currentPoints >= 100)
        {
            UIPointsController.Instance.ChangeNumOfPoints(-100);
        }
        else
        {
            UIPointsController.Instance.ChangeNumOfPoints(-UIPointsController.Instance._currentPoints);
            MainMenuController.Instance.ActivateDeathUI();
        }
    }

    IEnumerator AddPoints()
    {
        _canItAddPoints = false;
        
        UIPointsController.Instance.ChangeNumOfPoints(5 * Speed);
        SoundPlayer.Instance.AddPoints();
        
        yield return new WaitForSeconds(0.5f);

        _canItAddPoints = true;
    }
}
