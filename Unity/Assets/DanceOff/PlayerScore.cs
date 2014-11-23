using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int score = 0;
	public int MaxScore = 1000;
	
	public GameObject Trennwand;

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
	
	}
	
	void OnGUI()
	{
		GUILayout.Label ("Score : "+score);
	}
	
	IEnumerator Ender()
	{
		yield return new WaitForSeconds(5.0f);
		Trennwand.renderer.enabled = true;
	}
}
