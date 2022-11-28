using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeiCommentSpeechless : MonoBehaviour
{
    [SerializeField] private GameObject MeiText;

    private int count = 0;
    public void ActivateMeiText()
    {
        if (count == 0)
        {
            MeiText.SetActive(true);
            count++;
            Destroy(MeiText, 3f);
        }
    }
}
