using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [Header("Builder")]

    [Space(8)]

    [SerializeField] GameObject _tilePrefab;
    [SerializeField] Transform _tileHolder;
    [SerializeField] Transform _resourceHolder;
    [SerializeField] Transform _buildingHolder;



    public int levelWidth;
    public int levelLength;
    public float tileSize = 1;
    public float tileEndHeight = 1;

    [Space(8)]
    //this is the grid that directly stores all of the information.
    public TileObject[,] tileGrid = new TileObject[0, 0];

    [Header("Resources")]
    [Space(8)]

    [SerializeField] GameObject _woodPrefab;
    [SerializeField] GameObject _rockPrefab;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;


    public int xBounds = 3;
    public int zBounds = 3;

    [Space(8)]

    //Debug method(the selected method)
    public BuildingObject buildingToPlace;

    private void Awake()
    {
        GameManager.instance = this;
    }



    private void Start()
    {
        CreateLevel();

    }


    //<sumary>
    // Create our grid depending on our level Width and length.
    //</sumary>
    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();

        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //Directly spawns a tile.
                TileObject tileObj = SpawnTile(x * tileSize, z * tileSize);

                //Set the Tileobject world space data.
                tileObj.xPos = x;
                tileObj.zPos = z;

                //Checks whenever we can spawn an object inside a tile, using the bound parameters
                if (x < xBounds || z < zBounds || z > (levelLength - zBounds) || x > (levelWidth - zBounds))
                {
                    //We can spawn an obstacle in there

                    tileObj.data.StarterTileValue(false);
                }

                if (tileObj.data.canSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {
                        tileObj.data.SetOccupied(Tile.ObstacleType.Resource);
                        ObstacleObject tmpObstacle = SpawnObstacle(tileObj.transform.position.x, tileObj.transform.position.z);
                        tmpObstacle.SetTileReference(tileObj);

                    }
                }
                //Add the spawned visual tileobject inside the list.
                visualGrid.Add(tileObj);
            }

        }
        CreateGrid(visualGrid);
    }
    TileObject SpawnTile(float xPos, float zPos)
    {
        //this will spawn the tile
        GameObject tmpTile = Instantiate(_tilePrefab, _tileHolder);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);

        tmpTile.name = "Tile " + xPos + " - " + zPos;

        TileObject tileobj = tmpTile.GetComponent<TileObject>();
        return tileobj;
    }

    ObstacleObject SpawnObstacle(float xPos, float zPos)
    {

        // It has a 50% percent of Spawning a wood obstacle
        bool isWood = Random.value < 0.5f;

        GameObject spawnedObstacle = null;


        //check whether we spawn a wood obstacle or a stone obstacle
        if (isWood)
        {
            spawnedObstacle = Instantiate(_woodPrefab, _resourceHolder);
            spawnedObstacle.name = "Wood" + xPos + " - " + zPos;
        }
        else
        {
            spawnedObstacle = Instantiate(_rockPrefab, _resourceHolder);
            spawnedObstacle.name = "Stone" + xPos + " - " + zPos;

        }

        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        return spawnedObstacle.GetComponent<ObstacleObject>();

    }

    /// <summary>
    /// Creating tile grid to add buildings.
    /// </summary>
    public void CreateGrid(List<TileObject> visualList)
    {
        //set the size of tile grid.
        tileGrid = new TileObject[levelWidth, levelLength];
        //Debug.Log(tileGrid.GetLowerBound(1));
        //Debug.Log(tileGrid.GetUpperBound(1));


        //Iterates through all of the tile grid 
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //connects the tile grid directly to the visual grid. 
                tileGrid[x, z] = visualList.Find(v => v.xPos == x && v.zPos == z);
                //Debug.Log(tileGrid[x,z].gameObject.name);
            }
        }

    }

    public void SpawnBuilding(BuildingObject building, List<TileObject> tileObjects)
    {
        GameObject spawnedBuilding = Instantiate(building.gameObject, _buildingHolder);
        float sumX = 0;
        float sumZ = 0;

        //old position
        //Vector3 position = new Vector3(tileObject.xPos, tileEndHeight, tileObject.zPos);


        for (int i = 0; i < tileObjects.Count; i++)
        {
            sumX += tileObjects[i].xPos;
            sumZ += tileObjects[i].zPos;

            tileObjects[i].data.SetOccupied(Tile.ObstacleType.Building);
            Debug.Log("Placed building in" + tileObjects[i].xPos + " - " + tileObjects[i].zPos);
        }


        //set the correct position.
        Vector3 position = new Vector3((sumX / tileObjects.Count), tileEndHeight + building.data.yPadding, (sumZ / tileObjects.Count));

        //Sum value of X positions of all tileobjects
        //Sum value of the Z  positions of all the tiles.

        spawnedBuilding.transform.position = position;


    }
}
