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
    public bool isMoving = false;
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
        OnMovement();

        gameObject.GetComponent<CharacterController>().Move(new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime);
    }

    void LateUpdate()
    {
        // applying gravity
        ySpeed -= gravity;

        // terminal velocity
        if (ySpeed < -gravity)
        {
            ySpeed = -gravity;
        }
        
        // capping max speed
        if(xSpeed > maxSpeed) {
            xSpeed = maxSpeed;
        } else if(xSpeed < -maxSpeed) {
            xSpeed = -maxSpeed;
        }

        // applying drag
        if (isGrounded)
        {
            ApplyDrag(drag);
        }
        else
        {
            ApplyDrag(dragAir);
        }
    }

    public void OnMovement()
    {
        float movement = movementInput.ReadValue<float>();

        if (movement != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        xSpeed += movement * speed;
        Debug.Log("Movement: " + xSpeed);
    }

    public void ApplyDrag(float drag)
    {
        if (isMoving)
        {
            return;
        }

        // applying drag
        bool isNegativeDrag = xSpeed < 0;
        xSpeed = Mathf.Abs(xSpeed);
        xSpeed *= drag;
        xSpeed = isNegativeDrag ? -xSpeed : xSpeed;

        if (xSpeed < dragThreshold && xSpeed > -dragThreshold) {
            xSpeed = 0.0f;
        }
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
