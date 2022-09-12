using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractionZoneItems : MonoBehaviour
{
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject item;

    //bool
    private bool inside;
    [SerializeField] private bool pinkObj;
    [SerializeField] private bool blueObj;
    [SerializeField] private bool greenObj;
    [SerializeField] private bool yellowObj;
    [SerializeField] private bool redObj;

    //Input Action
    private PlayerInputSystem mInputSystem;
    private InputAction InteractInput;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }
    private void OnEnable()
    {
        InteractInput = mInputSystem.Player.Use;
        InteractInput.Enable();
        InteractInput.performed += collect;
    }
    private void OnDisable()
    {
        InteractInput.Disable();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            canvasPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = false;
            canvasPanel.SetActive(false);
        }
    }

    public void collect(InputAction.CallbackContext ctx)
    {
        if (inside && VariableHolder.pinkItem == false && pinkObj)
        {
            VariableHolder.pinkItem = true;
            item.SetActive(false);
        }

        if (inside && VariableHolder.redItem == false && redObj)
        {
            VariableHolder.redItem = true;
            item.SetActive(false);
        }
    }
}
