using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{

    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" )
        {
            gameManager.DeathPlayer();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }



}
