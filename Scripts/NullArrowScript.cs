using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NullArrowScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    public float NullArrowTokenSpeed;

    [SerializeField]
    public GameObject nullArrowTokenPrefab;
    public float timeOnScreen;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //rb.velocity = new Vector2(dirX, dirY);
        NullArrowTokenSpeed = 1f;

        //hardcoded direction and speed for now
        rb.velocity = new Vector3(NullArrowTokenSpeed, 0, 0);
       

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("R_Wall")){
            rb.velocity = new Vector3(-NullArrowTokenSpeed, 0f, 0f);
        } else if (other.gameObject.CompareTag("L_Wall"))
        {
            rb.velocity = new Vector3(NullArrowTokenSpeed, 0f, 0f);
        }


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
