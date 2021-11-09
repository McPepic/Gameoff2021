using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Transform mainCam;

    [SerializeField] private GameObject regular;
    [SerializeField] private GameObject invert;

    private bool riSwitch;

    [SerializeField] private LayerMask selectMask;
    private GameObject copy;

    private void Start() {
        regular.SetActive(true);
        invert.SetActive(false);

        mainCam = Camera.main.transform;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            riSwitch = !riSwitch;

            player.SetParent(null);

            foreach(ColliderStick stick in FindObjectsOfType<ColliderStick>()) {
                stick.ReturnObject();
            }

            regular.SetActive(!riSwitch);
            invert.SetActive(riSwitch);

            foreach(BugHandler handler in FindObjectsOfType<BugHandler>()) {
                handler.SetPlaying(!riSwitch);
            }
        }

        RaycastHit hit;
        bool raycast = Physics.Raycast(new Ray(mainCam.position, mainCam.forward), out hit, 100f, selectMask);

        if (raycast) {
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                Transform other = hit.transform;

                //Physics, no copy
                //Physics,    copy
                //Bug    , no copy
                //Bug    ,    copy

                if (other.CompareTag("Bug")) {
                    if (copy != null) {
                        other.parent.GetComponent<BugHandler>().SetObject(copy);

                        copy = null;
                    }

                    return;
                }

                if (copy != null) {
                    Destroy(copy);
                    copy = null;
                }

                GameObject original = other.CompareTag("Platform") ? other.parent.gameObject : other.gameObject;

                copy = Instantiate(original);
                copy.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Q)) {
                if(hit.transform.CompareTag("Bug")) {
                    hit.transform.parent.Rotate(Vector3.up * -90);
                }
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                if (hit.transform.CompareTag("Bug")) {
                    hit.transform.parent.Rotate(Vector3.up * 90);
                }
            }
        }
    }
}
