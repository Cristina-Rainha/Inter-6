using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VariableHolder : MonoBehaviour
{
    //bool Quest
    public static bool greenItem = false;
    public static bool greenItem2 = false;
    public static bool redItem = false;
    public static bool blueItem = false;
    public static bool purpleItem = false;
    public static bool orangeItem = false;

    public static bool greenNpc = false;
    public static bool greenNpc2 = false;
    public static bool redNpc = false;
    public static bool blueNpc = false;
    public static bool purpleNpc = false;
    public static bool orangeNpc = false;

    public static bool greenQuest = false;
    public static bool greenQuest2 = false;
    public static bool redQuest = false;
    public static bool blueQuest = false;
    public static bool purpleQuest = false;
    public static bool orangeQuest = false;

    public static bool testItem = false;

    [SerializeField] private int questCountTest;
    public static int questCount = 0;
    
    //Cam
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private int near;
    [SerializeField] private int far;

    //Cam
    public static VariableHolder Instance;
    public static int NearClipPlane;
    public static int FarClipPlane;
    public static bool outside = true;

    //Player
    public static bool PlayerWave = false;
    public static bool PlayerBowDown = false;
    public static bool PlayerPickUp = false;
    public static bool PlayerWaveNPC = false;
    
    //Text
    public static bool Text1 = false;

    //EndGame
    [SerializeField] private GameObject MeiPhoto;

    //sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip audioClip2;

    //cat
    [SerializeField] private GameObject Cat;

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
        greenItem = false;
        greenItem2 = false;
        redItem = false;
        blueItem = false;
        purpleItem = false;
        orangeItem = false;

        greenNpc = false;
        greenNpc2 = false;
        redNpc = false;
        blueNpc = false;
        purpleNpc = false;
        orangeNpc = false;

        greenQuest = false;
        greenQuest2 = false;
        redQuest = false;
        blueQuest = false;
        purpleQuest = false;
        orangeQuest = false;

        testItem = false;

        outside = true;

        questCount = questCountTest;
    }

    private void Update()
    {
        EndGame();
        NearClipPlane = near;
        FarClipPlane = far;

        if (greenItem == true && testItem == true)
        {
            Cat.SetActive(false);
        }
    }

    public void CamZoom()
    {
        if (greenNpc || greenNpc2 || redNpc || blueNpc || purpleNpc || orangeNpc)
        {
            if (virtualCamera.m_Lens.OrthographicSize >= 4)
            {
                virtualCamera.m_Lens.OrthographicSize -= 0.5f * Time.deltaTime;
                if (virtualCamera.m_Lens.OrthographicSize < 4)
                {
                    virtualCamera.m_Lens.OrthographicSize = 4;
                }
            }
        }
        else
        {
            if (virtualCamera.m_Lens.OrthographicSize <= 6)
            {
                virtualCamera.m_Lens.OrthographicSize += 1f * Time.deltaTime;
                if(virtualCamera.m_Lens.OrthographicSize > 6)
                {
                    virtualCamera.m_Lens.OrthographicSize = 6;
                }
            }
        }
    }

    public void CamZoomOut()
    {
        if (virtualCamera.m_Lens.OrthographicSize <= 6)
        {
            virtualCamera.m_Lens.OrthographicSize += 1f * Time.deltaTime;
            if (virtualCamera.m_Lens.OrthographicSize > 6)
            {
                virtualCamera.m_Lens.OrthographicSize = 6;
            }
        }
    }
    private void EndGame()
    {
        if (greenQuest && greenQuest2 && redQuest && blueQuest && purpleQuest && orangeQuest)
        {
            Debug.Log("End is on");
            MeiPhoto.SetActive(true);
        }
    }

    public void AddQuestCount()
    {
        questCount++;
    }

    public void OpenTextSound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void InventorySound()
    {
        audioSource.PlayOneShot(audioClip2);
    }
}
