﻿using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	DanceFloor MyDanceFloor;
	
	public Animator DanceAnim;
	// Use this for initialization
	void Start () {
	
		MyDanceFloor = GameObject.Find ("DanceOffControl").GetComponent<DanceFloor>();
		DanceAnim = this.transform.parent.GetComponent<Animator>();
		if(DanceAnim!=null)
		{
			DanceAnim.enabled = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("a"))
		{
			MyDanceFloor.TapButton(0);
		}
		if(Input.GetKeyDown ("s"))
		{
			MyDanceFloor.TapButton(1);
		}
		if(Input.GetKeyDown ("d"))
		{
			MyDanceFloor.TapButton(2);
		}
		if(Input.GetKeyDown ("f"))
		{
			MyDanceFloor.TapButton(3);
		}
		
	
	
	}
}
