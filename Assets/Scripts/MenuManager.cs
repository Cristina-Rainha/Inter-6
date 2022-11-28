using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int scene;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    
    [Header("Load")]
    [SerializeField] private GameObject load;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject rain;

    //buttons
    [SerializeField] private Button primarybutton;
    [SerializeField] private Button back;
    [SerializeField] private GameObject buttons;

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
            buttons.SetActive(false);
            back.Select();
        }
    }
    
    public void CloseCredits()
    {
        credits.SetActive(false);
        if (credits.activeSelf == false)
        {
            buttons.SetActive(true);
            primarybutton.Select();
        }
    }
    public void CloseGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoadLevelBtn(int levelToLoad)
    {
        load.SetActive(true);
        rain.SetActive(false);
        StartCoroutine(LoadAsynchronously(levelToLoad));
    }

    IEnumerator LoadAsynchronously(int levelToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    private void XboxInputControl(InputAction.CallbackContext ctx)
    {
        Cursor.lockState = CursorLockMode.Locked;
        primarybutton.Select();
    }
    private void PS4InputControl(InputAction.CallbackContext ctx)
    {
        Cursor.lockState = CursorLockMode.Locked;
        primarybutton.Select();

    }
    private void KeyboardInputControl(InputAction.CallbackContext ctx)
    {
        Cursor.lockState = CursorLockMode.None;
    }
}

