using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private InputActions inputAction;
    private bool gamePause;
    public bool gameIsPaused;

    private void Awake()
    {
        inputAction = new InputActions();
    }

    private void Update()
    {
        gamePause = inputAction.Player.Pause.triggered;

        if (gamePause)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        if (pauseCanvas == null) return;
        pauseCanvas.SetActive(false);
        AudioListener.pause = false;
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}