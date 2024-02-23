using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D myrigidbody { get; private set; }
    public float speed = 100f;
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
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        this.myrigidbody.AddForce(force.normalized * speed);

    }
    public void ResetBall()
    {
        transform.position = new Vector2(0.08f,0f );
        this.myrigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            Debug.Log("POwerup");
            int radChance = Random.Range(1,101);
            if (radChance <50)
            {
                Instantiate(health,other.transform.position,other.transform.rotation);
            
            }
        }
    }

}
