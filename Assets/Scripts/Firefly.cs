using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    [SerializeField] private GameObject Fireflytutorial;

    bool canShow = true;
    private void OnEnable()
    {
        if (canShow)
        {
            Fireflytutorial.SetActive(true);
            canShow = false;
        }
    }
}
