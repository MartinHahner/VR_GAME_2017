using UnityEngine;
using System.Collections;

public class Call_StartScene : MonoBehaviour {

	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;
	}

	void OnTriggerEnter(Collider other) {
		
		Application.LoadLevel ("Start_CannonGame");
	}
}
