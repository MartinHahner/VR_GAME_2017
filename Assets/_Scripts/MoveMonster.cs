using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move_Monster : MonoBehaviour {
	public float monster_speed;

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 0, 1*monster_speed) * Time.deltaTime);
	}
}
