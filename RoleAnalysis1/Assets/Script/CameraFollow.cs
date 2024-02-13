using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject objectToFollow;
    public float lookAheadCap = 5f;
    public float targetX;
    public float speed = 0.1f;
    public float yOffset = 2.5f;
    public float zLock = -10;
    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (objectToFollow == null) {
            objectToFollow = FindPlayer();
            return;
        }

        // The camera should tween between -lookAheadCap and +lookAheadCap on the x-axis based on how fast the player is moving
        float xSpeed = objectToFollow.GetComponent<PlayerMovement>().xSpeed; // Get the player's xSpeed

        float deltaX = objectToFollow.GetComponent<PlayerMovement>().maxSpeed / lookAheadCap;

        targetX = xSpeed / deltaX;

        Vector3 lookAhead = new Vector3(targetX, yOffset, 0);
        Vector3 targetPosition = objectToFollow.transform.position + lookAhead;
        targetPosition.z = zLock; // Keep the camera at -10 to see the player
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, speed);
        transform.position = smoothedPosition;
    }

    public GameObject FindPlayer() {
        return GameObject.FindGameObjectsWithTag("Player")[0];
    }
}
