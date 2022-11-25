using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> TextBoxes;
    [SerializeField] private float delayOnText1;

    private PlayerInputSystem mInputSystem;
    private InputAction interaction;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += NextText;
    }

    void OnDisable()
    {
        interaction.Disable();
    }

    private void Start()
    {
       //StartCoroutine(InicialDialog());
    }

    private void NextText(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (TextBoxes[0].activeSelf)
            {
                TextBoxes[0].GetComponent<Animator>().SetTrigger("Close");
                StartCoroutine(SecoundDialog());
            }
            if (TextBoxes[1].activeSelf)
            {
                TextBoxes[1].GetComponent<Animator>().SetTrigger("Close");
            }
        }
    }

    IEnumerator InicialDialog()
    {
        yield return new WaitForSeconds(delayOnText1);
        TextBoxes[0].SetActive(true);
    }

    IEnumerator SecoundDialog()
    {
        yield return new WaitForSeconds(0.1f);
        TextBoxes[1].SetActive(true);
    }

}
