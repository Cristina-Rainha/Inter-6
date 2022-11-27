using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            tutorial.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
