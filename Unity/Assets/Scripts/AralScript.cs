using UnityEngine;
using System.Collections;

public class AralScript : MonoBehaviour {

	public float spawnFrequency = 30f;
	private Renderer[] rs;
	private bool flag = false;
	// Use this for initialization
	void Start () {
		rs = GetComponentsInChildren<Renderer>();
		foreach(var r in rs)
			r.enabled = false;
		collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		spawnFrequency -= Time.deltaTime;
		if(spawnFrequency < 0f)
		{
			rs = GetComponentsInChildren<Renderer>();
			foreach(var r in rs)
				r.enabled = true;
			collider.enabled = true;
			spawnFrequency = 30f;
			flag = true;
		}
		if((transform.position - new Vector3(0,3f,-6)).magnitude < 0.5f)
			flag = false;
		if(flag){
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,3f,-6f), Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "Spaceship")
		{			
			float xPos = UnityEngine.Random.value * 16.5f;
			Vector3 pos = new Vector3(0,0,0);
			pos.x = xPos > 8.25f ? -(xPos - 8.25f) : xPos;
			pos.z = -6f;
			pos.y = 10f;
			transform.position = pos;
		}	
	}

	void FlyInto(){
		transform.position = Vector3.Lerp(transform.position, new Vector3(0,3f,-6), Time.deltaTime);
	}

}
