using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhdPendantSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject PhdPendantPrefab;

    //spawns are y:-9 to 8, -19 to 18

    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-19f, 20f), UnityEngine.Random.Range(-7f, 7f), 0.0f);
            var cpy = Instantiate(PhdPendantPrefab, position, Quaternion.identity);
            Destroy(cpy, 10);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTestTokenUnifDist(8.0f, 16.0f));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
