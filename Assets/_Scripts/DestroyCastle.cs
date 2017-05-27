using UnityEngine;


public class DestroyCastle : MonoBehaviour 
{

	public GameObject explosion;
	public GameObject WallCrumble;
	public GameObject CastleCrumble;

	public GameObject SpawnRestartPose;
	public GameObject Restart;
    public GameObject SpawnTitlePose;
    public GameObject Title;

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
        Instantiate (explosion, transform.position, transform.rotation);
		Instantiate (WallCrumble, transform.position, transform.rotation);
		Instantiate (CastleCrumble, transform.position, transform.rotation);

		Destroy(gameObject);
        Instantiate(Title, SpawnTitlePose.transform.position, SpawnTitlePose.transform.rotation);
        Instantiate (Restart, SpawnRestartPose.transform.position, SpawnRestartPose.transform.rotation);
	}
}
