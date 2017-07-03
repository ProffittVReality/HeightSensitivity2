using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;

public class GUI_Handler : MonoBehaviour {

	public GameObject menu; //Assign canvas to this in inspector, make sure script is on EventHandler
	public KeyCode hideShow; //Set to the key you want to press to open and close the GUI
	public string FileName; //Title the file you want to export data to!  Will be saved in Data.

	private bool isShowing;
	public InputField raName, partic,exp,age,height,weight,other; 
	//TODO: Ask around to see if there's a more efficient and elegant method to get references to all of the input fields!
	public Toggle left, right;
	public Dropdown sex, heels, subjectPosition;
	public Text sexLabel, heelsLabel, subjectPosLabel;
	public Button export;
	//Following is requirement for googleHeightStudies!  Can also be customized for other sripts
	public GetPosition cylinder;
	public bool isVisible {
		get {
			return menu.activeSelf;
		}
	}

	public HeightController heightController;


	// Use this for initialization
	void Start () {
		isShowing = true;
		//export.onClick.AddListener (exportData);

		if (FileName.Equals (""))
			FileName = "default";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (hideShow)) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);

			heightController.StartExperiment();
		}
	}

	public void exportData(List<string> data) {
		string path = @"Assets\Data\" + FileName + ".csv";
		string theDate = DateTime.Now.ToString ();
		if (!File.Exists (path)) {
			string header = "Time,RAName,Participant#,Experiment#,Age,Height,Weight,Gender,Heels,Hand,Position,Detected,MeasuredHeight,HeightDifference(%),HeightDifference(UnityUnits),CorrectCount,StepSize(%),StepSize(UnityUnits),Other\n";
			File.WriteAllText (path, header);
		}
		string hand = "";
		if (left.isOn)
			hand = hand + "L";
		if (right.isOn)
			hand = hand + "R";

		string dataText = "";
		foreach(string item in data) {
			dataText += "," + item;
		}
		string fixedData = theDate + "," + raName.text + "," + partic.text + "," + exp.text + "," + age.text + "," + height.text + "," + weight.text
			+ "," + sexLabel.text + "," + heelsLabel.text + "," + hand + "," + subjectPosLabel.text;
		string appendText = fixedData + dataText + "," + other.text + "\n";
		File.AppendAllText (path, appendText);
	}

}
