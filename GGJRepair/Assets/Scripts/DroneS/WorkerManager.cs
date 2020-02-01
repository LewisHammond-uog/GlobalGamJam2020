using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : DroneManager
{
    [SerializeField]
    private GameObject workerPrefab;
    public float upgradeCost = 30.0f;
    public float extractTime = 60.0f; //Time it takes to return to station
    public float repairPerMinute = 100f;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        totalDrones = donesOnShip;
    }

    public void BuyWorker()
    {
        if (GamestateManager.resources >= upgradeCost)
        {
            GamestateManager.resources -= upgradeCost;
            donesOnShip += 1;
            totalDrones += 1;
        }
    }

    public void DeployWorker()
    {
        if (donesOnShip >= 1)
        {
            GameObject newWorker = Instantiate(workerPrefab, new Vector3(0.7f, 5.7f, 0.0f), Quaternion.identity);
            newWorker.GetComponent<Worker>().repiarPerSec = repairPerMinute / 60;
            newWorker.GetComponent<Worker>().lifeTime = extractTime;
            donesOnShip--;
        }

    }
}
