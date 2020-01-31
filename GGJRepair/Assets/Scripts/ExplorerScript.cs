using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerScript : MonoBehaviour
{
    public int numOfExplorers;
    public bool explorersAvailable = false;
    public float health = 100.0f;
    public float repairTime;
    public float repairCost;
    public float upgradePrice;

    void Start()
    {
        numOfExplorers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
