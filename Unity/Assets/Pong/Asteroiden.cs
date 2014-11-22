using UnityEngine;
using System.Collections;

public class Asteroiden : MonoBehaviour {

	Animator MyAnimator;
	Settings Einstellungen;
	
	float runningcounter = 0;
	// Use this for initialization
	void Start () {
	
	MyAnimator = this.GetComponent<Animator>();
	MyAnimator.enabled = false;
	Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(this.gameObject.name == "1" && MyAnimator.enabled == true)
		{
			runningcounter += Time.deltaTime;
			if(runningcounter >= 10.0f)
			{
				Einstellungen.EndPhase();
			}
		}
		

	
	}
	
	public void ActivateAnimation()
	{
		MyAnimator.enabled = true;
	}
	
	
}
