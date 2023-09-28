using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject oleGerman;
    [SerializeField]
    public GameObject briIshProfessor;
    [SerializeField]
    public GameObject americanAcademic;

    public float timeOnScreen;

    IEnumerator SpawnBookToken(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(Random.Range(-31f, 31f), Random.Range(-4f,4f), 0.0f);
            Instantiate(oleGerman, position, Quaternion.identity);
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
        if (timeOnScreen > 500f)
        {
            DestroyImmediate(oleGerman, true);
            timeOnScreen = 0.0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameLogicScript.NullPointerAction();
            if(GameState.browniePoints >= 10)
            {
                if (!other.gameObject.CompareTag("Player"))
                {
                    Destroy(other.gameObject);
                }
            }
            GameState.browniePoints=0;
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            Destroy(gameObject);
        }
    }
}
