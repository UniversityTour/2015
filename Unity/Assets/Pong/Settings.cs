using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	public bool IntroOver = false;
	
	public bool StoreOpen = false;
	
	public long Dollarz = 0;
	
	public bool PlayIntro = false;

	public bool GamePaused = false;
	
	public bool RainbowTrails = false;
	
	public bool Cage = false;
	
	public Material CageTex;

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
			ColoriceMe();
		}
		if(item == "Rainb0w")
		{
			Debug.Log ("You activated RainbowMode");
			RainbowTrails = true;
		}
		if(item == "CageSkin")
		{
			Cage = true;
		}
		
		if(item == "MeteorRegen")
		{
			Debug.Log ("Triggering Apocalypse");
			GameObject[] Asteroiden = GameObject.FindGameObjectsWithTag("Asteroid");
			foreach(GameObject A in Asteroiden)
			{
				A.GetComponent<Asteroiden>().ActivateAnimation();
			}
		}
		
		if(item == "Musik-DLC")
		{
			Camera.main.GetComponent<Audio>().StartMusic();
		}
	}
	
	public void ColoriceMe()
	{
		GameObject[] AllNeons = GameObject.FindGameObjectsWithTag("Neon");
		for ( int i = 0; i < AllNeons.Length; i++ )
		{
			Destroy (AllNeons[i]);
		}
	}
	
	public void EndPhase()
	{
		GamePaused = true;
	}
}
