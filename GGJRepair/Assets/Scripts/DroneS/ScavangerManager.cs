using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavangerManager : DroneManager
{

    [SerializeField]
    private GameObject scavengerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dronesOnShip = 1;
        totalDrones = dronesOnShip;
    }

    public void CreateScavenger()
    {
        GameObject scavenger = Instantiate(scavengerPrefab);
    }
    

}
