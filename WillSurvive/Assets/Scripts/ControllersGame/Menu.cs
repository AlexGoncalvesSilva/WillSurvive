using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void exitOptionsMenu(GameObject op)
    {
        op.SetActive(false);
    }
    public void activeOptionsMenu(GameObject op)
    {
        op.SetActive(true);
    }

    public void exitCreditsMenu(GameObject cr)
    {
        cr.SetActive(false);
    }
    public void activeCreditsMenu(GameObject cr)
    {
        cr.SetActive(true);
    }

    public void exitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
