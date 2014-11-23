using UnityEngine;
using System.Collections;

public class EndShip : MonoBehaviour {
    public float velocity = 0.1f;
   public float scaler = 0.4f;
    Vector3 direction;
    public GameObject goal;
    bool go = false;
    bool done = false;
    bool trigger = false;
    bool endSceneB = false;

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
       // if (transform.position != goal.transform.position)
       // {
            if (transform.position.y <= -2.9f)
            {
                transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            }
            else if (transform.position.y > -3.1f && go == true)
            {
               direction = goal.transform.position - transform.position;
               // direction = new Vector3(0.5f, 0.5f, 0);
              // Debug.Log(direction);
                transform.Translate(direction * velocity * Time.deltaTime);
               // velocity -= 0.1f;
               // transform.localScale = transform.localScale - (new Vector3(0.1f ,0.1f, 0.1f )* scaler);

            }
            else if (done = true && trigger == false)
            {
                trigger = true; 
                StartCoroutine("talk");
            }
            else if (transform.position.y >= -2.9f && transform.position.y < -3.1f)             {
                done = true;
            }
            
        if (transform.position.y >= (2.6f) && transform.position.y < (3.7f) &&
                    transform.position.y <= (3.9f) && transform.position.y > (3.0f))
            {
                //Debug.Log("finished");
                velocity = 0;
                if (transform.localScale.y >= 0 && endSceneB == false){
                    transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }

                else if (endSceneB == false && transform.localScale.y < 0){
                    Debug.Log("done");
                    endSceneB = true;
                    StartCoroutine("endScene");
            }
                }
                    
      //  }
      //  else
      //  {
      //      Application.Quit();
      //  }
	}

    IEnumerator talk()
    {
       // Debug.Log("load");
        yield return new WaitForSeconds(4);
        go = true;
        //Debug.Log("true");
    }

    IEnumerator endScene()
    {
       // Debug.Log("endS");
        yield return new WaitForSeconds(3);
        //Debug.Log("waitO");
        Application.Quit();
    }
}
