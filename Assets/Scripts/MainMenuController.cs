using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;
    
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject RestartUI;
    [SerializeField] private GameObject WinUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Move.Instance.Acceleration = 0f;
        FovConroller.Instance.T = 0f;
        Rotation.Instance.Speed = 0f;
        
        MainMenuUI.SetActive(true);
        GameUI.SetActive(false);
        RestartUI.SetActive(false);
        WinUI.SetActive(false);
    }

    public void PlayButton()
    {
        MainMenuUI.SetActive(false);
        GameUI.SetActive(true);
        
        Move.Instance.Acceleration = 50f;
        FovConroller.Instance.T = 0.01f;
        Rotation.Instance.Speed = 7.5f;
    }

    public void RestartButton()
    {
        Application.LoadLevel(0);
    }

    public void ActivateDeathUI()
    {
        Move.Instance.Acceleration = 0f;
        FovConroller.Instance.T = 0f;
        Rotation.Instance.Speed = 0f;
        
        GameUI.SetActive(false);
        RestartUI.SetActive(true);
    }

    public void ActivateWinUI()
    {
        GameUI.SetActive(false);
        WinUI.SetActive(true);
    }
}
