using UnityEngine;
using System.Collections;
using Assets.Script;

public class Shooter : MonoBehaviour
{
    public LayerMask floorMask;
    public float camRayLength = 1000f;
    public float rotationSpeed = 10f;

    public GameObject grenade;
    public Transform initPosition;
    public float throwForce = 10f;

    private Rigidbody myRigidBody;
    private Quaternion newRotation = Quaternion.identity;
    private Vector3 toThrowAtForce;
    private GameObject player;
    private Animator myAnimator;
        
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
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
                toThrowAtForce = floorHit.point - transform.position;
                myAnimator.SetTrigger(Constants.PLAYER_ANIM_THROW);
            }
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }

    public void Shoot()
    {
        GameObject newGO = Instantiate(grenade);
        newGO.transform.position = initPosition.position;
        newGO.transform.localRotation = player.transform.rotation;

        newGO.GetComponent<Rigidbody>().AddForce(
            new Vector3(toThrowAtForce.x/2, throwForce, toThrowAtForce.z/2), 
            ForceMode.Impulse);
        newGO.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0f, throwForce), Random.Range(0f, throwForce), Random.Range(0f, throwForce)));
    }
}