using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHandler : MonoBehaviour
{
    [SerializeField] private GameObject playObject;

    private GameObject bug;

    private void Start() {
        bug = transform.GetChild(0).gameObject;

        SetPlaying(true);
    }

    //Child 0: Bug, only enable when !playing
    //Child 1: Play, only enable when playing. Set to playObject
    public void SetPlaying(bool playing) {
        bug.SetActive(!playing);
        if (playObject != null) {
            playObject.SetActive(playing);

            if(!playing) {
                Vector3 spawnPos = playObject.CompareTag("Platform") ? playObject.transform.GetChild(0).position :
                                                                       playObject.transform.position;

                transform.position = spawnPos;
            } else {
                playObject.transform.position = transform.position;
            }
        }
    }

    public void SetObject(GameObject other) {
        Transform spawn;
        if(playObject != null) {
            spawn = playObject.CompareTag("Platform") ? playObject.transform.GetChild(0) : playObject.transform;
        } else {
            spawn = transform;
        }

        Destroy(playObject);

        playObject = other;

        playObject.transform.position = spawn.position; 
        playObject.transform.rotation = spawn.rotation;

        playObject.transform.SetParent(transform);

        PlatformMover mover = other.GetComponent<PlatformMover>();
        if (mover != null) {
            mover.ResetPlatform();
        }

        playObject.SetActive(false);
    }
}
