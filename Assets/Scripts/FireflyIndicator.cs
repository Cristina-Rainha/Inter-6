using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyIndicator : MonoBehaviour
{
    [SerializeField] private GameObject fireflyPink;
    [SerializeField] private GameObject fireflyRed;
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("pinkArea"))
        {
            if (VariableHolder.pinkQuest == false)
            {
                fireflyPink.SetActive(true);
                StartCoroutine(StopFireFlys());
                Debug.Log("in pink zone");
            }
        }

        if (other.CompareTag("redArea"))
        {
            if (VariableHolder.redQuest == false)
            {
                fireflyRed.SetActive(true);
                StartCoroutine(StopFireFlys());
                Debug.Log("in red zone");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pinkArea"))
        {
            fireflyPink.SetActive(false);
            Debug.Log("out pink zone");
        }

        if (other.CompareTag("redArea"))
        {
            fireflyRed.SetActive(false);
            Debug.Log("out redArea zone");
        }
    }

    IEnumerator StopFireFlys()
    {
        yield return new WaitForSeconds(6);
        fireflyPink.SetActive(false);
        fireflyRed.SetActive(false);
    }
}
