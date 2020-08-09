using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    UIPanels panels;
    public bool paused { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        panels = GameObject.Find("Canvas").GetComponent<UIPanels>();
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.Find("Finish").GetComponent<Finish>().hasFinished)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        panels.pausePanel.SetActive(paused);
        if (panels.statsPanel.activeSelf)
        {
            panels.statsPanel.SetActive(false);
        }
    }
}
