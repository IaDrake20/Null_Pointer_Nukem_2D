using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
        //bool hasCollided = false;
    bool bugAffect = false;
    public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameState.toggleMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        float dirX = Input.GetAxisRaw("Horizontal");
        //Debug.Log(dirX);
        float dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX, dirY);
        
        //movement enabled or disabled by specific enemy type
        if(GameState.toggleMovement){
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector3(0f, speed, 0f);
            }
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
            {
                rb.velocity = new Vector3(0f, -speed, 0f);
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
            {
                rb.velocity = new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
            {
                rb.velocity = new Vector3(-speed, 0f, 0f);
            }
        }

        //bug affect
        //TODO: implement timer
        if(bugAffect){
            GameState.score -= 1;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    bool toggleScore = true;
    //    switch(collision.gameObject.tag){
    //        case "Enemy_NullPointer": 
    //        //Destroy(collision.gameObject);
    //        if((GameState.score / 2) > (GameState.score - 10)){
    //            GameState.score = GameState.score / 2;
    //        } else {
    //            GameState.score = GameState.score - 10;
    //        }
    //        UnityEngine.Debug.Log("NULL...Points Reduced " + GameState.score);
    //        break;

    //        case "Enemy_BugSwarm":
    //                    Destroy(collision.gameObject);
    //        if(1 == 1){
    //            //reduce GameState.score by 10% per second until next powerup
    //            bugAffect = true;
    //        }
    //        UnityEngine.Debug.Log("Bugs");
    //        break;

    //        case "Enemy_ProcrastinationPirate":
    //                    //Destroy(collision.gameObject);
    //        //stop for X seconds with a speech bubble that says I'll do it later. Ignore score increases
    //        toggleScore = false;
    //        GameState.toggleMovement = false;
    //        UnityEngine.Debug.Log("Pirate ");
    //        break;

    //        case "Help_BrowniePoint":
    //        GameState.browniePoints++;
    //        UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
    //        break;

    //        case "Score_PHDPendant":
    //        if(toggleScore){
    //            GameState.score += 25;
    //        }
    //        UnityEngine.Debug.Log("PHD...Points Increased " + GameState.score);
    //        break;

    //        case "Score_CodingCookbook":
    //        if(toggleScore){
    //            GameState.score += 1;
    //        }
    //        UnityEngine.Debug.Log("COOK...Points increased " + GameState.score);
    //        break;

    //    }
    //}
}
