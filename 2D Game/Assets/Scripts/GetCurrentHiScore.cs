using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCurrentHiScore : MonoBehaviour
{
    private DataController dController;
    private EndGameManager EGManager;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        EGManager = EndGameManager.Instance;
        dController = EGManager.dataContr;
        if(dController == null)
        {
            Debug.Log("dController NULL");
        }
        text.text = "HiScore: " + dController.GetHiScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
