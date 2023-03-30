using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int points = 0;
    public TextMeshProUGUI scoreText;

    public GameObject pausemenu;
    public GameObject Player;
    public GameObject GameOver;

    bool isGamePause = false;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button mainmenuButton;
    [SerializeField] private Button QuitButton;

    private void Awake()
    {
        Instance = this;
        resumeButton.onClick.AddListener(() =>
        {
            PauseGame();
        });

        RestartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("gameScene");
        });

        mainmenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Mainmenu");
        });

        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    void Start()
    {
        scoreText.text = points.ToString();
        pausemenu.SetActive(false);
        GameOver.SetActive(false);
        Time.timeScale = 1f;
    }
   
    public void UpdateScore(int score)
    {
        points += score;
        scoreText.text = points.ToString();
        
    }

    public void PauseGame()
    {
        isGamePause = !isGamePause;
        if (isGamePause)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
           // Player.SetActive(false);
        }
        else
        {
            pausemenu.SetActive(false);
           // Player.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    public void gameover()
    {
        GameOver.SetActive(true);
    }
}
