using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class GameManager : MasterManager
{
    public static GameManager Instance;
    [SerializeField] private PlayerInput input;
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private CanvasGroup panelWin;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += Lose;
        PlayerController.OnPlayerWin += Win;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= Lose;
        PlayerController.OnPlayerWin -= Win;
    }
    public void PauseGame(CanvasGroup pausePanel)
    {
        if (pausePanel.alpha == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            input.SwitchCurrentActionMap("Pause");
            input.enabled = false;
            Time.timeScale = 0;
            FadeObject(pausePanel, 1f, durationFadePanel, () =>
            {
                pausePanel.interactable = true;
                pausePanel.blocksRaycasts = true;
                input.enabled = true;
            });
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            input.SwitchCurrentActionMap("Game");
            input.enabled = false;
            FadeObject(pausePanel, 0f, durationFadePanel, () =>
            {
                pausePanel.interactable = false;
                pausePanel.blocksRaycasts = false;
                input.enabled = true;
                Time.timeScale = 1;
            });
        }
    }


    private void Lose()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        input.enabled = false;
        Time.timeScale = 0;
        FadePanelIn(panelLose);
    }

    private void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        input.enabled = false;
        Time.timeScale = 0;
        FadePanelIn(panelWin);
    }


}
