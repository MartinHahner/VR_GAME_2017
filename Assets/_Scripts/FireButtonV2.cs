using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireButtonV2 : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate = 0.5F;

    private float NextFire = 0.0F;

    public SteamVR_TrackedController ControllerRight;

    /*void Awake()
    {
        ControllerRight = GetComponent<SteamVR_TrackedController>();
        ControllerRight.TriggerClicked += Trigger;
            
       }

    // Fire the shots!
    void Trigger(object sender, ClickedEventArgs e)
    {
        //if(Time.time > NextFire)
        //{
        //    NextFire = Time.time + FireRate;
            // Instantiate(object, position, rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 
        //}        
    }*/

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            // Instantiate(object, position, rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 
        }
    }
}
