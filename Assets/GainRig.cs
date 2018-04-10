using System.IO;
using UnityEngine;
using VR = UnityEngine.VR;






public class GainRig : MonoBehaviour {
	///var other : GameObject;
	
	public float GainAmount = 1.0f;
	public float GainCompare = 1.0f;
	//public float GainStart = 2.0f;
	public float GainMax = 0.9f;
	public float GainMin = -0.9f;
	public Vector3 center_location;
	public int four_times_fail = 0;
	public int seven_times_pass = 0;
	public int ten_times = 0;
	public float decrement = 0.0f;
	public float alter_dec = 0.1f;
	public bool ten_check = false;
	public bool seven_check = true;
	public bool flop_down = false;
	public string file_name = System.DateTime.Now.ToString("MMMM dd, yyyy");
	public string participant_number = "";
	public bool realGainFirst = false;
	public bool realGainSecond = false;

	private Transform cameraTransform;
	private Vector3 originalCameraPosition;

	// Use this for initialization
	//CharacterController controller;
	void Start () {	
		cameraTransform = this.gameObject.transform.GetChild(0);
	}
	
	// Update is called once per frame
	// Moves CameraRig by GainAmount
	// We need to subtract 1 because CameraRig is already moving itself to the CenterEye localPosition
	// KEY PRESS ORDER SHOULD BE ENTER => PLUS => 0 OR 1 || A => B => X OR Y


