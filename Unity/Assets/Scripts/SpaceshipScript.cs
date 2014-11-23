using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SpaceshipScript : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject[] lasers;
	public GameObject explostion;
	public bool dubstepGun = false;
	public int points = 0;
	private int numLives = 3;


	void Start(){
		GameObject.Find("AsteroidSpawner").GetComponent<SpaceshipToggle>().Reposition();
	}

	void Update () {
        if(numLives < 0)
            Application.LoadLevel(0);

		if(points > 1111){
			GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(var go in gos){
				go.GetComponent<AsteroidScript>().Kill();
			}
			GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().paused = true;
			if(GameObject.Find("Done_Enemy Ship") != null)
				GameObject.Find("Done_Enemy Ship").transform.gameObject.SetActive(false);

			if(transform.position.y > 10f)
				Application.LoadLevel(6);
			transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0,8f,0), Time.deltaTime);
			return;	
		}
 		if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8)
		{
 			transform.position = transform.position + new Vector3(speed * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8)
		{
 			transform.position = transform.position +  new Vector3(-speed * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.DownArrow) && transform.position.y > -5.5)
		{
			transform.position = transform.position +  new Vector3(0,-speed * Time.deltaTime,0);
		}
		if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5.5)
		{
 			transform.position = transform.position +  new Vector3(0,speed * Time.deltaTime,0);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate(lasers[0], transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
		}
		if(Input.GetKeyDown(KeyCode.Return) && dubstepGun){
			GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(var go in gos){
				go.GetComponent<AsteroidScript>().Kill();
			}
			Instantiate(lasers[1], new Vector3(0, 0, -11f), Quaternion.identity);
			audio.Play();
			dubstepGun = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "Done_Enemy Ship"){

		}
		else{
			numLives--;
			GameObject.Find("AsteroidSpawner").GetComponent<SpaceshipToggle>().Reposition();
			Instantiate(explostion, transform.position, Quaternion.identity);
    	}
    }
   	void OnGUI()
	{
		var prev = GUI.skin;
		var centeredStyle = GUI.skin.GetStyle("Label");
    centeredStyle.alignment =  TextAnchor.MiddleRight;
		GUI.Label(new Rect(Screen.width - 70, 15, 60, 30), numLives + "   Lives", centeredStyle);
		GUI.Label(new Rect(Screen.width - 200, 30, 190, 30), points + "  Points",centeredStyle);
		GUI.skin = prev;
	}
}
