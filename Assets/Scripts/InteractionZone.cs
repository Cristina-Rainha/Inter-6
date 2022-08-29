using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject canvasText;

    bool insideInterationZone;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && insideInterationZone)
        {
            canvasText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInterationZone = true;
            virtualCamera.m_Lens.OrthographicSize = 4;
            canvasPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInterationZone = false;
            virtualCamera.m_Lens.OrthographicSize = 6;
            canvasPanel.SetActive(false);
            canvasText.SetActive(false);
        }
    }
}
