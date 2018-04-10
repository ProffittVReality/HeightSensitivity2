using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

	public GameObject cam;
	Vector3 pos;

	public float height;

	// Use this for initialization
	void Start () {

		pos = new Vector3 (cam.transform.position.x, height, cam.transform.position.z);

		transform.position = pos;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			pos = new Vector3 (cam.transform.position.x, height, cam.transform.position.z);
			transform.position = pos;
		}
			
		
	}
}
