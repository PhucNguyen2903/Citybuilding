using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tile 
{

    public Buildings buildingRef;
    public ObstacleType obstacleType;

    bool isStarterTile = true;

    public enum ObstacleType
    {
        None,
        Resource,
        Building,
    }

    #region Methods
    public void SetOccupied(ObstacleType type)
    {
        obstacleType = type;
        
    }

    public void SetOccupied(ObstacleType type, Buildings building)
    {      
        obstacleType = type;
        buildingRef = building;
    }

    public void CleanTile()
    {
        obstacleType = ObstacleType.None;
    }

    public void StarterTileValue(bool value)
    {
        isStarterTile = value;

    }
    #endregion

    #region Booleans

    public bool IsOccupied
    {
        get
        {
             return obstacleType != ObstacleType.None;
        }
    }

    public bool canSpawnObstacle
    {
        get
        {
            return !isStarterTile;
        }    
    }

    #endregion
}
