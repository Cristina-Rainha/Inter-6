using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    
    [SerializeField] private Button primarybutton;
    [SerializeField] private Button back;

    private PlayerInputSystem mInputSystem;
    private InputAction XboxInput;
    private InputAction PS4Input;
    private InputAction KeyboardInput;


    void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }
    void OnEnable()
    {
        XboxInput = mInputSystem.UI.XboxInput;
        XboxInput.Enable();
        XboxInput.performed += XboxInputControl;

        PS4Input = mInputSystem.UI.PS4Input;
        PS4Input.Enable();
        PS4Input.performed += PS4InputControl;

        KeyboardInput = mInputSystem.UI.KeyboardInput;
        KeyboardInput.Enable();
        KeyboardInput.performed += KeyboardInputControl;
    }

    void OnDisable()
    {
        XboxInput.Disable();
        PS4Input.Disable();
        KeyboardInput.Disable();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void Credits()
    {
        credits.SetActive(true);
        if(credits.activeSelf)
        {
            back.Select();
        }
    }
    
    public void CloseCredits()
    {
        credits.SetActive(false);
        if (credits.activeSelf == false)
        {
            primarybutton.Select();
        }
    }
    public void CloseGame()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    private void XboxInputControl(InputAction.CallbackContext ctx)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void PS4InputControl(InputAction.CallbackContext ctx)
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void KeyboardInputControl(InputAction.CallbackContext ctx)
    {
        Cursor.lockState = CursorLockMode.None;
    }
}

