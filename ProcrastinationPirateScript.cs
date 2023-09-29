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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            GameState.toggleMovement = true;
            Destroy(gameObject);
        }
    }
}
