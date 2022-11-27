using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayOnObj : MonoBehaviour
{
    [SerializeField] private GameObject objToSetActive;
    
    void Start()
    {
    }

    public void ActivateObj()
    {
        objToSetActive.SetActive(true);

    }

    public void DeactivateObj()
    {
        gameObject.SetActive(false);
    }
}
