using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MeiUse : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject icon;
    [SerializeField] private Animator iconAnim;

    private PlayerInputSystem mInputSystem;
    private InputAction interaction;

    private bool canshow = false;

    //End
    [SerializeField]private bool MeiEndGame = false;
    [SerializeField] private int LevelNumber;
    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += OpenTextBox;
        interaction.performed += PhotoEndGame;
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
                if (Text.activeSelf)
                {
                    Text.SetActive(false);
                }
                else
                {
                    Text.SetActive(true);
                }
            }
        }
    }

    private void PhotoEndGame(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (MeiEndGame)
            {
                Text.SetActive(true);
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(LevelNumber);
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
