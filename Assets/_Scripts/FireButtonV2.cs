using UnityEngine;
using System.Collections;

public class FireButtonV2 : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate = 0.5F;

    private Rigidbody rb;

    private float NextFire = 0.0F;


    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    // Fire the shots!
    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            // Instantiate(object, position, rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 
        }        
    }
}
