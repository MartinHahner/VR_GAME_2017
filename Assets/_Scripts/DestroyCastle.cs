using UnityEngine;
using System.Collections;


public class DestroyCastle : MonoBehaviour 
{

	public GameObject explosion;
	public GameObject WallCrumble;
	public GameObject CastleCrumble;

	public GameObject SpawnRestartPose;
	public GameObject Restart;
    public GameObject SpawnTitlePose;
    public GameObject Title;

	public GameObject Vibrations;

	private int lives = 5;


	void Start () {
		GetComponent<SphereCollider> ().isTrigger = true;

	}



    // This code destroys Canon Ball and Monster!
    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
        if (other.tag == "Player")
        {
            return;
        }
        if (other.tag == "Ball")
        {
            return;
        }
        if (other.tag == "controller")
        {
            return;
        }

		if (lives == 1) {

			Instantiate (explosion, transform.position, transform.rotation);
			Instantiate (WallCrumble, transform.position, transform.rotation);
			Instantiate (CastleCrumble, transform.position, transform.rotation);

			Destroy(gameObject);
			Instantiate(Title, SpawnTitlePose.transform.position, SpawnTitlePose.transform.rotation);
			Instantiate (Restart, SpawnRestartPose.transform.position, SpawnRestartPose.transform.rotation);

		}



		if (lives > 0) {
			
			lives = lives - 1;
		
		}


		TextMesh textObject = GameObject.Find("LifeText").GetComponent<TextMesh>();

		textObject.text = "lives: " + lives;

		Debug.Log (lives + " lives remaining");

        
	}
}
