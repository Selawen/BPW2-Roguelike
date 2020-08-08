using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Generation generation;
    SaveGame saveGame;
    UIPanels panels;
    private bool showStats;

    private void Start()
    {
        generation = GameObject.Find("GameManager").GetComponent<Generation>();
        saveGame = GameObject.Find("GameManager").GetComponent<SaveGame>();
        panels = gameObject.GetComponent<UIPanels>();
        showStats = false;
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        generation.NewDungeon();
    }

    public void RetryLevel()
    {
        GameObject.Find("GameManager").GetComponent<Pause>().PauseGame();
        generation.RegenerateDungeon();
    }

    public void NewGame()
    {
        saveGame.ClearData();
        generation.NewDungeon();
        panels.mainMenuPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        generation.RegenerateDungeon();
        panels.mainMenuPanel.SetActive(false);
    }

    public void Stats()
    {
        showStats = !panels.statsPanel.activeSelf;
        panels.statsPanel.SetActive(showStats);
    }

    public void MainMenu()
    {
        generation.DestroyOldDungeons();
        panels.pausePanel.SetActive(false);
        panels.statsPanel.SetActive(false);
        panels.finishPanel.SetActive(false);
        panels.mainMenuPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
