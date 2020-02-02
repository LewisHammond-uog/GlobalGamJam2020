using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField]
    private GameObject clusterPrefab;

    [SerializeField]
    private Vector3 worldDimentions;

    [SerializeField]
    private float startX;
    [SerializeField]
    private float startY;

    [SerializeField]
    private float scaleX;
    [SerializeField]
    private float scaleY;

    // Start is called before the first frame update
    void Start()
    {
        //Generate chunks in the world
        for(float x = startX; x < worldDimentions.x; x += 2.4f)
        {
            for(float y = startY; y < worldDimentions.z; y += 2.4f)
            {
                if(x == startX && y == startY)
                {
                    //Generate the first tile
                    GameObject newCluster = Instantiate(clusterPrefab);
                    newCluster.transform.localScale = new Vector2(scaleX, scaleY);
                    newCluster.transform.position = new Vector2(x, y);
                    newCluster.transform.parent = transform;
                    newCluster.name = ($"First Chunk");
                    newCluster.GetComponent<IslandChunk>().isFirstChunk = true;
                    
                }
                else
                {
                    GameObject newCluster = Instantiate(clusterPrefab);
                    newCluster.transform.localScale = new Vector2(scaleX, scaleY);
                    newCluster.transform.position = new Vector3(x, y);
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
