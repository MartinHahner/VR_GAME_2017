using UnityEngine;
using System.Collections;

public class BoxesNotFalling : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

    }
}
