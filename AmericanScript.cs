using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmericanScript : MonoBehaviour
{
    [SerializeField]
    public GameObject AmercianAcademic;

    public float timeOnScreen;

    IEnumerator SpawnAmerican(float mean, float stdDev)
    {
        while (true)
        {
            float waitTime = GaussianRandom(mean, stdDev);
            if (waitTime < 0)
            {
                waitTime = 0;
            }
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(AmercianAcademic, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAmerican(7.5f, .75f));
        timeOnScreen = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeOnScreen += 0.1f;
        if (timeOnScreen > 500f)
        {
            DestroyImmediate(AmercianAcademic, true);
            timeOnScreen = 0.0f;
        }

    }

    float GaussianRandom(float mean, float stdDev)
    {
        float u1 = UnityEngine.Random.value;
        float u2 = UnityEngine.Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        return mean + stdDev * randStdNormal;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameState.browniePoints >= 10)
            {
                GameState.recievedPowerup = true;
                GameState.isImmune = true;
            }
            GameState.browniePoints = 0;
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            Destroy(gameObject);
        }
    }
}
