using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    public Text textHN;
    public Text textSN;
    public Button reset;
    public Button quit;
    public Button menu;
    
    void Update()
    {
        textSN.text="Your Score: " + StartGame.Score.ToString();
        if (StartGame.Score>StartGame.HighScore)
        {
            StartGame.HighScore=StartGame.Score;
        }
        textHN.text="High Score: " + StartGame.HighScore.ToString();
    }

    void Start()
    {
        reset.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        textSN.gameObject.SetActive(true);
        textHN.gameObject.SetActive(true);
    }


    public void Ending()
    {
        reset.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MENU");
;
    }
}
