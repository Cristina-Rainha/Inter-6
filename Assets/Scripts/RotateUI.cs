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
            if (VariableHolder.outside)
            {
                transform.rotation = Quaternion.LookRotation(-2 * transform.position - cameraTransform.position);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
            }
        }
    }
}
