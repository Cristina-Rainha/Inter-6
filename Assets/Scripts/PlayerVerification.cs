using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerification : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("purple"))
        {
            VariableHolder.purpleNpc = true;
        }
        if (other.CompareTag("red"))
        {
            VariableHolder.redNpc = true;
        }

        if (other.CompareTag("blue"))
        {
            VariableHolder.blueNpc = true;
        }

        if (other.CompareTag("orange"))
        {
            VariableHolder.orangeNpc = true;
        }

        if (other.CompareTag("green"))
        {
            VariableHolder.greenNpc = true;
        }

        if (other.CompareTag("green2"))
        {
            VariableHolder.greenNpc2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("purple"))
        {
            VariableHolder.purpleNpc = false;
        }
        if (other.CompareTag("red"))
        {
            VariableHolder.redNpc = false;
        }

        if (other.CompareTag("blue"))
        {
            VariableHolder.blueNpc = false;
        }

        if (other.CompareTag("orange"))
        {
            VariableHolder.orangeNpc = false;
        }

        if (other.CompareTag("green"))
        {
            VariableHolder.greenNpc = false;
        }

        if (other.CompareTag("green2"))
        {
            VariableHolder.greenNpc2 = false;
        }
    }
}
