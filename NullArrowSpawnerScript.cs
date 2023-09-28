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
            GameState.TEXT_score.text = "Score: " + GameState.score.ToString();
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-17f, 18f), UnityEngine.Random.Range(-6,6), 0);//-16.5f, 3.5f, 0.0f);
            Instantiate(nullArrowTokenPrefab, position, Quaternion.identity);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnTestTokenUnifDist(4.0f, 8.0f));
        //timeOnScreen = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
