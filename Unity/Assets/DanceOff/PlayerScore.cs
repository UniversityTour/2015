using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int score = 0;
	public int MaxScore = 1000;
	
	bool StartGUIEnde = false;
	
	public GameObject Trennwand;
	
	float counter = 0;
	
	public string text;
	
	private string type = "";
	
	public float CharPassTime = 0.1f;
	
	bool Textfinished = false;
	

	// Use this for initialization
	void Start () {
	
		Trennwand = GameObject.Find ("Trennwand");
		Trennwand.renderer.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

	
		if(score >= MaxScore)
		{
			Camera.main.GetComponent<Animator>().enabled = false;
			Camera.main.transform.position = new Vector3(0,0,-27);
			GameObject.Find ("DanceOffControl").GetComponent<DanceFloor>().ShowRunning = false;
			GameObject.Find ("DanceOffControl").GetComponent<AudioSource>().audio.Stop();
			
			StartCoroutine("Ender");
		}
		
		if(StartGUIEnde)
		{
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
			}
			
			if(text=="")
			{
				Textfinished = true;
			}
		}
	
	}
	
	void OnGUI()
	{

		
		if(StartGUIEnde)
		{
			Rect MainWindow = new Rect(10,Screen.height/2,Screen.width/3,300);
			
			GUILayout.BeginArea(MainWindow);
			GUILayout.Label (type);
			if(GUILayout.Button ("Setze deine Reise fort"))
			{
				Application.LoadLevel("asteroids");
			}
			GUILayout.EndArea();
		}
		else
		{
			GUILayout.Label ("Score : "+score);
		}
	}
	
	IEnumerator Ender()
	{
		//GameObject.Find ("Danceoff.xcf-Player _0").GetComponent<Animator>().enabled = false;
		//GameObject.Find ("Player").GetComponent<Animator>().enabled = false;
		yield return new WaitForSeconds(2.0f);
		Trennwand.renderer.enabled = true;
		StartGUIEnde = true;
	}
}