	void Update () {
		Vector3 cameraLocalPos = cameraTransform.localPosition;
		transform.localPosition = new Vector3(0, GainAmount - 1, 0) + VR.InputTracking.GetLocalPosition(VR.VRNode.CenterEye);
		//cameraTransform.localPosition = new Vector3(0, GainAmount - 1, 0) + VR.InputTracking.GetLocalPosition(VR.VRNode.CenterEye);
		//controller.height = (controller.height + GainAmount);


		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			cameraLocalPos.y -= 0.5f;
			cameraTransform.localPosition = cameraLocalPos;
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			cameraLocalPos.y -= 0.25f;
			cameraTransform.localPosition = cameraLocalPos;
		}
		if (Input.GetKeyDown(KeyCode.Keypad5))
		{
			cameraLocalPos.y += 0.0001f;
			cameraTransform.localPosition = cameraLocalPos;   
		}
		if (Input.GetKeyDown(KeyCode.Keypad9))
		{
			cameraLocalPos.y += 0.25f;
			cameraTransform.localPosition = cameraLocalPos;
		}
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			cameraLocalPos.y += 0.5f;
			cameraTransform.localPosition = cameraLocalPos;
		}
		if (alter_dec < 0.00003) //Allows for up to 10 successes
		{
			Application.Quit();
			Debug.Break();
		}
		if (four_times_fail < 4)
		{
			if (ten_times < 10)////add this: seven_times_pass < 7 && if you want it to advance after 7 correct
			{
				if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown("joystick button 0")) //User enters A or Enter to begin trial, configures the first of the tuple of Gain Values [e.g. (1.9, 1) => 1.9] 
				{
					System.Random rand = new System.Random();
					int rand_gain = rand.Next(0, 10);
					//System.Random degree_rotate = new System.Random();
					//float headset_rotate = rand.Next(0, 360);
					if (flop_down) //If true, tuple of Gain Values will contain the Minimum instead of the Maximum [0.1 instead of 1.9]
					{
						if (rand_gain < 5) //If random number is less than 5, gain amount will be at extreme
						{
							GainAmount = GainMin + decrement; UnityEngine.VR.InputTracking.Recenter();
							GainCompare = GainAmount;
							realGainFirst = false;
						}
						else
						{
							GainAmount = 1.00001f; UnityEngine.VR.InputTracking.Recenter();
							realGainFirst = true;
						}
					}
					else
					{
						if (rand_gain < 5) //If random number is less than 5, gain amount will be at extreme
						{
							GainAmount = GainMax - decrement; UnityEngine.VR.InputTracking.Recenter();
							GainCompare = GainAmount;
							realGainFirst = false;
						}
						else
						{
							GainAmount = 1.00001f; UnityEngine.VR.InputTracking.Recenter();
							realGainFirst = true;
						}
					}
					
				}
				else if (Input.GetKeyDown (KeyCode.KeypadPlus) || Input.GetKeyDown("joystick button 1")) //User enters B or Plus to configure the second of the tuple of Gain Values [e.g. (1.9, 1) => 1]
				{
					if (flop_down)
					{
						if (GainAmount == 1.00001f)
						{
							GainAmount = GainMin + decrement; UnityEngine.VR.InputTracking.Recenter();
							GainCompare = GainAmount;
							flop_down = false;
							realGainSecond = false;
						}
						else
						{
							GainAmount = 1.00001f; UnityEngine.VR.InputTracking.Recenter();
							flop_down = false;
							realGainSecond = true;
						}
					}
					else
					{
						if (GainAmount == 1.00001f)
						{
							GainAmount = GainMax - decrement; UnityEngine.VR.InputTracking.Recenter();
							GainCompare = GainAmount;
							flop_down = true;
							realGainSecond = false;
						}
						else
						{
							GainAmount = 1.00001f; UnityEngine.VR.InputTracking.Recenter();
							flop_down = true;
							realGainSecond = true;
						}
					}
					
				}
				
				if ((Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown("joystick button 2")) && realGainFirst && seven_check == true)
				{
					seven_times_pass++;
					decrement += alter_dec;
					seven_check = true;
					ten_times++;
				}
				
				else if ((Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown("joystick button 2")) && realGainSecond)
				{
					ten_times++;
					seven_check = true;
					//seven_times_pass = 0;
				}
				
				else if ((Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown("joystick button 3")) && realGainFirst)
				{
					ten_times++;
					seven_check = true;//make these false and add in the expression below if you want to reset the 7 counter
					//seven_times_pass = 0;
				}
				
				else if ((Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown("joystick button 3")) && realGainSecond && seven_check == true)
				{
					seven_times_pass++;
					decrement += alter_dec;
					seven_check = true;
					ten_times++;
				}
				
				
				else if ((Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown("joystick button 2")) && realGainFirst && seven_times_pass == 0)
				{
					seven_times_pass++;
					decrement += alter_dec;
					seven_check = true;
					ten_times++;
				}
				
				else if ((Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown("joystick button 3")) && realGainSecond && seven_times_pass == 0)
				{
					seven_times_pass++;
					decrement += alter_dec;
					seven_check = true;
					ten_times++;
				}
				
				if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown("joystick button 2")) //User enters X or 1 to indicate "First Value is Gain of 1" 
				{
					string text = realGainFirst + "," + " Picked first. Saw: " + GainCompare + "," + "Times Correct: " + seven_times_pass + ","  + " Decrement:" + alter_dec + "\r\n";
					string path = "C:\\VRExperiments\\HeightData\\" + participant_number + " " + file_name +  ".txt";
					using (StreamWriter writer = new StreamWriter(path, true))
					{
						writer.Write(text);
					}
					
				}
				
				else if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown("joystick button 3")) //User enters Y or 0 to indicate "Second Value is Gain of 1"
				{
					string text = realGainSecond + "," + " Picked second. Saw: " + GainCompare + "," + "Times Correct: " + seven_times_pass + "," + " Decrement:" + alter_dec + "\r\n";
					string path = "C:\\VRExperiments\\HeightData\\" + participant_number + " " + file_name +  ".txt";
					using (StreamWriter writer = new StreamWriter(path, true))
					{
						writer.Write(text);
					}
				}
				
			}
			else if (seven_times_pass >= 7 && ten_times == 10) //(seven_times_pass >= 7) //&& (ten_times == 10)
			{
				decrement = 0.0f;
				alter_dec /= 2;
				seven_times_pass = 0;
				ten_times = 0;
				GainMax = 1 + alter_dec * 10;
				GainMin = 1 - alter_dec * 10;
			}
			else if (ten_times == 10)
			{
				four_times_fail++;
				ten_times = 0;
				seven_times_pass = 0;
				decrement = 0.0f;
			}
		}
		else
		{
			Application.Quit();
		}
		
		
		/*if (Input.GetKeyDown (KeyCode.Alpha1)) { 
			GainAmount = 0.75f; UnityEngine.VR.InputTracking.Recenter();//transform.localPosition = center_location;    
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)){
			GainAmount = 0.8f; UnityEngine.VR.InputTracking.Recenter();   
        }
		else if (Input.GetKeyDown (KeyCode.Alpha3)){
			GainAmount = 0.85f; UnityEngine.VR.InputTracking.Recenter();  
        }
		else if (Input.GetKeyDown (KeyCode.Alpha4)){
			GainAmount = 0.9f; UnityEngine.VR.InputTracking.Recenter();
        }
		else if (Input.GetKeyDown (KeyCode.Alpha5)){
			GainAmount = 0.95f; UnityEngine.VR.InputTracking.Recenter();
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)){
			GainAmount = 1.05f; UnityEngine.VR.InputTracking.Recenter();
		} 
		else if (Input.GetKeyDown (KeyCode.Alpha7)){
			GainAmount = 1.1f; UnityEngine.VR.InputTracking.Recenter();
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8)){
			GainAmount = 1.15f; UnityEngine.VR.InputTracking.Recenter();
		}
		else if (Input.GetKeyDown (KeyCode.Alpha9)){
			GainAmount = 1.20f; UnityEngine.VR.InputTracking.Recenter();
		}
		else if (Input.GetKeyDown (KeyCode.Alpha0)){
			GainAmount = 1.25f; UnityEngine.VR.InputTracking.Recenter();
		}
		else if (Input.GetKeyDown (KeyCode.Backspace)){
			GainAmount = 1.0f; UnityEngine.VR.InputTracking.Recenter();
		}*/
		
		
		
	}
	
}
