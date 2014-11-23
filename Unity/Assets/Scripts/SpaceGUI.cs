using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SpaceGUI : MonoBehaviour {

	public Texture background;
	public Texture[] textures;
	public string[] texts;
	public AudioClip[] clips;
	public float spawnTimer = 15f;
	public float displayTime = 5f;
	private bool showImage = false;
	private int toShow = 0;
	void Update(){
		spawnTimer -= Time.deltaTime;
		if(spawnTimer < 0f){

		 	AudioSource.PlayClipAtPoint(clips[toShow], new Vector3(0,0,0));
			toShow = (int)(UnityEngine.Random.value * textures.Length);	
			showImage = true;
			spawnTimer = 30f;
		}
		if(showImage){
			displayTime -= Time.deltaTime;
		}
		if(displayTime < 0){
			displayTime = 5f;
			showImage = false;
		}
	}
    void OnGUI() {
    	if(showImage){
			audio.Play();
    		GUI.DrawTexture(new Rect(10, 10, 100, 100), textures[toShow], ScaleMode.StretchToFill, true, 10.0F);
    		GUI.DrawTexture(new Rect(120, 10, 300, 100), background, ScaleMode.StretchToFill, true, 10.0F);
    		GUI.color = Color.black;
    		var centeredStyle = GUI.skin.GetStyle("Label");
    		centeredStyle.alignment =  TextAnchor.MiddleCenter;
    		GUI.Label(new Rect(140, 15, 280, 95), texts[toShow], centeredStyle);
       	}      
    }
}
