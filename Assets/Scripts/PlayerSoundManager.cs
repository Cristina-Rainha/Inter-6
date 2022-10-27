using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> footstepSounds;
    [SerializeField] private List<AudioClip> run;
    [SerializeField] private List<AudioClip> footstepSoundsWater;
    [SerializeField] private List<AudioClip> runWater;
    
    private AudioSource audioSource;
    private bool onWater = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Step(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight >= 0.5f)
        {
            if (!onWater)
            {
                AudioClip clip = GetRandomClip();
                audioSource.volume = 0.09f;
                audioSource.PlayOneShot(clip);
            }
            else
            {
                AudioClip clip = GetRandomClipWater();
                audioSource.volume = 0.09f;
                audioSource.PlayOneShot(clip);
            }
        }
        if (animationEvent.animatorClipInfo.weight >= 1f)
        {
           if(!onWater)
            {
                AudioClip clip = GetRandomClipRun();
                audioSource.volume = 0.01f;
                audioSource.PlayOneShot(clip);
            }
            else
            {
                AudioClip clip = GetRandomClipRunWater();
                audioSource.volume = 0.01f;
                audioSource.PlayOneShot(clip);
            }
        }
    }
    private AudioClip GetRandomClip()
    {
        return footstepSounds[Random.Range(0, footstepSounds.Count)];
    }

    private AudioClip GetRandomClipRun()
    {
        return run[Random.Range(0, run.Count)];
    }

    private AudioClip GetRandomClipWater()
    {
        return footstepSoundsWater[Random.Range(0, footstepSoundsWater.Count)];
    }

    private AudioClip GetRandomClipRunWater()
    {
        return runWater[Random.Range(0, runWater.Count)];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            onWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water"))
        {
            onWater = false;
        }
    }

}
