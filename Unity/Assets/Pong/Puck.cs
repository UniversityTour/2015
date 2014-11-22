using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {

	private Vector3 direction;
	private float speed;
	
	//public GameObject PuckPrefab;

	// Use this for initialization
	void Start () {
	
		this.direction = new Vector3(1.0f, 1.0f).normalized;
		this.speed = 0.1f;
		//this.rigidbody.velocity = new Vector3(0,1,0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position += direction * speed;
		
	
	}
	
	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Collision with "+col.gameObject.name);
		Vector3 normal = col.contacts[0].normal;
		direction = Vector3.Reflect(direction, normal);
		
		if(col.gameObject.name.Contains("Eigenraum"))
		{
			Destroy (this.gameObject);
			GameObject.Find ("Spawner").GetComponent<BallSpawner>().OnBallDeath();
		}
		
	}
	
}
