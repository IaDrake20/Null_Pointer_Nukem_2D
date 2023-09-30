using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScript : MonoBehaviour
{

    [SerializeField]
    public GameScript prefabGameScript;

    [SerializeField]
    static bool recievedPowerup;

    [SerializeField]
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //timer += (1f*Time.deltaTime);
        if (DrainScore() == true)
        {
            GameState.score -= (0.1 * GameState.score);
        }
        if(GameState.toggleMovement == false && !GameState.isImmune)
        {
            timer = 10f;

        }else
        {
            GameState.toggleMovement = true;
        }
    }

    public bool DrainScore()
    {
        if (GameState.recievedPowerup)
        {
            return false;
        }
        return true;
    }
}
