using UnityEngine;
using System.Collections;

public class TurnStyle_SoundnVibrate : MonoBehaviour {

    public GameObject clinkSoundClip;
    SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjR;
    SteamVR_Controller.Device deviceL;
    public SteamVR_TrackedObject trackedObjL;

    //public GameObject TurnStyle_Horiztal;

    public float currentAngle;
    public float prevAngle;
    public float timeSound;
    public float timeTrack;

    public int controllerNum;
    


    void Start()
    {
        GetComponent<CapsuleCollider>().isTrigger = true;
        deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
        deviceL = SteamVR_Controller.Input((int)trackedObjL.index);

        currentAngle = this.transform.rotation.z;
        prevAngle = currentAngle;

        timeSound = Time.deltaTime;
        timeTrack = Time.deltaTime;

        controllerNum = 0;

    }

    void Update()
    {
        currentAngle = this.transform.eulerAngles.z;
        timeTrack += Time.deltaTime;

        if ((Mathf.Abs(currentAngle - prevAngle) > 5)// && (timeTrack - timeSound) > 0.3f)
        {
            GameObject clink = Instantiate(clinkSoundClip, cannonPose.transform.position, Quaternion.identity) as GameObject;
            timeSound = timeTrack;
            prevAngle = currentAngle;


            rumbleController();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "controllerR")
        {
            controllerNum = 1;
        }
        if (other.gameObject.tag == "controllerL")
        {
            controllerNum = 2;
        }
    }

    void rumbleController()
    {

            StartCoroutine(LongVibration(1, 3999));

        }

        IEnumerator LongVibration(float length, float strength)
        {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            if (controllerNum == 1)
            {
            deviceR.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
            }

            if (controllerNum == 2)
            {
            deviceL.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
            }
        yield return null;
        }
    }
    
}
