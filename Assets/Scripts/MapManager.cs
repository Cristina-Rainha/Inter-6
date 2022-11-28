using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMap;
    [SerializeField] private GameObject icon;
    [SerializeField] private Animator iconAnim;
    [SerializeField] private AudioClip audioClip;

    private Animator animator;

    private AudioSource audioSource;
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
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnRange = false;
            iconAnim.SetTrigger("Reset");
        }
    }

    void OpenMap(InputAction.CallbackContext context)
    {
        if (playerOnRange)
        {
            if (pauseMap.activeSelf == false)
            {
                pauseMap.SetActive(true);
                audioSource.PlayOneShot(audioClip);
            }
            else
            {
                animator.SetTrigger("Close");
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
