using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player_Movement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<Player_Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") {

            playerMovement.Die();
            
        }

        Debug.Log("collision");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
