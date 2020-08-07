using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] Generation generation;

    private void Start()
    {

    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        generation.NewDungeon();
    }
}
