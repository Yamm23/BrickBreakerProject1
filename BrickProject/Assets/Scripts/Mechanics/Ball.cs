using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D myrigidbody { get; private set; }
    public float speed = 4f;
    public Transform health;

    private void Awake()
    {
        this.myrigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2(Random.Range(-1f, 1f), -1f).normalized * speed;
        this.myrigidbody.velocity = force;
    }

    public void ResetBall()
    {
        transform.position = new Vector2(0.08f, 0f);
        this.myrigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {

            Debug.Log("Powerup");
            int radChance = Random.Range(1, 101);
            if (radChance < 50)
            {
                Instantiate(health, other.transform.position, other.transform.rotation);
            }
        }
        else if (other.transform.CompareTag("Wall"))
        {
            // Calculate reflection based on the wall collided with
            Vector2 reflection = Vector2.zero;
            if (other.transform.position.x < transform.position.x || other.transform.position.x > transform.position.x)
            {
                // Left or right wall, bounce upwards
                reflection = Vector2.Reflect(myrigidbody.velocity, Vector2.up);
            }
            else
            {
                // Top wall, bounce downwards
                reflection = Vector2.Reflect(myrigidbody.velocity, Vector2.down);
            }
            myrigidbody.velocity = reflection;
        }
    }
}
