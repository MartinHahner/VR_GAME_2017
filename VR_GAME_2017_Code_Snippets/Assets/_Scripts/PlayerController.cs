using UnityEngine;
using System.Collections;
using EZEffects;

// [System.Serializable] makes it possible, to cache the variables in unity. 
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject controllerRight;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_TrackedController controller;
    private SteamVR_Controller.Device device;

    public EffectTracer TracerEffect;



    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float FireRate = 0.5F;

    private Rigidbody rb;

    private float NextFire = 0.0F;
    

    //private void Start()
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
    }
    
    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        ShootBall();
    }

    public void ShootBall()
    {
        /*if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            // Instantiate(object, position, rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
        }*/
         RaycastHit hit = new RaycastHit();
         Ray ray = new Ray(shotSpawn.position, shotSpawn.forward);

         device = SteamVR_Controller.Input((int)trackedObj.index);
         device.TriggerHapticPulse(750);
         TracerEffect.ShowTracerEffect(shotSpawn.position, shotSpawn.forward, 250f);
    }


    // Fire the shots!
    /*private void Update()
    {
        if (controller.TriggerClicked && Time.time > NextFire)
        //if (controller && Time.time > NextFire)
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            // Instantiate(object, position, rotation);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 
        }        
    }*/


    // Move the player
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(-moveHorizontal, moveVertical, 0.0f) * speed;

        // This vector clamps the player in the game field! 
        rb.position = new Vector3 
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
                0.0f
            );        
    }
}
