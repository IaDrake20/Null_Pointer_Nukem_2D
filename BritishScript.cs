using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrishSript : MonoBehaviour
{
    [SerializeField]
    public GameObject briIshProfessor;

    public float timeOnScreen;

    IEnumerator SpawnBrish(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(Random.Range(-31f, 31f), Random.Range(-4f, 4f), 0.0f);
            Instantiate(briIshProfessor, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBrish(5.0f, 9.0f));
        timeOnScreen = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeOnScreen += 0.1f;
        if (timeOnScreen > 500f)
        {
            DestroyImmediate(briIshProfessor, true);
            timeOnScreen = 0.0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameLogicScript.NullPointerAction();
            if (GameState.browniePoints >= 10)
            {
                GameState.recievedPowerup = true;
                GameState.isImmune = true;
                GameState.browniePoints = 0;

            }
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            Destroy(gameObject);
        }
    }
}
