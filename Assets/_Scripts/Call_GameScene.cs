using UnityEngine;
using System.Collections;

public class Call_GameScene : MonoBehaviour {

	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;
	}

	//void OnTriggerEnter(Collider other) {
		void OnMouseDown(){	
		Application.LoadLevel ("CannonGame");
	}
}
