using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float movingSpeed;
    public float jumpForce;

    private float moveInput;
    private Rigidbody2D rigidbody;
    private Animator animator;

    public Transform VTBulletPlayer;
    public GameObject bulletPlayer;
    public float bulletPlayerSpeed = 15.0f;

    private bool facingRight = false;
    public bool deathState = false;
    public bool deathEnemies = false;
    private bool isGrounded = false;
    public Transform groundCheck;

    public bool moveLeft;
    
    public bool moveRight;

    private GameManager gameManager;

    public bool isNextScenes;

    float flipBullet = 1;

    public bool checkNextScenes = false;
    public bool startshoot = false;


    public LayerMask ground;
    public Collider2D pointTrigger;

    [SerializeField] private AudioSource soundJump;
    [SerializeField] private AudioSource soundAttack;
    [SerializeField] private AudioSource soundKillenemy;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        deathEnemies = false;
        moveLeft = false;
        moveRight = false;
        checkNextScenes = false;
        isGrounded = false;

    }

    private void FixedUpdate()
    {
        CheckGround();
        MovementPlayer();

        if(deathEnemies == true)
        {
            rigidbody.AddForce(transform.up * (jumpForce + 5), ForceMode2D.Impulse);
            deathEnemies = false;
        }
    }

   

    void Update()
    {

         // ------------------------------- Player Controller --------------------------------

        if (Input.GetButton("Horizontal"))
        {
            moveInput = Input.GetAxis("Horizontal");
            Vector3 direction = transform.right * moveInput;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetBool("runState", true); // Turn on walk animation
            animator.SetBool("jumpState", false);

        }
        else
        {
            if (isGrounded == true) { animator.SetBool("jumpState", false); } // Turn on idle animation

        }

      

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            
            BtnJump();
        }
        if (isGrounded == false)
        {

            animator.SetBool("jumpState", true);
            animator.SetBool("runState", false);
        }// Turn on jump animation



        if (gameManager.coinsCounter >= 10)
        {
            startshoot = true;
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                BtnShoot();
            }
            
        }
        else
        {
                startshoot = false;
        }
        
    
        // -------------------------- Xu Ly Face va Ground ---------------------------------

        if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput < 0)
        {
            Flip();
        }


    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        flipBullet *= -1;
    }

    private void CheckGround()
    {
        if (pointTrigger.IsTouchingLayers(ground))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }



    // ------------------------------------Platfomr Move -----------------------------------------------------------
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlatformFly-X") || collision.gameObject.name.Equals("PlatformFly-Y"))
        {
            this.transform.parent = collision.transform;
        }

       
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlatformFly-X")|| collision.gameObject.name.Equals("PlatformFly-Y"))
        {
            this.transform.parent = null;
        }
    }




    // --------------------------- Xu Ly Va Cham -------------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            deathState = true;
        }
        else
        {
            deathState = false;
        }
        

        if (collision.gameObject.tag == "LoadCheckPoints")
        {
            isNextScenes = true;

        }
        else
        {
            isNextScenes = false;
        }


        if (collision.gameObject.tag == "killEnemy")
        {
            soundKillenemy.Play();
            deathEnemies = true;
        }
        else
        {
            deathEnemies = false;
        }


    }
     //---------------------------------------------------- Scenes -------------------------------------------


     void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NextScenes")
        {
            checkNextScenes = true;
        }
    }




 /*   ------------------------------ Button Mobile -------------------------------*/
    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    //I am not pressing the left button
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    //Same thing with the right button
    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        
        moveRight = false;
    }


    private void MovementPlayer()
    {
        if (moveLeft == true)
        {
                moveInput = -10;
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetBool("runState", true); // Turn on walk animation
                animator.SetBool("jumpState", false);
        }

        else if (moveRight == true)
        {
            moveInput = 10;
            Vector3 direction = transform.right * moveInput;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetBool("runState", true); // Turn on walk animation
            animator.SetBool("jumpState", false);
        }

        else
        {
            animator.SetBool("runState", false);
            moveInput = 0;
        }
    }



    public void BtnJump()
    {
        if (isGrounded == true)
        {
            soundJump.Play();
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    public void BtnShoot()
    {

        if (startshoot == true)
        {
            gameManager.coinsCounter -= 10;
            soundAttack.Play();
            var bulletplayer = Instantiate(bulletPlayer, VTBulletPlayer.position, VTBulletPlayer.rotation);
            bulletplayer.GetComponent<Rigidbody2D>().velocity = VTBulletPlayer.right * bulletPlayerSpeed * flipBullet;
        }


    }
}
