using UnityEngine;
using System.Collections;

public class Asteroiden : MonoBehaviour {

	Animator MyAnimator;
	// Use this for initialization
	void Start () {
	
	MyAnimator = this.GetComponent<Animator>();
	MyAnimator.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ActivateAnimation()
	{
		MyAnimator.enabled = true;
	}
	
	
}
