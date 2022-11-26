using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class SceneControl : MonoBehaviour
{
    private PlayerInputSystem mInputSystem;
    private InputAction UIinput;
    private InputAction XboxInput;
    private InputAction PS4Input;

    [SerializeField] private GameObject volume;
    [SerializeField] private string sceneMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject ControlePanel;
    [SerializeField] private GameObject SoundPanel;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button controleButton;


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
        volume.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene(sceneMenu);
    }

    public void ControlMenu()
    {
        if (ControlePanel.activeSelf == false)
        {
            ControlePanel.SetActive(true);
            controleButton.Select();
        }
        else
        {
            ControlePanel.SetActive(false);
            menuButton.Select();
        }
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
                //ControlePanel.SetActive(false);
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

    public void CotinueButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SoundMenu()
    {
        if (SoundPanel.activeSelf == false)
        {
            SoundPanel.SetActive(true);
        }
        else
        {
            SoundPanel.SetActive(false);
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
