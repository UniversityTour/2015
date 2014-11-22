using UnityEngine;
using System.Collections;

public class PongGUI : MonoBehaviour {
	
	
	private long Dollar;
	
	void OnGUI()
	{
		
		GUILayout.BeginHorizontal();
		GUILayout.Label ("Eskimo-Dollar: " + Dollar.ToString());
		GUILayout.EndHorizontal();
		
	}
	
	public void ChangeDollars(float dol)
	{
		this.Dollar += (long)dol;
	}
}