using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsGUI : MonoBehaviour
{
    private SaveGame saveGame;

    // Start is called before the first frame update
    void Start()
    {
        saveGame = GameObject.Find("GameManager").GetComponent<SaveGame>();
    }

    //get the amount of rooms completed
    private void OnEnable()
    {
        if (GameObject.Find("GameManager").GetComponent<SaveGame>().RoomsCompleted() != -1)
        { 
            this.GetComponent<TextMeshProUGUI>().text = "Rooms completed: <b>" + saveGame.RoomsCompleted() + "</b>" + 
                "<br>Mission failed: <b>" + saveGame.DeathCount() + "x </b>";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
