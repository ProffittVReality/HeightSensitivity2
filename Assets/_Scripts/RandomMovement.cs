using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
	private Vector3 pos;
	private int direction = 1;
	public float speed;

	void Start(){
		pos = Random.insideUnitCircle * 1;
		transform.Translate (pos);
	}

	void Update(){
		transform.Translate ((transform.forward * speed * Time.deltaTime) * direction);
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Wall") {
			if (direction == 1) {
				direction = -1;
			} else {
				direction = 1;
			}
		}

		if (other.tag == "Target") {
			if (direction == 1) {
				direction = -1;
			} else {
				direction = 1;
			}
		}

		if (other.tag == "Cube") {
			if (direction == 1) {
				direction = -1;
			} else {
				direction = 1;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Sphere") {
			other.transform.parent = null;
		}
	}


}