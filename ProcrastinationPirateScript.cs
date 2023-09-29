using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcrastinationPirateScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float pPTokenSpeed;

    [SerializeField]
    public GameObject procrastinationPiratePrefab;
    public float timeOnScreen;

    IEnumerator SpawnTestTokenUnifDist(float minTime, float maxTime)
    {
        while (true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(-16.5f, 3.5f, 0.0f);
            var cpy = Instantiate(procrastinationPiratePrefab, position, Quaternion.identity);
            Destroy(cpy, 10);
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
        //rb.velocity = new Vector2(dirX, dirY);
        pPTokenSpeed = 25f;

        //hardcoded direction and speed for now
        //rb.velocity = new Vector3(pPTokenSpeed, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("touched pirate ");
            Destroy(gameObject);
        }
    }
}
