using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public float PaddleSpeed = 5.0f;
	
	Settings Einstellungen;
	// Use this for initialization
	void Start () {
	
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Einstellungen.GamePaused)
		{
			return;
		}
	
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
