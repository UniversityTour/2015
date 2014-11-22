using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	public bool IntroOver = false;
	
	public bool StoreOpen = false;
	
	public long Dollarz = 0;
	
	public bool PlayIntro = false;

	public bool GamePaused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Dollarz >= 20 && Input.GetKeyDown("w"))
		{
			StoreOpen = true;
		}
		
		if(StoreOpen)
		{
			GamePaused = true;
		}
		if(!StoreOpen)
		{
			GamePaused = false;
		}
	
	
	}
	
	public void OnBoughtItem ( string item )
	{
		if(item == "Farb-DLC")
		{
			Debug.Log ("You bought a ColorDLC");
		}
	}
}
