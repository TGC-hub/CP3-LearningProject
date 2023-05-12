using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "killEnemy" || collision.gameObject.tag == "Wall")
        {

            Destroy(gameObject);

        }

    }
    
}
