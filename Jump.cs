using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    float savedSpeed;
    public float jumpPower;
    public float gravity;
    public float mouseSensitivity;
    public float tiltAngle;

    private float xRotation;

    CharacterController characterController;
    Rigidbody rb;
    Camera cam;

    public Transform groundDetection;
    public float distToGround;
    public LayerMask groundLayer;

    Vector3 velocity;

    bool isGrounded;
    bool secondJumpTriggered;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        secondJumpTriggered = false;
        savedSpeed = speed;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundDetection.position, distToGround, groundLayer);
        
        if(Input.GetButtonDown("Shift")){
            savedSpeed = savedSpeed / 2;
            speed = savedSpeed;
        }
        if(Input.GetButtonUp("Shift")){
            savedSpeed = savedSpeed * 2;
            speed = savedSpeed;
        }

        float horInput = Input.GetAxis("Horizontal") * speed * 1.2f;
        float verInput = Input.GetAxis("Vertical") * speed;
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        Vector3 axisZ = transform.rotation.eulerAngles;
        
        //camera tilt
       // if(horInput < 0){
       //     axisZ.z = tiltAngle;
       // }
       // if(horInput > 0){
       //     axisZ.z -= tiltAngle;
        //}
        //if(horInput == 0){
        //   axisZ.z = 0;
        //}

        //player movement
        Vector3 move = transform.right * horInput + transform.forward * verInput;
        characterController.Move(move * Time.deltaTime);
        
        //mouselook
        xRotation -= mouseY * mouseSensitivity * Time.deltaTime;
        xRotation =Mathf.Clamp(xRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, axisZ.z);

        //jumping/ground detection
        if (isGrounded){
            secondJumpTriggered = false;
            speed = savedSpeed;
            if (velocity.y < 0){
                    velocity.y = -4f;
                }
        }
        else{
            
        }
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
            
            if (characterController.velocity != Vector3.zero){
            Vector3 moveAir = transform.forward * speed;
            characterController.Move(moveAir * Time.deltaTime);
            }
        }
        if (Input.GetButtonDown("Fire1") && isGrounded == false && secondJumpTriggered == false){
            velocity.y = Mathf.Sqrt(jumpPower * -4f * gravity);
            secondJumpTriggered = true;
        }

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        

        
    }

    }