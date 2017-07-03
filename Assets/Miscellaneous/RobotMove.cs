using UnityEngine;
using System.Collections;

public class RobotMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		float x = 36.69F; //Initial position of x
		float y = 17.35F; //Initial position of y, should always stay the same
		float z = 32F; // Initial position of z

		if (Input.GetKeyDown (KeyCode.F1)) { //starting position(x,z) = (36.69, 32)
			transform.position = new Vector3 (x,y,z);
		}

		if (Input.GetKeyDown (KeyCode.F2)) { //slight shift to the left (x,z) = (39, 32)
			transform.position = new Vector3 (39, y, z);
		}

		if (Input.GetKeyDown (KeyCode.F3)) { //middle of the room (x,z) = (38.27,33.41)
			float xTemp = 38.27F;
			float zTemp = 33.41F;
			transform.position = new Vector3 (xTemp, y, zTemp);
		}

		if (Input.GetKeyDown(KeyCode.F4)) { //In front of the board (x,z) = (40.36,34.72)
			float xTemp = 40.36F;
			float zTemp = 34.72F;
			transform.position = new Vector3 (xTemp, y, zTemp);
		}

		if (Input.GetKeyDown(KeyCode.F5)) {// In front of TV (x,z) = (37.49,34.72)
			float xTemp = 37.49F;
			float zTemp = 34.72F;
			transform.position = new Vector3 (xTemp, y, zTemp);
		}
}
}