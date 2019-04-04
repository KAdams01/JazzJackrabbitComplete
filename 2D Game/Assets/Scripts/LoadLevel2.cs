using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel2 : MonoBehaviour
{
    private LevelLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        loader = LevelLoader.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        loader.LoadLevel("Level 2");
    }
}
