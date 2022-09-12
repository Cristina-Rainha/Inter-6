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
    private InputAction XboxInput;
    private InputAction PS4Input;

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

        XboxInput = mInputSystem.UI.XboxInput;
        //XboxInput.Enable();
        XboxInput.performed += XboxInputControl;

        PS4Input = mInputSystem.UI.PS4Input;
        //PS4Input.Enable();
        PS4Input.performed += PS4InputControl;
    }
    void OnDisable()
    {
        UIinput.Disable();
        XboxInput.Disable();
        PS4Input.Disable();
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
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
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

    private void XboxInputControl(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (pauseMenu.activeSelf)
            {
                //menuButton.Select();
            }
        }
    }

    private void PS4InputControl(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (pauseMenu.activeSelf)
            {
                //menuButton.Select();
            }
        }
    }
}
