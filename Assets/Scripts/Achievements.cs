using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Achievements : MonoBehaviour
{
    private SaveGame saveGame;

    // Start is called before the first frame update
    void Start()
    {
        saveGame = GameObject.Find("GameManager").GetComponent<SaveGame>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<SaveGame>().RoomsCompleted() != -1)
        {
            this.GetComponent<TextMeshProUGUI>().text = "Rooms completed this run: <b>" + saveGame.RoomsCompleted() + "</b>" +
                "<br>Missions failed this run: <b>" + saveGame.DeathCount() + "</b>" +
                "<br>Total amount of rooms completed: <b>" + PlayerPrefs.GetInt("totalRoomsCompleted") + "</b>" +
                "<br>Total amount of missions failed: <b>" + PlayerPrefs.GetInt("totalMissionsFailed") + "</b>" +
                "<br>Total amount of missions failed: <b>" + PlayerPrefs.GetInt("totalMissionsFailed") + "</b>" +
                "<br>highest amount of missions failed in one run: <b>" + PlayerPrefs.GetInt("highestDeathsInRun") + "</b>" +
                "<br>highest amount of rooms in one run: <b>" + PlayerPrefs.GetInt("highestRoomsInRun") + "</b>" 
                ;
        }
    }
}
