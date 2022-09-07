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
    [SerializeField] private GameObject fireflys;
    [SerializeField] private GameObject NPC;

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
            fireflys.SetActive(true);
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
            fireflys.SetActive(false);
        }
    }

    public void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (insideInterationZone)
        {
            canvasText.SetActive(true);
        }
        if (insideInterationZone && VariableHolder.pinkItem)
        {
            canvasText2.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        NPC.SetActive(false);
    }
}
