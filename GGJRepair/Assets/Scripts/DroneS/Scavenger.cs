using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : Drone
{
    public float resourcesPerMin;
    public ScavangerManager creator;
    public float resorcePerSec = 1;

    private void Update()
    {
        base.Update();

        if(currentState == DroneState.DOING_TASK)
        {
            GamestateManager.resources += resorcePerSec * Time.deltaTime;
        }

    }

}
