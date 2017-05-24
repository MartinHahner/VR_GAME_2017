using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class boundaries
{
	public float xVal, yVal, xTemp, yTemp, xRots, yRots, xTotDeg, yTotDeg, xTotDegLast, yTotDegLast, CannonX, CannonY;
}

public class MoveCannon : MonoBehaviour {

	public GameObject TurnStyle_Vertical;
	public GameObject TurnStyle_Horiztal;
	public Transform cannonPose;

	public boundaries Boundaries;

	public GameObject clinkSoundClip;
	public float timeSound;
	public float timeTrack;
    public float GearClickX;
    public float GearClickXLast;
    public float GearClickY;
    public float GearClickYLast;
    private bool Init = true;

	/*
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
	public float CannonY = 0;*/





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
		Boundaries.yVal = TurnStyle_Vertical.transform.eulerAngles.z;
		Boundaries.xVal = TurnStyle_Horiztal.transform.eulerAngles.z;



		//count number of rotations of wheels by counting flips from 0 to 360 or 360 to 0
		//limits count to 3 rotations
		if ((Boundaries.xVal < 10f && Boundaries.xTemp > 350f) && (Boundaries.xRots < 1)) {
			Boundaries.xRots += 1;
		}
		if ((Boundaries.xVal > 350f && Boundaries.xTemp < 10f) && (Boundaries.xRots > -1)) {
			Boundaries.xRots -= 1;
		}
		if ((Boundaries.yVal < 10f && Boundaries.yTemp > 350f) && (Boundaries.yRots < 1)) {
			Boundaries.yRots += 1;
		}
		if ((Boundaries.yVal > 350f && Boundaries.yTemp < 10f) && (Boundaries.yRots > -1)) {
			Boundaries.yRots -= 1;
		}

		//Update total degrees rotated

		//Limits Cannon to +/- 60 Deg Vertical
		/*if (xRots == 3) { 
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
		}*/

		if (Boundaries.yRots == 0)
        {
			Boundaries.yTotDeg = Boundaries.yVal;
        }
		if (Boundaries.xRots == 0)
        {
			Boundaries.xTotDeg = Boundaries.xVal;
        }
        



        //scale Cannon rotation to be equal to +/- 30Deg per Turner rotation
		Boundaries.CannonX = (Boundaries.xTotDeg / 3f)-60;
		Boundaries.CannonY = -(Boundaries.yTotDeg / 3f) - 120; // set's initial pose to correct orientation

		GearClickX = Boundaries.CannonX;
		GearClickY = Boundaries.CannonY;
        while(Init)
        {
			GearClickXLast = Boundaries.CannonX;
			GearClickYLast = Boundaries.CannonY;
            Init = false;
        }

        //Update Cannon Orientation
		cannonPose.rotation = Quaternion.Euler (Boundaries.CannonX, Boundaries.CannonY, 0);


		//Save current iteration values for future comparison
		Boundaries.xTemp = Boundaries.xVal;
		Boundaries.yTemp = Boundaries.yVal;

		if ((Mathf.Abs(GearClickXLast - GearClickX) > 5 || Mathf.Abs(GearClickY - GearClickYLast) > 5) && (timeTrack - timeSound) > 0.3f) {
				GameObject clink = Instantiate (clinkSoundClip, cannonPose.transform.position, Quaternion.identity) as GameObject;
				timeSound = timeTrack;
                GearClickXLast = GearClickX;
                GearClickYLast = GearClickY;
			
		}

		Boundaries.xTotDegLast = Boundaries.xTotDeg;
		Boundaries.yTotDegLast = Boundaries.yTotDeg;
		timeTrack += Time.deltaTime;
	
	}
}
