using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Drone
{
    public WorkerManager creator;
    public float repiarPerSec = 1;

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if(currentState == DroneState.DOING_TASK)
        {
            destinationTile.repairState += repiarPerSec * Time.deltaTime;
        }
    }
}
