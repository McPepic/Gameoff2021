using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPad : MonoBehaviour
{
    [SerializeField] private Reciever reciever;

    //Take in general script, activate common method when activated
    private void OnTriggerEnter(Collider other) {
        reciever.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        reciever.SetActive(false);
    }
}
