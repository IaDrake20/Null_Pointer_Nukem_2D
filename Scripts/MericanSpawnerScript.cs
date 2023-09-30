using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MericanSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject MERICANTokenPrefab;
    public Transform player;

    [SerializeField]
    public float minDistance;

    float locX;
    float locY;// = UnityEngine.Random.Range(-7f, 7f);

    //spawns are y:-9 to 8, -19 to 18

    IEnumerator SpawnTestTokenUnifDist(float mean, float stdDev)
    {
        while (true)
        {
            //float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            //yield return new WaitForSeconds(waitTime);
            //Vector3 position = new Vector3(locX, locY, 0.0f);
            //var cpy = Instantiate(procrastinationPiratePrefab, position, Quaternion.identity);

            float waitTime = GaussianRandom(mean, stdDev);
            if (waitTime < 0)
            {
                waitTime = 0;
            }
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(MERICANTokenPrefab, position, Quaternion.identity);

            // Check the distance between the player and the spawn point.
            float distanceToPlayer = Vector3.Distance(position, player.position);

            minDistance = 5f;

            if (distanceToPlayer > minDistance)
            {
                // Instantiate the object at the spawn position.
                var cpy = Instantiate(MERICANTokenPrefab, position, Quaternion.identity);
                Destroy(cpy, 5);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        locX = UnityEngine.Random.Range(-19f, 20f);
        locY = UnityEngine.Random.Range(-6f, 7f);
        StartCoroutine(SpawnTestTokenUnifDist(7.5f, .75f));
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    float GaussianRandom(float mean, float stdDev)
    {
        float u1 = UnityEngine.Random.value;
        float u2 = UnityEngine.Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        return mean + stdDev * randStdNormal;
    }
}
