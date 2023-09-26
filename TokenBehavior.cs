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
     //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject,1f);
            Debug.Log("Token Destroyed");
        }
    }
}
