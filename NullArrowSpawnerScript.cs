using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullArrowSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject nullArrowTokenPrefab;
    // Start is called before the first frame update

    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-19f, 20f), UnityEngine.Random.Range(-7f, 7f), 0.0f);
            var cpy = Instantiate(nullArrowTokenPrefab, position, Quaternion.identity);
            Destroy(cpy, 10);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnTestTokenUnifDist(8.0f, 16.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
