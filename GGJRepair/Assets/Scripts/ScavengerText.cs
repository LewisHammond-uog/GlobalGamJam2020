using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScavengerText : ScavangerManager
{
    public Text[] scavengerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numOfScav = numOfScavengers;
        int onShip = numOfScavengers;
        float numPerMin = resourcePerMinute;
        scavengerText[0].text = "Scavengers owned: " + numOfScav;
        scavengerText[1].text = "Scavengers on ship: " + onShip;
        scavengerText[2].text = "Resource income per minute: " + numPerMin;
        scavengerText[3].text = "Resource available: " + GamestateManager.resources;
    }
}
