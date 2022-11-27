using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MeiPhoto : MonoBehaviour
{

    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject icon;
    [SerializeField] private Animator iconAnim;
    [SerializeField] private int SceneNum;

    private PlayerInputSystem mInputSystem;
    private InputAction interaction;

    private bool canshow = false;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += OpenTextBox;
    }

    void OnDisable()
    {
        interaction.Disable();
    }

    private void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (canshow)
            {
                Text.SetActive(true);
                StartCoroutine(LoadScene());
            }
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneNum);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canshow = true;
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canshow = false;
            iconAnim.SetTrigger("Reset");
        }
    }
}
