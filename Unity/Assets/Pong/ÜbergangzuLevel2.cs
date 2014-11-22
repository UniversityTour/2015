using UnityEngine;
using System.Collections;

public class ÜbergangzuLevel2 : MonoBehaviour {

	public GUIStyle MyStyle;
	
	public bool Active = false;
	
	public string text;
	
	private string type;
	
	float counter = 0;
	
	public Transform Trennwand;
	
	public bool Textfinished = false;
	
	public float CharPassTime = 0.01f;
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(text!="")
		{
			counter += Time.deltaTime;
		}		
		if(counter > CharPassTime && text!="")
		{
			//Debug.Log ("Adding char");
			type += text[0];
			counter = 0;
			text = text.Substring(1);
		}
		
		if(text=="")
		{
			Textfinished = true;
		}
		
		
	
	}
	
	void OnGUI()
	{
		if(Active)
		{
			GameObject.Find ("Settings").GetComponent<Settings>().GamePlayOver = true;
			Debug.Log ("Active");
			GUI.Box (new Rect(50,Screen.height/3,Screen.width/3,Screen.height/2),type,MyStyle);
			if(GUILayout.Button ("Bring mich weiter"))
			{
				Application.LoadLevel(2);
			}
		}
	}
	
	public void CreateTrennwand()
	{
		Debug.Log ("Creating Wand");
		Instantiate(Trennwand,new Vector3(0,0,-9),Quaternion.identity);
	}
}
