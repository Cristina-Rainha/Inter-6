using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    private PlayerInputSystem mInputSystem;
    private InputAction interaction;
    private Animator anim;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        interaction = mInputSystem.Interact.Use;
        interaction.Enable();
        interaction.performed += CloseTutorial;
    }

    void OnDisable()
    {
        interaction.Disable();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void CloseTutorial(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            anim.SetTrigger("Close");
        }
    }

    public void PauseGame()
    {
        //Time.timeScale = 0;
    }

    public void DestroyTutorial()
    {
       //Time.timeScale = 1;
        Destroy(gameObject);
    }
}
