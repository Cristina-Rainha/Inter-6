using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagIcon : MonoBehaviour
{
    [SerializeField] private Animator inventoryIconAnimator;
    public void InvenIconAnim()
    {
        gameObject.SetActive(false);
    }
}
