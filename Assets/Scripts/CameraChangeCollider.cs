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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "null")
        {
            if(cam1.activeSelf)
            { 
                cam1.SetActive(false);
                cam2.SetActive(true);
                myCamera.orthographic = false;
            }
            else
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
                myCamera.orthographic = true;
                virtualCamera.m_Lens.NearClipPlane = -1000;
                virtualCamera.m_Lens.FarClipPlane = 5000;
            }
        }
    }//not in use

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
        virtualCamera.m_Lens.NearClipPlane = -1000;
        virtualCamera.m_Lens.FarClipPlane = 5000;
    }
}
