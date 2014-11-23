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
	
	public GameObject WoWPrefab;
	
	int Multiplikator = 0;

	// Use this for initialization
	void Start () {
	
		DanceOrders = new List<int>();
		GenerateStepOrders();
		Debug.Log (DanceOrders.Count);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
	
	}
	
	public void EnterShowMode()
	{
		ShowRunning = true;
		StartCoroutine(SendDanceOrders());
		audio.Play();
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
			Multiplikator++;
			Debug.Log ("Key hit");
			if(Key == 0)
			{
				Instantiate(WoWPrefab,new Vector3(-12,-3,0),Quaternion.identity);
			}
			if(Key == 1)
			{
				Instantiate(WoWPrefab,new Vector3(-4,-3,0),Quaternion.identity);
			}
			if(Key == 2)
			{
				Instantiate(WoWPrefab,new Vector3(3,-3,0),Quaternion.identity);
			}
			if(Key == 3)
			{
				Instantiate(WoWPrefab,new Vector3(13,-6,0),Quaternion.identity);
			}
			
			GameObject.Find ("Score").GetComponent<PlayerScore>().score += 10*Multiplikator;
			//Instantiate(WoWPrefab,new Vector3(0,0,0),Quaternion.identity);
		}
		else
		{
			Multiplikator=1;
			Debug.Log ("Wrong Node");
		}
		
		Mathf.Clamp (Multiplikator,1,100);
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
