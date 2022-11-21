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
    [SerializeField] private GameObject canvasText3;
    [SerializeField] private GameObject Item;
    [SerializeField] private GameObject Item2;

    private Animator animator;

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
        canvasText3.SetActive(false);
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypoint = 0;
        animator = GetComponent<Animator>();
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
            if (!VariableHolder.greenQuest)
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
        if (insideInteractionZone && VariableHolder.greenItem == false && VariableHolder.testItem == false && !text)
        {
            canvasText.SetActive(true);
            Item.SetActive(true);
            Item2.SetActive(true);
            StartCoroutine(Wait());
        }

        if (insideInteractionZone && VariableHolder.greenItem == true || insideInteractionZone && VariableHolder.testItem == true)
        {
            canvasText2.SetActive(true);
            StartCoroutine(Wait());
        }

        if (insideInteractionZone && VariableHolder.greenItem == true && VariableHolder.testItem == true)
        {
            canvasText3.SetActive(true);
            StartCoroutine(Wait());
        }

        if (text)
        {
            if (insideInteractionZone && !VariableHolder.greenItem && !VariableHolder.testItem || !insideInteractionZone && !VariableHolder.greenItem && !VariableHolder.testItem)
            {
                canvasText.SetActive(false);
            }
            if (insideInteractionZone && VariableHolder.greenItem == true || insideInteractionZone && VariableHolder.testItem == true || !insideInteractionZone && VariableHolder.greenItem == true || !insideInteractionZone && VariableHolder.testItem == true)
            {
                canvasText2.SetActive(false);
            }
            if (insideInteractionZone && VariableHolder.greenItem == true && VariableHolder.testItem == true || !insideInteractionZone && VariableHolder.greenItem == true && VariableHolder.testItem == true)
            {
                canvasText3.SetActive(false);
                canvasPanel.SetActive(false);
                StartCoroutine("GoAway");
                VariableHolder.greenQuest = true;
            }
            text = false;
        }
    }

    void UpdateDestination()
    {
        animator.SetTrigger("Walk");
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        text = true;
    }
}
