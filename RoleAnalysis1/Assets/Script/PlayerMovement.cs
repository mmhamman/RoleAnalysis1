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
    public float speed = 5.0f;
    public float maxSpeed = 10.0f;
    public float maxVelocity = 1.0f;
    public float acceleration = 0.001f;
    public float deceleration = 0.1f;
    public float drag = 0.005f;
    public float dragAir = 0.1f;


    [Header("Player Movement")]
    public bool isMoving = false;
    public bool isGrounded = false;
    public bool isTurning = false;
    public float xPositionLastFrame = 0.0f; // player input NOT xSpeed
    public float velocity = 0.0f;
    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isTurning) { velocity = 0.0f; }

        OnMovement();

        // applying gravity
        ySpeed -= gravity;

        // terminal velocity
        if (ySpeed < -gravity)
        {
            ySpeed = -gravity;
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

        xSpeed *= velocity;

        gameObject.GetComponent<CharacterController>().Move(new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime);
    }

    void LateUpdate()
    {
        xPositionLastFrame = gameObject.transform.position.x;

        if (velocity < 0.01f) { velocity = 0.0f; }
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
        
        // detecting if the player is turning
        if (movement > 0 && xSpeed < 0 && velocity > 0.5f)
        {
            isTurning = true;
        }
        else if (movement < 0 && xSpeed > 0 && velocity > 0.5f)
        {
            isTurning = true;
        }
        else
        {
            isTurning = false;
        }

        xSpeed += movement * speed;

        // capping max speed
        if(xSpeed > maxSpeed) {
            xSpeed = maxSpeed;
        } else if(xSpeed < -maxSpeed) {
            xSpeed = -maxSpeed;
        }

        // rounding to 4 decimal places
        xSpeed = Mathf.Round(xSpeed * 10000f) / 10000f;
    }

    public void ApplyDrag(float drag)
    {
        if (isMoving)
        {
            velocity = Mathf.Lerp(velocity, maxVelocity, acceleration);
            return;
        }

        // decelerating velocity by applying drag
        velocity = Mathf.Lerp(velocity, 0.0f, drag);

        // applying velocity on decelleration
        xSpeed = Mathf.Lerp(xSpeed, 0.0f, deceleration);
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
