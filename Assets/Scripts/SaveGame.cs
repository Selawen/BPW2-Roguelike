using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveGame : MonoBehaviour
{
    private SaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
        ReadSaveData();
        //Debug.Log(saveData.currentSeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadSaveData()
    {
        if (File.Exists(Application.dataPath + "/saveData.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/saveData.json");

            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }

    }

    /// <summary>
    /// returns the seed that was saved
    /// </summary>
    /// <returns></returns>
    public int LoadSeedData()
    {
        return saveData.currentSeed;
    }

    /// <summary>
    /// updates the seed in savedata to the new seed
    /// </summary>
    /// <param name="newSeed"></param>
    public void SaveNewSeed(int newSeed)
    {
        saveData.currentSeed = newSeed;
    }

    /// <summary>
    /// adds one to completed rooms counter
    /// </summary>
    public void CompletedRoom()
    {
        saveData.roomsCompleted++;
    }    
    
    /// <summary>
    /// adds one to death counter
    /// </summary>
    public void MissionFailed()
    {
        saveData.timesDied++;
    }

    /// <summary>
    /// returns # of rooms completed
    /// </summary>
    /// <returns></returns>
    public int RoomsCompleted()
    {
        try
        {
            return saveData.roomsCompleted;
        }
        catch (NullReferenceException)
        {
            return -1;
            throw;
        }
    }

    /// <summary>
    /// returns 3 of timed "died"
    /// </summary>
    /// <returns></returns>
    public int DeathCount()
    {
        try
        {
            return saveData.timesDied;
        }
        catch (NullReferenceException)
        {
            return -1;
            throw;
        }
    }

    public void ClearData()
    {
        saveData = new SaveData();
    }

    private void OnApplicationQuit()
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.dataPath + "/saveData.json", json);
    }
}
