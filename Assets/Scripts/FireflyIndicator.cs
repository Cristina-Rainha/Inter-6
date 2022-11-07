using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyIndicator : MonoBehaviour
{
    [SerializeField] private GameObject Navi;
    [SerializeField] private Light fireflyLight;
    [SerializeField] private Material fireflyMaterial;
    [SerializeField] private List<Color> fireflyColors;
    [SerializeField] private List<float> lightIntensity;
    [SerializeField] private Transform RedNpc;
    [SerializeField] private Transform PurpleNpc;
    [SerializeField] private Transform BlueNpc;
    [SerializeField] private Transform GreenNpc;
    [SerializeField] private Transform GreenNpc2;
    [SerializeField] private Transform OrangeNpc;

    private bool Redarea = false;
    private bool Purplearea = false;
    private bool Bluearea = false;
    private bool Greenarea = false;
    private bool Greenarea2 = false;
    private bool Orangearea = false;

    void Start()
    {
        Navi.SetActive(false);
        fireflyLight.intensity = 0.5f;
    }

    private void Update()
    {
        RedQuest();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("purpleArea"))
        {
            if (VariableHolder.purpleQuest == false)
            {
                Navi.SetActive(true);
                fireflyLight.color = fireflyColors[4];
                fireflyMaterial.color = fireflyColors[4];
                fireflyLight.intensity = lightIntensity[0];
                Purplearea = true;
            }
        }

        if (other.CompareTag("redArea"))
        {
            if (VariableHolder.redQuest == false)
            {
                Navi.SetActive(true);
                fireflyLight.color = fireflyColors[0];
                fireflyMaterial.color = fireflyColors[0];
                fireflyLight.intensity = lightIntensity[0];
                Redarea = true;
            }
        }

        if(other.CompareTag("blueArea"))
        {
            if (VariableHolder.blueQuest == false)
            {
                Navi.SetActive(true);
                fireflyLight.color = fireflyColors[2];
                fireflyMaterial.color = fireflyColors[2];
                fireflyLight.intensity = lightIntensity[0];
                Bluearea = true;
            }
        }

        if (other.CompareTag("greenArea"))
        {
            if (VariableHolder.greenQuest == false)
            {
                Navi.SetActive(true);
                fireflyLight.color = fireflyColors[1];
                fireflyMaterial.color = fireflyColors[1];
                fireflyLight.intensity = lightIntensity[0];
                Greenarea = true;
            }
        }

        if (other.CompareTag("greenArea2"))
        {
            if (VariableHolder.orangeQuest == false)
            {
                Navi.SetActive(true);
                fireflyLight.color = fireflyColors[1];
                fireflyMaterial.color = fireflyColors[1];
                fireflyLight.intensity = lightIntensity[0];
                Greenarea2 = true;
            }
        }

        if (other.CompareTag("orangeArea"))
        {
            if (VariableHolder.orangeQuest == false)
            {
                Navi.SetActive(true);
                fireflyLight.color = fireflyColors[3];
                fireflyMaterial.color = fireflyColors[3];
                fireflyLight.intensity = lightIntensity[0];
                Orangearea = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("purpleArea"))
        {
            Navi.SetActive(false);
        }

        if (other.CompareTag("redArea"))
        {
            Navi.SetActive(false);
        }

        if (other.CompareTag("blueArea"))
        {
            Navi.SetActive(false);
        }

        if (other.CompareTag("greenArea"))
        {
            Navi.SetActive(false);
        }

        if (other.CompareTag("greenArea2"))
        {
            Navi.SetActive(false);
        }

        if (other.CompareTag("orangeArea"))
        {
            Navi.SetActive(false);
        }
    }

    private void RedQuest()
    {
        float distance = Vector3.Distance(RedNpc.transform.position, transform.position);
        if (Redarea)
        {
            if (distance < 40)
            {
                fireflyLight.intensity = lightIntensity[0];
            }

            if (distance < 30)
            {
                fireflyLight.intensity = lightIntensity[1];
            }

            if (distance < 20)
            {
                fireflyLight.intensity = lightIntensity[2];
            }

            if (distance < 10)
            {
                fireflyLight.intensity = lightIntensity[3];
            }

            if (distance < 5)
            {
                fireflyLight.intensity = lightIntensity[4];
            }

            if (distance < 2)
            {
                Navi.SetActive(false);
            }
        }
    }
}


