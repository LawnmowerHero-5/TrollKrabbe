using System;
using MainMenu;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject player;
    public Button playButton;
    private InputActions inputAction;
    private bool gamePause;
    public bool gameIsPaused;
    public bool startMenu;
    public GameObject mainMenu;
    public GameObject menuCamera;
    private StartGame startGame;

    private void Awake()
    {
        inputAction = new InputActions();
    }

    private void Start()
    {
        MainMenu();
        gameIsPaused = false;
    }
    
    private void Update()
    {
        

        gamePause = inputAction.Player.Pause.triggered;
        if (startMenu == true) return;
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
        Cursor.lockState = CursorLockMode.None;             
        Cursor.visible = true;
    }

    public void PauseInMenu()
    {
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
        Cursor.lockState = CursorLockMode.Locked;             
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    private void MainMenu()
    {
        startMenu = true;
        player.SetActive(false);
        mainMenu.SetActive(true);
        menuCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;             
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        startMenu = false;
        player.SetActive(true);
        mainMenu.SetActive(false);
        menuCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;             
        Cursor.visible = false;
    }
}