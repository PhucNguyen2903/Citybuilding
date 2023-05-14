using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int resourceAmount = 10;
    TileObject refTile;


    //this can optimize
    bool usedResource = false;



    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);

        //Onclick Event

        //We can call directly the method that adds the resources

        switch (obstacleType)
        {
            case ObstacleType.Wood:
                usedResource = ResourcesManager.Instance.AddWood(resourceAmount);
                break;
            case ObstacleType.Rock:
                usedResource = ResourcesManager.Instance.AddStone(resourceAmount);             
                break;          
        }

        if (usedResource)
        {
            refTile.data.CleanTile();
            Destroy(gameObject);
        }
        else
            Debug.Log("Can't Add " + obstacleType);
    }

    public void SetTileReference(TileObject obj)
    {
        refTile = obj;

    }

    public enum ObstacleType
    {
        Wood,
        Rock,
    }
}
