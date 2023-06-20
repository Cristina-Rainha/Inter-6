using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> MainTheme;
    [SerializeField] private List<AudioClip> NPCSongs;

    private int counter = 0;
    private int counter2 = 0;
    private int counter3 = 0;
    private int counter4 = 0;
    private int counter5 = 0;
    private int counter6 = 0;

    public static SoundManger Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayRandomMusic();
    }

    private void Update()
    {
       //NPCMusic();
    }

    public void Music(float value)
    {
        audioSource.volume = value;
    }
    public void Allsounds(float value)
    {
        AudioListener.volume = value;
    }
    private void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, MainTheme.Count);
        audioSource.clip = MainTheme[randomIndex];
        audioSource.Play();

        float clipLenght = audioSource.clip.length;
        Invoke("PlayRandomMusic", clipLenght);
    }

    IEnumerator LoopMainMusic()
    {
        audioSource.PlayOneShot(MainTheme[Random.Range(0, MainTheme.Count)]);
        yield return new WaitForSeconds(audioSource.clip.length + 1 / Random.Range(0.5f, 1.5f));
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
