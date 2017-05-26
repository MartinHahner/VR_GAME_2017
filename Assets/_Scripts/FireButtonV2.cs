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
    SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjR;
    SteamVR_Controller.Device deviceL;
    public SteamVR_TrackedObject trackedObjL;

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
		GetComponent<CapsuleCollider> ().isTrigger = true;
        deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        deviceL = SteamVR_Controller.Input((int)trackedObjL.index);

    }

	void OnTriggerEnter(Collider other) {
        Debug.Log("Cannon touched");
//		if (Input.GetButton("Fire1") && Time.time > NextFire)
		if (Time.time > NextFire)
		{
			NextFire = Time.time + FireRate;
			Instantiate (Flash, shotSpawn.position, shotSpawn.rotation);// as GameObject;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 

			/*
			if(other.tag == "Player")
			{
				device.TriggerHapticPulse(1000);
				//https://forum.unity3d.com/threads/issue-with-triggerhapticpulse-vive-controller.411081/
			}
			*/

		}
        

        if (other.gameObject.tag == "controller")
        {
            rumbleController();
        }
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
}
