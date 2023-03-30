using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuScript : MonoBehaviour
{
    [SerializeField] private Button playbutton;
    [SerializeField] private Button Quitbutton;

    private void Awake()
    {
        playbutton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("gameScene");
        });

        playbutton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
