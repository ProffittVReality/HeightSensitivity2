using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using Valve.VR;

[System.Serializable]
public class TeleportLocation {
	public Vector3 location1;
	public Vector3 location2;
	public Vector3 location3;
	public Vector3 location4;
	public Vector3 location5;
	public Vector3 location6;
}

[RequireComponent(typeof(AudioSource))]
public class ShadowAndHeightController : MonoBehaviour
{
	private enum Option {
		RoomA = 0,
		RoomB = 1
	};

	public GameObject camShadow;

	public GameObject cameraRig;
	public GameObject tracker;
	public GameObject floor;
	public GUI_Handler gui;
	public float maxTrialTime = 30;
	public KeyCode switchRoom = KeyCode.Z;
	public KeyCode selectA = KeyCode.X;
	public KeyCode selectB = KeyCode.C;
	public UnityEngine.UI.Text roomText;

	public float initialHeightGapScalar;
	float maxHeightGapScalar;
	float heightGapScalar;
	private int heightGapSign;

	[HideInInspector]
	public float subjectHeight;

	public float maxHeightMultiplier = 0.6f; // decrement in maxGainProportion from block to block
	public float heightDecrementMultiplier = 0.6f; // change in trial decrement from block to block
	public float heightDecrement = 0.05f; // initial gain decrement

	private int failedBlocks = 0;
	private int maxFailedBlocks = 4;
	private bool started = false;

	private int trials = 0;
	private int correctTrials = 0;
	private int minTrialsToPass = 7;
	private int maxTrials = 10;

	private Option wrongHeightRoom;
	private Option selectedRoom;

	private AudioSource chimes;
	private bool chimesPlayed = false;
	private float timer = 0;

	[HideInInspector]
	public Vector3 cameraRigInitCoordinates;
	private int previousPosition;

	private System.Random random;
	public TeleportLocation teleportLocations;
	Vector3[] teleportSpots;

	public Animator anim;

	bool madeSelection = false;

	void Start()
	{
		chimes = this.gameObject.GetComponent<AudioSource>();
		random = new System.Random();
		wrongHeightRoom = (Option)random.Next(2);
		selectedRoom = Option.RoomA;
		SetRoomText(selectedRoom);

		maxHeightGapScalar = initialHeightGapScalar;
		heightGapScalar = initialHeightGapScalar;

		cameraRigInitCoordinates = cameraRig.transform.position;

		heightGapSign = 2 * random.Next (2) - 1; // random -1 or 1

		subjectHeight = tracker.transform.position.y - floor.transform.position.y;

		teleportSpots = new Vector3[6]{teleportLocations.location1, teleportLocations.location2, teleportLocations.location3, teleportLocations.location4, teleportLocations.location5, teleportLocations.location6};

	}

	void Update()
	{

		if (!started)
			return;

		timer += Time.deltaTime;
		if (timer > maxTrialTime && !chimesPlayed) {
			chimes.Play();
			chimesPlayed = true;
		}

		if ((Input.GetKeyDown(switchRoom) || madeSelection) && !gui.isVisible)//Change height
		{

			selectedRoom = selectedRoom == Option.RoomA ? Option.RoomB : Option.RoomA; // switches the room (A goes to B, B goes to A)
			timer = 0;
			chimesPlayed = false;

			// conditions for immediately after subject chooses A or B
			if (madeSelection)
				selectedRoom = Option.RoomA;
			madeSelection = false;

			SetRoomText(selectedRoom);

			if (selectedRoom == wrongHeightRoom && !gui.isVisible) {
				// set incorrect height
				float heightGap = subjectHeight * heightGapScalar;
				StartCoroutine(ChangeHeightAndTeleport(cameraRigInitCoordinates.y + (heightGap*heightGapSign)));
			}
			else {
				// set back to correct height
				StartCoroutine(ChangeHeightAndTeleport(cameraRigInitCoordinates.y));
			}
		}




		if (Input.GetKeyUp(selectA) || Input.GetKeyUp(selectB) && !gui.isVisible) //User answers
		{
			madeSelection = true;
			bool? correct = null;
			trials += 1;
			timer = 0f;
			chimesPlayed = false;

			if (Input.GetKeyUp(selectA)) //A is rotatings
			{
				correctTrials += wrongHeightRoom == Option.RoomA ? 1 : 0;
				correct = wrongHeightRoom == Option.RoomA;

				Debug.Log ("Selected A");
			}
			else if (Input.GetKeyUp(selectB)) //B is rotating
			{
				correctTrials += wrongHeightRoom == Option.RoomB ? 1 : 0;
				correct = wrongHeightRoom == Option.RoomB;

				Debug.Log ("Selected B");
			}

			Debug.Log(string.Format("Failed Trials: {0}, Number Answered: {1}, Number Right: {2}, Gain: {3}", failedBlocks, trials, correctTrials, heightGapScalar * heightGapSign));
			gui.exportData(new List<string> {correct.ToString(), subjectHeight.ToString(), (heightGapSign * heightGapScalar).ToString(), (heightGapSign*heightGapScalar*subjectHeight).ToString(), correctTrials.ToString(), heightDecrement.ToString(), (heightDecrement*subjectHeight).ToString()});

			heightGapScalar -= heightDecrement;

			if (trials >= maxTrials)
			{
				if (correctTrials >= minTrialsToPass)
				{
					maxHeightGapScalar *= maxHeightMultiplier;
					heightDecrement *= heightDecrementMultiplier;
				}
				else
				{
					failedBlocks += 1;
				}

				heightGapScalar = maxHeightGapScalar;
				trials = 0;
				correctTrials = 0;
			}

			wrongHeightRoom = (Option)random.Next(2);
			selectedRoom = Option.RoomA;
			SetRoomText(selectedRoom);
			heightGapSign *= -1;

			if (failedBlocks >= maxFailedBlocks)
			{
				Application.Quit();
				UnityEditor.EditorApplication.isPlaying = false;
			}
		}
	}

	public void StartExperiment() {
		if (!started) {
			Debug.Log("Started");
			/*roomObject.transform.Rotate(Vector3.down * random.Next(360));
			roomObject.transform.position = Vector3.zero;*/
		}
		started = true;
	}

	void SetRoomText(Option o) {
		if (o == Option.RoomA)
			roomText.text = "Room A";
		else if (o == Option.RoomB)
			roomText.text = "Room B";
	}

	IEnumerator ChangeHeightAndTeleport(float newHeight) {
		// start light to dark animation
		anim.SetTrigger("blink");
		yield return new WaitForSeconds(0.2f);

		// change height and teleport
		float rotation = random.Next(360);
		cameraRig.transform.Rotate (new Vector3 (0, rotation, 0));

		int teleportIndex = random.Next (6);
		// prevent same location twice in a row
		while (teleportIndex == previousPosition)
			teleportIndex = random.Next(6);
		previousPosition = teleportIndex;

		Vector3 newPosition = teleportSpots [teleportIndex];
		newPosition.y = newHeight;
		cameraRig.transform.position = newPosition;

		StartCoroutine (StopTrigger ());
	}

	IEnumerator StopTrigger() {
		yield return new WaitForSeconds (0.7f);
		anim.SetTrigger ("stop");
	}
}

