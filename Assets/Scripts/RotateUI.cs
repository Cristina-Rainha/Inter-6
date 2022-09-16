using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    private Transform localTransform;
    void Start()
    {
        localTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTransform)
        {
            localTransform.LookAt(2 * localTransform.position - cameraTransform.position);
        }
    }
}
