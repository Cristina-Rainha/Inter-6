using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    private PlayerInputSystem mInputSystem;
    private InputAction UIinput;

    [SerializeField] private string sceneMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button menuButton;


    void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }
    void OnEnable()
    {
        UIinput = mInputSystem.UI.PauseGame;
        UIinput.Enable();
        UIinput.performed += Pause;
    }
    void OnDisable()
    {
        UIinput.Disable();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(sceneMenu);
    }

    public void ExitPlayMode()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void Pause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                menuButton.Select();
                Cursor.lockState= CursorLockMode.None;
            }
        }
    }
}
