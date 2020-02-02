using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Drone
{

    [HideInInspector]
    public float repiarPerSec = 1;

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (currentState == DroneState.DOING_TASK)
        {
            if (destinationTile.discovered && destinationTile.repairState < 100)
            {
                destinationTile.repairState += repiarPerSec * Time.deltaTime;
            }
            else
            {
                currentState = DroneState.GOTO_BASE;
                creator.ReturnDrone();
            }
        }
    }
}
