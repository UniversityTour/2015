using UnityEngine;
using System.Collections;

public class UpgradeScreen : MonoBehaviour {

	public string[] Options;
	public string[] Desc;
	public int[] Price;
	
	public Texture2D background;
	
	Rect MainWindow = new Rect(Screen.width/4,Screen.height/20,Screen.width/2,Screen.height-(Screen.width/20));
	
	public GUIStyle MyStyle;
	
	Settings Einstellungen;

	// Use this for initialization
	void Start () {
	
	Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GameObject.Find ("Settings").GetComponent<Settings>().StoreOpen == true)
		{
	
		GUI.DrawTexture(MainWindow,background,ScaleMode.StretchToFill);
		GUILayout.BeginArea(MainWindow);
		GUILayout.Label("What are you buying?",MyStyle);
		GUILayout.Space(Screen.height/4);
		GUILayout.BeginVertical();
		
		for( int i = 0; i < Options.Length; i++)
		{
			GUILayout.BeginHorizontal();
			if(GUILayout.Button (Options[i]))
			{
				TellChangesToSettings(Options[i],Price[i]);
			}
			GUILayout.Label ("Price "+Price[i]+" "+Desc[i]);
			GUILayout.EndHorizontal();
		}
		
		GUILayout.Space(Screen.height/20);
		if(GUILayout.Button ("Fertig"))
		{
			Einstellungen.StoreOpen = false;
		}
		
		GUILayout.EndVertical();
		GUILayout.EndArea();
		
		}
	}
	
	void TellChangesToSettings(string Name, int Price)
	{
		GameObject.Find ("Settings").GetComponent<Settings>().OnBoughtItem(Name,Price);
	}
}
