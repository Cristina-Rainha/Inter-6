using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;

    void Update()
    {
        ItemVerification();
    }

    private void ItemVerification()
    {
        if (VariableHolder.greenItem == true)
        {
            items[0].SetActive(true);
        }

        if (VariableHolder.testItem == true)
        {
            items[6].SetActive(true);
        }

        if (VariableHolder.redItem == true)
        {
            items[3].SetActive(true);
        }

        if (VariableHolder.blueItem == true)
        {
            items[1].SetActive(true);
        }

        if (VariableHolder.purpleItem == true)
        {
            items[2].SetActive(true);
        }

        if (VariableHolder.orangeItem == true)
        {
            items[5].SetActive(true);
        }

        if (VariableHolder.greenItem2 == true)
        {
            items[4].SetActive(true);
        }

        if(VariableHolder.greenQuest)
        {
            items[0].SetActive(false);
            items[6].SetActive(false);
        }

        if (VariableHolder.redQuest)
        {
            items[3].SetActive(false);
        }

        if (VariableHolder.blueQuest)
        {
            items[1].SetActive(false);
        }

        if (VariableHolder.purpleQuest)
        {
            items[2].SetActive(false);
        }

        if (VariableHolder.orangeQuest)
        {
            items[5].SetActive(false);
        }

        if (VariableHolder.greenQuest2)
        {
            items[4].SetActive(false);
        }
    }
}
