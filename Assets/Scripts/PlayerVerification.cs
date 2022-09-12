using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerification : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("pink"))
        {
            VariableHolder.pinkNpc = true;
        }
        if (other.CompareTag("red"))
        {
            VariableHolder.redNpc = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pink"))
        {
            VariableHolder.pinkNpc = false;
        }
        if (other.CompareTag("red"))
        {
            VariableHolder.redNpc = false;
        }
    }
}
