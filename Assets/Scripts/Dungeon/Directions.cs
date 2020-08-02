using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//    public enum Direction
//    {
//        Up,
//        Right,
//        Down,
//        Left
//    }

public static class Directions
{
    public static Coordinate[] directionVectors { get; private set; } = {
        new Coordinate(0, 1),
        new Coordinate(1, 0),
        new Coordinate(0, -1),
        new Coordinate(-1, 0)
    };

    /// <summary>
    /// gives a random direction that is not the given direction
    /// </summary>
    /// <param name="back"></param>
    /// <returns></returns>
    public static Coordinate RandomDirection(Coordinate back)
    {
        Coordinate randomDirection;

        do
        {
            randomDirection = directionVectors[Random.Range(0, directionVectors.Length)];
        }
        while (randomDirection == back);

        {
            return randomDirection;
        }
    }
}
