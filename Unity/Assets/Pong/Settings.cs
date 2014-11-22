﻿using UnityEngine;
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
	
	FinalTalk EndDialogue;
	Animator Jet;
	
	public bool GamePlayOver = false;
	

	// Use this for initialization
	void Start () {
	
		EndDialogue = Camera.main.GetComponent<FinalTalk>();
		EndDialogue.enabled = false;
		Jet = GameObject.Find ("omega_fighter").GetComponent<Animator>();
		Jet.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Dollarz >= 20 && Input.GetKeyDown("w"))
		{
			StoreOpen = true;
		}
		
		if(Input.GetKeyDown ("u"))
		{
			Camera.main.GetComponent<ÜbergangzuLevel2>().CreateTrennwand();
			Camera.main.GetComponent<ÜbergangzuLevel2>().Active = true;
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
	
	public void OnBoughtItem ( string item , int Price)
	{
		if(Dollarz >= Price)
		{
			Dollarz -= Price;
		}
		if(Dollarz < Price)
		{
			return;
		}
	
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
		EndDialogue.enabled = true;
	}
	
	public void StartJet()
	{
	 	Jet.enabled = true;
	}
}
