using UnityEngine;
using System.Collections;

public class WoWBubble : MonoBehaviour {

	public float speed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(transform.position.y >= 20)
		{
			Destroy (this.gameObject);
		}
		transform.Translate(Vector3.up*Time.deltaTime*speed);
		transform.Rotate(new Vector3(0,1,0));
	
	}
}
