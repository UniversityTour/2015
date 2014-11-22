using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public float PaddleSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey("a"))
		{
			this.transform.position = new Vector3(transform.position.x - PaddleSpeed*Time.deltaTime,transform.position.y,transform.position.z);
		}
		if(Input.GetKey("d"))
		{
			this.transform.position = new Vector3(transform.position.x + PaddleSpeed*Time.deltaTime,transform.position.y,transform.position.z);
		}
	
	}
}
