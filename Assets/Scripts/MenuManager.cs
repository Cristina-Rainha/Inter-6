using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private Button back;
    [SerializeField] private Button primarybutton;

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void Credits()
    {
        credits.SetActive(true);
        if(credits.activeSelf)
        {
            back.Select();
        }
    }
    
    public void CloseCredits()
    {
        credits.SetActive(false);
        if (credits.activeSelf == false)
        {
            primarybutton.Select();
        }
    }
    public void CloseGame()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

