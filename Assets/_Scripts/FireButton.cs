using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour {

	public Transform CannonTip;
	public GameObject prefab;
	public Transform parentCB;

	public GameObject Flash;


	private Quaternion rot;
	private Vector3 pos;

	public float speed = 1;
	public float timer = .5f;
	private Quaternion rotMF;
	private Vector3 posMF;

    private int count;

    void OnMouseDown(){

		Shoot ();
		MuzzleFlash ();

	}

	void Shoot(){
		rot = CannonTip.rotation;
		pos = CannonTip.position;
		GameObject projectile = (GameObject) Instantiate (prefab, pos, rot, parentCB);
		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * 30;
	}

	void MuzzleFlash(){
		rot = CannonTip.rotation;
		pos = CannonTip.position;
		GameObject MFlash = Instantiate (Flash, pos, rot) as GameObject;
	}
}
