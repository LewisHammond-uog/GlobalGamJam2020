using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : Drone
{
    public float resourcesPerMin;
    public ScavangerManager creator;


    //public void CollectResources(GameObject scavenger)
    //{
    //    float time = 60.0f;
    //    while (time <= extractTime)
    //    {
    //        GamestateManager.resources += 1.0f;
    //        time += Time.deltaTime;
    //    }
    //    ReturnScavenger();
    //}
}
