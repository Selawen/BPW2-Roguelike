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
        if (generation.gameObject.GetComponent<Pause>().paused)
        {
            generation.gameObject.GetComponent<Pause>().PauseGame();
        }
        else
        {
            panels.deathPanel.SetActive(false);
            Time.timeScale = 1;
        }
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
        if (generation.gameObject.GetComponent<Pause>().paused)
        {
            generation.gameObject.GetComponent<Pause>().PauseGame();
        }
        panels.finishPanel.SetActive(false);
        panels.deathPanel.SetActive(false);
        panels.mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
