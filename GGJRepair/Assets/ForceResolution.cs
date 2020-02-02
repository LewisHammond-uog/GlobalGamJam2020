using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int width = 959; // or something else
        int height = 611; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
