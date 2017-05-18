using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStyle : MonoBehaviour {


	private float baseAngle = 0.0f;


	void OnMouseDown() {
		Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - dir;
		baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
	}

	void OnMouseDrag ()
	{
		Vector3 dir = Camera.main.WorldToScreenPoint (transform.position);
		dir = Input.mousePosition - dir;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - baseAngle;
		transform.rotation = Quaternion.AngleAxis (-angle, Vector3.forward);

	}
}
	
	

//	public void OnMouseEnter()
//	{
//		Debug.Log ("ENTER");
//		enter = true;
//	 
//	}
//
//	public void OnMouseExit()
//	{
//		Debug.Log ("EXIT");
//		enter = false;
//
//	}
//
//	public void OnMouseDown()
//	{
//		Debug.Log ("DOWN");
//		down = true;
//
//
//	}
//	public void OnMouseUp()
//	{
//		Debug.Log ("UP");
//		down = false;
//	}
//}
