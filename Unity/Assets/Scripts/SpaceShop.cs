using UnityEngine;
using System.Collections;

public class SpaceShop : MonoBehaviour {

	public string[] Options;
	public string[] Desc;
	public int[] Price;
	public bool StoreOpen = false;
	private AsteroidSpawner roids;
	private SpaceshipScript ship;

	public Texture2D background;
	
	Rect MainWindow = new Rect(Screen.width/4,Screen.height/20,Screen.width/2,Screen.height-(Screen.width/20));
	
	public GUIStyle MyStyle;
	// Use this for initialization
	void Start () {
		ship = GameObject.Find("Spaceship").GetComponent<SpaceshipScript>() as SpaceshipScript;
		roids = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>() as AsteroidSpawner;
	}

	void OnGUI()
	{
		if(StoreOpen == true)
		{
	
		GUI.DrawTexture(MainWindow,background,ScaleMode.StretchToFill);
		GUILayout.BeginArea(MainWindow);
		GUILayout.Label("What are you buying?",MyStyle);
		GUILayout.Space(Screen.height/4);
		GUILayout.BeginVertical();
		
			GUILayout.BeginHorizontal();
			if(GUILayout.Button (Options[0]) && ship.points > Price[0]){
								ship.points -= Price[0];
				roids.cows = true;			
			}
			GUILayout.Label ("Price "+Price[0]+" "+Desc[0]);
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			if(GUILayout.Button (Options[1]) && ship.points > Price[1]){
				ship.points -= Price[1];
				ship.dubstepGun = true;
			}
			GUILayout.Label ("Price "+Price[1]+" "+Desc[1]);
			GUILayout.EndHorizontal();
			
		GUILayout.Space(Screen.height/20);
		if(GUILayout.Button ("Fertig"))
		{
			roids.paused = false;
			StoreOpen = false;
						GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(var go in gos){
				go.GetComponent<AsteroidScript>().paused = false;
			}
		}
		
		GUILayout.EndVertical();
		GUILayout.EndArea();
		
		}
	}
}
