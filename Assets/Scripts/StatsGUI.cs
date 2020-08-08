using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //get the amount of rooms completed
    private void OnEnable()
    {
        if (GameObject.Find("GameManager").GetComponent<SaveGame>().RoomsCompleted() != -1)
        { 
            this.GetComponent<TextMeshProUGUI>().text = "<b>" + GameObject.Find("GameManager").GetComponent<SaveGame>().RoomsCompleted() + "</b> rooms completed";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
