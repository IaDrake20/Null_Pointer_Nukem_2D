using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PHDTokenScript : MonoBehaviour
{
    [SerializeField]
    public GameObject phdTokenPrefab;

    public float timeOnScreen;
    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(2.5f, -6.5f, 0.0f);
            Instantiate(phdTokenPrefab, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTestTokenUnifDist(3.0f, 7.0f));
        timeOnScreen = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeOnScreen += 0.1f;
        if(timeOnScreen > 350)
        {
            DestroyImmediate(phdTokenPrefab, true);
            timeOnScreen = 0.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameState.score += 25;
            UnityEngine.Debug.Log("PHD...Points Increased " + GameState.score);
            Destroy(gameObject);
        }
    }
}
