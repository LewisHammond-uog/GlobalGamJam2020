using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas menuButtons;
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private Camera menuCamera;
    [SerializeField]
    private Camera playerCamera;
    private bool inConsole = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                playerCamera.gameObject.SetActive(false);
                menuCamera.gameObject.SetActive(true);
                map.gameObject.SetActive(true);
                menuButtons.gameObject.SetActive(true);
                inConsole = true;
            }
        }
        else
        {
            return;
        }
    }

    public void ExitConsole()
    {
        menuCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
        map.gameObject.SetActive(false);
        menuButtons.gameObject.SetActive(false);
        inConsole = false;
    }
}
