using UnityEngine;
using System.Collections;

    public class DestroyMonster : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Monster"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
            }
        }
}
