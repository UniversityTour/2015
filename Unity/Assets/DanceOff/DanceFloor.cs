using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DanceFloor : MonoBehaviour {

 	public GameObject[] DanceFloors;
 	
	public bool ShowRunning = false;
	
	private float counter = 0.0f;
	public int OrderCount = 100;
	
	private int LastOrder=0;
	
	public List<int> DanceOrders;
	
	public int ActiveNode;

	// Use this for initialization
	void Start () {
	
		DanceOrders = new List<int>();
		GenerateStepOrders();
		Debug.Log (DanceOrders.Count);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("w"))
		{
			ShowRunning = true;
			StartCoroutine(SendDanceOrders());
			audio.Play();
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

			for ( int i = 0; i < OrderCount; i++ )
			{
				DanceOrders.Add ((int)Random.Range (0,3));
			}
		
	}
	
	public void TapButton(int Key)
	{
		if(Key == ActiveNode)
		{
			Debug.Log ("Correct "+Time.time);
		}
	}
	
	IEnumerator SendDanceOrders()
	{
		for(int i = 0; i < DanceOrders.Count; i++)
		{
			int NewOrder = DanceOrders[i];
			if(NewOrder == LastOrder)
			{
				if(NewOrder>0)
				{
					NewOrder--;
				}
				else
				{
					NewOrder++;
				}
			}
			ChooseDanceFloor(DanceOrders[i]);
			LastOrder = NewOrder;
			ActiveNode = LastOrder;
			yield return new WaitForSeconds(1.0f);
			ResetDanceFloors();
			
		}
		DanceOrders.Clear();
	}
}
