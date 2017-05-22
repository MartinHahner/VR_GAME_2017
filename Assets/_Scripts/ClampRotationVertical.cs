using UnityEngine;
using System.Collections;

public class ClampRotationVertical : MonoBehaviour {
    private float VertMax = 179;
    private float VertMin = -179;
    Vector3 curRot;
	// Use this for initialization
	void Start () {
        curRot = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        curRot.z = Mathf.Clamp(curRot.z, VertMax, VertMin);

        this.transform.eulerAngles = curRot;
	}
}
