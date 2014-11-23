using UnityEngine;
using System.Collections;

public class TalkSound : MonoBehaviour {

	public AudioClip[] TalkSounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("o"))
		{
			TheoTalk();
		}
	
	}
	
	public void TheoTalk()
	{
		Debug.Log ("Playing Theo");
		this.audio.clip = TalkSounds[2];
		this.audio.Play();
	}
	
	public void GunnarTalk()
	{
		Debug.Log ("Playing Gunnar");
		this.audio.clip = TalkSounds[1];
		this.audio.Play ();
	}
}
