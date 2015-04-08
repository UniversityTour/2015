using UnityEngine;
using System.Collections;

public class CreditsBehav : MonoBehaviour {
    public float velocityy =2 ;
    bool trigger = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate(Vector3.forward * velocityy * Time.deltaTime);
        transform.position += new Vector3(velocityy * Time.deltaTime, 0, 0);

        if (transform.position.x <= 0.2f && transform.position.x >= -0.2f && trigger == false)
        {
            Debug.Log("if");
            velocityy = 0;
            StartCoroutine("wait");

        }

        if (transform.position.x >= 10)
            Destroy(gameObject);
	
	}
    IEnumerator wait()
    {
        trigger = true;
        yield return new WaitForSeconds(3);
        velocityy = 2; 
    }
}
