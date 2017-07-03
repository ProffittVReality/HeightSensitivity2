using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	//public GameObject robotBody;
	public Camera mobileCam1;
	public Camera mobileCam2;
	public Camera mobileCam3;
	public Camera mobileCam4;
	public Camera bodyCamera;
	public Camera overheadCamera;
	public Renderer robot;
	public Renderer target;
	public Renderer PlayerLimit;

	// Use this for initialization
	void Start () {
		bodyCamera.enabled = true;
		mobileCam1.enabled = false;
		mobileCam2.enabled = false;
		mobileCam3.enabled = false;
		mobileCam4.enabled = false;
		overheadCamera.enabled = false;
		robot.enabled = true;
		target.enabled = false;
		PlayerLimit.enabled = true;
	}

	// Update is called once per frame
	void Update () { 
		if (Input.GetKeyDown (KeyCode.Alpha1)) { // first person view 
			bodyCamera.enabled = true;
			mobileCam1.enabled = false;	
			mobileCam2.enabled = false;
			mobileCam3.enabled = false;
			mobileCam4.enabled = false;
			overheadCamera.enabled = false;
			robot.enabled = true;
			target.enabled = false;
			PlayerLimit.enabled = true;

		}

		if (Input.GetKeyDown(KeyCode.Alpha5)){ //mobile camera 1
			bodyCamera.enabled = false;
			overheadCamera.enabled = false;
			mobileCam1.enabled = true;
			mobileCam2.enabled = false;
			mobileCam3.enabled = false;
			mobileCam4.enabled = false;
			robot.enabled = true;
			target.enabled = false;
			PlayerLimit.enabled = true;

		}

		if (Input.GetKeyDown(KeyCode.Alpha2)){ //mobile camera 2
			bodyCamera.enabled = false;
			overheadCamera.enabled = false;
			mobileCam1.enabled = false;
			mobileCam2.enabled = true;
			mobileCam3.enabled = false;
			mobileCam4.enabled = false;
			robot.enabled = true;
			target.enabled = false;
			PlayerLimit.enabled = true;

		}

		if (Input.GetKeyDown(KeyCode.Alpha3)){ //mobile camera 3
			bodyCamera.enabled = false;
			overheadCamera.enabled = false;
			mobileCam1.enabled = false;
			mobileCam2.enabled = false;
			mobileCam3.enabled = true;
			mobileCam4.enabled = false;
			robot.enabled = true;
			target.enabled = false;
			PlayerLimit.enabled = true;

		}

		if (Input.GetKeyDown(KeyCode.Alpha4)){ //mobile camera 4
			bodyCamera.enabled = false;
			overheadCamera.enabled = false;
			mobileCam1.enabled = false;
			mobileCam2.enabled = false;
			mobileCam3.enabled = false;
			mobileCam4.enabled = true;
			robot.enabled = true;
			target.enabled = false;
			PlayerLimit.enabled = true;

		}

		if (Input.GetKeyDown(KeyCode.Alpha6)){ //overhead camera
			bodyCamera.enabled = false;
			mobileCam1.enabled = false;	
			mobileCam2.enabled = false;
			mobileCam3.enabled = false;
			mobileCam4.enabled = false;
			overheadCamera.enabled = true;
			robot.enabled = false;
			target.enabled = true;
			PlayerLimit.enabled = false;

		}
}
}