using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip MainTheme;
    [SerializeField] private List<AudioClip> NPCSongs;

    private int counter = 0;
    private int counter2 = 0;
    private int counter3 = 0;
    private int counter4 = 0;
    private int counter5 = 0;
    private int counter6 = 0;

    void Start()
    {
        if (!audioSource.isPlaying)
        {
            StartCoroutine(LoopMainMusic());
        }
    }

    private void Update()
    {
       //NPCMusic();
    }


    IEnumerator LoopMainMusic()
    {
        audioSource.PlayOneShot(MainTheme, 0.3f);

        yield return new WaitForSeconds(MainTheme.length + Random.Range(10f, 20f));
        StartCoroutine(LoopMainMusic());
    }

    private void NPCMusic()
    {
        if (VariableHolder.redNpc)
        {
            if (counter == 0)
            {
                audioSource.Stop();
                audioSource.clip = NPCSongs[0];
                audioSource.Play();
                counter++;
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(LoopMainMusic());
                }
            }
        }

        if (VariableHolder.blueNpc)
        {
            if (counter2 == 0)
            {
                audioSource.Stop();
                audioSource.clip = NPCSongs[2];
                audioSource.Play();
                counter2++;
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(LoopMainMusic());
                }
            }
        }

        if (VariableHolder.purpleNpc)
        {
            if (counter3 == 0)
            {
                audioSource.Stop();
                audioSource.clip = NPCSongs[4];
                audioSource.Play();
                counter3++;
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(LoopMainMusic());
                }
            }
        }

        if (VariableHolder.orangeNpc)
        {
            if (counter4 == 0)
            {
                audioSource.Stop();
                audioSource.clip = NPCSongs[4];
                audioSource.Play();
                counter4++;
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(LoopMainMusic());
                }
            }
        }

        if (VariableHolder.greenNpc)
        {
            if (counter5 == 0)
            {
                audioSource.Stop();
                audioSource.clip = NPCSongs[1];
                audioSource.Play();
                counter5++;
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(LoopMainMusic());
                }
            }
        }

        if (VariableHolder.greenNpc2)
        {
            if (counter6 == 0)
            {
                audioSource.Stop();
                audioSource.clip = NPCSongs[3];
                audioSource.Play();
                counter6++;
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(LoopMainMusic());
                }
            }
        }
    }

    //Tema 2: Para a estudante menina(Red) - 0

    //Tema 3 - Para a idosa do gato(Green) - 1

    //Tema 4 - Para o menino criança(Blue) - 2

    //Tema 5 -  Para o idoso(Green) - 3

    //Tema 6 - Para a mulher do casal(Purple and Orange) - 4

}
