using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DroneManager
{
    public int totalDrones;

    /// <summary>
    /// Wait for the player to click and select a location to go to
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForClickToLocation(Drone drone)
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    WorldTile obj = hit.transform.gameObject.GetComponent<WorldTile>();
                    if (obj != null)
                    {
                        drone.GoToLocatation(obj.transform.position);
                    }
                }
            }
        }
    }

}
