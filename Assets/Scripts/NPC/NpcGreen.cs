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
    [SerializeField] private List<GameObject> canvasText;
    [SerializeField] private Collider npcCollider;
    [SerializeField] private Animator iconanim;
    [SerializeField] private GameObject Item;
    [SerializeField] private GameObject Item2;

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
            if (!VariableHolder.greenQuest)
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
        if(insideInteractionZone && !VariableHolder.greenItem && !VariableHolder.testItem)
        {
            if(index == 0)
            {
                canvasText[0].SetActive(true);
                Item.SetActive(true);
                Item2.SetActive(true);
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
                StartCoroutine(ZeroIndex());
            }
        }

        if (insideInteractionZone && VariableHolder.greenItem && !VariableHolder.testItem || insideInteractionZone && !VariableHolder.greenItem && VariableHolder.testItem)
        {
            if (index == 0)
            {
                canvasText[2].SetActive(true);
                StartCoroutine(AddIndex());
            }
            if (index == 1)
            {
                canvasText[3].GetComponent<Animator>().SetTrigger("Close");
                StartCoroutine(ZeroIndex());
            }
        }

        if (VariableHolder.questCount < 5)
        {
            if (insideInteractionZone && VariableHolder.greenItem && VariableHolder.testItem)
            {
                if (index == 0)
                {
                    canvasText[3].SetActive(true);
                    StartCoroutine(AddIndex());
                }
                if (index == 1)
                {
                    canvasText[3].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[4].SetActive(true);
                    StartCoroutine(AddIndex());
                }
                if (index == 2)
                {
                    canvasText[4].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[5].SetActive(true);
                    StartCoroutine(AddIndex());
                }
                if (index == 3)
                {
                    canvasText[5].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[6].SetActive(true);
                    StartCoroutine(DisableText());
                }
            }
            if (insideInteractionZone && VariableHolder.greenItem && VariableHolder.testItem && text)
            {
                canvasText[6].GetComponent<Animator>().SetTrigger("Close");
                VariableHolder.playercanwalk = false;
                VariableHolder.PlayerBowDown = true;
                animator.SetTrigger("Walk");
                insideInteractionZone = false;
                VariableHolder.greenNpc = false;
                VariableHolder.greenQuest = true;
                VariableHolder.Instance.AddQuestCount();
                Destroy(canvasPanel);
                npcCollider.enabled = false;
            }
        }
        if (VariableHolder.questCount == 5)
        {
            if (insideInteractionZone && VariableHolder.greenItem && VariableHolder.testItem)
            {
                if (index2 == 3)
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
                    StartCoroutine(AddIndex2());
                }
                if (index2 == 8)
                {
                    canvasText[7].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[8].SetActive(true);
                    StartCoroutine(AddIndex2());
                }
                if (index2 == 9)
                {
                    canvasText[8].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[9].SetActive(true);
                    StartCoroutine(AddIndex2());
                }
                if (index2 == 10)
                {
                    canvasText[9].GetComponent<Animator>().SetTrigger("Close");
                    canvasText[10].SetActive(true);
                    StartCoroutine(DisableText());
                }
            }

            if (insideInteractionZone && VariableHolder.greenItem && VariableHolder.testItem && text)
            {
                canvasText[10].GetComponent<Animator>().SetTrigger("Close");
                VariableHolder.playercanwalk = false;
                VariableHolder.PlayerBowDown = true;
                animator.SetTrigger("Walk");
                insideInteractionZone = false;
                VariableHolder.greenNpc = false;
                VariableHolder.greenQuest = true;
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
