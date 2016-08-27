using UnityEngine;
using System.Collections;
using Assets.Script;

public class EnemyFollow : MonoBehaviour {

    private Transform target;
    public float speed = 3.0f;
    public float rotationSpeed = 10f;

    void Start () {
        target = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).transform;
	}
	
	void Update () {
	}

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * rotationSpeed);
    }
}
