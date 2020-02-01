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
            resourcePerMinute *= 1.5f;
            totalDrones += 1;
            upgradeCost += 10.0f;
            
        }
    }

    public void DeployScavenger()
    {
        if(scavengersOnShip >= 1)
        {
            GameObject newScavenger = Instantiate(scavengerPrefab, new Vector3(0.7f, 5.7f, 0.0f), Quaternion.identity);
            //newScavenger.transform.position = new Vector3(0.7f, 5.7f, 0.0f);
            //Freezes here below!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Pretty sure it's not actually finding the prefab, so newScavenger is always a nullptr as it will never have a sprite attached. Cant figure out how to sort it out.
            //Tried a bunch of things I thought might fix it. Like been doing this for an hour and half now
            //
            WaitForClickToLocation(newScavenger.gameObject.GetComponent<Drone>());
            scavengersOnShip--;
            //CollectResources(newScavenger);

        }

    }

    public void RepairScavenger()
    {
        //if()
    }

    public void CollectResources(GameObject scavenger)
    {
        GamestateManager.resources += resourcePerMinute;
        //ReturnScavenger();
    }

    public void ReturnScavenger()
    {

    }
}
