using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrishSript : MonoBehaviour
{
    [SerializeField]
    public GameObject britishProfessor;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameLogicScript.NullPointerAction();
            if (GameState.browniePoints >= 10)
            {
                GameState.recievedPowerup = true;
                GameState.isImmune = true;
                GameState.browniePoints = 0;

            }
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            Destroy(gameObject);
        }
    }
}
