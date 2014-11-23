using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SpaceshipScript : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject[] lasers;
	public GameObject explostion;
	public bool dubstepGun = false;
	private int numLives = 3;


	void Start(){
		GameObject.Find("AsteroidSpawner").GetComponent<SpaceshipToggle>().Reposition();
	}

	void Update () {
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
				Debug.Log(go);
				go.GetComponent<AsteroidScript>().Kill();
			}
			Instantiate(lasers[1], new Vector3(0, 0, -11f), Quaternion.identity);
			audio.Play();
			dubstepGun = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject.Find("AsteroidSpawner").GetComponent<SpaceshipToggle>().Reposition();
		Instantiate(explostion, transform.position, Quaternion.identity);
    }
}
