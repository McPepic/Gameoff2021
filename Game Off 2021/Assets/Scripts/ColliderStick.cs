using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStick : MonoBehaviour
{
    private Transform objParent;

    private void OnTriggerEnter(Collider other) {
        objParent = other.transform.parent;

        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other) {
        ReturnObject();
    }

    public void ReturnObject() {
        if (transform.childCount == 0) return;

        transform.GetChild(0).transform.SetParent(objParent);
        objParent = null;
    }
}
