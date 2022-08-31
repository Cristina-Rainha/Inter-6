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
            foreach (TextMeshProUGUI text in UseText)
            {
                text.text = "B";
            }
        }
    }
    private void OpenTextBoxPS(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            foreach (TextMeshProUGUI text in UseText)
            {
                text.text = "O";
            }
        }
    }

    private void OpenTextBoxKB(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            foreach (TextMeshProUGUI text in UseText)
            {
                text.text = "E";
            }
        }
    }
}
