using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance = null;
    public DataController dataContr;
    public DisplayFinalScore finalScore;
    private SoundManager sm;
    private bool gameEnded;
    private LevelLoader loader;
    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        sm = SoundManager.Instance;
        loader = LevelLoader.Instance;
        gameEnded = false;
    }
    private void Update()
    {
        if(gameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }
    public void TriggerEndGame(int score)
    {
        finalScore = Camera.main.GetComponent<DisplayFinalScore>();
        sm.ToggleSoundActive(false);
        Time.timeScale = 0;
        if (dataContr.SubmitNewHiScore(score))
        {
            finalScore.createUpdateText("New High Score!" + "\nScore: " + score + "\nPress SPACE to return to Main Menu");
            finalScore.setTextActive(true);
        }
        else
        {
            finalScore.createUpdateText("\nFinal Score: " + score + "\nPress SPACE to return to Main Menu");
            finalScore.setTextActive(true);
        }
        gameEnded = true;
    }
    private void ResetGame()
    {
        gameEnded = false;
        Time.timeScale = 1;
        Score.score = 0;
        loader.LoadLevel("MainMenu");
        sm.ToggleSoundActive(true);
    }
    /*public void TriggerGameOver(float score)
    {
        sm.ToggleSoundActive(false);
        if (hiScores.isNewHighScore(score))
        {
            hiScores.RegisterNewScore(score);
        }
    }*/
}
