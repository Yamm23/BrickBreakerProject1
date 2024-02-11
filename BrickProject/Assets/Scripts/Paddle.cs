using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D myrigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxAngle = 75f;

    private void Awake()
    {
        this.myrigidbody = GetComponent<Rigidbody2D>();
    }
    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0.03f, this.transform.position.y);
        this.myrigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball!=null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;
            float offset = paddlePosition.x-contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.myrigidbody.velocity);
            float bounceAngle = (offset / width)*this.maxAngle;

            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -bounceAngle, bounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.myrigidbody.velocity = rotation * Vector2.up * ball.myrigidbody.velocity.magnitude;
        }
    }
}
