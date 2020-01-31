using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerScript : MonoBehaviour
{
    //Staff owned:
    [SerializeField]
    public int numOfScavengers;
    public bool scavengersAvailable = true;
    public int scavengersOnShip;
    public float resourcePerMin;
    public float health = 100.0f;
    public float repairTime;
    public float repairCost;
    public float upgradePrice;


    // Start is called before the first frame update
    void Start()
    {
        numOfScavengers = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
