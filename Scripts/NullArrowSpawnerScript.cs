using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullArrowSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject nullArrowTokenPrefab;
    // Start is called before the first frame update
    public Transform player;

    [SerializeField]
    public float minDistance;

    float locX;
    float locY;// = UnityEngine.Random.Range(-7f, 7f);

    //spawns are y:-9 to 8, -19 to 18

    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(locX, locY, 0.0f);
            //var cpy = Instantiate(procrastinationPiratePrefab, position, Quaternion.identity);

            // Check the distance between the player and the spawn point.
            float distanceToPlayer = Vector3.Distance(position, player.position);

            minDistance = 5f;

            if (distanceToPlayer > minDistance)
            {
                // Instantiate the object at the spawn position.
                var cpy = Instantiate(nullArrowTokenPrefab, position, Quaternion.identity);
                Destroy(cpy, 7);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        locX = UnityEngine.Random.Range(-19f, 20f);
        locY = UnityEngine.Random.Range(-6f, 7f);
        StartCoroutine(SpawnTestTokenUnifDist(8.0f, 16.0f));
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
