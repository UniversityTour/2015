using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

	public float Speed { get; set; }
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.down * Speed * Time.deltaTime;
	}
}
