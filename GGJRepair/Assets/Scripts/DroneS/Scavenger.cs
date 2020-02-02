using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : Drone
{

    [HideInInspector]
    public float resorcePerSec = 1;

    private void Update()
    {
        base.Update();

        if(currentState == DroneState.DOING_TASK)
        {
            //If this tile runs out of resources then return the
            //drone to base
            if (destinationTile.discovered)
            {
                if (destinationTile.remainingResources > 0)
                {
                    float resorucesToTakeThisFrame = resorcePerSec * Time.deltaTime;
                    GamestateManager.resources += resorucesToTakeThisFrame;
                    destinationTile.remainingResources -= resorucesToTakeThisFrame;
                }
                else
                {
                    currentState = DroneState.GOTO_BASE;
                }
            }
            else
            {
                currentState = DroneState.GOTO_BASE;
            }
        }

    }

}
