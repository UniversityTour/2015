using UnityEngine;
using System.Collections;

public class TextSequence : MonoBehaviour {

	public string text;
	
	private string type = "";
	
	public float CharPassTime = 0.1f;
	
	public GUIStyle MyStyle;
	
	bool Textfinished = false;
	
	float counter = 0;
	
	Settings Einstellungen;

	// Use this for initialization
	void Start () {
	
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Einstellungen.PlayIntro==false)
		{
			Textfinished = true;
			return;
		}
		if(text!="")
		{
			counter += Time.deltaTime;
		}		
		if(counter > CharPassTime && text!="")
		{
			Debug.Log ("Adding char");
			type += text[0];
			counter = 0;
			text = text.Substring(1);
			TypedAChar();
		}
		
		if(text=="")
		{
			Textfinished = true;
		}
		
		
	
	}
	
	void OnGUI()
	{
		GUI.Box (new Rect(50,Screen.height/3,Screen.width/3,Screen.height/2),type,MyStyle);
		if(Textfinished)
		{
			if(GUILayout.Button ("Weiter"))
			{
				OnVideoOver();
			}
		}
	}
	
	void TypedAChar()
	{
	
	}
	

	
	void OnVideoOver()
	{
		GameObject.Find ("Settings").GetComponent<Settings>().IntroOver = true;
		Destroy(GameObject.Find ("Trennwand"));
		Destroy (this.gameObject);
	}
	

}
