using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    public int value;
    private Transform localTransform;
    void Start()
    {
        localTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VariableHolder.outside)
        {
            transform.rotation = Quaternion.LookRotation(-2 * localTransform.position - cameraTransform.position);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(localTransform.position - cameraTransform.position);
        }
    }
}
