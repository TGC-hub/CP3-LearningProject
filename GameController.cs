using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private int saveScenes;
    private int sceneToContinue;

    private GameObject pauseUI;

    GameObject lv2;
    GameObject lv3;
    GameObject lv4;
    GameObject lv5;
    GameObject lv6;
    GameObject lv7;
    GameObject lv8;
    GameObject lv9;
    GameObject lv10;



    void Start()
    {
        Time.timeScale = 1.0f;
        pauseUI = GameObject.Find("PauseUI");

        lv2 = GameObject.Find("LV2");
        lv3 = GameObject.Find("LV3");
        lv4 = GameObject.Find("LV4");
        lv5 = GameObject.Find("LV5");
        lv6 = GameObject.Find("LV6");
        lv7 = GameObject.Find("LV7");
        lv8 = GameObject.Find("LV8");
        lv9 = GameObject.Find("LV9");
        lv10 = GameObject.Find("LV10");

        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 14)
        {
            pauseUI.SetActive(false);
        }

    }


    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 14)
        {
            saveScenes = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SaveScene", saveScenes);

        }
        sceneToContinue = PlayerPrefs.GetInt("SaveScene", saveScenes);

        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            switch (sceneToContinue)
            {
                case 1:
                    lv2.SetActive(true);
                    lv3.SetActive(true);
                    lv4.SetActive(true);
                    lv5.SetActive(true);
                    lv6.SetActive(true);
                    lv7.SetActive(true);
                    lv8.SetActive(true);
                    lv9.SetActive(true);
                    lv10.SetActive(true);
                    break;
                case 2: lv2.SetActive(false); break;
                case 3:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    break;
                case 4:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    break;
                case 5:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    break;
                case 6:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    lv6.SetActive(false);
                    break;
                case 7:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    lv6.SetActive(false);
                    lv7.SetActive(false);
                    break;
                case 8:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    lv6.SetActive(false);
                    lv7.SetActive(false);
                    lv8.SetActive(false);
                    break;
                case 9:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    lv6.SetActive(false);
                    lv7.SetActive(false);
                    lv8.SetActive(false);
                    lv9.SetActive(false);
                    break;
                case 10:
                    lv2.SetActive(false);
                    lv3.SetActive(false);
                    lv4.SetActive(false);
                    lv5.SetActive(false);
                    lv6.SetActive(false);
                    lv7.SetActive(false);
                    lv8.SetActive(false);
                    lv9.SetActive(false);
                    lv10.SetActive(false);
                    break;

                default: break;
            }


        }
    }



    public void PauseUI()
    {
        
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;

    }


    public void CancelPause()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
    }


    public void LoadContinue()
    {

        if (sceneToContinue != 0)
        {

            SceneManager.LoadScene(sceneToContinue);
            Time.timeScale = 1.0f;

        }

    }


    public void LoadLv1()
    {
        NewGame();
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void LoadLv2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }

    public void LoadLv3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }
    public void LoadLv4()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1.0f;
    }
    public void LoadLv5()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1.0f;
    }

    public void LoadLv6()
    {
        SceneManager.LoadScene(8);
        Time.timeScale = 1.0f;
    }
    public void LoadLv7()
    {
        SceneManager.LoadScene(9);
        Time.timeScale = 1.0f;
    }
    public void LoadLv8()
    {
        SceneManager.LoadScene(11);
        Time.timeScale = 1.0f;
    }
    public void LoadLv9()
    {
        SceneManager.LoadScene(12);
        Time.timeScale = 1.0f;
    }
    public void LoadLv10()
    {
        SceneManager.LoadScene(13);
        Time.timeScale = 1.0f;
    }

    public void LoadMenu()
    {
       

        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void SeLectLecvel()
    {
        SceneManager.LoadScene(14);
        Time.timeScale = 1.0f;

    }
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("SaveScene");
        Time.timeScale = 1.0f;
    }
    public void StartGame()
    {
        Invoke("NewGame", 1);
    }


    public void Exit()
    {
        Application.Quit();
    }


    public void LinkStore()
    {
        Application.OpenURL("https://thaogc.itch.io");
    }

    public void SelectCharacter()
    {
        SceneManager.LoadScene(16);
        Time.timeScale = 1.0f;
    }
}
