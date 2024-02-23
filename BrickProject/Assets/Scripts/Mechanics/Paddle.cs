using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed = 30f;
    public float maxBounceAngle = 75f;
    public EasyManager em;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPaddle();
    }

    public void ResetPaddle()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(0.11f, transform.position.y);
    }

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch (assuming single touch control)

            // Convert touch position to world space
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Retain the existing z-position of the paddle
            touchPosition.z = transform.position.z;

            // Ensure the paddle stays in the same y-position
            touchPosition.y = transform.position.y;

            // Move the paddle to the touch position
            transform.position = touchPosition;
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rb.AddForce(direction * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        Rigidbody2D ball = collision.rigidbody;
        Collider2D paddle = collision.otherCollider;

        // Gather information about the collision
        Vector2 ballDirection = ball.velocity.normalized;
        Vector2 contactDistance = paddle.bounds.center - ball.transform.position;

        // Rotate the direction of the ball based on the contact distance
        // to make the gameplay more dynamic and interesting
        float bounceAngle = (contactDistance.x / paddle.bounds.size.x) * maxBounceAngle;
        ballDirection = Quaternion.AngleAxis(bounceAngle, Vector3.forward) * ballDirection;

        // Re-apply the new direction to the ball
        ball.velocity = ballDirection * ball.velocity.magnitude;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HealthUp"))
        {
            FindObjectOfType<EasyManager>().UpdateLives();
            Destroy(other.gameObject);
        }
    }

}