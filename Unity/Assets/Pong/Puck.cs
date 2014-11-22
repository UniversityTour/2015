using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {

	private Vector3 direction;
	private float speed;
	
	Settings Einstellungen;
	
	TrailRenderer RainbowTrail;
	
	//public GameObject PuckPrefab;

	// Use this for initialization
	void Start () {
	
		RainbowTrail = this.GetComponent<TrailRenderer>();
		RainbowTrail.enabled = false;
	
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
		//this.direction = new Vector3(1.0f, 1.0f).normalized;
		this.speed = 0.0f;
		//this.rigidbody.velocity = new Vector3(0,1,0);
		
		if(Einstellungen.Cage == true)
		{
			ActivateCage();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Einstellungen.GamePaused == false)
		{
			this.transform.position += direction * speed;
		}

		
		if(Input.GetKeyDown ("space"))
		{
			this.direction = new Vector3(1.0f,1.0f).normalized;
			this.speed = 0.1f;
		}
		
		if(Einstellungen.RainbowTrails == true)
		{
			EnableRainbow();
		}
		
		if(Einstellungen.Cage==true)
		{
			this.renderer.material = Einstellungen.CageTex;
		}
	
	}
	
	void OnCollisionEnter (Collision col)
	{
		//Debug.Log ("Collision with "+col.gameObject.name);
		Vector3 normal = col.contacts[0].normal;
		direction = Vector3.Reflect(direction, normal);
		speed += 0.01f;
		
		if(col.gameObject.name.Contains("Eigenraum"))
		{
			if(col.gameObject.name.Contains("Gegner"))
			{
				GrantPlayerPoints(10.0f);
			}
			Destroy (this.gameObject);
			GameObject.Find ("Spawner").GetComponent<BallSpawner>().OnBallDeath();
		}
		
	}
	
	void GrantPlayerPoints(float points)
	{
		Einstellungen.Dollarz += (long)points;
	}
	
	void EnableRainbow()
	{
		RainbowTrail.enabled = true;
	}
	
	void ActivateCage()
	{
		this.renderer.material = Einstellungen.CageTex;
	}
	
}
