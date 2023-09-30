using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSwarmScript : MonoBehaviour
{
    [SerializeField]
    public GameObject BugSwarmPrefab;

    public bool toggleScoreDrain = false;

    public float timeOnScreen;
    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-4f, -2f, 0.0f);
            Instantiate(BugSwarmPrefab, position, Quaternion.identity);
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
        if (timeOnScreen < 125f)
        {
            Destroy(gameObject);
            timeOnScreen = 0.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            toggleScoreDrain = true;
            Destroy(gameObject);
        }
    }
}
