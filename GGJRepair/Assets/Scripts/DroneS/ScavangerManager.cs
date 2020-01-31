using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavangerManager : DroneManager
{

    [SerializeField]
    private GameObject scavengerPrefab;
    public float upgradeCost = 20.0f;
    public int scavengersOnShip;


    // Start is called before the first frame update
    void Start()
    {
        scavengersOnShip = 1;
        totalDrones = scavengersOnShip;
    }

    public void BuyScavenger()
    {
        if (GamestateManager.resources >= upgradeCost)
        {
            GamestateManager.resources -= upgradeCost;
            scavengersOnShip++;
            totalDrones++;
        }   
    }

    public void DeployScavenger()
    {
        //Choose destination 
        
        scavengersOnShip--;
    }
    
}
