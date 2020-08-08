using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField] private int minLength, maxLength;
    private int length;
    [SerializeField] private int minHeight, maxHeight;
    private int height;
    public Coordinate size;

    private Wall[,] pathGrid;
    private Ground[,] fillerGrid;
    [SerializeField] private Wall wallPrefab;
    [SerializeField] private Ground groundPrefab;
    [SerializeField] private Border borderPrefab;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Finish finishPrefab;

    public List<Wall> path { get; private set; }
    public Coordinate nextDirection;
    public Coordinate previousDirection;

    [SerializeField] private Coordinate startCoordinate;
    [SerializeField] private Coordinate endCoordinate;

    // Start is called before the first frame update
    void Start()
    {
        length = Random.Range(minLength, maxLength);
        height = Random.Range(minHeight, maxHeight);
        //save the length and height of the dungeon as one "Coordinate"
        size = new Coordinate(length, height);
        //initialise grids for path and filler
        pathGrid = new Wall[size.x, size.y];
        fillerGrid = new Ground[size.x, size.y];

        //create a path through the dungeon
        path = new List<Wall>();
        GeneratePath();
        GenerateFiller();
        GenerateBorders();
        GenerateContent();
    }

    /// <summary>
    /// make a path for the player to walk through
    /// </summary>
    public void GeneratePath()
    {
        Coordinate thisCoordinate = RandomStartCoordinate;

        //while there are no start or endpoints yet
        do
        { 
            //while the coordinates are within the array and there is not already a wall
            do
            {
                if (GetWall(thisCoordinate) == null)
                {
                    //place a wall at the given coordinates
                    path.Add(CreateWall(thisCoordinate));

                    //generate next coordinate
                    nextDirection = Directions.RandomDirection(previousDirection);
                    thisCoordinate += nextDirection;

                    //saves the direction we came from
                    previousDirection = nextDirection * -1;
                }
                else //take a random tile on the path and try from there
                {
                    thisCoordinate = path[(int)Random.Range(0, path.Count - 1)].coordinates;
                    previousDirection = new Coordinate(0, 0);

                    nextDirection = Directions.RandomDirection(previousDirection);
                    thisCoordinate += nextDirection;
                }
            } while (ContainsCoordinates(thisCoordinate));
            thisCoordinate = path[(int)Random.Range(0, path.Count - 1)].coordinates;
        } while ((endCoordinate == new Coordinate(0, 0)));
    }

    //gets the wall at the given coordinates
    public Wall GetWall(Coordinate coordinates)
    {
        return pathGrid[coordinates.x, coordinates.y];
    }

    /// <summary>
    /// instantiates a wall and places it at the given coordinates
    /// </summary>
    /// <param name="wallCoordinate"></param>
    private Wall CreateWall(Coordinate wallCoordinate)
    {
        //instantiate wall
        Wall newWall = Instantiate(wallPrefab, transform) as Wall;
        pathGrid[wallCoordinate.x, wallCoordinate.y] = newWall;
        newWall.name = "Wall " + wallCoordinate.x + ", " + wallCoordinate.y;
        newWall.coordinates = wallCoordinate;
        newWall.transform.position = new Vector3(wallCoordinate.x * 1.6f - size.x * 0.7f + 0.2f, wallCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0f);

        //set begin or endtile if at start or endpos
        if(wallCoordinate.x == 0)
        {
            startCoordinate = wallCoordinate;
        }
        if (wallCoordinate.x == size.x-1)
        {
            endCoordinate = wallCoordinate;
        }

        return newWall;
    }

    /// <summary>
    /// generate a random coordinate within the size of the dungeon, leaving the top and bottom layer free
    /// </summary>
    public Coordinate RandomStartCoordinate
    {
        get
        {
            return new Coordinate(0, Random.Range(1, size.y-1));
        }
    }

    /// <summary>
    /// see if given coordinates are within the set size for the dungeon
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    public bool ContainsCoordinates(Coordinate coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.y >= 1 && coordinate.y < (size.y-1);
    }

    /// <summary>
    /// fill all empty spaces with ground
    /// </summary>
    public void GenerateFiller()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Coordinate thisCoordinate = new Coordinate(x, y);
                if (GetWall(thisCoordinate) == null)
                {
                    CreateGround(thisCoordinate);
                }
            }
        }
    }

    /// <summary>
    /// instantiates a ground tile and places it at the given coordinates
    /// </summary>
    /// <param name="groundCoordinate"></param>
    private Ground CreateGround(Coordinate GroundCoordinate)
    {
        Ground newGround = Instantiate(groundPrefab, transform) as Ground;
        fillerGrid[GroundCoordinate.x, GroundCoordinate.y] = newGround;
        newGround.name = "Ground " + GroundCoordinate.x + ", " + GroundCoordinate.y;
        newGround.coordinates = GroundCoordinate;
        newGround.transform.position = new Vector3(GroundCoordinate.x * 1.6f - size.x * 0.7f + 0.2f, GroundCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0f);
        return newGround;
    }

    
    private void GenerateBorders()
    {
        Border borderLeft = Instantiate(borderPrefab, transform) as Border;
        borderLeft.name = "Border Left";
        borderLeft.coordinates = new Coordinate(-1,0);
        borderLeft.transform.localScale = new Vector3(borderLeft.transform.localScale.x, borderLeft.transform.localScale.y * size.y, borderLeft.transform.localScale.z);
        borderLeft.transform.position = new Vector3(borderLeft.coordinates.x * 1.6f - size.x * 0.7f + 0.2f, 0.0f, 0.0f);

        Border borderRight = Instantiate(borderPrefab, transform) as Border;
        borderRight.name = "Border Right";
        borderRight.coordinates = new Coordinate((size.x+1), 0);
        borderRight.transform.localScale = new Vector3(borderRight.transform.localScale.x, borderRight.transform.localScale.y * size.y, borderRight.transform.localScale.z);
        borderRight.transform.position = new Vector3(borderRight.coordinates.x *1.6f - size.x*0.8f + 0.2f, 0.0f, 0.0f);
    }
    


    private void GenerateContent()
    {
        //instantiate player
        Player newPlayer = Instantiate(playerPrefab, transform) as Player;
        newPlayer.name = "Player";

        while (GetWall(startCoordinate - new Coordinate(0,1)) != null)
        {
            startCoordinate -= new Coordinate(0, 1);
        }

        newPlayer.transform.position = new Vector3(startCoordinate.x * 1.6f - size.x * 0.7f + 0.2f, startCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0.0f);

        //instantiate finish
        Finish newFinish = Instantiate(finishPrefab, transform) as Finish;
        newFinish.name = "Finish";
        newFinish.GetComponent<Finish>().hasFinished = false;

        newFinish.transform.position = new Vector3(endCoordinate.x * 1.6f - size.x * 0.7f + 0.2f, endCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0.0f);
    }
}
