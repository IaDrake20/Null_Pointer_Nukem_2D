using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrownieTokenScript : MonoBehaviour
{

    public GameObject brownieTokenPrefab;

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
            GameState.browniePoints++;
            UnityEngine.Debug.Log("Brownie Points: " + GameState.browniePoints);
            Destroy(gameObject);
        }
    }
}