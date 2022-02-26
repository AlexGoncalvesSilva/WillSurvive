using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerGame : MonoBehaviour
{

    public GameObject GameOver;
    public GameObject GameOverOxygen;
    public GameObject WinScreen;
    public GameObject WinScreen50;
    public GameObject WinScreen0;


    public GameObject pauseMenu;
    private bool activeMenu;
    private bool isPause;

    private bool isGameOver;
    private bool isFinished;

    public int Score;
    public Text scoreText;

    public int Life;
    public Text LifeText;

    public static GameControllerGame instance;

    public void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver && !isFinished)
        {
            activeMenu = !activeMenu;
            isPause = !isPause;
            pauseMenu.SetActive(activeMenu);

            if (isPause)
            {
                Pause();
            }
            else
            {
                unPause();
            }
        }
    }   

    void Pause()
    {
        Time.timeScale = 0;
    }

    void unPause()
    {
        Time.timeScale = 1;
    }

    public void GetPlant()
    {
        Score++;
        scoreText.text = "X " + Score.ToString();
    }

    public void Health()
    {
        Life--;
        LifeText.text = "X " + Life.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);  
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void PlayAgainWhenOxygenIsOver()
    {
        SceneManager.LoadScene(2);
        OxygenBar.instance.Oxygen = 120;
        Time.timeScale = 1;
    }
    public void WinGame()
    {
        isFinished = true;
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }

    public void WinGame50()
    {
        isFinished = true;
        Time.timeScale = 0;
        WinScreen50.SetActive(true);
    }
    public void WinGame0()
    {
        isFinished = true;
        Time.timeScale = 0;
        WinScreen0.SetActive(true);
    }


    public void exitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
    public void ShowGameOverOxygen()
    {
        isGameOver = true;
        Time.timeScale = 0;
        GameOverOxygen.SetActive(true);
    }
}
