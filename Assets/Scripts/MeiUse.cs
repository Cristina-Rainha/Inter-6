using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeiUse : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject icon;
    [SerializeField] private Animator iconAnim;

    private PlayerInputSystem mInputSystem;
    private InputAction interaction;

    private bool canshow = false;
    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += OpenTextBox;
    }
    void OnDisable()
    {
        interaction.Disable();
    }

    private void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (canshow)
            {
                if (Text.activeSelf)
                {
                    Text.SetActive(false);
                }
                else
                {
                    Text.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canshow = true;
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canshow = false;
            iconAnim.SetTrigger("Reset");
        }
    }
}
