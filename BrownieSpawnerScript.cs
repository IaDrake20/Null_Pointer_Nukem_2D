using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownieSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject brownieTokenPrefab;
    public float timeOnScreen;


    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(brownieTokenPrefab, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTestTokenUnifDist(4.0f, 8.0f));
        timeOnScreen = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        timeOnScreen += 0.1f;
        if (timeOnScreen > 387f)
        {
            DestroyImmediate(brownieTokenPrefab, true);
            timeOnScreen = 0.0f;
        }
    }
}
