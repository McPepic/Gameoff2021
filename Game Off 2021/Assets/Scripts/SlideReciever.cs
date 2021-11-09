using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideReciever : Reciever
{
    [SerializeField] private Transform block, endPosition;
    [SerializeField] private float speed;

    private Vector3 offset;

    private void Start() {
        offset = Vector3.up * (transform.GetChild(0).position.y - transform.position.y);

        transform.GetChild(0).position = transform.position + offset;
    }

    private void Update() {
        if (block.parent != transform) return;

        Vector3 target = GetActive() ? endPosition.position : transform.position;
        target += offset;

        block.position = Vector3.MoveTowards(block.position, target, speed * Time.deltaTime);
    }
}
