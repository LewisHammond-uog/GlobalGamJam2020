using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField]
    private GameObject clusterPrefab;

    [SerializeField]
    private Vector2 worldDimentions;

    // Start is called before the first frame update
    void Start()
    {
        //Generate chunks in the world
        for(int x = 1; x < worldDimentions.x; x += 2)
        {
            for(int y = 1; y < worldDimentions.y; y += 2)
            {
                if(x == 1 && y == 1)
                {
                    //Generate the first tile
                    GameObject newCluster = Instantiate(clusterPrefab);
                    newCluster.transform.position = new Vector2(x, y);
                    newCluster.transform.parent = transform;
                    newCluster.name = ($"First Chunk");
                    newCluster.GetComponent<IslandChunk>().isFirstChunk = true;
                    
                }
                else
                {
                    GameObject newCluster = Instantiate(clusterPrefab);
                    newCluster.transform.position = new Vector2(x, y);
                    newCluster.transform.parent = transform;
                    newCluster.name = ($"World Chunk {x},{y}");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
