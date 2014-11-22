using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	public Transform PuckPrefab;
	
	private int ActiveBalls = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("z"))
		{
			Instantiate(PuckPrefab,new Vector3(0,0,0),Quaternion.identity);
		}
		
		if(ActiveBalls <= 0)
		{
			Instantiate(PuckPrefab,new Vector3(0,0,0),Quaternion.identity);
			ActiveBalls++;
		}
	
	}
	
	public void OnBallDeath()
	{
		ActiveBalls--;
	}
}
