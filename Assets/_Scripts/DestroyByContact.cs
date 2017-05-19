﻿using UnityEngine;


public class DestroyByContact : MonoBehaviour 
{

	public GameObject explosion;

	// This code destroys Canon Ball and Monster!
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
