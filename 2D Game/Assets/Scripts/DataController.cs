using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public Score[] allScores;
    private HiScores hiScores;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadHiScores();
    }
    public Score GetCurrentScore()
    {
        return allScores[0];
    }
    public bool SubmitNewHiScore(int newScore)
    {
        if(newScore > hiScores.HiScore)
        {
            hiScores.HiScore = newScore;
            SaveHiScore();
            return true;
        }
        return false;
    }
    public int GetHiScore()
    {
        return hiScores.HiScore;
    }

    private void LoadHiScores()
    {
        hiScores = new HiScores();
        if (PlayerPrefs.HasKey("hiScore"))
        {
            hiScores.HiScore = PlayerPrefs.GetInt("hiScore");
        }
    }
    private void SaveHiScore()
    {
        PlayerPrefs.SetInt("hiScore", hiScores.HiScore);
    }

}
