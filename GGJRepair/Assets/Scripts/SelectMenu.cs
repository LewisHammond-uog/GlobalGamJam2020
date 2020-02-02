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
    public bool inConsole = false;

    // Start is called before the first frame update
    void Start()
    {
        menuButtons.GetComponent<Canvas>().scaleFactor = 0;
        map.SetActive(false);
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
                map.SetActive(true);
                

                menuButtons.GetComponent<Canvas>().scaleFactor = 1;
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
        menuButtons.GetComponent<Canvas>().scaleFactor = 0;
        map.SetActive(false);
        inConsole = false;
    }
}
