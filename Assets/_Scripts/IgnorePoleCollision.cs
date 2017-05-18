using UnityEngine;
using System.Collections;

public class IgnorePoleCollision : MonoBehaviour {

	public GameObject Cylinder_Vertical;
	public GameObject Cylinder_Horizontal;//Collider actually attached to Cannon Plane

	// Use this for initialization
	void Start () {
		Cylinder_Vertical = GameObject.FindWithTag ("VerticalPole");
		Cylinder_Horizontal = GameObject.FindWithTag ("HorizontalPole");
	
		Physics.IgnoreCollision(Cylinder_Vertical.GetComponent<Collider>(), Cylinder_Horizontal.GetComponent<Collider>(), true);
	}

}
