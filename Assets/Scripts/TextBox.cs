using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextBox : MonoBehaviour
{
    private PlayerInputSystem mInputSystem;
    private InputAction interaction;
    private Animator Animator;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += CloseTextBox;
        VariableHolder.Instance.OpenTextSound();
    }

    private void OnDisable()
    {
        interaction.Disable();
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }
    
    private void CloseTextBox(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Animator.SetTrigger("Close");
        }
    }

    public void CloseText()
    {
        gameObject.SetActive(false);
    }
}
