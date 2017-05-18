﻿using UnityEngine;
using System.Collections;

public class MuzzleEffect : MonoBehaviour {

	public float lifetime;
	// Use this for initialization
	void Start () {

	}

	void OnEnable()
	{
		Invoke ("SetAct", lifetime);
	}

	void SetAct(){
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {

	}
}
