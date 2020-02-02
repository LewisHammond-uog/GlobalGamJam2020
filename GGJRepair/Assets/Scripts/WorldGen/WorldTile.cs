using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class WorldTile : MonoBehaviour
{

    public enum TileTypes
    {
        Dessert,
        Ocean,
        Forest
    }

    //Properties for this world tile
    public bool discovered;
    [Range(0,100)]
    public float repairState = 0;
    [Range(0, 100)]
    public float remainingResources;

    [SerializeField]
    public Sprite goodSprite, badSprite, undiscoveredSprite;
    private SpriteRenderer spriteRenderer;
    public Drone user;

    [Header("Is Start Tile")]
    public bool isStartTile = false;

    //Event for tile clicked
    public delegate void TileClick(WorldTile tile);
    public static event TileClick TileClicked; 

    // Start is called before the first frame update
    void Start()
    {
        if (!isStartTile)
        {
            //Initalise values
            discovered = false;
            repairState = 0f;
            remainingResources = 20f;
            //Start with the badSprite
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = undiscoveredSprite;
        }
        else
        {
            discovered = true;
            repairState = 100f;
            remainingResources = 100f;
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = goodSprite;
        }

           user = null;

    }

    private void Update()
    {
        //Unrepair if we completely deplete the resources
        if(remainingResources <= 0)
        {
            repairState = 0;
            spriteRenderer.sprite = badSprite;
        }

        //Reset Resources if we repair to 100
        if(repairState >= 100)
        {
            remainingResources = 100;
            spriteRenderer.sprite = goodSprite;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //DiscoverTile();
        }
    }

    public void DiscoverTile()
    {
        if(discovered == false)
        {
            discovered = true;
            spriteRenderer.sprite = badSprite;
            //StartCoroutine(FadeToSprite(2f,badSprite));
        }
    }


    //Call Event when this tile is clicked
    private void OnMouseDown()
    {
        TileClicked?.Invoke(this);
    }

    /// <summary>
    /// Fade this tile to have a new sprite
    /// This objects sprite will be changes
    /// </summary>
    /// <param name="time"></param>
    /// <param name="newSprite"></param>
    /// <returns></returns>
    IEnumerator FadeToSprite(float time, Sprite newSprite)
    {
        /*This Function Creates a new sprite object behind this one,
         * fades this sprite out, then once fully faded deletes the new
         * sprite object and sets this object sprite to the new sprite
         */
        //Init values
        GameObject newSpriteObj; //New obj that will be created to put the new sprite on while we transision
        SpriteRenderer thisObjSpriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //Sprite Renderer on this obj

        //Create Good Sprite behind this one on a new game obj
        newSpriteObj = new GameObject();
        newSpriteObj.transform.position = transform.position;
        newSpriteObj.transform.parent = transform;
        newSpriteObj.name = "TransisionSprite";
        //Add a sprite renderer to the new object and assign it the new sprie
        newSpriteObj.AddComponent<SpriteRenderer>().sprite = newSprite;
        newSpriteObj.AddComponent<SpriteRenderer>().sortingOrder = -1;

        //Fade out Old Sprite
        float currentAlpha = thisObjSpriteRenderer.color.a;
        float intendedAlpha = 0.0f;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color newColour = new Color(1, 1, 1, Mathf.Lerp(currentAlpha, intendedAlpha, t));
            thisObjSpriteRenderer.color = newColour;
            yield return null;
           
        }

        //Change This Objects Sprite and destory the 
        //old object
        thisObjSpriteRenderer.sprite = goodSprite;
        thisObjSpriteRenderer.color = Vector4.one;
        Destroy(newSpriteObj);

    }
}
