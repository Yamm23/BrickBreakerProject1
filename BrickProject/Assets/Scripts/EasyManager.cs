using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public int score;
    public int lives = 3;
    //public int level = 1;

    private void Awake()
    {
        // Check if the current scene is an ELevel scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (!currentSceneName.StartsWith("ELevel"))
        {
            // If not, destroy this EasyManager instance
            Destroy(gameObject);
            return;
        }

        // Persist this GameObject across scene changes
        DontDestroyOnLoad(gameObject);

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
        // Load the level scene asynchronously
        SceneManager.LoadSceneAsync("ELevel");

        // Start a new game
        NewGame();
    }

    private void NewGame()
    {
        // Reset the score and lives
        this.score = 0;
        this.lives = 3;

        // Load the first level
        //LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        //this.level = level;
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
}
