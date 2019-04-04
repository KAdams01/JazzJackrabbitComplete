using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    //public Button play;
    //public Button exit;
    public Button[] buttonsInScene;
    private int selectedButton;
    private LevelLoader loader;

    void Start()
    {
        loader = LevelLoader.Instance;
        for(int i = 0; i < buttonsInScene.Length; i++)
        {
            switch (buttonsInScene[i].name.ToLower())
            {
                case "play":
                    buttonsInScene[i].onClick.AddListener(StartGame);
                    selectedButton = i;
                    break;
                case "exit":
                    buttonsInScene[i].onClick.AddListener(ExitGame);
                    break;
                case "hiscores":
                    buttonsInScene[i].onClick.AddListener(HiScores);
                    break;
            }
        }
        foreach(Button but in buttonsInScene)
        {
  
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(selectedButton < 0)
        {
            selectedButton = buttonsInScene.Length-1;
            Debug.Log(buttonsInScene.Length);
        }
        selectedButton = selectedButton % 3;
        buttonsInScene[selectedButton].Select();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButton++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButton--;
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)){
            switch (buttonsInScene[selectedButton].name.ToLower())
            {
                case "play":
                    StartGame();
                    break;
                case "exit":
                    ExitGame();
                    break;
                case "hiscores":
                    HiScores();
                    break;
            }
        }

        /*if (selectedButton == "play" && (Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartGame();
        }
        else if (selectedButton == "exit" && (Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Application.Quit();
        };*/

	}

    private void StartGame()
    {
        loader.LoadLevel("Level 1");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    private void HiScores()
    {
        loader.LoadLevel("HiScores");
    }
}
