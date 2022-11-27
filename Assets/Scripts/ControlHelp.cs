using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHelp : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private int timeToGoDissolve;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(CloseHelp());
    }

    IEnumerator CloseHelp()
    {
        yield return new WaitForSeconds(timeToGoDissolve);
        anim.SetTrigger("Dissolve");
    }
}
