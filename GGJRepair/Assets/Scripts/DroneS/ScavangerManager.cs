using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavangerManager : DroneManager
{
    [SerializeField]
    public GameObject scavengerPrefab;
    public float upgradeCost = 20.0f;
    public float extractTime = 60.0f; //Time it takes to return to station
    public float resourcePerMinute = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        totalDrones = donesOnShip;
    }

    public void BuyScavenger()
    {
        if (GamestateManager.resources >= upgradeCost)
        {
            GamestateManager.resources -= upgradeCost;
            donesOnShip += 1;
            totalDrones += 1;
        }
    }

    public void DeployScavenger()
    {
        if(donesOnShip >= 1)
        {
            GameObject newScavenger = Instantiate(scavengerPrefab, baseLocation, Quaternion.identity);
            newScavenger.GetComponent<Scavenger>().resorcePerSec = resourcePerMinute / 60;
            newScavenger.GetComponent<Scavenger>().lifeTime = extractTime;
            newScavenger.GetComponent<Scavenger>().creator = this;
            donesOnShip--;
        }

    }
}
