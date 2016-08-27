using UnityEngine;
using System.Collections;

public class FollowTargetPlayer : MonoBehaviour {

    public Transform target;
    public float speed = 0.5f;

    void Start () {
	}
	
	void Update () {
	}

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
    }
}
