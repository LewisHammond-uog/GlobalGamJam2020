using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public int health;
    public float repairTime;
    public float repairCost;

    private bool movingToLocation;
    private float moveSpeed;
    public Vector2 destination;

    public void StartMoveToLocation(Vector2 location)
    {
        movingToLocation = true;
        destination = location;
    }

    private void Update()
    {
        if (movingToLocation)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

            if(Vector3.Distance(transform.position, destination) < 0.1f) {
                movingToLocation = false;
            }

        }
    }


}
