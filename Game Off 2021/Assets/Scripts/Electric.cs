using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Electric : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
