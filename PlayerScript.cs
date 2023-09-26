using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
        Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
                rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 20f;
        float dirX = Input.GetAxisRaw("Horizontal");
        //Debug.Log(dirX);
        float dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX, dirY);
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0f, speed, 0f);
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            rb.velocity = new Vector3(0f, -10f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            rb.velocity = new Vector3(-speed, 0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        bool toggleScore = true;
        switch(collision.gameObject.tag){
            case "Enemy_NullPointer": 
            Destroy(collision.gameObject);
            if((GameState.score / 2) > (GameState.score - 10)){
                GameState.score = GameState.score / 2;
            } else {
                GameState.score = GameState.score - 10;
            }
            break;

            case "Enemy_BugSwarm":
                        Destroy(collision.gameObject);
            if(1 == 1){
                //reduce GameState.score by 10% per second until next powerup
            }
            break;

            case "Enemy_ProcrastinationPirate":
                        Destroy(collision.gameObject);
            //stop for X seconds with a speech bubble that says I'll do it later. Ignore score increases
            toggleScore = false;
            //wait
            toggleScore = true;
            break;

            case "Help_BrowniePoint":
            GameState.browniePoints++;
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            break;

            case "Score_PHDPendant":
            if(toggleScore){
                GameState.score += 25;
            }
            break;

            case "Score_CodingCookbook":
            if(toggleScore){
                GameState.score += 1;
            }
            break;

        }
        if(collision.gameObject.tag == "Enemy_NullPointer")
        {
            //tick scores
            Destroy(gameObject);

        }
    }
}
