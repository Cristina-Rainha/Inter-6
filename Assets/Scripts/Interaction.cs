using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Interaction : MonoBehaviour
{
    //Input System
    private PlayerInputSystem mInputSystem;
    private InputAction XboxInput;
    private InputAction PS4Input;
    private InputAction KeyboardInput;

    //UI
    [SerializeField] private List<TextMeshProUGUI> UseText;
    [SerializeField] private GameObject KeyboardControls;
    [SerializeField] private GameObject XboxControls;
    [SerializeField] private GameObject PS4Controls;

    void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }
    void OnEnable()
    {
        XboxInput = mInputSystem.UI.XboxInput;
        XboxInput.Enable();
        XboxInput.performed += OpenTextBox;
        
        PS4Input = mInputSystem.UI.PS4Input;
        PS4Input.Enable();
        PS4Input.performed += OpenTextBoxPS;
        
        KeyboardInput = mInputSystem.UI.KeyboardInput;
        KeyboardInput.Enable();
        KeyboardInput.performed += OpenTextBoxKB;
    }
    void OnDisable()
    {
        XboxInput.Disable();
        PS4Input.Disable();
        KeyboardInput.Disable();
    }
    private void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Xbox");
            foreach (TextMeshProUGUI text in UseText)
            {
                text.text = "B";
                KeyboardControls.SetActive(false);
                XboxControls.SetActive(true);
                PS4Controls.SetActive(false);
            }
        }
    }
    private void OpenTextBoxPS(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("PS4");
            foreach (TextMeshProUGUI text in UseText)
            {
                text.text = "O";
                KeyboardControls.SetActive(false);
                XboxControls.SetActive(false);
                PS4Controls.SetActive(true);
            }
        }
    }

    private void OpenTextBoxKB(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Keyboard");
            foreach (TextMeshProUGUI text in UseText)
            {
                text.text = "E";
                KeyboardControls.SetActive(true);
                XboxControls.SetActive(false);
                PS4Controls.SetActive(false);
            }
        }
    }
}
