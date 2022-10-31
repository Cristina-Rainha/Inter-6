using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TraficLight : MonoBehaviour
{
    [SerializeField] private GameObject canvasPromp;
    [SerializeField] private GameObject canvasDistrictName;

    private PlayerInputSystem mInputSystem;
    private InputAction InterectInput;
    private bool inside;

    void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        InterectInput = mInputSystem.Player.Use;
        InterectInput.Enable();
        InterectInput.performed += OpenName;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            canvasPromp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = false;
            canvasPromp.SetActive(false);
            canvasDistrictName.SetActive(false);
        }
    }

    private void OpenName(InputAction.CallbackContext obj)
    {
        if(inside)
        {
            if (canvasDistrictName.activeSelf == false)
            {
                canvasDistrictName.SetActive(true);
            }
            else
            {
                canvasDistrictName.SetActive(false);
            }
        }
        
    }
}
