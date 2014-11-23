using UnityEngine;
using System.Collections;

public class Pitfall_HiddenTreasure : MonoBehaviour {

    SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spr.enabled = true;
        }
    }


}
