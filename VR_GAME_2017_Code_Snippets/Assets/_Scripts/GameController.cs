using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;

    void Start()
    {
       StartCoroutine (Spawnwaves());
    }

    IEnumerator Spawnwaves()
    {
        for(int i=0;i<hazardCount;i++)
        {
            yield return new WaitForSeconds(startWait);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }

    }
}
