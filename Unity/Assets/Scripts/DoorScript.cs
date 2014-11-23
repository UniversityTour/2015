using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    [HideInInspector]
    public bool playerAtDoor = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerAtDoor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerAtDoor = false;
        }
    }

    public bool getTriggerStateDoor()
    {
        return (playerAtDoor) ? true : false;
    }

    public void loadNewLevel()
    {
        if (Application.loadedLevel == 1)
            Application.LoadLevel(2);

        else if (Application.loadedLevel == 2)
            Application.LoadLevel(4);
    }
}
