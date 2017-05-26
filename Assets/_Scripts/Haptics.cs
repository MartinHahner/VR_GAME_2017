using UnityEngine;
using System.Collections;

public class Haptics : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

	void Awake ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void FixedUpdate()
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag = "Player") {
			rumbleController ();
		}
	}

	void rumbleController ()
	{
		
				StartCoroutine(LongVibration(1,3000));

	}

	IEnumerator LongVibration(float length, float strength)
	{
		for(float i = 0; i < length; i += Time.deltaTime)
		{
			device.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
			yield return null;
		}
	}
}
