using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMap;

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
        Debug.Log("player is on range " + playerOnRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = false;
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
