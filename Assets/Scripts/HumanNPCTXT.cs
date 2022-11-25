using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanNPCTXT : MonoBehaviour
{
    [SerializeField] private GameObject TextInput;
    [SerializeField] private float TextTiming;
    [SerializeField] private List<GameObject> texts;
    [SerializeField] private List<Animator> textAnimator;
    [SerializeField] private Animator IconAnimator;
    private PlayerInputSystem mInputSystem;
    private InputAction interaction;


    private bool inRange = false;
    private int index = 0;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += OpenTextBox;
    }

    private void OnDisable()
    {
        interaction.Disable();
    }
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextInput.SetActive(true);
            inRange = true;
            index = 0;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IconAnimator.SetTrigger("Reset");
            inRange = false;
            index = 0;
        }
    }

    private void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && inRange)
        {
            if (index == 0)
            {
                texts[0].SetActive(true);
                StartCoroutine(InicialDialog());
                VariableHolder.PlayerWaveNPC = true;
            }
            if(index == 1)
            {
                textAnimator[0].SetTrigger("Close");
                texts[1].SetActive(true);
                StartCoroutine(InicialDialog());
            }
            if (index == 2)
            {
                textAnimator[1].SetTrigger("Close");
                StartCoroutine(CloseDialog());
            }
        }
    }
    public void CloseText()
    {
        gameObject.SetActive(false);
    }
    IEnumerator InicialDialog()
    {
        yield return new WaitForSeconds(TextTiming);
        index++;
    }

    IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(TextTiming);
        index = 0;
    }
}
