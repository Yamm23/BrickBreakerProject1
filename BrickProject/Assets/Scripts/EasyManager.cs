using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EasyManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public int score;
    public int lives = 3;


    private void Awake()
    {
        // Check if the current scene is Easy or an ELevel scene with level between 1 and 10
        string currentSceneName = SceneManager.GetActiveScene().name;
        if ((currentSceneName.Equals("Easy")) || (currentSceneName.StartsWith("ELevel") && GetLevelFromSceneName(currentSceneName) <= 10))
        {
            // If it's an appropriate scene, do not destroy this EasyManager instance
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If not, destroy this EasyManager instance
            Destroy(gameObject);
            return;
        }

        // Register to the sceneLoaded event
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnDestroy()
    {
        // Unregister from the sceneLoaded event
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    private void Start()
    {
        // Start the game
        StartGame();
    }

    public void StartGame()
    {
        // Load the level scene asynchronously only if it's not already loaded
        if (SceneManager.GetActiveScene().name != "Easy")
        {
            SceneManager.LoadSceneAsync("Easy");
        }

        // Start a new game
        NewGame();
    }

    private void NewGame()
    {
        // Reset the score and lives
        this.score = 0;
        this.lives = 3;

    }

    private void LoadLevel(int level)
    {
        SceneManager.LoadScene("ELevel" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the ball and paddle in the scene
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
    }

    public void Hit(Brick brick)
    {
        // Increment the score when the ball hits a brick
        this.score += brick.points;
    }

    private void ResetLevel()
    {
        // Reset the ball and paddle position
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver()
    {
        // Start a new game
        NewGame();
    }

    public void Miss()
    {
        // Decrement lives when the ball is missed
        this.lives--;

        if (this.lives > 0)
        {
            // Reset the level
            ResetLevel();
        }
        else
        {
            // Start a new game
            GameOver();
        }
    }
    public void UpdateLives()
    {
        FindObjectOfType<HeartManager>();
      
        Debug.Log("Health+");
        lives++;
    }



    private int GetLevelFromSceneName(string sceneName)
    {
        // Extract the level number from the scene name
        int level;
        if (int.TryParse(sceneName.Replace("ELevel", ""), out level))
        {
            return level;
        }
        return -1; // Return -1 if the level number cannot be extracted
    }
}
