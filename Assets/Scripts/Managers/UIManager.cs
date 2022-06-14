using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject CreditsPanel;
    public GameObject ScoreTimePanel;
    public GameObject MenuButton;
    public GameObject TapToStartButton;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;
    public GameObject joystick;


    [HideInInspector]
    public int score; //dynamic current score to screen
    
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");

        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        
    }

    void Update()
    {
          
        if(GameManager.ControlTime > GameManager.staticLevelTime)
        {
            TimeText.text = "Bully T�me";
            ScoreText.text = "Bonus";
        }
        else
        {
            TimeText.text = "T�me: " + (GameManager.staticLevelTime - (int)GameManager.ControlTime);
            ScoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        }
    }


    public void ResumeButton()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
        ScoreTimePanel.SetActive(true);
        MenuButton.SetActive(true);
        joystick.SetActive(true);
    }

    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);
        joystick.SetActive(false);
        MenuPanel.SetActive(false);
        ScoreTimePanel.SetActive(false);
        MenuButton.SetActive(false);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause2Menu()
    {
        joystick.SetActive(false);
        MenuPanel.SetActive(true);
        ScoreTimePanel.SetActive(false);
        MenuButton.SetActive(false);
        CreditsPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void tapToStart()
    {
        TapToStartButton.SetActive(false);
        MenuButton.SetActive(true);
        ScoreTimePanel.SetActive(true);
        joystick.SetActive(true);
        Time.timeScale = 1;
    }

}
