using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public LayerMask wall;
  

    private Rigidbody2D rigidbody;
    public Collider2D triggerCollider;

    public GameObject DeathEffectEnemy;
    private PlayerController playerkill;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerkill = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        
    }

    public void EnemyDie()
    {
        Destroy(Instantiate(DeathEffectEnemy, gameObject.transform.position, gameObject.transform.rotation), 1.5f);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (triggerCollider.IsTouchingLayers(wall))
        {
            Flip();
        }
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "bulletPlayer")
        {
            EnemyDie();
        }
        
    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
    }

   
      
}
