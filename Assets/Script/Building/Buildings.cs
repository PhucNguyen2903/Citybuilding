using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Buildings 
{

    //Building ID for referencing the exact type of building
    public int buildingID;

    // Width X Axis that will be used inside the grid
    public int width = 0;

    // Length Z Axis that will be used inside the grid
    public int length = 0;

    //visual of the building.
    public GameObject buildingModel;

    //small padding in case the building is clipping through the floor.
    public float yPadding = 0;

    // Type of functionality of the the building 
    public ResourceType resourceType = ResourceType.None;

    public enum ResourceType
    {
        None,
        Standard,
        Preminum,

    }


}
