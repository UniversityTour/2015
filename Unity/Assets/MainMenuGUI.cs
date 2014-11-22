using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	public GUIStyle MainMenuStyle;
	
	bool Credits = false;


	Rect MainWindow = new Rect(Screen.width/2-(Screen.width/4),0,Screen.width/2,Screen.height);
	
	Rect SecondWindow = new Rect(Screen.width/2-(Screen.width/8),Screen.height/4,Screen.width/4,Screen.height/2);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{

		GUI.Box(MainWindow,"");
		
		//GUI.Box (SecondWindow,"");
		
		GUILayout.BeginArea(MainWindow);
		GUILayout.Space(Screen.height/10);
		GUILayout.Label("ESKIMO CHRONICLES",MainMenuStyle);
		GUILayout.Space(Screen.height/10);
		
		GUILayout.EndArea();
		
		
		GUILayout.BeginArea(SecondWindow);
		if(Credits==false)
		{
			if(GUILayout.Button ("New Game"))
			{
				Application.LoadLevel (0);
			}
			GUILayout.Space(Screen.height/10);
			if(GUILayout.Button ("Credits"))
			{
				Credits = true;
			}
			GUILayout.Space(Screen.height/10);
			if(GUILayout.Button ("Exit"))
			{
				Application.Quit();
			}
		}
		else
		{
			GUILayout.Label("Michael Niederreiter",MainMenuStyle);
			GUILayout.Space(Screen.height/20);
			GUILayout.Label ("Andreas Langbein",MainMenuStyle);
			GUILayout.Space(Screen.height/20);
			GUILayout.Label ("Dominik Giebert",MainMenuStyle);
			GUILayout.Space(Screen.height/20);
			GUILayout.Label ("Roman Maier",MainMenuStyle);
			GUILayout.Space(Screen.height/20);
			if(GUILayout.Button ("Back"))
			{
				Credits = false;
			}
			
		}
		GUILayout.EndArea();
	}
}
