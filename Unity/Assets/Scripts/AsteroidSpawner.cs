using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject[] Asteroids;
	public float spawnValue = 1f;
	// Use this for initialization
	private List<GameObject> liveAsteroids;
	private float timePassed = 0.0f;

	void Start () {
		liveAsteroids = new List<GameObject>();

		UnityEngine.Random.seed = (int)(new DateTime()).Ticks; 
	}
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		checkBoundaries();
		spawnAsteroids();
	}

	void checkBoundaries(){
		List<int> indexes = new List<int>();
		for(int i = 0; i < liveAsteroids.Count; i++){
			if(liveAsteroids[i].transform.position.y < -8){
				indexes.Add(i);
			}
		}
		foreach(var index in indexes){
			GameObject del = liveAsteroids[index];
			liveAsteroids.RemoveAt(index);
			Destroy(del);
		}
		
	}
	
	// Range [-8.25,8.25]
	void spawnAsteroids(){
		float probability = timePassed / UnityEngine.Random.value  ;
		if(probability > spawnValue){
			GameObject newAsteroid = Instantiate(Asteroids[(int)(UnityEngine.Random.value * 5)]) as GameObject;
			newAsteroid.GetComponent<AsteroidScript>().Speed = UnityEngine.Random.value * 30;
			float xPos = UnityEngine.Random.value * 16.5f;
			Vector2 pos = newAsteroid.transform.position;
			pos.x = xPos > 8.25f ? -(xPos - 8.25f) : xPos;
			newAsteroid.transform.position = pos;
			liveAsteroids.Add(newAsteroid);
			timePassed = 0f;
		}
	}
}
