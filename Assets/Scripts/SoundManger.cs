using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip MainTheme;
    [SerializeField] private AudioClip[] clips;

    void Start()
    {
        if (!audioSource.isPlaying)
        {
            StartCoroutine(LoopMainMusic());
        }
    }
    void Update()
    {
    }

    IEnumerator LoopMainMusic()
    {
        yield return new WaitForSeconds(Random.Range(10f, 20f));
        audioSource.PlayOneShot(MainTheme, 0.3f);

        yield return new WaitForSeconds(MainTheme.length + Random.Range(10f, 20f));
        StartCoroutine(LoopMainMusic());
    }

}
