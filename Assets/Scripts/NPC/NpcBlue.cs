using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class NpcBlue : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private List<GameObject> canvasText;
    [SerializeField] private Collider npcCollider;
    [SerializeField] private Animator iconanim;
    [SerializeField] private GameObject Item;

    private int index = 0;
    private Animator animator;
    
    //bool
    bool insideInteractionZone;
    bool text;

    //Input Action
    private PlayerInputSystem mInputSystem;
    private InputAction InteractInput;

    //IA
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
            //GetNextWaypoint();
            //UpdateDestination();
        }
        VariableHolder.Instance.CamZoom();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInteractionZone = true;
            if (!VariableHolder.blueQuest)
            {
                canvasPanel.SetActive(true);
                index = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideInteractionZone = false;
            iconanim.SetTrigger("Reset");
            index = 0;
        }
    }

    public void OpenTextBox(InputAction.CallbackContext ctx)
    {
        if (insideInteractionZone && !VariableHolder.blueItem)
        {
            if (index == 0)
            {
                canvasText[0].SetActive(true);
                Item.SetActive(true);
                VariableHolder.PlayerWave = true;
                StartCoroutine(AddIndex());
            }

            if (index == 1)
            {
                canvasText[0].GetComponent<Animator>().SetTrigger("Close");
                canvasText[1].SetActive(true);
                StartCoroutine(AddIndex());
            }
            if(index == 2)
            {
                canvasText[1].GetComponent<Animator>().SetTrigger("Close");
                StartCoroutine(ZeroIndex());
            }
        }
        
        if (insideInteractionZone && VariableHolder.blueItem)
        {
            canvasText[2].SetActive(true);
            StartCoroutine(DisableText());
        }
        
        if(insideInteractionZone && VariableHolder.blueItem && text)
        {
            canvasText[2].GetComponent<Animator>().SetTrigger("Close");
            VariableHolder.PlayerBowDown = true;
            animator.SetTrigger("Walk");
            insideInteractionZone = false;
            VariableHolder.blueNpc = false;
            VariableHolder.blueQuest = true;
            VariableHolder.Instance.AddQuestCount();
            Destroy(canvasPanel);
            npcCollider.enabled = false;
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
    IEnumerator AddIndex()
    {
        yield return new WaitForSeconds(0.4f);
        index++;
    }

    IEnumerator ZeroIndex()
    {
        yield return new WaitForSeconds(0.4f);
        index = 0;
    }
    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(0.2f);
        text = true;
    }
}
