using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAchievements : MonoBehaviour
{
    private SaveGame saveGame;

    private void Start()
    {
        saveGame = GameObject.Find("GameManager").GetComponent<SaveGame>();
    }

    private void Update()
    {
        if (saveGame.RoomsCompleted() > PlayerPrefs.GetInt("highestRoomsInRun"))
        {
            PlayerPrefs.SetInt("highestRoomsInRun", saveGame.RoomsCompleted());
        }

        if (saveGame.DeathCount() > PlayerPrefs.GetInt("highestDeathsInRun"))
        {
            PlayerPrefs.SetInt("highestDeathsInRun", saveGame.DeathCount());
        }
    }
}
