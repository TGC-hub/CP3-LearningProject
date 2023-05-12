using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSnail : MonoBehaviour
{
    public Vector2 moveDeathSnail;
    public float moveSpeed = 10.0f;
    public LayerMask wall,ground;

    public bool runSnail = false;
    public bool killPlayer = false;

    private Rigidbody2D rigidbody;
    public Collider2D triggerCollider;
    public GameManager gameManager;


     void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        killPlayer = false;
        runSnail = false;
    }

     void Update()
    {
        if(runSnail == true)
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
          
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            runSnail = true;

            if (killPlayer == true)
            {
                gameManager.DeathPlayer();
                killPlayer = false;
                runSnail=false;
            }

        }
    }


    void FixedUpdate()
    {
        if (triggerCollider.IsTouchingLayers(wall) || triggerCollider.IsTouchingLayers(ground))
        {
            Flip();
            killPlayer = true;
        }
        

    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
    }


}
