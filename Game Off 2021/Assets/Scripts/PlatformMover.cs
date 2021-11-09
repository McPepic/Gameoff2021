using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform platform;
    private Vector3 platformOffset;

    [SerializeField] private Transform[] points;

    [SerializeField] private float speed;

    private int pointIndex;

    private void Start() {
        ResetPlatform();
    }

    private void FixedUpdate() {
        Vector3 target = pointIndex == 0 ? transform.position : points[pointIndex - 1].position;
        target += platformOffset;

        platform.position = Vector3.MoveTowards(platform.position, target, speed * Time.deltaTime);
        if (platform.position == target) {
            pointIndex++;

            if (pointIndex > points.Length) {
                pointIndex = 0;
            }
        }
    }

    public void ResetPlatform() {
        platformOffset = Vector3.up * (platform.position.y - transform.position.y);

        platform.position = transform.position + platformOffset;

        pointIndex = 0;
    }
}
