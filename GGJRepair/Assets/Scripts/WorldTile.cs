using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{

    public enum TileTypes
    {
        Dessert,
        Ocean,
        Forest
    }

    //Properties for this world tile
    private bool discovered;
    [Range(0,100)]
    private float repairState;
    [Range(0, 100)]
    private float remainingResources;
    private bool beingRepaired;

    [SerializeField]
    private TileTypes ourType;


    // Start is called before the first frame update
    void Start()
    {
        //Initalise values
        discovered = false;
        repairState = 0f;
        remainingResources = 0f;
        beingRepaired = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
