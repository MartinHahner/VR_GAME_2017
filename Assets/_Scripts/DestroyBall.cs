using UnityEngine;
using System.Collections;

public class DestroyBall : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
