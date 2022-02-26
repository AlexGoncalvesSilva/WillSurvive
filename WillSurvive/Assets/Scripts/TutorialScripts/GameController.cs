using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject GameOver;
    public GameObject GameOverOxygen;
    public GameObject FinishedTutorial;

    public GameObject pauseMenu;
    private bool activeMenu;
    private bool isPause;

    private bool isGameOver;
    private bool isFinished;

    public int Score;
    public Text scoreText;

    public int Life;
    public Text LifeText;

    public static GameController instance;

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
            Score += 1;
            scoreText.text = "X " + Score.ToString();
        if (Score >= 4)
        {
            ShowFinishedTutorial();
        }
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

    public void CloseTutorial(GameObject cr)
    {
        cr.SetActive(false);
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
    public void ShowFinishedTutorial()
    {
        isFinished = true;
        Time.timeScale = 0;
        FinishedTutorial.SetActive(true);
    }
}
