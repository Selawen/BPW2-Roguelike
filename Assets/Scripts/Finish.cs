using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    UIPanels panels;
    public bool hasFinished;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        panels = GameObject.Find("Canvas").GetComponent<UIPanels>();
        panels.finishPanel.SetActive(false);
        hasFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<SaveGame>().CompletedRoom();
            hasFinished = true;
            Time.timeScale = 0;
            panels.finishPanel.SetActive(true);
        }
    }
}
