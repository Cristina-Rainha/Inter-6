using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NpcGreen : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject canvasText;
    [SerializeField] private GameObject canvasText2;
    [SerializeField] private GameObject Item;

    //bool
    bool insideInterationZone;

    //Input Action
    private PlayerInputSystem mInputSystem;
    private InputAction InteractInput;

    NavMeshAgent agent;

    [SerializeField] private List<Transform> waypoints;

    private int currentWaypoint;
    private float waitTime = 0.5f;

    private Vector3 target;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }
    private void OnEnable()
    {
        InteractInput = mInputSystem.Player.Use;
        InteractInput.Enable();
        InteractInput.performed += OpenTextBox;
    }
    private void OnDisable()
    {
        InteractInput.Disable();
        canvasText.SetActive(false);
        canvasText2.SetActive(false);
        virtualCamera.m_Lens.OrthographicSize = 6;
    }
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInterationZone = true;
            virtualCamera.m_Lens.OrthographicSize = 4;
            canvasPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInterationZone = false;
            virtualCamera.m_Lens.OrthographicSize = 6;
            canvasPanel.SetActive(false);
            canvasText.SetActive(false);
            canvasText2.SetActive(false);
        }
    }

    public void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (insideInterationZone)
        {
            canvasText.SetActive(true);
            if (VariableHolder.greenItem == false)
            {
                Item.SetActive(true);
                VariableHolder.greenNpc = true;
            }
        }

        if (insideInterationZone && VariableHolder.greenItem == true)
        {
            canvasText2.SetActive(true);
            StartCoroutine("GoAway");
            VariableHolder.greenQuest = true;
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
