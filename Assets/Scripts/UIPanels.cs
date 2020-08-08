using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanels : MonoBehaviour
{
    public GameObject statsPanel;
    public GameObject mainMenuPanel;
    public GameObject finishPanel;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");        
        finishPanel = GameObject.Find("FinishPanel");
        statsPanel = GameObject.Find("StatsPanel");
        mainMenuPanel = GameObject.Find("MainMenuPanel");

        pausePanel.SetActive(false);
        finishPanel.SetActive(false);
        statsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
