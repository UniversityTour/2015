using UnityEngine;
using System.Collections;

public class EnemySquishyCollider : MonoBehaviour {

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 vel = this.gameObject.GetComponentInParent<Rigidbody>().velocity;
            vel = new Vector3(vel.x, vel.y + 3.0f, vel.z);
            this.gameObject.GetComponentInParent<Rigidbody>().velocity = vel;
            this.gameObject.GetComponentInParent<BoxCollider>().isTrigger=true;
            this.gameObject.GetComponentInParent<EnemyAI>().isDead = true;
        }
    }

}
