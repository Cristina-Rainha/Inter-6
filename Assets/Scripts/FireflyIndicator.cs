using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyIndicator : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireflyParticles;
    [SerializeField] private Light fireflyLight;
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
        fireflyParticles.Stop();
        fireflyLight.intensity = 10;
    }

    private void Update()
    {
        RedQuest();
        PurpleQuest();
        BlueQuest();
        GreenQuest();
        GreenQuest2();
        OrangeQuest();

        fireflyParticles.transform.position = Vector3.Lerp(fireflyParticles.transform.position, transform.position, Time.deltaTime * 15);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("purpleArea"))
        {
            if (VariableHolder.purpleQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(120, 0, 255);
                fireflyLight.intensity = 10;
                Purplearea = true;
            }
        }

        if (other.CompareTag("redArea"))
        {
            if (VariableHolder.redQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(255, 0, 0);
                fireflyLight.intensity = 10;
                Redarea = true;
            }
        }

        if(other.CompareTag("blueArea"))
        {
            if (VariableHolder.blueQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(0, 0, 255);
                fireflyLight.intensity = 10;
            }
        }

        if (other.CompareTag("greenArea"))
        {
            if (VariableHolder.greenQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(0, 255, 0);
                fireflyLight.intensity = 10;
            }
        }

        if (other.CompareTag("greenArea2"))
        {
            if (VariableHolder.orangeQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(0, 255, 0);
                fireflyLight.intensity = 10;
            }
        }

        if (other.CompareTag("orangeArea"))
        {
            if (VariableHolder.orangeQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(255, 165, 0);
                fireflyLight.intensity = 10;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("purpleArea"))
        {
            fireflyParticles.Stop();
            Purplearea = false;

        }

        if (other.CompareTag("redArea"))
        {
            fireflyParticles.Stop();
            Redarea = false;
        }

        if (other.CompareTag("blueArea"))
        {
            fireflyParticles.Stop();
            Bluearea = false;
        }

        if (other.CompareTag("greenArea"))
        {
            fireflyParticles.Stop();
            Greenarea = false;
        }

        if (other.CompareTag("greenArea2"))
        {
            fireflyParticles.Stop();
            Greenarea2 = false;
        }

        if (other.CompareTag("orangeArea"))
        {
            fireflyParticles.Stop();
            Orangearea = false;
        }
    }
    private void RedQuest()
    {
        float distance = Vector3.Distance(RedNpc.transform.position, transform.position);
        if (Redarea)
        {
            //Debug.Log("red quest" + distance);
            if(distance < 40)
            {
                fireflyLight.intensity = 10;
            }
            
            if(distance < 30)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 100;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }
    
    private void PurpleQuest()
    {
        float distance = Vector3.Distance(PurpleNpc.transform.position, transform.position);

        if (Purplearea)
        {
            //Debug.Log("pink quest" + distance);
            if (distance < 40)
            {
                fireflyLight.intensity = 10;
            }

            if (distance < 30)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 100;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }

    private void BlueQuest()
    {
        float distance = Vector3.Distance(BlueNpc.transform.position, transform.position);

        if (Bluearea)
        {
            //Debug.Log("blue quest" + distance);
            if (distance < 40)
            {
                fireflyLight.intensity = 10;
            }

            if (distance < 30)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 100;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }
    
    private void GreenQuest()
    {
        float distance = Vector3.Distance(GreenNpc.transform.position, transform.position);

        if (Greenarea)
        {
            //Debug.Log("green quest" + distance);
            if (distance < 40)
            {
                fireflyLight.intensity = 10;
            }

            if (distance < 30)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 100;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }

    private void GreenQuest2()
    {
        float distance = Vector3.Distance(GreenNpc2.transform.position, transform.position);

        if (Greenarea2)
        {
            //Debug.Log("green quest2" + distance);
            if (distance < 40)
            {
                fireflyLight.intensity = 10;
            }

            if (distance < 30)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 100;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }

    private void OrangeQuest()
    {
        float distance = Vector3.Distance(OrangeNpc.transform.position, transform.position);

        if (Orangearea)
        {
            //Debug.Log("orange quest" + distance);
            if (distance < 40)
            {
                fireflyLight.intensity = 10;
            }

            if (distance < 30)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 100;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }
}

