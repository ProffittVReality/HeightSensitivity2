using UnityEngine;
using System.Collections;

public class GetPosition : MonoBehaviour {

	string xPosition;
	string zPosition;
	public string finalPosition;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		//if (OVRGamepadController.GPC_GetButtonDown(button:0)) { //Press the A button on the xbox controller to log the current position
		//	xPosition = transform.position.x.ToString();
		//	zPosition = transform.position.z.ToString();
		//	finalPosition = "x position: " + xPosition + " z position: " + zPosition;
		//	Debug.Log (finalPosition);
		//}

		/*if (OVRGamepadController.GPC_GetButtonDown(button:0) || Input.GetKeyDown(KeyCode.Space)) { //Press the A button on the xbox controller to log the current position
			xPosition = transform.position.x.ToString();
			zPosition = transform.position.z.ToString();
			finalPosition = "x position: " + xPosition + " z position: " + zPosition;
			Debug.Log (finalPosition);
		}*/
	}
}
