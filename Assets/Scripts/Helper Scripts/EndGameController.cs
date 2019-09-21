using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public static EndGameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowDeathScreen(int wave)
    {
        gameObject.SetActive(true);
        GameObject.FindWithTag(Tags.FINAL_SCORE).GetComponent<Text>().text = string.Format("Fala: {0}", wave);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}