using UnityEngine;
using System.Collections;

public class Call_GameScene : MonoBehaviour {

	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;
	}

	void OnTriggerEnter(Collider other) {
		
		Application.LoadLevel ("CannonGame");
	}
}
