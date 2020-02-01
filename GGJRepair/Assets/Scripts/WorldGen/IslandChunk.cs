using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandChunk : MonoBehaviour
{
    [SerializeField]
    private GameObject firstChunkPrefab;

    //All island clusters that there can be
    [SerializeField]
    private List<GameObject> chunks;

    [SerializeField]
    private Sprite unDiscoveredSprite;

    //The chunk that this object owns
    private GameObject ourChunk;

    //is this the first chunk?
    public bool isFirstChunk = false;

    // Start is called before the first frame update
    void Start()
    {
        if (chunks != null)
        {
            if (isFirstChunk)
            {
               
                GameObject selectedChunk = firstChunkPrefab;
                ourChunk = Instantiate(selectedChunk);
                ourChunk.transform.parent = transform;
                ourChunk.transform.localPosition = Vector3.zero;

                WorldTile[] tiles = GetComponentsInChildren<WorldTile>();

                foreach (WorldTile tile in tiles)
                {
                    tile.undiscoveredSprite = unDiscoveredSprite;
                    tile.isStartTile = true;
                }
            }
            else
            {
                //Choose a random cluster
                int randomChunkID = Random.Range(0, chunks.Count);
                GameObject selectedChunk = chunks[randomChunkID];
                ourChunk = Instantiate(selectedChunk);
                ourChunk.transform.parent = transform;
                ourChunk.transform.localPosition = Vector3.zero;

                WorldTile[] tiles = GetComponentsInChildren<WorldTile>();

                foreach (WorldTile tile in tiles)
                {
                    tile.undiscoveredSprite = unDiscoveredSprite;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
