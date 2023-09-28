using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookbookTokenScript : MonoBehaviour
{
    [SerializeField]
    public GameObject cookbookTokenPrefab;

    public float timeOnScreen;

    IEnumerator SpawnBookToken(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(Random.Range(-31f, 31f), Random.Range(-4f, 4f), 0.0f);
            Instantiate(cookbookTokenPrefab, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBookToken(3.0f, 7.0f));
        timeOnScreen = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeOnScreen += 0.1f;
        if(timeOnScreen > 500f)
        {
            DestroyImmediate(cookbookTokenPrefab, true);
            timeOnScreen = 0.0f;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameLogicScript.NullPointerAction();
            GameState.browniePoints++;
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            Destroy(gameObject);
        }
    }
}
