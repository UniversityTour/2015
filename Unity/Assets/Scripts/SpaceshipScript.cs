using UnityEngine;
using System.Collections;

public class SpaceshipScript : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject[] Lasers;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
			Instantiate(Lasers[0], transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
		}
	}


	 void OnTriggerEnter(Collider other) {
        Debug.Log("test");
    }
}
