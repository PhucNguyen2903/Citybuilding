using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingObject : MonoBehaviour
{
    public Buildings data;


    [Header("Resource Generation")]
    [Space(8)]



    //this will be the resource that has been created by this building.
    public float resource = 0;


    //Limit that this building can generate or do.
    public int resourcelimit;


    //Speed that the resource is generated.
    public float generationSpeed = 100;

    Coroutine buildingBehaviour;

    private void Start()
    {
        buildingBehaviour = StartCoroutine(CretaResource());
    }

    IEnumerator CretaResource()
    {
        //It will create resources infinetly. 
        while (true)
        {
            resource += generationSpeed * Time.deltaTime;

        }

        yield return null;
    }

}
