using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DroneManager : MonoBehaviour
{
    public int totalDrones;
    public int donesOnShip;
    public Vector3 baseLocation;

    public void ReturnDrone()
    {
        donesOnShip++;
    }
}
