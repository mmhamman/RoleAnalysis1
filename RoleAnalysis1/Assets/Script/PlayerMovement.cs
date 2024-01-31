using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Movement")]
    public InputAction movementInput;
    public InputAction jumpInput;
    public InputAction zipInput;
    public InputAction swingInput;

    [Header("Constants")]
    public float gravity = 9.8f;
    public float drag = 0.5f;
    public float dragAir = 0.1f;
    public float dragThreshold = 0.001f;


    [Header("Player Movement")]
    public bool isGrounded = false;
    public float speed = 5.0f;
    public float maxSpeed = 10.0f;
    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMovement(movementInput);

        gameObject.GetComponent<CharacterController>().Move(new Vector3(xSpeed, ySpeed, 0));
    }

    void LateUpdate()
    {
        ySpeed -= gravity * Time.deltaTime;

        // terminal velocity
        if (ySpeed < -gravity)
        {
            ySpeed = -gravity;
        }

        xSpeed *= drag;

        if (xSpeed < dragThreshold && xSpeed > -dragThreshold) {
            xSpeed = 0.0f;
        }
    }

    public void OnMovement(InputAction context)
    {
        float movement = context.ReadValue<float>();
        xSpeed += movement * Time.deltaTime * speed;
    }

    void OnEnable()
    {
        movementInput.Enable();
        jumpInput.Enable();
        zipInput.Enable();
        swingInput.Enable();
    }

    void OnDisable()
    {
        movementInput.Disable();
        jumpInput.Disable();
        zipInput.Disable();
        swingInput.Disable();
    }
}
