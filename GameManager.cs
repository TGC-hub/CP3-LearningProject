using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int coinsCounter = 0;
    public GameObject playerGameObject;
    private PlayerController player;
    private SpawnCharacter characterManager;

    public GameObject[] deathPlayerPrefab;
    public Text coinText;
    public Text coinDeath;
    public Text coinWin;
    public Text DeathTime;

    public GameObject deathUI;
    public GameObject winningUI;
    public GameObject btnDown;
    public int times;
    public float timeStart = 0;

    public Transform pointAddCharacter;

    public int playerIndex;

    [SerializeField] public AudioSource soundLoserGame;
  



    void Awake()
    {
        

    }
    void Start()
    {
    
        characterManager = GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<SpawnCharacter>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        deathUI = GameObject.Find("DeathUI");
        winningUI = GameObject.Find("WinningUI");
        btnDown = GameObject.Find("Down");

        deathUI.SetActive(false);
        winningUI.SetActive(false);
        btnDown.SetActive(false);

        playerIndex = characterManager.characterIndex;
    }

    public void DeathPlayer()
    {
        
       
        GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab[playerIndex], playerGameObject.transform.position, playerGameObject.transform.rotation);

        deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
        player.gameObject.SetActive(false);
        player.deathState = false;
        soundLoserGame.Play();
        Invoke("OnUIDeath", 2.0f);
    }

    public void OnUIDeath()
    {
       
        deathUI.SetActive(true);
    }
    
    public void NextScenes()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = sceneIndex + 1;

        if (SceneManager.GetActiveScene().buildIndex < 13)
        {
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
                Time.timeScale = 1;
            }

        }
        else if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            SceneManager.LoadScene(15);
        }

    }
    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);

    }


    void Update()
    {   
      

        coinText.text = "x" + coinsCounter.ToString();
        coinDeath.text = "Your Cherry : " + coinsCounter.ToString();
        coinWin.text = "Your Cherry : " + coinsCounter.ToString();

        times = 120 - Mathf.RoundToInt((timeStart += Time.deltaTime));

        DeathTime.text = "Time : " + times.ToString();



        if (times == 0)
        {
            Invoke("OnUIDeath", 2.0f);
            player.gameObject.SetActive(false);
            player.deathState = false;
            soundLoserGame.Play();

        }

        if (player.deathState == true)
        {
            DeathPlayer();


        }

        if (player.isNextScenes == true)
        {

            winningUI.SetActive(true);
        }

        if (player.checkNextScenes == true)
        {
            btnDown.SetActive(true);

        }
        else
        {
            btnDown.SetActive(false);
        }

      



    }

}

