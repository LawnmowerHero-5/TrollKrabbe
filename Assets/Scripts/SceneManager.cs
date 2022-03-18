using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    private InputActions inputAction;
    private bool pause;
    public bool gameIsPaused;

    private void Awake()
    {
        inputAction = new InputActions();
    }

    private void Update()
    {
        pause = inputAction.Player.Pause.triggered;

        if (pause)
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
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        if (pauseCanvas == null) return;
        pauseCanvas.SetActive(false);
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