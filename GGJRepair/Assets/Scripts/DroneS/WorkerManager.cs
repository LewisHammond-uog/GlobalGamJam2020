using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : DroneManager
{
    [SerializeField]
    private GameObject workerPrefab;
    public float upgradeCost = 30.0f;
    public int workersOnShip;

    // Start is called before the first frame update
    void Start()
    {
        workersOnShip = 1;
    }


    public void BuyWorker()
    {
        if (GamestateManager.resources >= upgradeCost)
        {
            GamestateManager.resources -= upgradeCost;
            workersOnShip++;
            totalDrones++;
            upgradeCost += 10.0f;
        }
    }

    public void DeployWorker()
    {
        //Choose destination 
        GameObject newWorker = Instantiate(workerPrefab);
        newWorker.transform.position = new Vector3(0.7f, 5.7f, 0.0f);
        WaitForClickToLocation(newWorker.gameObject.GetComponent<Drone>());
        workersOnShip--;
    }

    public void RepairWorker()
    {
        //if()
    }
}
