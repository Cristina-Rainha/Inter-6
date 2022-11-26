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
    private InputAction KeyboardInput;

    [SerializeField] private GameObject volume;
    [SerializeField] private string sceneMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject ControlePanel;
    [SerializeField] private GameObject SoundPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject MenuButtonsGrup;


    [SerializeField] private Button menuButton;
    [SerializeField] private Button controleButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button noToMenuButton;
    [SerializeField] private Button noToExitButton;

    private bool ps4;
    private bool xbox;
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

        KeyboardInput = mInputSystem.UI.KeyboardInput;
        //KeyboardInput.Enable();
        KeyboardInput.performed += KeyboardInputControl;
        
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

    private void Pause(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                ControlePanel.SetActive(false);
                SoundPanel.SetActive(false);
                exitPanel.SetActive(false);
                menuPanel.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pauseMenu.SetActive(true);
                if(ps4 || xbox)
                {
                    menuButton.Select();
                }
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void OpenControlMenu()
    {
        ControlePanel.SetActive(true);
        controleButton.Select();
        MenuButtonsGrup.SetActive(false);
    }
    public void OpenExitOption()
    {
        exitPanel.SetActive(true);
        noToExitButton.Select();
        MenuButtonsGrup.SetActive(false);
    }

    public void OpenMenuOption()
    {
        menuPanel.SetActive(true);
        noToMenuButton.Select();
        MenuButtonsGrup.SetActive(false);
    }
    public void OpenSoundMenu()
    {
        SoundPanel.SetActive(true);
        soundButton.Select();
        MenuButtonsGrup.SetActive(false);
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

    public void CotinueButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseControlMenu()
    {
        ControlePanel.SetActive(false);
        MenuButtonsGrup.SetActive(true);
        menuButton.Select();
    }

    public void CloseSoundMenu()
    {
        SoundPanel.SetActive(false);
        MenuButtonsGrup.SetActive(true);
        menuButton.Select();
    }

    public void CloseExit()
    {
        exitPanel.SetActive(false);
        MenuButtonsGrup.SetActive(true);
        menuButton.Select();
    }
    
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        MenuButtonsGrup.SetActive(true);
        menuButton.Select();
    }

    private void XboxInputControl(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            xbox = true;
        }
    }

    private void PS4InputControl(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            ps4 = true;
        }
    }

    private void KeyboardInputControl(InputAction.CallbackContext ctx)
    {
        ps4 = false;
        xbox = false;
    }
}
