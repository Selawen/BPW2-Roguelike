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

    public List<Wall> path { get; private set; }
    public Coordinate nextDirection;
    public Coordinate previousDirection;

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
        MakePath();
        GenerateFiller();
    }

    /// <summary>
    /// make a path for the player to walk through
    /// </summary>
    public void MakePath()
    {
        Coordinate thisCoordinate = RandomCoordinates;

        //while the coordinates are within the array and there is not already a wall
        do
        {
            if (GetWall(thisCoordinate) == null)
            {
                //place a wall at the given coordinates
                path.Add(CreateWall(thisCoordinate));
                nextDirection = Directions.RandomDirection(previousDirection);
                thisCoordinate += nextDirection;
                //saves the direction we came from
                previousDirection = nextDirection * -1;
            }
            else //take a step back and try from there
            {
                path.RemoveAt(path.Count - 1);
                thisCoordinate = path[path.Count - 1].coordinates;
                previousDirection *= -1;
                nextDirection = Directions.RandomDirection(previousDirection);
                thisCoordinate += nextDirection;
            }
        } while (ContainsCoordinates(thisCoordinate) && path.Count > 0);
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
        Wall newWall = Instantiate(wallPrefab) as Wall;
        pathGrid[wallCoordinate.x, wallCoordinate.y] = newWall;
        newWall.name = "Wall " + wallCoordinate.x + ", " + wallCoordinate.y;
        newWall.coordinates = wallCoordinate;
        newWall.transform.parent = transform;
        newWall.transform.localPosition = new Vector3(wallCoordinate.x * 1.6f - size.x * 0.7f + 0.2f, wallCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0f);
        return newWall;
    }

    /// <summary>
    /// generate a random coordinate within the size of the dungeon
    /// </summary>
    public Coordinate RandomCoordinates
    {
        get
        {
            return new Coordinate(Random.Range(0, size.x), Random.Range(1, size.y));
        }
    }

    /// <summary>
    /// see if given coordinates are within the set size for the dungeon, leaving a layer for ground
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    public bool ContainsCoordinates(Coordinate coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.y >= 1 && coordinate.y < size.y;
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
        Ground newGround = Instantiate(groundPrefab) as Ground;
        fillerGrid[GroundCoordinate.x, GroundCoordinate.y] = newGround;
        newGround.name = "Ground " + GroundCoordinate.x + ", " + GroundCoordinate.y;
        newGround.coordinates = GroundCoordinate;
        newGround.transform.parent = transform;
        newGround.transform.localPosition = new Vector3(GroundCoordinate.x * 1.6f - size.x * 0.7f + 0.2f, GroundCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0f);
        return newGround;
    }
}
