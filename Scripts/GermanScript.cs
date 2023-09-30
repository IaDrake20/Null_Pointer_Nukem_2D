using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermanScript : MonoBehaviour
{
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.toggleMovement)
        {

        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && GameState.browniePoints >= 10)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Debug.Log("Rmving "+enemy);
                Destroy(enemy);
            }
        }
        GameState.browniePoints = 0;
        Destroy(this.gameObject);
    }
}
