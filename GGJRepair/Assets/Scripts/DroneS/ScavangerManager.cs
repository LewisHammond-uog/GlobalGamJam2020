using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavangerManager : DroneManager
{
    [SerializeField]
    public GameObject scavengerPrefab;
    public float upgradeCost = 20.0f;
    public int scavengersOnShip = 1;
    public int numOfScavengers = 1;
    public float extractTime = 60.0f; //Time it takes to return to station
    public float resourcePerMinute = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        //scavengerPrefab = GameObject.Find("TestSprite");
        scavengersOnShip = numOfScavengers;
        totalDrones = scavengersOnShip;
    }

    public void BuyScavenger()
    {
        if (GamestateManager.resources >= upgradeCost)
        {
            GamestateManager.resources -= upgradeCost;
            scavengersOnShip += 1;
            numOfScavengers += 1;
            totalDrones += 1;
        }
    }

    public void DeployScavenger()
    {
        if(scavengersOnShip >= 1)
        {
            GameObject newScavenger = Instantiate(scavengerPrefab, new Vector3(0.7f, 5.7f, 0.0f), Quaternion.identity);
            newScavenger.GetComponent<Scavenger>().resorcePerSec = resourcePerMinute / 60;
            scavengersOnShip--;
        }

    }
}
