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
    private Transform mapPosition;
    [SerializeField]
    private Camera menuCamera;
    [SerializeField]
    private Camera playerCamera;
    public bool inConsole = false;

    // Start is called before the first frame update
    void Start()
    {
        map.transform.position = new Vector3(-100.0f, -100.0f, 0);
        menuButtons.GetComponent<Canvas>().scaleFactor = 0;
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
                map.transform.position = mapPosition.position;
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
        map.transform.position = new Vector3(-100.0f, -100.0f, 0);
        menuButtons.GetComponent<Canvas>().scaleFactor = 0;
        inConsole = false;
    }
}
