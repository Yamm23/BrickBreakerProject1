using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball {  get; private set; }
    public Paddle paddle { get; private set; }
    public int score;
    public int lives = 3;
    public int level = 1;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Levels");
        NewGame();
    }
        
    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        LoadLevel(1);
    }
    private void LoadLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level "+1);
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
    }
    public void Hit(Brick brick)
    {
        this.score += brick.points;
    }
    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }
    private void GameOver()
    {
        NewGame();
    }
    public void Miss()
    {
        this.lives--;
        if(this.lives > 0 )
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }
}
