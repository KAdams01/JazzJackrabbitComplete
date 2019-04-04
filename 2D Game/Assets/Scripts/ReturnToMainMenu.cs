using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMainMenu : MonoBehaviour
{
    private LevelLoader loader;
    public Button mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        loader = LevelLoader.Instance;
        mainMenu.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            loader.LoadLevel("mainmenu");
        }
        
    }
}
