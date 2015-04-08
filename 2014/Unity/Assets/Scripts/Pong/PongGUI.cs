using UnityEngine;
using System.Collections;

public class PongGUI : MonoBehaviour {
	
	private bool IntroOver = false;
	
	private long Dollar;
	
	Settings Einstellungen;
	
	void Start()
	{
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
	}
	
	void OnGUI()
	{
		Dollar = Einstellungen.Dollarz;
		
		if(Einstellungen.GamePlayOver==false)
		{
		
			if(IntroOver == false)
			{
				this.IntroOver = GameObject.Find ("Settings").GetComponent<Settings>().IntroOver;
			}
			
			if(IntroOver)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label ("Eskimo-Dollar: " + Dollar.ToString());
				GUILayout.EndHorizontal();
			}
		}
		
	}

}