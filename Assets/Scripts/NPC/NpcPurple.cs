using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NpcPurple : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject canvasText;
    [SerializeField] private GameObject canvasText2;
    [SerializeField] private GameObject Item;

    //bool
    bool insideInteractionZone;
    bool text;

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
        VariableHolder.Instance.CamZoom();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInteractionZone = true;
            if (!VariableHolder.purpleQuest)
            {
                canvasPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInteractionZone = false;
            canvasPanel.SetActive(false);
        }
    }

    public void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (insideInteractionZone && !VariableHolder.purpleItem && !text)
        {
            canvasText.SetActive(true);
            Item.SetActive(true);
            StartCoroutine(DisableText());
        }
        if (insideInteractionZone && VariableHolder.purpleItem && !text)
        {
            canvasText2.SetActive(true);
            StartCoroutine(DisableText());
        }

        if (text)
        {
            if (insideInteractionZone && !VariableHolder.purpleItem || !insideInteractionZone && !VariableHolder.purpleItem)
            {
                canvasText.SetActive(false);
            }
            if (insideInteractionZone && VariableHolder.purpleItem || !insideInteractionZone && VariableHolder.purpleItem)
            {
                canvasText2.SetActive(false);
                canvasPanel.SetActive(false);
                StartCoroutine(GoAway());
                VariableHolder.purpleQuest = true;
            }
            text = false;
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
    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(1f);
        text = true;
    }
}
