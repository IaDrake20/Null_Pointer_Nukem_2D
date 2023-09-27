using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TokenBehavior : MonoBehaviour
{
    [SerializeField]
    public GameObject TestTokenPrefab;

    public float timeOnScreen;
    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-4f, -2f, 0.0f);
            Instantiate(TestTokenPrefab, position, Quaternion.identity);
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
        if(timeOnScreen < 125f) 
        {
            Destroy(gameObject);
            timeOnScreen = 0.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameLogicScript.NullPointerAction();

            Destroy(gameObject);
        }
    }

}

/*Spawning Script:
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject hexBallPrefab;

    [SerializeField]
    private TextMeshProUGUI timeIntervalText;

    private string waitTimeString = "Wait Time: \n";
    IEnumerator SpawnHexBallsAtRate(float waitTime)
    {
        
        while (true)
        {
            waitTimeString = waitTimeString + waitTime.ToString() + "\n";
            timeIntervalText.text = waitTimeString;
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(hexBallPrefab, position, Quaternion.identity);
        }
    }

    IEnumerator SpawnHexBallsGaussianDist(float mean, float stdDev)
    {
        while (true)
        {
            float waitTime = GaussianRandom(mean, stdDev);
            if(waitTime < 0)
            {
                waitTime = 0;
            }
            waitTimeString = waitTimeString + waitTime.ToString() + "\n";
            timeIntervalText.text = waitTimeString;
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(hexBallPrefab, position, Quaternion.identity);
        }
    }

    IEnumerator SpawnHexBallsUniformDist(float minTime, float maxTime)
    {
        while (true) 
        { 
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            waitTimeString = waitTimeString + waitTime.ToString() + "\n";
            timeIntervalText.text = waitTimeString;
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(hexBallPrefab, position, Quaternion.identity);
        }
    }
    IEnumerator SpawnHexBallsExponentialDist(float mean)
    {
        while (true)
        {
            float waitTime = ExponentialRandom(mean);
            waitTimeString = waitTimeString + waitTime.ToString() + "\n";
            timeIntervalText.text = waitTimeString;
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            Instantiate(hexBallPrefab, position, Quaternion.identity);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnHexBallsAtRate(5.0f));
        //StartCoroutine(SpawnHexBallsUniformDist(3.0f,7.0f));
        //StartCoroutine(SpawnHexBallsGaussianDist(5.0f, 3.0f));
        //std dev 0.5: 68% 4.5-5.5, 95%: 4-6
        //std dev: 3.0: 68% 2.0-8.0, 95% -1.0 - 11.0
        StartCoroutine(SpawnHexBallsExponentialDist(5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //helper functions
    float GaussianRandom(float mean, float stdDev)
    {
        float u1 = UnityEngine.Random.value;
        float u2 = UnityEngine.Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI*u2);
        return mean+ stdDev*randStdNormal;
    }
    float ExponentialRandom(float mean)
    {
        float u = UnityEngine.Random.value;
        return -mean * Mathf.Log(1 - u);
    }
}
*/