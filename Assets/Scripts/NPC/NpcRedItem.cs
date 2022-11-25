using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcRedItem : MonoBehaviour
{
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject item;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private Animator animator;

    [SerializeField] private Animator iconanim;

    //bool
    private bool inside;
    //Input Action
    private PlayerInputSystem mInputSystem;
    private InputAction InteractInput;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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
    void Update()
    {
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
            iconanim.SetTrigger("Reset");
        }
    }
    public void collect(InputAction.CallbackContext ctx)
    {
        if (inside && VariableHolder.redItem == false)
        {
            VariableHolder.redItem = true;
            VariableHolder.PlayerPickUp = true;
            animator.SetTrigger("Collect");
            canvasPanel.SetActive(false);
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        item.SetActive(false);
    }
}
