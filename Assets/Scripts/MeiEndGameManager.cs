using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeiEndGameManager : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private GameObject endMap;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private AudioSource endGameMusic;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!endGameMusic.isPlaying)
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    public void LoadScene()
    {
        if (!endGameMusic.isPlaying)
        {
           // StartCoroutine(LoadSceneAfterDelay());
        }
    }

    public void DisableAndEnable()
    {
        endGameCanvas.SetActive(true);
        endMap.SetActive(false);
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
