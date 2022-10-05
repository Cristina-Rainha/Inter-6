using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private List<Transform> waypoints;

    private int currentWaypoint;
    private float waitTime = 0.5f;

    private Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypoint = 0;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1f)
        {
            GetNextWaypoint();
            UpdateDestination();
        }

        if (VariableHolder.redQuest == true)
        {
            StartCoroutine("GoAway");
        }
    }

    void UpdateDestination()
    {
        target = waypoints[currentWaypoint].position;
        agent.SetDestination(target);

        if (currentWaypoint == waypoints.Count - 1)
        {
            agent.isStopped = true;
            gameObject.SetActive(false);
        }
    }

    void GetNextWaypoint()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        }
    }

    IEnumerator GoAway()
    {
        yield return new WaitForSeconds(3f);
        UpdateDestination();
    }
}
