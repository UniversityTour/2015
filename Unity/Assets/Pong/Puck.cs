using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {

	private Vector3 direction;
	private float speed;
    public GameObject pong;
	
	Settings Einstellungen;
	
	TrailRenderer RainbowTrail;
	
	int hitcounter = 0;
	
	//public GameObject PuckPrefab;

	// Use this for initialization
	void Start () {
	
		RainbowTrail = this.GetComponent<TrailRenderer>();
		RainbowTrail.enabled = false;
        pong = GameObject.Find("AudioPong");
	
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
		//this.direction = new Vector3(1.0f, 1.0f).normalized;
		//this.speed = 0.0f;
		//this.rigidbody.velocity = new Vector3(0,1,0);
		
		if(Einstellungen.Cage == true)
		{
			ActivateCage();
		}
		
		this.direction = new Vector3(1.0f,1.0f).normalized;
		this.speed = 0.1f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Einstellungen.GamePaused == false)
		{
			this.transform.position += direction * speed;
		}

        if (transform.position.x >= 20 || transform.position.x <= -20)
        {
            Destroy(gameObject);
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
		hitcounter ++;
		//Debug.Log ("Collision with "+col.gameObject.name);
		Vector3 normal = col.contacts[0].normal;
		direction = Vector3.Reflect(direction, normal);
        Instantiate(pong);
        
		speed += 0.01f;
		
		if(col.gameObject.name.Contains("Eigenraum"))
		{
			if(col.gameObject.name.Contains("Gegner"))
			{
				GrantPlayerPoints(10.0f* hitcounter * Time.time);
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
