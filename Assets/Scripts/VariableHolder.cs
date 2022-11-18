using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VariableHolder : MonoBehaviour
{
    //bool
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

    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public static VariableHolder Instance;

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
    private void Update()
    {
        EndGame();
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

    private void EndGame()
    {
        if (greenQuest && greenQuest2 && redQuest && blueQuest && purpleQuest && orangeQuest)
        {
            Debug.Log("End is on");
        }
    }
}
