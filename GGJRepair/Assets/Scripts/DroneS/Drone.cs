using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public int health;
    public float repairTime;
    public float repairCost;

    public float lifeTime = 60f;
    private float aliveTimer = 0f;

    private bool movingToLocation;
    private float moveSpeed = 20;
    public Vector2 destination;
    public Vector2 baseLocation;

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
    }
    
    private void SetLocation(WorldTile tile)
    {
        if(destination == Vector2.zero)
        {
            destination = tile.transform.position;
            movingToLocation = true;
        }
    }
    protected void Update()
    {
        if (movingToLocation)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

            if(Vector3.Distance(transform.position, destination) < 0.1f) {
                movingToLocation = false;
            }
        }

        aliveTimer += Time.deltaTime;

        if(aliveTimer > lifeTime)
        {
            //Recall Drone
            transform.position = Vector3.MoveTowards(transform.position, baseLocation, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, baseLocation) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }


}
