using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

	public GameObject Explosion;
	public float Speed;
    public bool paused = false;
	// Update is called once per frame
    private float angle = 0.0F;
    private Vector3 axis = Vector3.zero;
    private bool up = false;
    private SpaceshipScript ship;

    void Start(){
		ship = GameObject.Find("Spaceship").GetComponent<SpaceshipScript>() as SpaceshipScript;
		Random.rotation.ToAngleAxis(out angle, out axis);
    }
	void Update () {
		if(paused)
			return;
		transform.position += Vector3.down * Speed * Time.deltaTime;
		checkBoundaries();
		transform.RotateAround(transform.position, axis, Time.deltaTime * 20);
	}


	void OnTriggerEnter(Collider other) {
		if(other.name.Contains("Asteroid")){
			if(other.gameObject.transform.position.y < transform.position.y)
				Speed = Mathf.Lerp(0f, Speed * 0.75f,Time.time);
				StartCoroutine(recoil(0.075f,  Vector3.up));
			}
		else if( other.name.Contains("Laser")){
			ship.points += 10;
    		GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().numAsteroids--;
			Instantiate(Explosion, transform.position, Quaternion.identity);
        	Destroy(this.gameObject);
		}
		else if(other.name == "Spaceship")
		{
    		GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().numAsteroids--;
			Instantiate(Explosion, transform.position, Quaternion.identity);
        	Destroy(this.gameObject);
    	}
    }

    void checkBoundaries(){
		if(transform.position.x < -10 || transform.position.x > 10){
			Destroy(this.gameObject);
			GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().numAsteroids--;
		}
		else if(transform.position.y > 30 || transform.position.y < -10){
			Destroy(this.gameObject);
			GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().numAsteroids--;
		}
	}


    IEnumerator recoil(float duration, Vector3 direction) {
    	up = true;
        while (duration > 0f) {
            duration -= Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime);
      
            yield return new WaitForSeconds(duration);
        }
        up = false;
     }

    public void Kill(){
    	ship.points += 10;
    	Destroy(this.gameObject);
    	GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().numAsteroids--;
    }
}
