using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    }

    void OnDisable()
    {
        interaction.Disable();
    }

    private void Start()
    {
        //StartCoroutine(InicialDialog());
    }

    IEnumerator InicialDialog()
    {
        yield return new WaitForSeconds(delayOnText1);
        TextBoxes[0].SetActive(true);
    }

}
