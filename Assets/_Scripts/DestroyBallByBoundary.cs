using UnityEngine;
using System.Collections;

public class DestroyBallByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
