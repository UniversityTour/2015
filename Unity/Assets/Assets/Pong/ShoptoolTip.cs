using UnityEngine;
using System.Collections;

public class ShoptoolTip : MonoBehaviour {

	Settings Einstellungen;
	// Use this for initialization
	void Start () {
	
		Einstellungen = GameObject.Find ("Settings").GetComponent<Settings>();
		this.renderer.enabled = false;	
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Einstellungen.Dollarz > 1)
		{
			this.renderer.enabled = true;
			Destroy (this.GetComponent<ShoptoolTip>());
		}
	
	}
}
