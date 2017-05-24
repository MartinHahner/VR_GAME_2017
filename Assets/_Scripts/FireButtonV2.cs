using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireButtonV2 : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate = 0.5F;
	private int i = 1;

	public GameObject Flash;
	private Quaternion rot;
	private Vector3 pos;

    private float NextFire = 0.0F;

	/*
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;



	private void Awake ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void FixedUpdate()
	{
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}*/

	void MuzzleFlash(){
		rot = shotSpawn.rotation;
		pos = shotSpawn.position;
		GameObject MFlash = Instantiate (Flash, pos, rot) as GameObject;
	}
	private List<GameObject> collidingObjects = new List<GameObject>();

	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;
	}

	void OnTriggerEnter(Collider other) {
//		if (Input.GetButton("Fire1") && Time.time > NextFire)
		if (Time.time > NextFire)
		{
			NextFire = Time.time + FireRate;
			Instantiate (Flash, shotSpawn.position, shotSpawn.rotation);// as GameObject;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 

			/*
			if(i==1)
			{
				device.TriggerHapticPulse(1000);
				//https://forum.unity3d.com/threads/issue-with-triggerhapticpulse-vive-controller.411081/
			}
			*/

		}
	}
}
