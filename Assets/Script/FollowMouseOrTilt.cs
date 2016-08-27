using UnityEngine;
using System.Collections;

public class FollowMouseOrTilt : MonoBehaviour
{
    public float speed = 3.0f;
    public LayerMask floorMask;
    public float camRayLength = 1000f;
    private Vector3 targetPosition;
    private Rigidbody myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            FollowAccelerometer();
        }
        else
        {
            FollowMouse();
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    private void FollowAccelerometer()
    {
        targetPosition = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);
        targetPosition.Normalize();
        targetPosition += transform.position;
    }

    private void FollowMouse()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;
        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            targetPosition = floorHit.point;

            // Ensure the vector is entirely along the floor plane.
            targetPosition.y = 0f;
        }
    }
}