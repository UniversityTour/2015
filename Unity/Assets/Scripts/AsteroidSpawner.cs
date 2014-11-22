using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject[] Asteroids;
	public float spawnValue = 1f;
	public float maxAsteroidSpeed = 3f;
	public int maxAsteroids = 10;
	public int numAsteroids = 0;
	// Use this for initialization
	private float timePassed = 0.0f;

	void Start () {
		UnityEngine.Random.seed = (int)(new DateTime()).Ticks; 
	}

	void Update () {
		timePassed += Time.deltaTime;
		spawnAsteroids();
	}

	// Range [-8.25,8.25]
	void spawnAsteroids(){
		float probability = timePassed / UnityEngine.Random.value;
		if(probability > spawnValue && numAsteroids < maxAsteroids){
			numAsteroids++;
			GameObject newAsteroid = Instantiate(Asteroids[(int)(UnityEngine.Random.value * Asteroids.Length)]) as GameObject;
			newAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().Speed = UnityEngine.Random.value * maxAsteroidSpeed;
			float xPos = UnityEngine.Random.value * 16.5f;
			Vector3 pos = newAsteroid.transform.position;
			pos.x = xPos > 8.25f ? -(xPos - 8.25f) : xPos;
			pos.z = -5f;
			newAsteroid.transform.GetChild(0).transform.position = pos;
			timePassed = 0f;
		}
	}
}
