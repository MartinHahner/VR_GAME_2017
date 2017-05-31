using UnityEngine;
using System.Collections;

public class Call_EasyGameScene : MonoBehaviour {

	SteamVR_Controller.Device deviceR;
	public SteamVR_TrackedObject trackedObjR;
	SteamVR_Controller.Device deviceL;
	public SteamVR_TrackedObject trackedObjL;

	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;
		deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
		deviceL = SteamVR_Controller.Input((int)trackedObjL.index);
	}

	void rumbleController()
	{

		StartCoroutine(LongVibration(1, 3999));

	}

	IEnumerator LongVibration(float length, float strength)
	{
		for (float i = 0; i < length; i += Time.deltaTime)
		{
			deviceR.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
			deviceL.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
			yield return null;
		}
	}

	void OnTriggerEnter(Collider other) {
		//void OnMouseDown(){
		if (other.gameObject.tag == "controller")
		{
			rumbleController();
		}
		Application.LoadLevel ("Easy_CannonGame");
	}
}
