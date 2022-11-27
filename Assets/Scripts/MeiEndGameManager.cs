using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeiEndGameManager : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
