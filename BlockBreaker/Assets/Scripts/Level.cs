using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    SceneLoader sceneLoader;
    
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Update()
    {
        if (isGameOver()) {
            Debug.Log("GAMEOVER!");
            sceneLoader.LoadNextScene();
        }
    }
    public void CountBlocks() {
        breakableBlocks++;
    }

    public void DestroyBreakableBlock() {
        breakableBlocks--;
    }

    private bool isGameOver() {
        if (breakableBlocks == 0) {
            return true;
        }

       return false;
    }
}
