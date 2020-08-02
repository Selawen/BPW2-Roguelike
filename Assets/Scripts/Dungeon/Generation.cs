using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private int seed;

    public Dungeon dungeonPrefab;

    private Dungeon dungeonInstance;

    // Start is called before the first frame update
    void Start()
    {
        //when no seed is given, generate one
        if (seed == 0)
        {
            seed = Random.Range(1,1024);
        }

        //initialise random state with seed
        Random.InitState(seed);

        GenerateDungeon();
    }

    public void GenerateDungeon()
    {
        dungeonInstance = Instantiate(dungeonPrefab) as Dungeon;
    }

}
