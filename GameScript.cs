using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScript : MonoBehaviour
{

    [SerializeField]
    public GameScript prefabGameScript;

    [SerializeField]
    static bool recievedPowerup;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (DrainScore() == true)
        {
            GameState.score -= (0.1 * GameState.score);
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
