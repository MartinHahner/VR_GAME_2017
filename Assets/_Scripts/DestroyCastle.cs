using UnityEngine;


public class DestroyCastle : MonoBehaviour 
{

	public GameObject explosion;
	public GameObject WallCrumble;
	public GameObject CastleCrumble;

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
        Instantiate (explosion, transform.position, transform.rotation);
		Instantiate (WallCrumble, transform.position, transform.rotation);
		Instantiate (CastleCrumble, transform.position, transform.rotation);

		Destroy(gameObject);
	}
}
