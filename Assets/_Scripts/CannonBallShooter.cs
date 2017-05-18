// author: David Guralnick

System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShooter : MonoBehaviour {

	public float timer = 3f;
	public float speed = 5f;

	void Start(){
		Invoke ("DestroyProjectile", timer);
	}

	void DestroyProjectile(){
		Destroy (gameObject);	
	}
			
}
