using UnityEngine;
using System.Collections;

public class velocity : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = transform.forward * 10;
	}
}
