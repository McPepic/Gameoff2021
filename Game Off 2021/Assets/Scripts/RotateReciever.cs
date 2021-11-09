using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReciever : Reciever
{
    [SerializeField] private float speed;

    private Vector3 target;
    private bool rise, fall;

    private void Start() {
        target = transform.eulerAngles;
    }

    private void Update() {
        if(transform.rotation == Quaternion.Euler(target)) {
            if (GetActive()) {
                fall = true;
                if (rise) {
                    rise = false;

                    target += transform.up * 90f;
                }
            } else {
                rise = true;
                if (fall) {
                    fall = false;

                    target += transform.up * 90f;
                }
            }
        } else {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(target), speed * Time.deltaTime);

        }
    }
}
