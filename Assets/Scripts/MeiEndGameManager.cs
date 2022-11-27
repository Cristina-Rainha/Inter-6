using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeiEndGameManager : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private GameObject endMap;
    [SerializeField] private GameObject endGameCanvas;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadScene()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    public void DisableAndEnable()
    {
        endGameCanvas.SetActive(true);
        endMap.SetActive(false);
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneToLoad);
    }
}
