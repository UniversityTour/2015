using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {


	GameObject Ball;
	public float tolerance = 1.0f;
	public float speed = 7.0f;
	
	private Vector3 StartPos;
	
	Settings Einstellungen;
	
	// Use this for initialization
	void Start () {
	
		Ball = GameObject.Find ("Puck");
		StartPos = this.transform.position;
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
		
	}
	
	public void ResetToStart()
	{
		this.transform.position = StartPos;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Ball!=null && Einstellungen.GamePaused==false)
		{
			
			if(transform.position.x < (Ball.transform.position.x))
			{
				this.transform.position = new Vector3(transform.position.x+speed*Time.deltaTime,transform.position.y,
				transform.position.z);
			}
			if(transform.position.x >= (Ball.transform.position.x))
			{
				this.transform.position = new Vector3(transform.position.x-speed*Time.deltaTime,transform.position.y,transform.position.z);
			}
		}
		
		if(Ball==null)
		{
			Ball = GameObject.Find ("Puck");
		}
	
	}
}
