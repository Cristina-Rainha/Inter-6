using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> TextBoxes;

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
                VariableHolder.playercanwalk = true;
            }
        }
    }

    public void InicialDialogueStart()
    {
        TextBoxes[0].SetActive(true);
    }

    IEnumerator SecoundDialog()
    {
        yield return new WaitForSeconds(0.1f);
        TextBoxes[1].SetActive(true);
    }

}
