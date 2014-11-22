using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

	public float Speed { get; set; }
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.down * Speed * Time.deltaTime;
		checkBoundaries();
	}


	void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }

    void checkBoundaries(){
		if(transform.position.x < -10 || transform.position.x > 10)
			Destroy(this.gameObject);
		else if(transform.position.y > 30 || transform.position.y < -10){
			Destroy(this.gameObject);
		}
	}
}
