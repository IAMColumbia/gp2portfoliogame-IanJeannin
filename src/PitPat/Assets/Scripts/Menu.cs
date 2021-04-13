using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject creditsPanel;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        GameState.stateOfGame = GameState.StateOfGame.Menu;
        //menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        GameState.stateOfGame = GameState.StateOfGame.Menu;
        menuPanel.SetActive(true);
    }

    public void PlayGame()
    {
        menuPanel.SetActive(false);
        if (GameState.stateOfGame == GameState.StateOfGame.Menu)
        {
        }
        GameState.stateOfGame = GameState.StateOfGame.Play;
        Time.timeScale = 1;
        Songs.PlaySong(Songs.GetRandomSong());
    }

    public void ShowCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}