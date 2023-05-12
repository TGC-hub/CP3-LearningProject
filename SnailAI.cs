using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAI : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public LayerMask wall;


    private Rigidbody2D rigidbody;
    public Collider2D triggerCollider;

    public GameObject DeathEffectEnemy;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        
    }

    public void SnailDie()
    {
        Instantiate(DeathEffectEnemy, gameObject.transform.position, Quaternion.identity);
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
            SnailDie();
        }    
    }

    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
    }


}
