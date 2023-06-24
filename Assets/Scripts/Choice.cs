using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    [SerializeField] private Button primarybutton;
    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    void Start()
    {
        primarybutton.Select();
    }
}
