using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    [SerializeField] private int minLength, maxLength;
    private int length;
    [SerializeField] private int height;
    public Coordinate size;

    private Wall[,] dungeonGrid;
    [SerializeField] private Wall wallPrefab;

    public Coordinate nextDirection;
    public Coordinate previousWall;

// Start is called before the first frame update
void Start()
    {
        length = Random.Range(minLength, maxLength);
        //save the length and height of the dungeon as one "Coordinate"
        size = new Coordinate(length, height);

        MakePath();
    }

  /// <summary>
  /// make a path for the player to walk through
  /// </summary>
    public void MakePath()
    {
        dungeonGrid = new Wall[size.x, size.y];
        Coordinate coordinates = RandomCoordinates;
        //while the coordinates are within the array and there is not already a wall
        while (ContainsCoordinates(coordinates) && GetWall(coordinates) == null)
        {
            //place a wall at the given coordinates
            CreateWall(coordinates);
            nextDirection = Directions.RandomDirection(previousWall);
            coordinates += nextDirection;
            //saves the direction we came from
            previousWall = nextDirection * -1;
        }
    }

    //gets the wall at the given coordinates
    public Wall GetWall(Coordinate coordinates)
    {
        return dungeonGrid[coordinates.x, coordinates.y];
    }

    /// <summary>
    /// instantiates a wall and places it at the given coordinates
    /// </summary>
    /// <param name="wallCoordinate"></param>
    private void CreateWall(Coordinate wallCoordinate)
    {
        Wall newWall = Instantiate(wallPrefab) as Wall;
        dungeonGrid[wallCoordinate.x, wallCoordinate.y] = newWall;
        newWall.name = "Wall " + wallCoordinate.x + ", " + wallCoordinate.y;
        newWall.coordinates = wallCoordinate;
        newWall.transform.parent = transform;
        newWall.transform.localPosition = new Vector3(wallCoordinate.x *1.6f - size.x * 0.7f + 0.2f, wallCoordinate.y * 1.6f - size.y * 0.7f + 0.2f, 0f); 
    }

    /// <summary>
    /// generate a random coordinate within the size of the dungeon
    /// </summary>
    public Coordinate RandomCoordinates
    {
        get
        {
            return new Coordinate(Random.Range(0, size.x), Random.Range(0, size.y));
        }
    }

    /// <summary>
    /// see if given coordinates are within the set size for the dungeon
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    public bool ContainsCoordinates(Coordinate coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.y >= 0 && coordinate.y < size.y;
    }
}
