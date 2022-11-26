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
    [SerializeField] private List<Image> iconImage;
    [SerializeField] private List<Sprite> iconSprite;
    [SerializeField] private Image meiIcon;
    [SerializeField] private List<Sprite> meiSprite;
    [SerializeField] private GameObject KeyboardControls;
    [SerializeField] private GameObject XboxControls;
    [SerializeField] private GameObject PS4Controls;

    //FristText
    [SerializeField] private List<Image> MeiDialogs;
    [SerializeField] private List<Sprite> MeiDialogSprites;

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
            foreach (Image image in iconImage)
            {
                image.sprite = iconSprite[0];
                KeyboardControls.SetActive(false);
                XboxControls.SetActive(true);
                PS4Controls.SetActive(false);
                meiIcon.sprite = meiSprite[0];
                MeiDialogs[0].sprite = MeiDialogSprites[0];
                MeiDialogs[1].sprite = MeiDialogSprites[1];
            }
        }
    }
    private void OpenTextBoxPS(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            foreach (Image image in iconImage)
            {
                image.sprite = iconSprite[1];
                KeyboardControls.SetActive(false);
                XboxControls.SetActive(false);
                PS4Controls.SetActive(true);
                meiIcon.sprite = meiSprite[1];
                MeiDialogs[0].sprite = MeiDialogSprites[2];
                MeiDialogs[1].sprite = MeiDialogSprites[3];
            }
        }
    }

    private void OpenTextBoxKB(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            foreach (Image image in iconImage)
            {
                image.sprite = iconSprite[2];
                KeyboardControls.SetActive(true);
                XboxControls.SetActive(false);
                PS4Controls.SetActive(false);
                meiIcon.sprite = meiSprite[2];
                MeiDialogs[0].sprite = MeiDialogSprites[4];
                MeiDialogs[1].sprite = MeiDialogSprites[5];
            }
        }
    }
}
