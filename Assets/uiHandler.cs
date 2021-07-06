using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiHandler : MonoBehaviour
{
    GameObject pauseMenu;
    GameObject deathMenu;
    GameObject mainMenu;
    GameObject inGame;
    Text hiScore;
    Text hiScore2;
    Text score;
    bool death ;

    void Start()
    {
      hiScore = GameObject.Find("hiScore").GetComponent<Text>();
      hiScore2 = GameObject.Find("hiScore2").GetComponent<Text>();
      score = GameObject.Find("Score").GetComponent<Text>();
      pauseMenu = GameObject.Find("PauseMenu");
      deathMenu = GameObject.Find("DeathMenu");
      mainMenu = GameObject.Find("MainMenu");
      inGame = GameObject.Find("inGame");
      MainMenu();
      DontDestroyOnLoad(this.gameObject);
      Debug.Log("Start");
    }
    
    void Update()
    {
      hiScore.text = PlayerPrefs.GetInt("hiScore").ToString();
      hiScore2.text = PlayerPrefs.GetInt("hiScore").ToString();
      score.text = PlayerPrefs.GetInt("score").ToString();
      if(PlayerPrefs.GetInt("death") == 1)
      {
        Death();
      }

    }

    public void Restart()
    {
      inGame.SetActive(true);
      pauseMenu.SetActive(false);
      deathMenu.SetActive(false);
      mainMenu.SetActive(false);
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
      Time.timeScale = 1f;
    }

    public void Continue()
    {
      inGame.SetActive(true);
      pauseMenu.SetActive(false);
      deathMenu.SetActive(false);
      mainMenu.SetActive(false);
      Debug.Log("SetFalse");
      Time.timeScale = 1f;
    }
    public void Pause()
    {
      Time.timeScale = 0f;
      inGame.SetActive(false);
      pauseMenu.SetActive(true);
      deathMenu.SetActive(false);
      mainMenu.SetActive(false);
    }
    public void Death()
    {
      Time.timeScale = 0f;
      inGame.SetActive(false);
      pauseMenu.SetActive(false);
      deathMenu.SetActive(true);
      mainMenu.SetActive(false);
      PlayerPrefs.SetInt("death", 0);
    }
    public void MainMenu()
    {
      Time.timeScale = 0f;
      inGame.SetActive(false);
      pauseMenu.SetActive(false);
      deathMenu.SetActive(false);
      mainMenu.SetActive(true);
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
    }



}
