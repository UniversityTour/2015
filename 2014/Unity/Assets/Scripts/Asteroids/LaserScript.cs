using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public float Speed = 15f;
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * Speed, Time.deltaTime);
		checkBoundaries();
	}
	void checkBoundaries(){
		if(transform.position.x < -10 || transform.position.x > 10)
			Destroy(this.gameObject);
		else if(transform.position.y > 10 || transform.position.y < -10){
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.name.Contains("Asteroid")){
			Destroy(this.gameObject);
		}
	}
}
