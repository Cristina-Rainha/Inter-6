using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
