using UnityEngine;
using System.Collections;

public class FinalTalk : MonoBehaviour {

	public string[] Talks;
	
	Rect Dialogue = new Rect(0,(Screen.height/4)*3,Screen.width,Screen.height/4);
	
	public Texture2D Gunnar;
	public Texture2D Theo;
	
	//Theo der Böse

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Box(Dialogue,"");
		GUILayout.BeginArea(Dialogue);
		GUILayout.BeginHorizontal();
		GUILayout.Box (Gunnar);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
