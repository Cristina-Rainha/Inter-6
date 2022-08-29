using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvas;

    bool insideInterationZone;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && insideInterationZone)
        {
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionZone"))
        {
            insideInterationZone = true;
            virtualCamera.m_Lens.OrthographicSize = 4;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractionZone"))
        {
            insideInterationZone = false;
            virtualCamera.m_Lens.OrthographicSize = 6;
            canvas.SetActive(false);
        }
    }
}
