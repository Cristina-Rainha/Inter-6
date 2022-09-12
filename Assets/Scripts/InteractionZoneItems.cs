using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractionZoneItems : MonoBehaviour
{
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject canvasText;
    
    //bool
    private bool inside;
  
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
        if(inside && VariableHolder.pinkNpc)
        {
            VariableHolder.pinkItem = true;
            gameObject.SetActive(false);
            Debug.Log("Pink Item Collected");
        }
        if(inside && VariableHolder.redNpc)
        {
            VariableHolder.redItem = true;
            gameObject.SetActive(false);
            Debug.Log("Red Item Collected");
        }
    }
}
