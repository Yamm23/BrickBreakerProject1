using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D myrigidbody { get; private set; }
    public float speed = 150f;

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
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.myrigidbody.AddForce(force.normalized * speed);

    }
    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.myrigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 1f);
    }
}
