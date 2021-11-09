using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    private bool activated;

    public bool GetActive() => activated;
    public void SetActive(bool active) => activated = active;
}
