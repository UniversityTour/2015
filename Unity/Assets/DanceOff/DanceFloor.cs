using UnityEngine;
using System.Collections;

public class DanceFloor : MonoBehaviour {

 	public GameObject[] DanceFloors;
 	
	public bool ShowRunning = false;
	
	private float counter = 0.0f;
	private float NextNodeTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("w"))
		{
			Debug.Log ("Show Running");
			ShowRunning = true;
			//GenerateStepOrders();
		}
	
	}
	
	public void ChooseDanceFloor (int key)
	{
		//0 = none
		//1 = A
		//2 = S
		//3 = D
		//4 = F
		int Number = 0;
		
		switch(key)
		{
			case 0:
			Number = 1;
			break;
			
			case 1:
			Number = 2;
			break;
			
			case 2:
			Number = 3;
			break;
			
			case 3:
			Number = 4;
			break;
		}
		
		for ( int i = 0; i < DanceFloors.Length; i++)
		{
			if(i!=Number)
			{
				DanceFloors[i].renderer.enabled = false;
			}
		}
		
	}
	
	public void ResetDanceFloors()
	{
		foreach(GameObject GO in DanceFloors)
		{
			GO.renderer.enabled = true;
		}
	}
	
	public void StartMusic()
	{
		audio.Play();
	}
	
	public void GenerateStepOrders()
	{
		while(ShowRunning)
		{
			counter += Time.deltaTime;
			if(NextNodeTime == 0)
			{
				NextNodeTime = Random.Range(0.5f,1.5f);
			}
			else
			{
				if(counter >= NextNodeTime)
				{
					counter = 0;
					NextNodeTime = 0;
					
					int Node = (int)Random.Range(0,3);
					ChooseDanceFloor(Node);
				}
			}
		}
	}
}
