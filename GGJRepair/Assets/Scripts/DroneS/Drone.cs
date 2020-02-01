using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    protected enum DroneState
    {
        IDLE,
        GOTO_DEST,
        DOING_TASK,
        GOTO_BASE
    }

    /*
    public int health;
    public float repairTime;
    public float repairCost;
    */

    public float lifeTime = 60f;
    private float aliveTimer = 0f;

    private float moveSpeed = 5f;

    protected DroneState currentState;
    public Vector3 destination;
    public WorldTile destinationTile;
    public Vector3 baseLocation;

    #region Tile Click Event
    protected void OnEnable()
    {
        WorldTile.TileClicked += SetLocation;
    }

    protected void OnDisable()
    {
        WorldTile.TileClicked -= SetLocation;
    }
    #endregion

    protected void Start()
    {
        destination = Vector2.zero;
        currentState = DroneState.IDLE;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
    
    private void SetLocation(WorldTile tile)
    {
        if(currentState == DroneState.IDLE)
        {
            destination = tile.transform.position;
            destinationTile = tile;
            currentState = DroneState.GOTO_DEST;
        }
    }
    protected void Update()
    {

        //This Handels going to/from destination/base
        switch (currentState)
        {
            case(DroneState.GOTO_DEST):
                {

                    transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, destination) < 0.1f)
                    {
                        currentState = DroneState.DOING_TASK;
                    }

                    break;
                }
            case (DroneState.GOTO_BASE):
                {

                    //Recall Drone
                    transform.position = Vector3.MoveTowards(transform.position, baseLocation, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, baseLocation) < 0.1f)
                    {
                        Destroy(gameObject);
                    }

                    break;
                    
                }
        }

        aliveTimer += Time.deltaTime;
        if(aliveTimer > lifeTime)
        {
            currentState = DroneState.GOTO_BASE;
        }
    }


}
