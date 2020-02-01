using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadsUpMenu : MonoBehaviour
{

    [SerializeField]
    private Text resourcesText, scavsText, exporeText, workerText;

    [SerializeField]
    private ScavangerManager scavMan;
    [SerializeField]
    private ExplorerManager exploreMan;
    [SerializeField]
    private WorkerManager workerMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resourcesText.text = $"RESOURCES : {Mathf.RoundToInt(GamestateManager.resources)}";
        scavsText.text = $"Scavs :  {Mathf.RoundToInt(scavMan.totalDrones - scavMan.donesOnShip)} ({scavMan.totalDrones}";
        exporeText.text = $"Explores : {Mathf.RoundToInt(exploreMan.totalDrones - exploreMan.donesOnShip)} ({exploreMan.totalDrones})";
        workerText.text = $"Workers : {Mathf.RoundToInt(workerMan.totalDrones - workerMan.donesOnShip)} ({workerMan.totalDrones})";
    }

    
}
