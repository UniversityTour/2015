using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

public AudioClip BattleMusic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartMusic()
	{
		this.audio.clip = BattleMusic;
		this.audio.Play();
	}
}
