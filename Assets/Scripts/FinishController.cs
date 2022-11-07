using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            SoundPlayer.Instance.FinishLevel();
            Move.Instance.FinishMove();
            MainMenuController.Instance.ActivateWinUI();
        }
    }
}
