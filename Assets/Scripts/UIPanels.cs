using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanels : MonoBehaviour
{
    public GameObject statsPanel;
    public GameObject achievementsPanel;
    public GameObject mainMenuPanel;
    public GameObject howToPlayPanel;
    public GameObject enemyExplainPanel;
    public GameObject finishPanel;
    public GameObject pausePanel;
    public GameObject deathPanel;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");        
        finishPanel = GameObject.Find("FinishPanel");
        statsPanel = GameObject.Find("StatsPanel");
        achievementsPanel = GameObject.Find("AchievementsPanel");
        mainMenuPanel = GameObject.Find("MainMenuPanel");
        howToPlayPanel = GameObject.Find("HowToPlayPanel");
        enemyExplainPanel = GameObject.Find("EnemyExplainPanel");
        deathPanel = GameObject.Find("DeathPanel");

        pausePanel.SetActive(false);
        finishPanel.SetActive(false);
        statsPanel.SetActive(false);
        achievementsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        enemyExplainPanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
