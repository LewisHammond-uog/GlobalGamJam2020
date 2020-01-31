using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavangerManager : DroneManager
{

    [SerializeField]
    private GameObject scavengerPrefab;
    public float upgradeCost = 20.0f;
    public int scavengersOnShip;
    public float extractTime;


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
            upgradeCost += 10.0f;
        }
    }

    public void DeployScavenger()
    {
        GameObject newScavenger = Instantiate(scavengerPrefab);
        newScavenger.transform.position = new Vector3(0.7f, 5.7f, 0.0f);
        WaitForClickToLocation(newScavenger.gameObject.GetComponent<Drone>());
        scavengersOnShip--;

        CollectResources(newScavenger);
    }

    public void RepairScavenger()
    {
        //if()
    }

    public void CollectResources(GameObject scavenger)
    {
        float time = 60.0f;
        while(time <= extractTime)
        {
            GamestateManager.resources += 1.0f;
            time += Time.deltaTime;
        }
        ReturnScavenger();
    }

    public void ReturnScavenger()
    {

    }
}
