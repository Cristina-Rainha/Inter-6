using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject canvasText;
    [SerializeField] private GameObject canvasText2;
    [SerializeField] private GameObject Item;

    //animator
    private Animator myAnimator;

    //bool
    bool insideInterationZone;

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
        InteractInput.performed += OpenTextBox;
    }
    private void OnDisable()
    {
        InteractInput.Disable();
        canvasText.SetActive(false);
        canvasText2.SetActive(false);
        virtualCamera.m_Lens.OrthographicSize = 6;
    }
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInterationZone = true;
            virtualCamera.m_Lens.OrthographicSize = 4;
            canvasPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInterationZone = false;
            virtualCamera.m_Lens.OrthographicSize = 6;
            canvasPanel.SetActive(false);
            canvasText.SetActive(false);
            canvasText2.SetActive(false);
        }
    }

    public void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (insideInterationZone)
        {
            canvasText.SetActive(true);
            Item.SetActive(true);
        }
        if (insideInterationZone && VariableHolder.pinkItem && VariableHolder.pinkNpc)
        {
            canvasText2.SetActive(true);
            VariableHolder.pinkQuest = true;
        }
        if (insideInterationZone && VariableHolder.redItem && VariableHolder.redNpc)
        {
            canvasText2.SetActive(true);
            VariableHolder.redQuest = true;
        }
    }
}
