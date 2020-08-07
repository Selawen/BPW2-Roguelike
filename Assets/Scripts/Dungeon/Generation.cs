using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private int seed;
    private bool newSeed;

    public Dungeon dungeonPrefab;

    private Dungeon dungeonInstance;

    // Start is called before the first frame update
    void Start()
    {
        SetSeed();
        GenerateDungeon();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            NewDungeon();
        }
    }

    private void SetSeed()
    {
        //when no seed is given, generate one
        if (seed == 0 || newSeed == true)
        {
            seed = Random.Range(1, 1024) + Random.Range(0, 1024);
            newSeed = false;
        }

        //initialise random state with seed
        Random.InitState(seed);
    }

    public void GenerateDungeon()
    {
        dungeonInstance = Instantiate(dungeonPrefab) as Dungeon;
    }

    public void NewDungeon()
    {
        newSeed = true;
        dungeonInstance.gameObject.SetActive(false);
        SetSeed();
        GenerateDungeon();
    }
}
