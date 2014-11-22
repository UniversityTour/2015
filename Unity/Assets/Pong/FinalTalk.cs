using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalTalk : MonoBehaviour {

	public List<string> Talks;
	
	Rect Dialogue = new Rect(Screen.width/4,(Screen.height/4)*3,Screen.width/2,Screen.height/4);
	
	public GUIStyle LeftStyle;
	public GUIStyle RightStyle;
	
	public Texture2D Gunnar;
	public Texture2D Theo;
	
	private string Msg;
	
	//Theo der Böse

	// Use this for initialization
	void Start () {
	
		Msg = Talks[0];
		Talks.RemoveAt(0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("return"))
		{
			if(Talks.Count > 0)
			{
				Msg = Talks[0];
				Talks.RemoveAt (0);
			}
		}
	
	}
	
	void OnGUI()
	{
		GUI.Box(Dialogue,"");
		GUILayout.BeginArea(Dialogue);
		GUILayout.BeginHorizontal();
		
			if(Msg.Contains("/G"))
			{
				GUILayout.Box (Gunnar,LeftStyle);
				GUILayout.Label (Msg.Replace("/G",""));
			}
			if(Msg.Contains("/T"))
			{
				GUILayout.Box (Theo,RightStyle);
				GUILayout.Label (Msg.Replace("/T",""));
			}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
