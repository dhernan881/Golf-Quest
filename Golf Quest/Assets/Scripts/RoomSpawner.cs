using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum direction {
        LEFT,
        RIGHT,
        BOTTOM,
        TOP
    }

    // needs to be a room with an opening in direction openingDirection
    public direction openingDir;
    private RoomTemplates templates;
    private bool spawned = false;

    private void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("Spawn", 0.1f);
    }

    void Spawn() {
        if (spawned == false) {
            int randIdx;
            switch (openingDir) {
                case direction.LEFT:
                    randIdx = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[randIdx], this.transform.position,
                        templates.leftRooms[randIdx].transform.rotation);
                    break;
                case direction.RIGHT:
                    randIdx = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[randIdx], this.transform.position,
                        templates.rightRooms[randIdx].transform.rotation);
                    break;
                case direction.BOTTOM:
                    randIdx = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[randIdx], this.transform.position,
                        templates.bottomRooms[randIdx].transform.rotation);
                    break;
                case direction.TOP:
                    randIdx = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[randIdx], this.transform.position,
                        templates.topRooms[randIdx].transform.rotation);
                    break;
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("SpawnPoint")) {
            Destroy(this.gameObject);
        }
    }
}
