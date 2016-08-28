using UnityEngine;
using System.Collections;
using Assets.Script;

public class EnemyFollow : MonoBehaviour {

    private Transform target;
    public float speed = 3.0f;
    public float rotationSpeed = 10f;
    private Vector3 velocity = Vector3.zero;

    void Start () {
        target = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).transform;
	}
	
	void Update () {
	}

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, speed);
        Quaternion newRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }
}
