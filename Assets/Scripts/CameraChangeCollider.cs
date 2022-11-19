using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChangeCollider : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float camChangeTime = 0.5f;

    private void Start()
    {
        cam2.SetActive(false);
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(InsideCam());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(OutsideCam());
        }
    }

    IEnumerator InsideCam()
    {
        yield return new WaitForSeconds(camChangeTime);
        cam1.SetActive(false);
        cam2.SetActive(true);
        myCamera.orthographic = false;
    }

    IEnumerator OutsideCam()
    {
        yield return new WaitForSeconds(camChangeTime);
        cam1.SetActive(true);
        cam2.SetActive(false);
        myCamera.orthographic = true;
        virtualCamera.m_Lens.NearClipPlane = VariableHolder.NearClipPlane;
        virtualCamera.m_Lens.FarClipPlane = VariableHolder.FarClipPlane;
    }
}
