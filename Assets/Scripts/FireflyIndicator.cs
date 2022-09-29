using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyIndicator : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireflyParticles;
    [SerializeField] private Light fireflyLight;
    [SerializeField] private Transform RedNpc;
    [SerializeField] private Transform PinkNpc;

    private bool Redarea = false;
    private bool Pinkarea = false;
    void Start()
    {
        fireflyParticles.Stop();
        fireflyLight.intensity = 1;
    }

    private void Update()
    {
        RedQuest();
        PinkQuest();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pinkArea"))
        {
            if (VariableHolder.pinkQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(255, 0, 255);
                fireflyLight.intensity = 1;
                Pinkarea = true;
            }
        }

        if (other.CompareTag("redArea"))
        {
            if (VariableHolder.redQuest == false)
            {
                var main = fireflyParticles.main;
                fireflyParticles.Play();
                main.startColor = new Color(255, 0, 0);
                fireflyLight.intensity = 1;
                Redarea = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pinkArea"))
        {
            fireflyParticles.Stop();
            Pinkarea = false;

        }

        if (other.CompareTag("redArea"))
        {
            fireflyParticles.Stop();
            Redarea = false;
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
                fireflyLight.intensity = 5;
            }
            
            if(distance < 30)
            {
                fireflyLight.intensity = 20;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }
    
    private void PinkQuest()
    {
        float distance = Vector3.Distance(PinkNpc.transform.position, transform.position);

        if (Pinkarea)
        {
            //Debug.Log("pink quest" + distance);
            if (distance < 40)
            {
                fireflyLight.intensity = 5;
            }

            if (distance < 30)
            {
                fireflyLight.intensity = 20;
            }

            if (distance < 20)
            {
                fireflyLight.intensity = 40;
            }

            if (distance < 10)
            {
                fireflyLight.intensity = 60;
            }

            if (distance < 5)
            {
                fireflyLight.intensity = 80;
            }

            if (distance < 2)
            {
                fireflyParticles.Stop();
            }
        }
    }
}
