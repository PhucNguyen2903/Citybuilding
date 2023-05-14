using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class TileObject : MonoBehaviour
{
    public Tile data;

    [Header("World Tile Data")]
    [Space(8)]

    //position of the tile

    public int xPos;
    public int zPos;

    public void OnMouseDown()
    {
        if (!data.IsOccupied)
        {
            if (GameManager.Instance.buildingToPlace != null)
            {


                List<TileObject> iterateTiles = new List<TileObject>();
              
                //Flag for chiecking if we are able to build in here.
                bool canPlaceBuildingHere = true;

                var width = GameManager.Instance.buildingToPlace.data.width;
                for (int x = xPos; x < xPos + width; x++)
                {
                    if (canPlaceBuildingHere)
                    {
                        var length = GameManager.Instance.buildingToPlace.data.length;
                        for (int z = zPos; z < zPos + length; z++)
                        {
                            iterateTiles.Add(GameManager.Instance.tileGrid[x,z]);

                            bool check = GameManager.Instance.tileGrid[x, z].data.IsOccupied;
                            if (check)
                            {
                                canPlaceBuildingHere = false;
                            }

                            break;
                        }
                    }
                    else
                    {
                        break;
                    }


                }

                if (canPlaceBuildingHere)
                {
                    GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iterateTiles);
                }
                else
                {
                    Debug.Log(" Could not place building");
                }
            }
            else
            {
                Debug.Log("building to place is null");
            }
        }
        Debug.Log("Clicked on " + gameObject.name);
    }
}
