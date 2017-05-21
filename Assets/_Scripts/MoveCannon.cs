using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannon : MonoBehaviour {

	public GameObject TurnStyle_Vertical;
	public GameObject TurnStyle_Horiztal;
	public Transform cannonPose;

	public GameObject soundClip;
	public float timeSound;
	public float timeTrack;

	public float xVal = 0;
	public float yVal = 0;
	public float xTemp = 0;
	public float yTemp = 0;

	public int xRots = 0;
	public int yRots = 0;

	public float xTotDeg = 0;
	public float yTotDeg = 0;
	public float xTotDegLast = 0;
	public float yTotDegLast = 0;


	public float CannonX = 0;
	public float CannonY = 0;





	void Start () {
		TurnStyle_Vertical = GameObject.FindWithTag ("Vertical");
		TurnStyle_Horiztal = GameObject.FindWithTag ("Horizontal");
		cannonPose = transform;

		timeSound = Time.deltaTime;
		timeTrack = Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {

		//Get current orientation of z-axis for both the Vertical_Turner and the Horizontal_Turner
		yVal = TurnStyle_Vertical.transform.eulerAngles.z;
		xVal = TurnStyle_Horiztal.transform.eulerAngles.z;



		//count number of rotations of wheels by counting flips from 0 to 360 or 360 to 0
		//limits count to 3 rotations
		if ((xVal < 10f && xTemp > 350f) && (xRots < 3)) {
			xRots += 1;
		}
		if ((xVal > 350f && xTemp < 10f) && (xRots > -4)) {
			xRots -= 1;
		}
		if ((yVal < 10f && yTemp > 350f) && (yRots < 3)) {
			yRots += 1;
		}
		if ((yVal > 350f && yTemp < 10f) && (yRots > -4)) {
			yRots -= 1;
		}

		//Update total degrees rotated

		//Limits Cannon to +/- 60 Deg Vertical
		if (xRots == 3) { 
			xTotDeg = (xRots * 360);
		} else if (xRots == -4) {
			xTotDeg = ((xRots + 1) * 360);
		} else {
			xTotDeg = (xRots * 360) + xVal;
		}



		//limits Cannon to +/- 60 Deg Horizontal
		if (yRots == 3) { 
			yTotDeg = (yRots * 360);
		} else if (yRots == -4) {
			yTotDeg = ((yRots + 1) * 360);
		} else {
			yTotDeg = (yRots * 360) + yVal;
		}

		//scale Cannon rotation to be equal to +/- 30Deg per Turner rotation
		CannonX = -(xTotDeg / 18f);
		CannonY = (yTotDeg / 18f) - 180; // set's initial pose to correct orientation

		//Update Cannon Orientation
		cannonPose.rotation = Quaternion.Euler (CannonX, CannonY, 0);


		//Save current iteration values for future comparison
		xTemp = xVal;
		yTemp = yVal;

		if (Mathf.Abs (xTotDeg - xTotDegLast) > 2 || Mathf.Abs (yTotDeg - yTotDegLast) > 2) {
			if (timeTrack - timeSound > 0.06f) {
				GameObject clink = Instantiate (soundClip, cannonPose.transform.position, Quaternion.identity) as GameObject;
				timeSound = timeTrack + 0.06f;
			}
		}

		xTotDegLast = xTotDeg;
		yTotDegLast = yTotDeg;
		timeTrack += Time.deltaTime;
	
	}
}
