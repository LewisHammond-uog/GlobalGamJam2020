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
    private bool discovered;
    [Range(0,100)]
    private float repairState;
    [Range(0, 100)]
    private float remainingResources;
    private bool beingRepaired;

    [SerializeField]
    private TileTypes ourType;

    [SerializeField]
    private Sprite goodSprite, badSprite, undiscoveredSprite;
    private SpriteRenderer spriteRenderer;

    //Event for tile clicked
    public delegate void TileClick(WorldTile tile);
    public static event TileClick TileClicked; 


    // Start is called before the first frame update
    void Start()
    {
        //Initalise values
        discovered = false;
        repairState = 0f;
        remainingResources = 0f;
        beingRepaired = false;

        //Start with the badSprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = badSprite;

    }

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
        newSpriteObj.transform.position = transform.position + new Vector3(0, 0, 10);
        newSpriteObj.transform.parent = transform;
        newSpriteObj.name = "TransisionSprite";
        //Add a sprite renderer to the new object and assign it the new sprie
        newSpriteObj.AddComponent<SpriteRenderer>().sprite = newSprite;

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
