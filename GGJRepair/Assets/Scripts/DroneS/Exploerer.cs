using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploerer : Drone
{

    // Update is called once per frame
    private void Update()
    {
        base.Update();

        if (currentState == DroneState.DOING_TASK)
        {
            //If this tile runs out of resources then return the
            //drone to base
            destinationTile.DiscoverTile();

            if (destinationTile.discovered)
            {
                currentState = DroneState.GOTO_BASE;
            }
        }

    }
}
