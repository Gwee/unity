using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] private bool isAutoPlay;

    [SerializeField] private int currentScore = 0;
    [SerializeField] private int blockPointValue = 83;

    [SerializeField] private TextMeshProUGUI scoreText;
    
    //Singleton pattern to keep single instantiated GameStatus across all levels in the game (for example keep current score when moving scenes) 
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false); //Singleton pattern bug fix race condition where sometimes more than one gameStatusCount may exist
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        this.currentScore += blockPointValue;
        scoreText.text = this.currentScore.ToString();
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled() {
        return this.isAutoPlay;
    }
}
