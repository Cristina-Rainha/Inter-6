using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NpcGreen2 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private List<GameObject> canvasText;
    [SerializeField] private GameObject Item;
    [SerializeField] private Collider npcCollider;
    [SerializeField] private Animator iconanim;

    private int index = 0;
    private int index2 = 3;
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
            if (!VariableHolder.greenQuest2)
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
        if (insideInteractionZone && !VariableHolder.greenItem2)
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
            if (index == 2)
            {
                canvasText[1].GetComponent<Animator>().SetTrigger("Close");
                canvasText[2].SetActive(true);
                StartCoroutine(AddIndex());
            }
            if (index == 3)
            {
                canvasText[2].GetComponent<Animator>().SetTrigger("Close");
                StartCoroutine(ZeroIndex());
            }
        }

        if (VariableHolder.questCount < 5)
        {
            if (insideInteractionZone && VariableHolder.greenItem2)
            {
                canvasText[3].SetActive(true);
                StartCoroutine(DisableText());
            }
            if (insideInteractionZone && VariableHolder.greenItem2 && text)
            {
                canvasText[3].GetComponent<Animator>().SetTrigger("Close");
                VariableHolder.PlayerBowDown = true;
                VariableHolder.playercanwalk = false;
                animator.SetTrigger("Walk");
                insideInteractionZone = false;
                VariableHolder.greenNpc2 = false;
                VariableHolder.greenQuest2 = true;
                VariableHolder.Instance.AddQuestCount();
                Destroy(canvasPanel);
                npcCollider.enabled = false;
            }
        }
        if (VariableHolder.questCount == 5)
        {
            if (insideInteractionZone && VariableHolder.greenItem2)
            {
                if(index2 == 3)
                {
                    canvasText[3].SetActive(true);
                    StartCoroutine(AddIndex2());
                }

                if (index2 == 4)
                {
                    canvasText[3].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[4].SetActive(true);
                    StartCoroutine(AddIndex2());
                }

                if (index2 == 5)
                {
                    canvasText[4].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[5].SetActive(true);
                    StartCoroutine(AddIndex2());
                }
                if (index2 == 6)
                {
                    canvasText[5].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[6].SetActive(true);
                    StartCoroutine(AddIndex2());
                }
                if (index2 == 7)
                {
                    canvasText[6].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[7].SetActive(true);
                    StartCoroutine(DisableText());
                }
            }

            if (insideInteractionZone && VariableHolder.greenItem2 && text)
            {
                canvasText[7].GetComponent<Animator>().SetTrigger("Close");
                VariableHolder.playercanwalk = false;
                VariableHolder.PlayerBowDown = true;
                animator.SetTrigger("Walk");
                insideInteractionZone = false;
                VariableHolder.greenNpc2 = false;
                VariableHolder.greenQuest2 = true;
                VariableHolder.Instance.AddQuestCount();
                VariableHolder.Instance.FireflyOff();
                Destroy(canvasPanel);
                npcCollider.enabled = false;
            }
        }
    }
    public void TurnOFFNPC()
    {
        VariableHolder.playercanwalk = true;
        gameObject.SetActive(false);
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
    IEnumerator AddIndex2()
    {
        yield return new WaitForSeconds(0.4f);
        index2++;
    }
}
