using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerManager : DroneManager
{
    [SerializeField]
    private GameObject exploererPrefab;
    public float upgradeCost = 30.0f;
    public float extractTime = 60.0f; //Time it takes to return to station
    public float repairPerMinute = 100f;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        totalDrones = donesOnShip;
    }

    public void BuyExplorer()
    {
        if (GamestateManager.resources >= upgradeCost)
        {
            GamestateManager.resources -= upgradeCost;
            donesOnShip += 1;
            totalDrones += 1;
        }
    }

    public void DeployExplorer()
    {
        if (donesOnShip >= 1)
        {
            GameObject newExploerer = Instantiate(exploererPrefab, baseLocation, Quaternion.identity);
            newExploerer.GetComponent<Exploerer>().lifeTime = extractTime;
            donesOnShip--;
        }

    }
}
