using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    //private
    private CharacterController myController;
    private Animator myAnimator;
    private float mSpeedY = 0;
    private float mGravity = -9.81f;

    //Serialized
    [SerializeField] private Camera myCamera;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject HUD;

    //bool
    private bool mSprinting = false;
    private bool mJumping = false;

    [Header("Player Move Values")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float desiredRotation = 0f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float jumpForce = 1f;
    
    [Header("Player Animation")]
    [SerializeField] private float disiredAnimationSpeed = 0f;
    [SerializeField] private float AnimationBlendSpeed = 2f;

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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && myController.isGrounded)
        {
            mJumping = true;
            myAnimator.SetTrigger("Jump");
            mSpeedY += jumpForce;
        }
        if (!myController.isGrounded)
        {
            mSpeedY += mGravity * Time.deltaTime;   
        }
        else if(mSpeedY < 0)
        {
            mSpeedY = 0;
        }
        myAnimator.SetFloat("SpeedY",mSpeedY / jumpForce);

        if (mJumping && mSpeedY < 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Ground")))
            {
                mJumping = false;
                myAnimator.SetTrigger("Land");
            }
        }

        mSprinting = Input.GetKey(KeyCode.LeftShift);
        
        Vector3 movement = new Vector3(x, 0, z).normalized;
        Vector3 rotatedMovement = Quaternion.Euler(0, myCamera.transform.rotation.eulerAngles.y, 0) * movement;
        Vector3 verticalMovement = Vector3.up * mSpeedY;

        myController.Move((verticalMovement +(rotatedMovement * (mSprinting ? sprintSpeed : moveSpeed))) * Time.deltaTime);

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (cam.activeSelf)
            {
                cam.SetActive(false);
                body.SetActive(false);
                HUD.SetActive(true);
            }
            else
            {
                cam.SetActive(true);
                body.SetActive(true);
                HUD.SetActive(false);
            }
        }
    }
}
