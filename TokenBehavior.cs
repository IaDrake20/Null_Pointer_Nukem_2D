using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenBehavior : MonoBehaviour
{
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

            Destroy(gameObject);
        }
    }

}
