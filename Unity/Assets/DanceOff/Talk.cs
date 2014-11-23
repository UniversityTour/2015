using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Talk : MonoBehaviour {

	bool TalkActive = false;
	
	public List<string> Talks;
	
	private string msg;
	
	Rect DialogueBoxLeft = new Rect(0,(Screen.height/4)*3-((Screen.height/3)/4),Screen.width/2,Screen.height/3);
	Rect DialogueBoxRight = new Rect(Screen.width/2,(Screen.height/4)*3-((Screen.height/3)/4),Screen.width/2,Screen.height/3);
	
	public Texture Captain;
	public Texture Gunnar;
	
	public GUIStyle MyStyle;
	public GUIStyle Right;

	// Use this for initialization
	void Start () {
	
		msg = Talks[0];
		Talks.RemoveAt(0);
		
		Debug.Log (msg);
		
		TalkActive = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if(Input.GetKeyDown ("return"))
		{
			if(Talks.Count > 0)
			{
				msg = Talks[0];
				Talks.RemoveAt(0);
			}
			else
			{
				return;
			}
		}
	
	}
	
	void OnGUI()
	{
		if(TalkActive)
		{
			GUILayout.BeginArea(DialogueBoxLeft);
			GUILayout.BeginHorizontal();
			GUILayout.Box(Gunnar,MyStyle);
			if(msg.Contains("/G"))
			{
				string temp = msg.Replace("/G","");
				GUILayout.Label(temp,MyStyle);
			}
			GUILayout.EndHorizontal();
	
			GUILayout.EndArea();
			
			GUILayout.BeginArea(DialogueBoxRight);
			GUILayout.BeginHorizontal();
			if(msg.Contains("/C"))
			{
				string temp = msg.Replace("/C","");
				GUILayout.BeginVertical();
				GUILayout.Label(temp,Right);
				GUILayout.EndVertical();
			}
			if(msg.Contains ("/E"))
			{
				TalkActive = false;
				GameObject.Find ("DanceOffControl").GetComponent<DanceFloor>().EnterShowMode();
				Destroy(this.gameObject);
			}
	
			GUILayout.Box(Captain,Right);
	
			GUILayout.EndHorizontal();
			
			GUILayout.EndArea();
			
		
		}
	}
}
