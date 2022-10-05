using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableHolder : MonoBehaviour
{
    //bool
    public static bool pinkItem = false;
    public static bool blueItem = false;
    public static bool greenItem = false;
    public static bool yellowItem = false;
    public static bool redItem = false;

    public static bool pinkNpc = false;
    public static bool blueNpc = false;
    public static bool greenNpc = false;
    public static bool yellowNpc = false;
    public static bool redNpc = false;

    public static bool pinkQuest = false;
    public static bool blueQuest = false;
    public static bool greenQuest = false;
    public static bool yellowQuest = false;
    public static bool redQuest = false;


    void Start()
    {
        pinkItem = false;
        blueItem = false;
        greenItem = false;
        yellowItem = false;
        redItem = false;

        pinkNpc = false;
        blueNpc = false;
        greenNpc = false;
        yellowNpc = false;
        redNpc = false;

        pinkQuest = false;
        blueQuest = false;
        greenQuest = false;
        yellowQuest = false;
        redQuest = false;
        
    }
    private void Update()
    {
    }
}
