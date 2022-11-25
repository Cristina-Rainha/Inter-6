using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] sentences;
    private int index;
    [SerializeField] private float typingSpeed;

    [SerializeField] private float delay;
    [SerializeField] private GameObject allSound;
    [SerializeField] private GameObject IntroPanel;
    [SerializeField] private Animator animator;
    [SerializeField] private string triggerAnim;
    [SerializeField] private bool secound;
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        yield return new WaitForSeconds(1f);
        
        foreach (char letter in sentences[index].ToCharArray())
        {
            audioSource.PlayOneShot(audioSource.clip);
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (index >= sentences.Length - 1)
        {
            if(secound)
            {
                animator.SetTrigger(triggerAnim);
            }
            yield return new WaitForSeconds(delay);
            allSound.SetActive(true);    
            IntroPanel.SetActive(false);
        }
    } 
}
