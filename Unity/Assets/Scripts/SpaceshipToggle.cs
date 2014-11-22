using UnityEngine;
using System.Collections;

public class SpaceshipToggle : MonoBehaviour {

	public float duration = 5f;
	private GameObject go;

	void Start () {
        go = GameObject.Find ("Spaceship");
	}

	public void Reposition()
	{
		StartCoroutine(wait(0.5f));
	}
	
	IEnumerator wait(float sec){
		go.SetActive(false);
		yield return new WaitForSeconds(sec);
		go.SetActive(true);
		yield return StartCoroutine(DoBlinks(0.15f, 0.05f));
	}


    IEnumerator DoBlinks(float duration, float blinkTime) {
        Renderer[] rs = go.GetComponentsInChildren<Renderer>();
        go.collider.enabled = false;
        go.transform.position = new Vector3(0f,-5.5f, -5f);
        while (duration > 0f) {
            duration -= Time.deltaTime;
      
            //toggle renderer

            foreach(var r in rs){
              	r.enabled = !r.enabled;
            }
      
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }
  		foreach(var r in rs)
           	r.enabled = true;
        
        go.collider.enabled = true;
     }

}
