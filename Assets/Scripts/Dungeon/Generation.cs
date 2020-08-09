using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int seed;
    private bool newSeed;

    public Dungeon dungeonPrefab;

    private Dungeon dungeonInstance;

    public List<Dungeon> generatedDungeons;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            NewDungeon();
        }
    }

    private void SetSeed()
    {
        seed = gameObject.GetComponent<SaveGame>().LoadSeedData();

        //when no seed is given or a new seed is needed, generate one
        if (seed == 0 || newSeed == true)
        {
            seed = Random.Range(1, 1024) + Random.Range(0, 1024);
            newSeed = false;
            gameObject.GetComponent<SaveGame>().SaveNewSeed(seed);
        }

        //initialise random state with seed
        Random.InitState(seed);
    }

    public void GenerateDungeon()
    {
        dungeonInstance = Instantiate(dungeonPrefab) as Dungeon;
        generatedDungeons.Add(dungeonInstance);
    }

    public void NewDungeon()
    {
        newSeed = true;
        if (generatedDungeons.Count != 0)
        {
            generatedDungeons[generatedDungeons.Count - 1].gameObject.SetActive(false);
        }
        SetSeed();
        GenerateDungeon();
    }

    public void RegenerateDungeon()
    {
        if (generatedDungeons.Count != 0)
        {
            generatedDungeons[generatedDungeons.Count-1].gameObject.SetActive(false);
        }
        SetSeed();
        GenerateDungeon();
    }


    public void DestroyOldDungeons()
    {
        for (int x = generatedDungeons.Count-1; x >= 0; x--)
        {
            Destroy(generatedDungeons[x].gameObject);
            generatedDungeons.RemoveAt(x);
        }
    }
}
