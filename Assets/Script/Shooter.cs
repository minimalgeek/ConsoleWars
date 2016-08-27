using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public LayerMask floorMask;
    public float camRayLength = 1000f;
    public float rotationSpeed = 10f;

    private Rigidbody myRigidBody;
    private Quaternion newRotation = Quaternion.identity;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;
            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                newRotation = Quaternion.LookRotation(floorHit.point - transform.position);
            }
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }
}