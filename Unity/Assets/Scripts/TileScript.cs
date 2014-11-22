using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public GameObject Tile;
	public float speed = 1f;
	private Transform[] allChildren;
	// Use this for initialization
	void Start(){

		allChildren = new Transform[transform.childCount];
		for(int i = 0; i < allChildren.Length; i++){
			allChildren[i] = transform.GetChild(i);
		}
	}
	// Update is called once per frame
	void Update () {
		foreach(var t in allChildren){
			t.transform.position += Vector3.down * speed * Time.deltaTime;
		}
		checkBoundaries();
	}

    void checkBoundaries(){
    	
	    foreach(var t in allChildren){
			if(t.transform.position.y < -10){
				t.transform.position += new Vector3(0,30f,0);
			}
		}
	}
}
