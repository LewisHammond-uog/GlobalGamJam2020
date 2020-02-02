using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadsUpMenu : MonoBehaviour
{

    [SerializeField]
    private Text resourcesText, scavsText, scavsText2, exporeText, exporeText2, workerText, workerText2;

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
        scavsText.text = $"Scavengers on Ship:  {Mathf.RoundToInt(scavMan.donesOnShip)}";
        scavsText2.text = $"Total:  {Mathf.RoundToInt(scavMan.totalDrones)}";
        exporeText.text = $"Explorers on Ship: {Mathf.RoundToInt(exploreMan.donesOnShip)}";
        exporeText2.text = $"Total:  {Mathf.RoundToInt(exploreMan.totalDrones)}";
        workerText.text = $"Workers on Ship: {Mathf.RoundToInt(workerMan.donesOnShip)}";
        workerText2.text = $"Total:  {Mathf.RoundToInt(workerMan.totalDrones)}";
    }

    
}
