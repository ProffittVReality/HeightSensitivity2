using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusRotate : MonoBehaviour {

	public int Hspeed;
	public float Vspeed;

	private int direction = 1;
	private Vector3 dir = Vector3.up;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,0, Hspeed * Time.deltaTime));
		movePlatform ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Target") { 
			if (dir == Vector3.up) {
				dir = Vector3.down;
			} else {
				dir = Vector3.up ;
			}
		}

		if (other.tag == "Wall") { 
			if (dir == Vector3.up) {
				dir = Vector3.down;
			} else {
				dir = Vector3.up ;
			}
		}

		if (other.tag == "Cube") { 
			if (dir == Vector3.up) {
				dir = Vector3.down;
			} else {
				dir = Vector3.up ;
			}
		}
	}

	void movePlatform(){
		transform.Translate (dir * Vspeed * direction * Time.deltaTime);
	}

	void onTriggerExit(Collider other){
		if (other.tag == "Cube"){
			other.transform.parent = null;
		}
	}
}


