using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTargetWithOffset : MonoBehaviour
    {
        public Transform target;
        public float smoothTime = 1f;
        private Vector3 offset;
        private Vector3 currentVelocity = Vector3.zero;

        void Start()
        {
            offset = transform.position;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
        }
    }
}
