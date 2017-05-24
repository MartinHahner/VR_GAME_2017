using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireButtonV2 : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate = 0.5F;

	public GameObject Flash;
	private Quaternion rot;
	private Vector3 pos;

    private float NextFire = 0.0F;

	SteamVR_Controller.Device device;
	SteamVR_TrackedObject trackedObj;

	void Awake ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void FixedUpdate()
	{
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}

	void MuzzleFlash(){
		rot = shotSpawn.rotation;
		pos = shotSpawn.position;
		GameObject MFlash = Instantiate (Flash, pos, rot) as GameObject;
	}
	private List<GameObject> collidingObjects = new List<GameObject>();

	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;
		if(device.GetPressDown (SteamVR_Controller.ButtonMask.Grip))
		{
			device.TriggerHapticPulse(1000);	
		}
	}

	void OnTriggerEnter(Collider other) {
//		if (Input.GetButton("Fire1") && Time.time > NextFire)
		if (Time.time > NextFire)
		{
			NextFire = Time.time + FireRate;
			// Instantiate(object, position, rotation);
			Instantiate (Flash, shotSpawn.position, shotSpawn.rotation);// as GameObject;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 


		}
	}
}
