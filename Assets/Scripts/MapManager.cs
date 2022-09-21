using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMap;
    [SerializeField] private GameObject interectPronp;

    private PlayerInputSystem mInputSystem;
    private InputAction InterectInput;

    private bool playerOnRange;

    void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        InterectInput = mInputSystem.Player.Use;
        InterectInput.Enable();
        InterectInput.performed += OpenMap;
    }

    void OnDisable()
    {
        InterectInput.Disable();
    }

    void Update()
    {
        if (!playerOnRange && pauseMap.activeSelf == true)
        {
           pauseMap.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = true;
            interectPronp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = false;
            interectPronp.SetActive(false);
        }
    }

    void OpenMap(InputAction.CallbackContext context)
    {
        if (playerOnRange)
        {
            if (pauseMap.activeSelf == false)
            {
                pauseMap.SetActive(true);
            }
            else
            {
                pauseMap.SetActive(false);
            }
        }
    }
}
