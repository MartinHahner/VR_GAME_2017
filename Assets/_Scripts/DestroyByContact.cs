using UnityEngine;


public class DestroyByContact : MonoBehaviour 
{
	// scoring
	public int scoreValue = 1;
	private GameController gameController;

	public GameObject explosion;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	// This code destroys Canon Ball and Monster!
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
        if (other.tag == "Ground")
        {
            return;
        }
        if (other.tag == "Player")
        {
            return;
        }
        Instantiate (explosion, transform.position, transform.rotation);

		//Destroy(other.gameObject);
		Destroy(gameObject);

		// scoring
		gameController.AddScore(scoreValue);

	}
}
