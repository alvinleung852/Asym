using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public bool isVisible = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isVisible){
			GetComponent<Renderer>().enabled = true;
		}else{
			GetComponent<Renderer>().enabled = false;
		}
	}

	public void setVisible(bool _visible){
		isVisible = _visible;
	}
}
