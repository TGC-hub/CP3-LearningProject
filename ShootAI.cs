using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public GameObject bulletAI;
  
    public Transform vtBullet;

    public bool fireActive = false;
    public float shootTime = 3.0f;
    float nextShoot = 0.0f;
    public float bulletAIspeed = 22.5f;

    public GameObject DeathPlant;
    [SerializeField] public Animator anim;
    [SerializeField] AudioSource soundPlantAttack;
    public Rigidbody2D rb;

    public float range = 15.0f;
    public PlayerController playerdetect;

    // Start is called before the first frame update
    void Start()
    {
        playerdetect = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        soundPlantAttack.Stop();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
     
    }


    public void StartPlantShoot()
    {       
        if (!soundPlantAttack.isPlaying)
        {
            soundPlantAttack.Play();
        }
        var bulletai = Instantiate(bulletAI, vtBullet.position, vtBullet.rotation);
        bulletai.GetComponent<Rigidbody2D>().velocity = -vtBullet.right * bulletAIspeed;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(playerdetect.transform.position, transform.position) < range)
        {
            if (Time.time > nextShoot)
            {
                anim.SetBool("PlantAttack", true);
                nextShoot = Time.time + shootTime;

            }

        }
        else
        {
            soundPlantAttack.Stop();
            anim.SetBool("PlantAttack", false);
        }
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bulletPlayer")
        {
            Destroy(Instantiate(DeathPlant, gameObject.transform.position, gameObject.transform.rotation), 1.5f);
            Destroy(gameObject);
        }

    }

    
}
