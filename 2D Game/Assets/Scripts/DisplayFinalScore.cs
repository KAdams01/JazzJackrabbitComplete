using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        finalScoreText.gameObject.SetActive(false);
    }

    public void createUpdateText(string endGameText)
    {
        finalScoreText.text = endGameText;
    }
    public void setTextActive(bool active)
    {
        finalScoreText.gameObject.SetActive(true);
    }
}
