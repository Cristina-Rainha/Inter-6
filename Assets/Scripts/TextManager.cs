using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextManager : MonoBehaviour
{

    private PlayerInputSystem mInputSystem;
    private InputAction interaction;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += CloseTextBpx;
    }

    private void OnDisable()
    {
        interaction.Disable();
    }
    private void CloseTextBpx(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            gameObject.SetActive(false);
        }
    }
}
