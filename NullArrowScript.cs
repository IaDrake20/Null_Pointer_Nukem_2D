using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullArrowScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float NullArrowTokenSpeed;

    [SerializeField]
    public GameObject nullArrowTokenPrefab;
    public float timeOnScreen;

    
    // Start is called before the first frame update
    void Start()
    {
        //destory after 20 seconds
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        float dirX, dirY;
        dirX = 0f; dirY = 0f;
        //rb.velocity = new Vector2(dirX, dirY);
        NullArrowTokenSpeed = 25f;

        //hardcoded direction and speed for now
        //rb.velocity = new Vector3(NullArrowTokenSpeed, 0, 0);

        timeOnScreen += 0.1f;
        if (timeOnScreen > 387f)
        {
            DestroyImmediate(nullArrowTokenPrefab, true);
            timeOnScreen = 0.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if((GameState.score / 2) > (GameState.score - 10))
            {
                GameState.score /= 2;
            } else
            {
                GameState.score -= 10;
            }
            Destroy(gameObject);
        }
    }
}
