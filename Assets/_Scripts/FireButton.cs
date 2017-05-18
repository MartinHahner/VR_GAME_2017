using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FireButton : MonoBehaviour {

	public Transform CannonTip;
	public GameObject prefab;
	public Transform parentCB;

	public GameObject Flash;

    public Text countText;
    public Text winText;

	private Quaternion rot;
	private Vector3 pos;

	public float speed = 1;
	public float timer = .5f;
	private Quaternion rotMF;
	private Vector3 posMF;

    private int count;

    private void Start()
    {
        count = 0;
        countshots();
        winText.text = "";
    }

    void OnMouseDown(){

		Shoot ();
		MuzzleFlash ();

	}

	void Shoot(){
		rot = CannonTip.rotation;
		pos = CannonTip.position;
		GameObject projectile = (GameObject) Instantiate (prefab, pos, rot, parentCB);
		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * 30;
	}

	void MuzzleFlash(){
		rot = CannonTip.rotation;
		pos = CannonTip.position;
		GameObject MFlash = Instantiate (Flash, pos, rot) as GameObject;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Destroy(other.gameObject);
            //other.gameObject.Setactive(false);
            count = count + 1;
            countshots();
        }
    }

    void countshots() // function that counts the points and displays it in the game!
    {
        countText.text = "Count: " + count.ToString();
        if (count>=2) // change the number to the real number of monsters on the field!
        {
            winText.text = ("You fucking won!!!!");
        }
    }
}
