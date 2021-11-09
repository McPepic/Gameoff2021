using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReciever : Reciever
{
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        anim.SetBool("IsOpen", GetActive());
    }
}
