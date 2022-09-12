using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //private
    private CharacterController myController;
    private Animator myAnimator;
    private Vector3 moveDirection;
    private float mSpeedY = 0;
    private float mGravity = -9.81f;

    //Serialized
    [SerializeField] private Camera myCamera;
    [SerializeField] LayerMask groundLayer;

    //bool
    private bool mSprinting = false;
    private bool mJumping = false;

    //InputSystem
    private PlayerInputSystem mInputSystem;
    private InputAction MoveInput;
    private InputAction JumpInput;
    private InputAction Sprintinput;
    private InputAction UseInput;
    private InputAction DanceInput;

    [Header("Player Move Values")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float desiredRotation = 0f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float jumpForce = 1f;

    [Header("Player Animation")]
    [SerializeField] private float disiredAnimationSpeed = 0f;
    [SerializeField] private float AnimationBlendSpeed = 2f;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    private void OnEnable()
    {
        MoveInput = mInputSystem.Player.Move;
        MoveInput.Enable();

        JumpInput = mInputSystem.Player.Jump;
        //JumpInput.Enable();
        JumpInput.performed += ctx => mJumping = true;
        JumpInput.canceled += ctx => mJumping = false;

        Sprintinput = mInputSystem.Player.Sprint;
        Sprintinput.Enable();
        Sprintinput.performed += ctx => mSprinting = true;
        Sprintinput.canceled += ctx => mSprinting = false;

        UseInput = mInputSystem.Player.Use;
        UseInput.Enable();
        UseInput.performed += CollectItem;

        DanceInput = mInputSystem.Player.Dance;
        DanceInput.Enable();
        DanceInput.performed += DanceFortinitro;
    }

    private void OnDisable()
    {
        MoveInput.Disable();
        JumpInput.Disable();
        Sprintinput.Disable();
        UseInput.Disable();
        DanceInput.Disable();
    }

    void Start()
    {
        myController = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       Movemente();
    }

    private void Movemente()
    {
        moveDirection = new Vector3(MoveInput.ReadValue<Vector2>().x, 0, MoveInput.ReadValue<Vector2>().y);

        if (mJumping && myController.isGrounded)
        {
            myAnimator.SetTrigger("Jump");
            mSpeedY += jumpForce;
        }
        if (!myController.isGrounded)
        {
            mSpeedY += mGravity * Time.deltaTime;
        }
        else if (mSpeedY < 0)
        {
            mSpeedY = 0;
        }
        myAnimator.SetFloat("SpeedY", mSpeedY / jumpForce);

        if (!mJumping && mSpeedY < 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, groundLayer))
            {
                myAnimator.SetTrigger("Land");
                mJumping = false;
            }
            Debug.DrawRay(transform.position, Vector3.down, Color.yellow, 1f);
        }
        
        Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.z).normalized;
        Vector3 rotatedMovement = Quaternion.Euler(0, myCamera.transform.rotation.eulerAngles.y, 0) * movement;
        Vector3 verticalMovement = Vector3.up * mSpeedY;

        myController.Move((verticalMovement + (rotatedMovement * (mSprinting ? sprintSpeed : moveSpeed))) * Time.deltaTime);

        if (rotatedMovement.magnitude > 0)
        {
            desiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            disiredAnimationSpeed = mSprinting ? 1 : 0.5f;
        }
        else
        {
            disiredAnimationSpeed = 0f;
        }

        myAnimator.SetFloat("Speed", Mathf.Lerp(myAnimator.GetFloat("Speed"), disiredAnimationSpeed, AnimationBlendSpeed * Time.deltaTime));

        Quaternion currentRotation = transform.rotation;
        Quaternion TargetRotation = Quaternion.Euler(0, desiredRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, TargetRotation, rotationSpeed * Time.deltaTime);
    }
    
    private void DanceFortinitro(InputAction.CallbackContext ctx)
    {
        myAnimator.SetTrigger("Fortnitro");
    }

    private void CollectItem(InputAction.CallbackContext ctx)
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pink"))
        {
            VariableHolder.pinkNpc = true;
        }
        if (other.CompareTag("red"))
        {
            VariableHolder.redNpc = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pink"))
        {
            VariableHolder.pinkNpc = false;
        }
        if (other.CompareTag("red"))
        {
            VariableHolder.redNpc = false;
        }
    }
}
